function solve(arr){
    let result = Number.MIN_SAFE_INTEGER;

    for (const arrar in arr) {
        let curentArr = arr[arrar];
        for (const number in curentArr) {
            result = Math.max(result, curentArr[number]);
        }
    }

    console.log(result);
}

solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]   
   );