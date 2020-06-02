function solve(arr) {
    let numArr = arr.map(Number);
    let firstNum = numArr.shift();
    let lastNum = numArr.length > 0 ?numArr.pop() : firstNum;
    let result = firstNum + lastNum;
    console.log(result);
}

solve(['20']);