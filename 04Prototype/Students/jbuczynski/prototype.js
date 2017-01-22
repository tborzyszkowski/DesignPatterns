/*jshint node: true */

var CarPrototype1 = {

    wheels: 4,

    drive: function () {
        console.log("Car driving!");
    },

    getModel: function () {
        console.log("My model is." + this.model);
    }

};

var myRawCar = Object.create(CarPrototype1);

console.log('Example with ECMAScript 5 Object.create');
console.log('');
console.log('');
console.log('myRawCar raw car proto: ' + myRawCar.__proto__); //[object Object]
console.log('myRawCar constructor: ' + myRawCar.constructor); //function Object() { [native code] }
console.log('myRawCar constructor.prototype: ' + myRawCar.constructor.prototype); //[object Object]
console.log('myRawCar constructor.prototype  ==  CarPrototype1.__proto__' + (myRawCar.__proto__ == CarPrototype1.prototype)); //false
console.log('');
console.log('');

var myFancyFordMondeo1 = Object.create(CarPrototype1, {

    "model": {
        value: "Ford Mondeo"
    },

    "color": {
        value: "dark blue"
    },

    "fastDriving": {
        value: function () {
            console.log("fas driving car!");
        }
    }

});

console.log('MyFancyFordMondeo1 raw car proto: ' + myFancyFordMondeo1.__proto__); //[object Object]
console.log('MyFancyFordMondeo1 constructor: ' + myFancyFordMondeo1.constructor); //function Object() { [native code] }
//Object.create builds an object that inherits directly from the one passed as its first argument.
console.log('myFancyFordMondeo1.constructor.prototype.wheels: ' + myFancyFordMondeo1.constructor.prototype.wheels); //undefined
console.log("myFancyFordMondeo1.wheels': " + myFancyFordMondeo1.wheels);
console.log('');
console.log('');


console.log('Example with new operator and prototype chain');
console.log('');
console.log('');
var CarPrototype2 = function CarPrototype2(_model) {

    //protection for wrong this keyword scope, when no new operator
    if (!(this instanceof CarPrototype2)) {
        return new CarPrototype2(_model);
    }
    this.model = _model;

    this.wheels = 4;

    this.drive = function () {
        console.log("Car driving!");
    };

    this.getModel = function () {
        console.log("My model is." + this.model);
    };

};

var myRawCar2 = new CarPrototype2();
console.log('myRawCar2 constructor: ' + (typeof myRawCar2.constructor)); //function
console.log('myRawCar2 constructor.prototype: ' + myRawCar2.constructor.prototype); //[object Object]
//constructor functions, the newly created object inherits from the constructor's prototype
console.log('CarPrototype2.prototype.prototype: ' + CarPrototype2.prototype); //[object Object]
console.log('CarPrototype2.prototype.prototype: ' + CarPrototype2.prototype.wheels);
console.log('CarPrototype2 __proto__: ' + CarPrototype1.__proto__); //[object Object]
console.log('myRawCar2constructor.prototype == myRawCar2.__proto__ ' + (myRawCar2.__proto__ == CarPrototype2.prototype)); //false

var MyFancyFordMondeo2 = function MyFancyFordMondeo2(mondeoSpecific) {
    this.isFancy = true;
    this.mondeoSpecific = mondeoSpecific;
};

var MyFancyFordFocus2 = function MyFancyFordFocus2(focusSpecific) {
    this.focusSpecific = focusSpecific;

};
console.log('');
MyFancyFordMondeo2.prototype = new CarPrototype2("mondeo");
MyFancyFordFocus2.prototype = new CarPrototype2("focus");

var myFancyFordMondeo2 = new MyFancyFordMondeo2("mondeoSpecific");
console.log('myFancyFordMondeo2 is instance of all prototypes in it\'s chain');
console.log('');
console.log('myFancyFordMondeo2 instanceof CarPrototype2 ' + (myFancyFordMondeo2 instanceof CarPrototype2));
console.log('myFancyFordMondeo2 instanceof MyFancyFordMondeo2 ' + (myFancyFordMondeo2 instanceof MyFancyFordMondeo2));
console.log('');

console.log('myFancyFordMondeo2.model: ' + myFancyFordMondeo2.model);
console.log('myFancyFordMondeo2.mondeoSpecific: ' + myFancyFordMondeo2.mondeoSpecific);

console.log('');
var myFancyFordFocus2 = new MyFancyFordFocus2("focusSpecific");
console.log('MyFancyFordFocus2.model: ' + myFancyFordFocus2.model);
console.log('myFancyFordMondeo2.focusSpecific: ' + myFancyFordFocus2.focusSpecific);
console.log('');

console.log('overriding prototype affects all inhrtiting objects');
MyFancyFordMondeo2.prototype.drive = function () {
    console.log("Imporved Car driving!");
};
myFancyFordMondeo2.drive();

MyFancyFordMondeo2.prototype.isFancy = false;
console.log("myFancyFordMondeo2.isFancy " + myFancyFordMondeo2.isFancy);

myFancyFordFocus2.drive();

console.log('');
console.log('');
