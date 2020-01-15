function solve(arr) {
    let obj = {};

    for (i = 0; i < arr.length; i += 2) {
        let element = arr[i];
        let value = Number(arr[i + 1]);
        obj[element] = value;
    }

    console.log(obj);
}

solve(['Yoghurt', 48, 'Rise', 138, 'Apple', 52])