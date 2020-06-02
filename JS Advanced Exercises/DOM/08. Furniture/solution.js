function solve() {
  let generate = document.querySelector('#exercise > button:nth-child(3)');
  let buy = document.querySelector('#exercise > button:nth-child(6)');
  let table = document.getElementsByTagName('tbody')[0];
  let textArea = document.querySelector('#exercise > textarea:nth-child(5)');

  let checkedItems = [];
  let totalPrice = 0;
  let avDecFactor =0;

  generate.addEventListener('click', generateData);
  buy.addEventListener('click',showResult);  

  function showResult(e){
      let items =[...document
          .querySelectorAll('input')].reduce((a,b,i)=>{
            if(b.checked===true){
              a.push(table.children[i]);             
            }
            return a;
          },[]);      
      
      checkedItems = items.map(i=>i.children[1].textContent);
      totalPrice = items.reduce((a,b) => {
        a+= Number(b.children[2].textContent);
        return a;
      },0);

      avDecFactor+=items.reduce((a,b) => {
        a+= Number(b.children[3].textContent);
        return a;
      },0)/checkedItems.length;

      textArea.textContent += `Bought furniture: ${checkedItems.join(', ')}\n`;
      textArea.textContent+=`Total price: ${totalPrice.toFixed(2)}\n`;
      textArea.textContent+=`Average decoration factor: ${avDecFactor}`;
  }

  function generateData(e) {
    let input = JSON.parse(document.querySelector('#exercise > textarea:nth-child(2)').value);
   

    for (let dataInfo of input) {
      let row = document.createElement('tr');
      console.log(dataInfo);

      let image = document.createElement('td');
      let img = document.createElement('img');
      img.src = `${dataInfo.img}`;
      image.appendChild(img);
      row.appendChild(image);

      let nameRow = createCell(dataInfo, 'name');
      let priceRow = createCell(dataInfo, 'price');
      let decorationFactorRow = createCell(dataInfo,'decFactor');
      row.appendChild(nameRow);
      row.appendChild(priceRow);
      row.appendChild(decorationFactorRow);

      let checkBox = document.createElement('td');
      let check = document.createElement('input');     
      check.setAttribute('type', 'checkbox');
      checkBox.appendChild(check);
      row.appendChild(checkBox);    
      table.appendChild(row);
    }    
  }

  function createCell(obj, header) {
    let heading = document.createElement('td');
    let par = document.createElement('p');
    par.textContent = obj[header];
    heading.appendChild(par);
    return heading;
  }
}