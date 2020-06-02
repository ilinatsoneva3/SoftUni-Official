function solve(params) {
    let speed = Number(params[0]);
    let area = params[1];

    const operational = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20
    };

    let result = "";
    let difference = speed - operational[area];

    result = difference <= 0 ? ''
        : difference <= 20 ? 'speeding'
            : difference <= 40 ? 'excessive speeding'
                : 'reckless driving';

    console.log(result);
};

solve([40, 'city']);