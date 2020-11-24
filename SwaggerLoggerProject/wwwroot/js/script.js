var message = "Hello TypeScript";
console.log(message);


var Person = /** @class */ (function () {
    function Person(Name) {
        this.Name = Name;
    }
    return Person;
}());
var p1 = new Person("John");
console.log("Hello " + p1.Name);
//# sourceMappingURL=script.js.map