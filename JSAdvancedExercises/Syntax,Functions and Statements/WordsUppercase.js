function solve(sentence){
    let result = sentence.match(/\w+/gim).map(l=>l.toUpperCase());
    console.log(result.join(", "));
}

solve("Hi, how are you");