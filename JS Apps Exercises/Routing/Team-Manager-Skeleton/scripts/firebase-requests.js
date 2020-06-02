let name = "teams";
let collectionUrl = `https://routingexercise.firebaseio.com/${name}`;

function getAll(token) {
  return fetch(`${collectionUrl}.json${token ? `?auth${token}` : ""}`)
    .then(responseHandler)
    .then(x => x.json())
    .catch(errHandler);
}

function getById(token, id) {
  return fetch(`${collectionUrl}/${id}.json${token ? `?auth${token}` : ""}`)
    .then(responseHandler)
    .then(x => x.json())
    .catch(errHandler);
}

function createEntity(token, dataObj) {
  return fetch(`${collectionUrl}.json${token ? `?auth${token}` : ""}`, {
    method: "POST",
    body: JSON.stringify(dataObj)
  })
    .then(responseHandler)
    .catch(errHandler);
}

function updateRecord(token, id, data) {
  return fetch(
    `${collectionURL}/${id}.json` + (token ? `?auth=${token}` : ""),
    {
      method: "PUT",
      body: JSON.stringify(data)
    }
  )
    .then(CheckStatus)
    .catch(handleError);
}

function partialUpdateRecord(token, id, data) {
  return fetch(
    `${collectionURL}/${id}.json` + (token ? `?auth=${token}` : ""),
    {
      method: "PATCH",
      body: JSON.stringify(data)
    }
  )
    .then(CheckStatus)
    .catch(handleError);
}

function deleteRecord(token, id) {
  return fetch(
    `${collectionURL}/${id}.json` + (token ? `?auth=${token}` : ""),
    {
      method: "DELETE"
    }
  )
    .then(CheckStatus)
    .catch(handleError);
}

function errHandler(err) {
  console.log(err);
}

function responseHandler(res) {
  if (!res.ok) {
    throw new Error(
      `Status code: ${res.statu}; Error message: ${res.statusText}`
    );
  }

  return res;
}

export const fireBaseRequestFactory = {
  getAll,
  getById,
  createEntity,
  updateEntity,
  patchEntity,
  deleteEntity
};
