import extend from "../utils/context.js";
import models from "../models/index.js";
import docModifier from "../utils/doc-modifier.js";
import fillForm from "../utils/fillForm.js";

export default {
  get: {
    dashboard(context) {
      models.treks.getAll().then(response => {
        const treks = response.docs.map(docModifier);

        context.treks = treks;

        extend(context).then(function() {
          this.partial("../view/treks/dashboard.hbs");
        });
      });
    },
    create(context) {
      extend(context).then(function() {
        this.partial("../view/treks/create.hbs");
      });
    },
    details(context) {
      const { treksId } = context.params;

      models.treks
        .get(treksId)
        .then(response => {
          const treks = docModifier(response);

          Object.keys(treks).forEach(key => {
            context[key] = treks[key];
          });

          context.canEdit =
            treks.organizer === localStorage.getItem("userEmail");

          extend(context).then(function() {
            this.partial("../view/treks/details.hbs");
          });
        })
        .catch(err => console.error(err));
    },
    edit(context) {
      extend(context).then(function() {
        context.id = context.params.treksId;
        this.partial("../view/treks/edit.hbs");
      });

      const { treksId } = context.params;

      models.treks.get(treksId).then(response => {
        const data = response.data();
        const form = document.getElementsByClassName("create-trek")[0];

        Object.entries(data).map(([inputName, value]) => {
          if (!form.elements.namedItem(inputName)) {
            return;
          }

          form.elements.namedItem(inputName).value = value;
        });
      });
    }
  },
  post: {
    create(context) {
      const data = {
        ...context.params,
        organizer: localStorage.getItem("userEmail"),
        likes: 0
      };

      if (data.location.length > 6 && data.description.length > 10) {
        models.treks
          .create(data)
          .then(response => {
            context.redirect("#/treks/dashboard");
          })
          .catch(e => console.error(e));
      }
    }
  },
  del: {
    close(context) {
      const { treksId } = context.params;

      models.treks.del(treksId).then(response => {
        context.redirect("#/treks/dashboard");
      });
    }
  },
  put: {
    edit(context) {
      const { treksId } = context.params;
      const trek = {
        ...context.params,
        uid: localStorage.getItem("userEmail")
      };

      models.treks
        .put(treksId, trek)
        .then(response => {
          context.redirect("#/treks/dashboard");
        })
        .catch(error => console.error(error));
    },
    like(context) {
      const { treksId } = context.params;

      models.treks
        .get(treksId)
        .then(response => {
          const trek = docModifier(response);
          trek.likes = +trek.likes + 1;

          models.treks.put(treksId, trek).then(response => {
            context.redirect(`#/treks/details/${treksId}`);
          });
        })
        .catch(error => console.error(error));
    }
  }
};
