function solve(arr=[], criteria){
    let result = [];

    switch(criteria){
        case'asc': return arr.sort((a,b)=>a-b);
        case 'desc': return arr.sort((a,b)=>b-a);
    }

    console.log(result);
}

solve([14, 7, 17, 6, 8], 'asc');
solve([14, 7, 17, 6, 8], 'desc');