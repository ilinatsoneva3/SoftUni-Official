function solve(fruit, weightInGrams, pricePerKG){
    let money = 0;
    let weightInKg = weightInGrams / 1000;
    money = pricePerKG*weightInKg;

    console.log(`I need $${money.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
};

solve('apple', 1563, 2.35);