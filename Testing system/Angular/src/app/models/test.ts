import { Question } from './question'

export class Test{
    constructor(
        public id: number,
        public name: string,
        public description: string,
        public questions: Question[]
    ){}
}