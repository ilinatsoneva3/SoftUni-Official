function solve(n, k) {
    let result = [1];
    
    for (i = 0; i<n-1;i++) {
        let newNumber = 1;
        let arrToSum = result.length<k ? result.slice() : result.slice(result.length-k, result.length);
       newNumber = i===0 ? newNumber : arrToSum.reduce((x,y)=>x+y);
       result.push(newNumber);
    }

    console.log(result);
}

solve(8,2);