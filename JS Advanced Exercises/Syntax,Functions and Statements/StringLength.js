function solve(...params){
    let sum = params.reduce((a, b) => a+b.length
    , 0
    );
    let average = Math.floor(sum/params.length);
    console.log(sum);
    console.log(average);
}

solve('chocolate', 'ice cream', 'cake');