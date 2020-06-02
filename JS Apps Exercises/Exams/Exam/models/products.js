const collectionName = "products";

export default {
  create(data) {
    return firebase.firestore().collection(collectionName).add(data);
  },
  getAll() {
    return firebase.firestore().collection(collectionName).get();
  },
  get(id) {
    return firebase.firestore().collection(collectionName).doc(id).get();
  },
  del(id) {
    return firebase.firestore().collection(collectionName).doc(id).delete();
  },
  put(id, data) {
    return firebase.firestore().collection(collectionName).doc(id).update(data);
  },
  getCount() {
    // Sum the count of each shard in the subcollection
    firebase
      .firestore()
      .collection(collectionName)
      .get()
      .then((snapshot) => {
        let total_count = 0;
        snapshot.forEach((doc) => {
          total_count += doc.data().count;
        });

        return total_count;
      });
  },
};
