class Rat{
    constructor(name){
        this.name = name;
        this.unitedRats = [];
    }

    unite(newRat){
        if(newRat instanceof Rat){
            this.unitedRats.push(newRat);
        }
    }

    getRats(){
        return this.unitedRats;
    }

    toString(){
        let allRats = `${this.name}\n`;
        this.unitedRats.forEach(rat =>{
            allRats+=`${rat.name}\n`;
        });
        return allRats;
    }
}