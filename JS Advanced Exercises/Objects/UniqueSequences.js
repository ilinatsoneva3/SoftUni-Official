function solve(arr = []) {
        
    let result = [];

    for (let array of arr) {
        let sortedArray = JSON.parse(array).sort((x,y)=>y-x);
        let currentResult = sortedArray.reduce((a,b)=>a+b,0);       

        if(!result.some((z) => z.reduce((a, b) => a + b, 0)===currentResult)){
            result.push(sortedArray);
        }
    }

    result = result.sort((x,y)=>x.length-y.length).forEach(x=>{
        console.log(`[${x.join(", ")}]`);
    });
   
}

solve(["[-3, -2, -1, 0, 1, 2, 3, 4]",
    "[10, 1, -17, 0, 2, 13]",
    "[4, -3, 3, -2, 2, -1, 1, 0]"]
);

solve(["[7.14, 7.180, 7.339, 80.099]",
    "[7.339, 80.0990, 7.140000, 7.18]",
    "[7.339, 7.180, 7.14, 80.099]"]
);