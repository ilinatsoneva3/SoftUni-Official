function solve(arr){
    let result = arr.filter((number, index) => index%2!==0).map(number => number* 2).reverse().join(" ");

    console.log(result);
}

solve([3, 0, 10, 4, 7, 3]);