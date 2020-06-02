function solve(arr = []) {
    let juices = {};
    let bottles = {};

    arr.forEach((item) => {
        let [fruit, quantity] = item.split(" => ");
        quantity = Number(quantity);

        if (!juices.hasOwnProperty(fruit)) {
            juices[fruit] = 0;
        }

        juices[fruit] += quantity;
        let currentQuantity = juices[fruit];

        if (currentQuantity >= 1000) {
            bottles[fruit] = Math.trunc(currentQuantity/1000);
        }
    });

   for(let fruit in bottles){
       console.log(`${fruit} => ${bottles[fruit]}`);
   }
}

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
);