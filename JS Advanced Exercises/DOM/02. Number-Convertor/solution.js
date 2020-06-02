function solve() {
    let optionsMenu = document.getElementById('selectMenuTo');

    document.querySelector('#container > button').addEventListener('click', convert);

    function convert(){
        let result;
        let number = Number(document.getElementById('input').value);

        if(optionsMenu.value==='binary'){
            result = convertToBinary(number);
        }else if(optionsMenu.value==='hexadecimal'){
            result = convertToHex(number);
        }

        document.getElementById('result').value = result;
    }

    function convertToBinary(number){
        return (number >>> 0).toString(2);
    }

    function convertToHex(number){
        return number.toString(16).toUpperCase();
    }
    
    function createMenu(){
        let binaryOption = document.createElement('option');
        binaryOption.textContent='Binary';
        binaryOption.value = 'binary';

        optionsMenu.appendChild(binaryOption);

        let hexadecimalOption = document.createElement('option');
        hexadecimalOption.textContent='Hexadecimal';
        hexadecimalOption.value = 'hexadecimal';

        optionsMenu.appendChild(hexadecimalOption);
    }

    createMenu();
}