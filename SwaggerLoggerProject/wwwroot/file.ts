let message: string = "Hello TypeScript";

console.log(message);

class Person {
    constructor(public Name: string) { }
}

let p1 = new Person("John");

console.log( "Hello " + p1.Name );