function solve(area, vol, input) {
  let obj = JSON.parse(input);
  function getResults(obj) {
    let areaValue = Math.abs(area.call(obj));
    let volumeValue = Math.abs(vol.call(obj));
    return { area: areaValue, volume: volumeValue };
  }
  return obj.map(getResults);
}

function area() {
  return this.x * this.y;
}

function vol() {
  return this.x * this.y * this.z;
}
