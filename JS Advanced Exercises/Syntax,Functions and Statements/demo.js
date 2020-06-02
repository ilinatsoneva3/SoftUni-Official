function solve(arr) {

    let number = Number(arr.shift());

    const operations = {
        chop: x => { return x / 2 },
        dice: x => { return Math.sqrt(x) },
        spice: x => { return x += 1 },
        bake: x => { return x * 3 },
        fillet: x => { return x = x * 0.8 }
    }

    for (const command of arr) {
        number = operations[command](number);
        console.log(number);
    }
}

solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);