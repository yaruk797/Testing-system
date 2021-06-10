import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { Answer } from 'src/app/models/answer';
import { Question } from 'src/app/models/question';

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

  constructor(ts: TestsService) {
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
    console.log(this.testForm.value);
    this.getResult();
    this.testForm = new FormGroup({
      test: new FormControl('', Validators.required)
    });
    this.counter++;

    if(this.counter == this.selectedTest.questions?.length){
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
    if(this.tests != undefined)
      console.log(this.tests)
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
      return new Question(0,'Hello','', undefined);
  }

  getResult(){

      for(var j=0; j<this.selectedTest.questions[this.counter].answers.length; j++){
        if(this.selectedTest.questions[this.counter].answers[j].isRight == true &&
          this.selectedTest.questions[this.counter].answers[j].name  == this.userAnswer){
          this.testResult++;
        }
    }
  }

  backToTests(){
    this.testIsPassed = false;
    this.showTests = true;
    this.counter = 0;
    this.testResult = 0;
  }

}
