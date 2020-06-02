function solve([arr]) {
    let resArr = arr.split(/\W+/).filter(w => w != "");
    let result = {};

    for (let i = 0; i < resArr.length; i++) {

        let key = resArr[i];

        if (!Object.keys(result).find(x => x === key)) {
            result[key] = 0;
        }
        result[key]++;
    }

    console.log(JSON.stringify(result));
}