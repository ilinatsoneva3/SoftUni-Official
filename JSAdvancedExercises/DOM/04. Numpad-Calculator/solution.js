function solve() {
    let expressionOutput = document.getElementById('expressionOutput');
    let expression = "";
    let resultOutput = document.getElementById('resultOutput');

    Array.from(document.querySelectorAll('button')).forEach(b => {
        b.addEventListener('click', () => {

            if (b.textContent === "=") {
                let arg = expression.split(" ");
                let firstNum = Number(arg[0]);
                let operator = arg[1];
                let secondNum = Number(arg[2]);

                if (!firstNum || !operator || !secondNum) {
                    resultOutput.textContent = "NaN";
                    return;
                } else{
                    let result = eval(`${firstNum} ${operator === 'x' ? '*': operator} ${secondNum}`);                   
                    resultOutput.textContent=result;
                    return;
                }
            }

            if(!isNaN(b.textContent) || b.textContent==="."){
                expression+=b.textContent;
            } else if(b.textContent==='C'){
                expression="";
                expressionOutput.textContent="";
                resultOutput.textContent="";
            }else{
                expression+=` ${b.textContent} `;
            }

            expressionOutput.textContent=expression;
        });
    });
}