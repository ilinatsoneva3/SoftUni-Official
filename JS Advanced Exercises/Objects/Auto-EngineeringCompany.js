function solve(arr = []) {
    let cars = new Map();

    arr.forEach((line) => {
        let [brand, model, units] = line.split(" | ");
        units = Number(units);

        if (!cars.get(brand)) {
            cars.set(brand, new Map());
        }

        if(!cars.get(brand).get(model)){
            cars.get(brand).set(model, 0);
        }

        cars.get(brand).set(model, cars.get(brand).get(model)+units);
    });

    console.log();

    for(let [brand, models] of cars){
        console.log(brand);

        for(let [model, units] of models){
            console.log(`###${model} -> ${units}`);
        }
    }    
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']);