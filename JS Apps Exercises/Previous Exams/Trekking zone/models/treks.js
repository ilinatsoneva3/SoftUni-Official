const collectionName = "treks";

export default {
  create(data) {
    return firebase
      .firestore()
      .collection(collectionName)
      .add(data);
  },
  getAll() {
    return firebase
      .firestore()
      .collection(collectionName)
      .get();
  },
  get(id) {
    return firebase
      .firestore()
      .collection(collectionName)
      .doc(id)
      .get();
  },
  del(id) {
    return firebase
      .firestore()
      .collection(collectionName)
      .doc(id)
      .delete();
  },
  put(id, data) {
    return firebase
      .firestore()
      .collection(collectionName)
      .doc(id)
      .update(data);
  }
};
