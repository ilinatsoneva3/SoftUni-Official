function solve(){
    let result = {};

    for (let arg of arguments){

        let type = typeof arg;
        let printArg = type=== 'object' ? '': arg;
        console.log(`${type}: ${printArg}`);

        if(!result.hasOwnProperty(type)){
            result[type]=0;
        }
        result[type]++;
    }

    Object.keys(result)
        .sort((a,b)=>result[b]-result[a])
            .forEach(element =>{
                console.log(`${element} = ${result[element]}`);
            })
}

solve({ name: 'bob'}, 3.333, 9.999);