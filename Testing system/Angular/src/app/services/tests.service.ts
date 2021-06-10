import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

import { Test } from 'src/app/models/test'
import { Question } from '../models/question';
import { Observable } from 'rxjs';
import { SYSTEM_API_URL } from '../app-injection-token';

@Injectable({
    providedIn: 'root'
})

export class TestsService{

    private url = `${this.apiUrl}api/tests`
    constructor(private http:HttpClient, @Inject(SYSTEM_API_URL) private apiUrl: string){}

    getTests():Observable<Test[]> {
        return this.http.get<Test[]>(`${this.url}/tests`);
    }

    getTestById(test: Test){
        return this.http.get<Test>(`${this.url}/test/${test.id}`)
    }

    getTestResult(testId: number, questions: Question[]){
        return this.http.post<number>(`${this.url}/result/${testId}`, {questions})
    }
}