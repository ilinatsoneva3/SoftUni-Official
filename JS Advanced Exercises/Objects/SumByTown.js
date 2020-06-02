function solve(arr = []) {
    let result = {};

    for (let i = 0; i < arr.length; i += 2) {
        let key = arr[i];
        let value = Number(arr[i + 1]);

        if (!Object.keys(result).find(x => x === key)) {
            result[key] = 0;
        }

        result[key] += value;
    }

    console.log(JSON.stringify(result));
};