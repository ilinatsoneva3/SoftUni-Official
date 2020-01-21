function solve(arr = []) {
    let result = [];

    for (const command in arr) {
        if (arr[command] === "add") {
            result.push(Number(command) + 1);
        } else {
            result.pop();
        }
    }

    console.log(result.length > 0 ? result.join('\n') : 'Empty');
}


solve(['add',
'add',
'remove',
    'remove',
    'remove']
);