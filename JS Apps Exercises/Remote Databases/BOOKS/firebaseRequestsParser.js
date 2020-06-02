const url = `https://jsappsdbexercise.firebaseio.com/`; //insert firebase url here

export function listAllBooks() {
  return fetch(`${url}books.json`)
    .then(errorHandler)
    .then(serializeData);
}

export function createNewBook(data) {
  fetch(`${url}books.json`, {
    method: "POST",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(data)
  })
    .then(errorHandler)
    .then(serializeData);
}

export function updateBook(data, id) {
  fetch(`${url}books/${id}.json`, {
    method: "PUT",
    headers: { "Content-type": "application/json" },
    body: JSON.stringify(data)
  }).then(errorHandler);
}

export function deleteBook(data, id) {
  fetch(`${url}books/${id}.json`, {
    method: "DELETE"
  }).then(errorHandler);
}

function errorHandler(e) {
  if (!e.ok) {
    throw new Error(`Something went wrong: ${e.statusText}`);
  }

  return e;
}

function serializeData(response) {
  return response.json();
}
