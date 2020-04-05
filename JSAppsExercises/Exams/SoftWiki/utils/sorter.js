export default function (arr, keyword) {
  return arr
    .filter((a) => a.category === keyword)
    .sort((a, b) => {
      return a.title.localeCompare(b.title);
    });
}
