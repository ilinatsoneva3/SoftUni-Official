function create(words) {
   let content = document.getElementById('content');

   words.forEach(element => {
      let div = document.createElement('div');
      let p = document.createElement('p');
      p.style.display = 'none';
      p.textContent = element;
      div.appendChild(p);
      content.appendChild(div);
      div.addEventListener('click', () => {
         p.style.display = 'inline-block';
      });
   });
}