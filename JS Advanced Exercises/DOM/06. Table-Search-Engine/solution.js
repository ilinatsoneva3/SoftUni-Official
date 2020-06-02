function solve() {
   let button = document.getElementById('searchBtn');

   button.addEventListener('click', highlightResults);

   function highlightResults() {
      let query = document.getElementById('searchField').value.toLowerCase();

      let tableData = document.querySelector('body > table > tbody');
      let rowData = tableData.getElementsByTagName('tr');

      for (let row of rowData) {
         row.classList.remove('select');
         let cells = row.getElementsByTagName('td');

         for (let cell of cells) {
            if (cell.textContent.toLowerCase().includes(query)) {
               row.classList.add('select');
            }
         }
      }
      document.getElementById('searchField').value = '';
   }
}