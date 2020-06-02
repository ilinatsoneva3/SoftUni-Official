function solve(x, y, z){
    let largestNum = Math.max(Math.max(x, y), z);
    console.log(`The largest number is ${largestNum}.`);
}

solve(5, -3, 16);