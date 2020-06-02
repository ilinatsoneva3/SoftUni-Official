function solve() {
  let answersNum = 0;
  let index = 0;

 Array.from(document.querySelectorAll('.quiz-answer'))
    .map(a => a.addEventListener('click', function nextQuestion(e) {

      if (e.target.textContent === 'onclick' || e.target.textContent === 'JSON.stringify()'
        || e.target.textContent === 'A programming API for HTML and XML documents') {
        answersNum++;
      }

      let currentSection = document.querySelectorAll('section')[index];

      currentSection.style.display = 'none';
      currentSection.classList.add('hidden');

      let nextSection = document.querySelectorAll('section')[index + 1];

      if (nextSection) {
        nextSection.classList.remove('hidden');
      } else {
        showResult(answersNum);
      }

      nextSection.style.display = 'block';
      index++;
    }));

  function showResult(answersNum) {
    document.querySelector('#results').style.display = 'block';

    if (answersNum === 3) {
      document.querySelector('#results > li > h1').textContent = 'You are recognized as top JavaScript fan!';
    } else {
      document.querySelector('#results > li > h1').textContent = (`You have ${answersNum} right answers`);
    }
  }
}
