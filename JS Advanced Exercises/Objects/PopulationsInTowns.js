function solve(arr=[]) {
    let result = {};

    for (var i = 0; i < arr.length; i++) {
        let currentCity = arr[i].split(" <-> ");
        let key = currentCity[0];
        let value = Number(currentCity[1]);

        if (!result.hasOwnProperty(key)) {
            result[key] = 0;
        }

        result[key] += value;
    }

    for (const town in result) {
        console.log(`${town} : ${result[town]}`)
    }
}

solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
);

solve(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']);
