function areSameNumbers(number){
    let arrayFromNumberAsString = Array.from(String(number));
    let arrayFromNumber = arrayFromNumberAsString.map(x=>Number(x));
    let sum = arrayFromNumber.reduce((x,y) => x+y,0);
    let areEqual = arrayFromNumber.every(x=>x===arrayFromNumber[0]);
    console.log(areEqual);
    console.log(sum);
};

areSameNumbers(1234);