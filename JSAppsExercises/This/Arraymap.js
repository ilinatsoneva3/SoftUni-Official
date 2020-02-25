//function arrayMap(arr, func) {
//  return arr.reduce((a, b) => {
//    return [...a, func(b)];
//  }, []);
//}

//same output

function arrayMap(arr, func) {
  let result = [];
  for (const item of arr) {
    result.push(func(item));
  }
  return result;
}

let nums = [1, 2, 3, 4, 5];
console.log(arrayMap(nums, item => item * 2)); // [ 2, 4, 6, 8, 10 ]
