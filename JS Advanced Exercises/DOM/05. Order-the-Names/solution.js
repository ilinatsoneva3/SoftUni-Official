function solve() {
    let addButton = document.querySelector('#exercise > article > button');
    addButton.addEventListener('click', addNameToList);

    function addNameToList(){
        let newName = document.querySelector('input').value;
        let firstLetterIndex = newName.toLocaleLowerCase().charCodeAt(0)-97;
        
        if(firstLetterIndex>=0&&firstLetterIndex<=25){
            let name = newName.charAt(0).toUpperCase()+newName.substr(1).toLowerCase();
            console.log(name);

            let list = document.querySelectorAll('li');
            let currentListElement = list[firstLetterIndex];

            if(currentListElement.textContent===""){
                currentListElement.textContent=name;
            } else {
                currentListElement.textContent+= ", " + name;
            }

            document.querySelector('input').value = "";
        }        
    }
}