function solve(numbers){
    aggregate(numbers, 0, (x,y)=>x+y);
    aggregate(numbers, 0, (x,y)=>x+ 1/y);
    aggregate(numbers, "", (x,y)=>x+y);
    function aggregate(arr, initialValue, func){
        let value = initialValue;
        for(i=0;i<arr.length;i++){
            value=func(value, arr[i]);
        }
        console.log(value);
    }
}

solve([2, 4, 8, 16]);