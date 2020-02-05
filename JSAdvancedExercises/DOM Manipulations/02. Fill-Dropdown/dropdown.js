function addItem() {
    let text = document.getElementById('newItemText').value;
    let value = document.getElementById('newItemValue').value;

    if(text==='' || value===''){
        alert('Insert text and value')
    }

    let newMenuItem = document.createElement('option');
    newMenuItem.value=value;
    newMenuItem.textContent=text;

    document.getElementById('menu').appendChild(newMenuItem);

    document.getElementById('newItemText').value='';
    document.getElementById('newItemValue').value='';
}