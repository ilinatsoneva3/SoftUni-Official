function solve(arr=[]){
    let areEqual = true;
    let firstSum = arr[0].reduce((a, b) => a+b,0);

    for(let i = 1; i<arr.length; i++){
        let currentSum = arr[i].reduce((a, b) => a+b);
        if(firstSum!==currentSum){
            areEqual = false;
            break;
        }
    }

    for(let i = 0; i<arr[0].length; i++){
        let currentSum = 0;

        for(j=0; j<arr.length;j++){
            currentSum+=arr[j][i];
        }

        if(firstSum!==currentSum){
            areEqual = false;
            break;
        }
    }

    console.log(areEqual);
}

solve([[1, 0, 0],
[0, 0, 1]]
);
