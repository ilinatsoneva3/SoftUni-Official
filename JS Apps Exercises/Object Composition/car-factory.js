function assemble(compononents) {
  const engineModels = [
    { power: 90, volume: 1800 },
    { power: 120, volume: 2400 },
    { power: 200, volume: 3500 }
  ];

  return {
    model: compononents.model,
    engine: engineModels.find(e => compononents.power <= e.power),
    carriage:
      compononents.carriage === "hatchback"
        ? { type: "hatchback", color: compononents.color }
        : { type: "coupe", color: compononents.color },
    wheels: Array(4).fill(
      compononents.wheelsize % 2 === 0
        ? compononents.wheelsize - 1
        : compononents.wheelsize
    )
  };
}

console.log(
  assemble({
    model: "VW Golf II",
    power: 90,
    color: "blue",
    carriage: "hatchback",
    wheelsize: 14
  })
);
