function solve(arr) {
    let [x1, y1, x2, y2] = arr.map(Number);
    let result = "";

    function checkIfValid(x1, y1, x2, y2) {
        let distance = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
        result = distance % 1 == 0 ? `{${x1}, ${y1}} to {${x2}, ${y2}} is valid` : `{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`;
        console.log(result);
    };

    checkIfValid(x1, y1, 0, 0);
    checkIfValid(x2, y2, 0, 0);
    checkIfValid(x1, y1, x2, y2);
};

solve([2, 1, 1, 1])