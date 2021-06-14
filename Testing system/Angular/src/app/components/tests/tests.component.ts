import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { Answer } from 'src/app/models/answer';
import { Question } from 'src/app/models/question';
import { Router } from '@angular/router';

import { Test } from 'src/app/models/test'
import { TestsService } from 'src/app/services/tests.service';

@Component({
  selector: 'app-tests',
  templateUrl: './tests.component.html',
  styleUrls: ['./tests.component.css']
})
export class TestsComponent implements OnInit {

  tests: Test[] | undefined;
  selectedTest: any;
  testsService: TestsService;
  counter: number = 0;
  testResult: number = 0;
  showTests: boolean = true;
  showDescr: boolean = false;
  testIsStarting: boolean = false;
  testIsPassed: boolean = false;
  userAnswer: string = '';

  constructor(ts: TestsService, private router: Router) {
    this.testsService = ts;
   }

  ngOnInit(): void {
    this.loadTests();
  }

  agreeForm = new FormGroup({
    agree: new FormControl('', Validators.required)
  });

  testForm = new FormGroup({
    test: new FormControl('', Validators.required)
  });
  
  get f(){
    return this.testForm.controls;
  }
  
  testSubmit(){
    this.selectedTest.questions[this.counter].userAnswer = this.userAnswer;
    this.selectedTest.questions[this.counter].answers = null;
    
    this.testForm = new FormGroup({
      test: new FormControl('', Validators.required)
    });
    this.counter++;

    if(this.counter == this.selectedTest.questions?.length){
      this.getResult();
      this.testIsPassed = true;
      this.testIsStarting = false;
    }

  }
  agreeSubmit(){
    this.showTests = false;
    this.showDescr = false;
    this.testIsStarting = true;
  }

  loadTests(){
    this.testsService.getTests()
    .subscribe((data: Test[])=> this.tests = data);
    this.router.navigate(['tests']);
  }

  showDescription(test: Test){
    this.selectedTest = test;
    this.showDescr = true;
    this.agreeForm = new FormGroup({
      agree: new FormControl('', Validators.required)
    });
    this.testsService.getTestById(test)
    .subscribe((data: Test)=> this.selectedTest = data);
  }

  getQuestion():Question{
    if(this.counter < this.selectedTest.questions?.length)
      return this.selectedTest?.questions[this.counter];
    else
      return new Question(0,'','', 0, undefined);
  }

  getResult(){
    this.testsService.getTestResult(this.selectedTest.questions)
    .subscribe((data: number)=>this.testResult = data);
  }

  backToTests(){
    this.testIsPassed = false;
    this.showTests = true;
    this.counter = 0;
    this.testResult = 0;
  }

}
