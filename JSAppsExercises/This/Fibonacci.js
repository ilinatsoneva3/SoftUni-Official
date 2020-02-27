function getFibonator() {
  let prev = 0;
  let cur = 1;

  return function solve() {
    let result = prev + cur;
    prev = cur;
    cur = result;

    return prev;
  };
}
