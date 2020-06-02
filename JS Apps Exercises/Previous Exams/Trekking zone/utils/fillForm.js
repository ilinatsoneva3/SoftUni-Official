export default function(data, form) {
  Object.entries(form).map(([inputName, value]) => {
    if (!form.elements.namedItem(inputName)) {
      return;
    }
    form.elements.namedItem(inputName).value = value;
  });

  console.log(form);
}
