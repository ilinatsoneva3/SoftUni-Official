function solve(n, m){
    let x = Number(n);
    let y = Number(m);
    let result=0;

    for (i=x;i<=y;i++){
        result+=i;
    }

    console.log(result);
}

solve("5", "9");