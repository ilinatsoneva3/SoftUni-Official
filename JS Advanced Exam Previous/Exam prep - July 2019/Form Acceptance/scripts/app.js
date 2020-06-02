function acceptance() {
	let addBtn = document.getElementById("acceptance");
	let warehouse = document.getElementById("warehouse");
	addBtn.addEventListener("click", addItem);

	function addItem(e) {
		let company = document.getElementsByName("shippingCompany")[0].value;
		let productName = document.getElementsByName("productName")[0].value;
		let productQuantity = +document.getElementsByName("productQuantity")[0].value;
		let productScrap = +document.getElementsByName("productScrape")[0].value;

		if (company && productName && productQuantity > 0 && productScrap) {
			if (productQuantity - productScrap > 0) {
				let div = createHTMLElement("div");
				let p = createHTMLElement("p", `[${company}] ${productName} - ${productQuantity - productScrap} pieces`);
				let button = createHTMLElement("button", "Out of stock");
				button.type = "button";
				button.addEventListener("click", removeProduct);
				div = appendChildren([p, button], div);
				warehouse.appendChild(div);
			}
		}

		document.getElementsByName("shippingCompany")[0].value = "";
		document.getElementsByName("productName")[0].value = "";
		document.getElementsByName("productQuantity")[0].value = "";
		document.getElementsByName("productScrape")[0].value = "";
	}

	function removeProduct(e) {
		let target = e.target;
		let div = target.parentNode;
		warehouse.removeChild(div);
	}

	function createHTMLElement(type, textContent) {
		let el = document.createElement(type);
		if (textContent) {
			el.textContent = textContent;
		}
		return el;
	}

	function appendChildren(children, parent) {
		children.forEach(child => {
			parent.appendChild(child);
		});
		return parent;
	}
}