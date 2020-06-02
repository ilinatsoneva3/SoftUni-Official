import extend from "../utils/context.js";
import models from "../models/index.js";
import docModifier from "../utils/doc-modifier.js";

export default {
  get: {
    dashboard(context) {
      models.products.getAll().then((response) => {
        const products = response.docs.map(docModifier);

        context.products = products;

        extend(context).then(function () {
          this.partial("../view/products/dashboard.hbs");
        });
      });
    },
    create(context) {
      extend(context).then(function () {
        this.partial("../view/products/create.hbs");
      });
    },
    details(context) {
      const { productId } = context.params;

      models.products
        .get(productId)
        .then((response) => {
          const products = docModifier(response);

          Object.keys(products).forEach((key) => {
            context[key] = products[key];
          });

          context.canComment =
            products.creator === localStorage.getItem("userEmail");

          extend(context).then(function () {
            this.partial("../view/products/details.hbs");
          });
        })
        .catch((err) => console.error(err));
    },
    edit(context) {
      extend(context).then(function () {
        context.id = context.params.productId;
        this.partial("../view/products/edit.hbs");
      });

      const { productId } = context.params;

      models.products.get(productId).then((response) => {
        const data = response.data();
        const form = document.getElementsByClassName("create-product")[0];

        Object.entries(data).map(([inputName, value]) => {
          if (!form.elements.namedItem(inputName)) {
            return;
          }

          form.elements.namedItem(inputName).value = value;
        });
      });
    },
  },
  post: {
    create(context) {
      const data = {
        ...context.params,
        creator: localStorage.getItem("userEmail"),
        uid: localStorage.getItem("userId"),
      };

      models.products
        .create(data)
        .then((response) => {
          context.redirect("#/products/dashboard");
        })
        .catch((e) => console.error(e));
    },
  },
  del: {
    close(context) {
      const { productId } = context.params;

      models.products.del(productId).then((response) => {
        context.redirect("#/products/dashboard");
      });
    },
  },
  put: {
    edit(context) {
      const { productId } = context.params;
      const product = {
        ...context.params,
        uid: localStorage.getItem("userEmail"),
      };

      models.products
        .put(productId, product)
        .then((response) => {
          context.redirect("#/products/dashboard");
        })
        .catch((error) => console.error(error));
    },
    like(context) {
      const { productId } = context.params;

      models.products
        .get(productId)
        .then((response) => {
          const product = docModifier(response);
          product.likes = +product.likes + 1;

          models.products.put(productId, product).then((response) => {
            context.redirect(`#/products/details/${productId}`);
          });
        })
        .catch((error) => console.error(error));
    },
    comment(context) {
      const { productId, newComment } = context.params;

      models.products
        .get(productId)
        .then((response) => {
          const product = docModifier(response);

          let comment = `${localStorage.getItem("userEmail")} : ${newComment}`;

          product.comments.push(comment);
          return models.products.put(productId, product);
        })
        .then((response) => {
          context.redirect(`#/products/details/${productId}`);
        });
    },
  },
};
