function solveEquation(x, y, operator){
    let result;
    switch(operator){
        case "+": result = x + y; 
            break;
        case "-": result = x - y; 
            break;
        case "/": result = x / y; 
            break;
        case "*": result = x * y; 
            break;
        case "%": result = x % y; 
            break;
        case "**": result = x ** y; 
            break;
    }
    console.log(result);
}

solveEquation(5,2,"**");