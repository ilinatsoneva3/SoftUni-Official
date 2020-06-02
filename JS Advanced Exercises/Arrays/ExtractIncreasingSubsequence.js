function solve(arr=[]) {
    let result = arr.reduce((acc, currentNum) =>{
        let lastNum = acc[acc.length-1];

        if(currentNum>=lastNum || lastNum===undefined){
            acc.push(currentNum);
        }

        return acc;
    }, []);

    console.log(result.join('\n'));
}

solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
);
