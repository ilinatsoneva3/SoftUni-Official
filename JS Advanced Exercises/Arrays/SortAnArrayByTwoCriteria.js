function solve(arr = []){
    let result = arr.sort((firstWord, secondWord)=>{
        firstWord = firstWord.toLowerCase();
        secondWord=secondWord.toLowerCase();
        if(firstWord.length === secondWord.length){
            return firstWord.localeCompare(secondWord);
        } else
        {
            return firstWord.length - secondWord.length;}
    });

    console.log(result.join('\n'));
}

solve(['alpha', 
'beta', 
'gamma']
);

solve(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']
);

solve(['test', 
'Deny', 
'omen', 
'Default']
);