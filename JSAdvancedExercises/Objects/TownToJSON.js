// JavaScript source code
function solve(arr = []) {
    let keys = arr[0].split('|').filter(x => x !== '').map(word => word.trim());
    let values = [];
    for (let i = 1; i < arr.length; i++) {
        let value = arr[i].split('|').filter(x => x !== '').map(word => word.trim());
        values.push(value);
    }

    let result = [];

    for (let i = 0; i < values.length; i++) {
        let obj = {};
        for (let j = 0; j < values[i].length; j++) {
            let value = 0;
            if (j !== 0) {
                value = Number(values[i][j]).toFixed(2);
                obj[keys[j]] = Number(value);
            }
            else {
                value = values[i][j];
                obj[keys[j]] = value;
            }

        }
        result.push(obj);
    }
    result = JSON.stringify(result);
    console.log(result);
}
