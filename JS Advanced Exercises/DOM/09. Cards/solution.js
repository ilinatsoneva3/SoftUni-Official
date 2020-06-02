function solve() {
   Array.from(document.getElementsByTagName('img'))
      .forEach(i => i.addEventListener('click', compareCards));

   function compareCards(e) {
      let card = e.target;
      let parent = card.parentNode;
      card.removeEventListener('click', compareCards);

      let result = document.getElementById('result').children;
      let leftPlayer = result[0];
      let rightPlayer = result[2];

      card.src = './images/whiteCard.jpg'; //D:\GitHub\SoftUni-Official\JSAdvancedExercises\DOM\09. Cards\images\whiteCard.jpg

      if (parent.id === 'player1Div') {
         leftPlayer.textContent = card.name;
      }
      else if (parent.id === 'player2Div') {
         rightPlayer.textContent = card.name;
      }

      if (leftPlayer.textContent && rightPlayer.textContent) {
         let winner;
         let loser;

         console.log('im in');

         if (+leftPlayer.textContent > +rightPlayer.textContent) {
            winner = document.querySelector(`#player1Div img[name="${leftPlayer.textContent}"]`);
            loser = document.querySelector(`#player2Div img[name="${rightPlayer.textContent}"]`);
         } else {
            winner = document.querySelector(`#player2Div img[name="${rightPlayer.textContent}"]`);
            loser = document.querySelector(`#player1Div img[name="${leftPlayer.textContent}"]`);
         }

         winner.style.border = '2px solid green';
         loser.style.border = '2px solid red';

         document.getElementById('history').textContent += `[${leftPlayer.textContent} vs ${rightPlayer.textContent}] `;

         leftPlayer.textContent = "";
         rightPlayer.textContent = "";
      }
   }
}