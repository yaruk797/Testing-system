import { Answer } from './answer'

export class Question{
    constructor(
        public id: number,
        public name: string,
        public userAnswer: string,
        public testId: number,
        public answers?: Answer[]
    ){}
}