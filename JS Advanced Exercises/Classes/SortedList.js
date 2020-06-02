class List{
    constructor(arr = []){
        this.list = arr.sort((a, b) => a-b);     
        this.size = this.list.length;   
    }   
   
    add(number){
        this.list.push(number);
        this.size++;
        return this.list.sort((a, b) => a-b);
    }

    remove(index){
        if(index>this.list.length || index<0){
            throw new Error("Invalid index");
        }
        this.size > 0 ? this.size-- : this.size = 0;
        return this.list.splice(index, 1);
    }

    get(index){
        if(index>this.list.length|| index<0){
            throw new Error("Invalid index");
        }
        return this.list[index];
    }
}