function solve(arr=[]){
    let result = new Set();

    arr=arr.sort((a, b) => {
        return a.length - b.length || a.localeCompare(b);
    }).forEach(a=>result.add(a));

    result.forEach(a=>console.log(a));
}

solve(['Ashton',
'Kutcher',
'Ariel',
'Lilly',
'Keyden',
'Aizen',
'Billy',
'Braston']
);

solve(['Denise',
'Ignatius',
'Iris',
'Isacc',
'Indie',
'Dean',
'Donatello',
'Enfuego',
'Benjamin',
'Biser',
'Bounty',
'Renard',
'Rot']
);