// import '../styles/index.scss';

// console.log('webpack starterkit');

console.log('Hi');

const carId = 100; // constants have to be initialized and once they are 
                    // initialize dwe cannot change their values 

let x = 42; 
var y = 41;
// when we use let then the variable is only available only inside the block we declare it 
// when we use var the variable is used globally 
// also if we initialize a variable with let and we use it before we initialize it then the compiler produces an error
// but if we declare it with var then the compiler produces undefined 

// Rest Parameters : e.g. ...allCarIds
// with rest parameters we can send any number of 
// arguments in a function and use rest parameter to gather all these 
// parameters in an array
// Rest parameter must be the last parameter in the function arguments

function sendCars(day, ...allCarIds) {
    allCarIds.forEach(id => console.log(id));
}

sendCars('Day',1,2,3);

//Destructuring arrays
let carIds = [100,200,5];
let [car1, car2,car3] = carIds;
console.log(car1,car2,car3);

let car5, remainingCars;
[car5, ...remainingCars] = carIds;
console.log(car5, remainingCars);

let remCars;

//the comma means: skip the first element of the array, 
// you can have as many commas you need so as to skip as many elements you need
[,, ... remCars] = carIds;

console.log(remCars);

//Destructuring Objects
let car = {id: 5000, style: 'convertible'};
let {id, style} = car;
console.log(id, style);

//another way of property initialization for object destructuring
({id, style} = car);
console.log(id, style);