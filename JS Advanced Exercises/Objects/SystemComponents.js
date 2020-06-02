function solve(arr = []) {
    let result = new Map();

    for (let line of arr) {
        let [system, component, subcomponent] = line.split(" | ");

        if (!result.get(system)) {
            result.set(system, new Map());
        }

        if (!result.get(system).get(component)) {
            result.get(system).set(component, []);
        }

        result.get(system).get(component).push(subcomponent);
    }

    console.log([...result]
        .sort((a, b) => b[1].size - a[1].size || a[0].localeCompare(b[0]))
        .map(s => `${s[0]}\n${[...s[1]]
            .sort((a, b) => b[1].length - a[1].length)
            .map(i => `|||${i[0]}\n${[...i[1]]
                .map(c => `||||||${c}`)
                .join("\n")}`)
            .join("\n")}`)
        .join("\n"));
}

solve(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
);