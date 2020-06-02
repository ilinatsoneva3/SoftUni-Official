function solve(x=5){
    let result = new Array(x);

    for(i = 0; i<x;i++){
        result[i] ="* ".repeat(x).trim();
    }

    console.log(result.join("\n"));
}

solve(2)