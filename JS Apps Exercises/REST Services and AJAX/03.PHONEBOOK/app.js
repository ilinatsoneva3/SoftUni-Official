function attachEvents() {
  const loadBtn = document.getElementById("btnLoad");
  const createBtn = document.getElementById("btnCreate");

  let phoneBook = document.getElementById("phonebook");
  const personName = document.getElementById("person");
  const personPhone = document.getElementById("phone");

  loadBtn.addEventListener("click", loadPhonebook);
  createBtn.addEventListener("click", createContact);

  function loadPhonebook(e) {
    phoneBook.innerHTML = "";

    fetch(`https://phonebook-nakov.firebaseio.com/phonebook.json`)
      .then(res => res.json())
      .then(displayPhonebook)
      .catch(err => console.log(err));
  }

  function createContact(e) {
    const person = personName.value;
    const phone = personPhone.value;

    const headers = {
      method: "POST",
      headers: { "Content-type": "application/json" },
      body: JSON.stringify({ person, phone })
    };

    fetch(`https://phonebook-nakov.firebaseio.com/phonebook.json`, headers)
      .then(() => {
        phoneBook.innerHTML = "";
        personName.value = "";
        personPhone.value = "";

        loadPhonebook();
      })
      .catch(error);
  }

  function displayPhonebook(data) {
    Object.entries(data).forEach(([entryId, input]) => {
      const { person, phone } = input;

      let li = document.createElement("li");

      li.textContent = `${person}: ${phone}`;

      let deleteBtn = document.createElement("button");
      deleteBtn.textContent = "Delete";
      deleteBtn.setAttribute("data-target", entryId);
      deleteBtn.addEventListener("click", deleteContact);

      li.appendChild(deleteBtn);
      phoneBook.appendChild(li);
    });
  }

  function deleteContact(e) {
    let contactId = e.target.getAttribute("data-target");

    const headers = {
      method: "DELETE"
    };

    fetch(
      `https://phonebook-nakov.firebaseio.com/phonebook/${contactId}.json`,
      headers
    )
      .then(() => {
        phoneBook.innerHTML = "";
        loadPhonebook();
      })
      .catch(error);
  }

  function error() {
    phoneBook.innerHTML = "Sorry, something went wrong";
  }
}

attachEvents();
