import models from "../models/index.js";
import extend from "../utils/context.js";
import docModifier from "../utils/doc-modifier.js";

export default {
  get: {
    login(context) {
      extend(context).then(function () {
        this.partial("../view/user/login.hbs");
      });
    },
    register(context) {
      extend(context).then(function () {
        this.partial("../view/user/register.hbs");
      });
    },
    logout(context) {
      models.user.logout().then((response) => {
        context.redirect("#/home");
      });
    },
  },

  post: {
    login(context) {
      const { email, password } = context.params;

      models.user
        .login(email, password)
        .then((response) => {
          context.user = response;
          context.username = response.email;
          context.isLoggedIn = true;
          context.id = response.uid;
          context.redirect("#/articles/dashboard");
        })
        .catch((e) => console.error(e));
    },
    register(context) {
      const { email, password } = context.params;
      const reppass = context.params["rep-pass"];

      if (password === reppass) {
        models.user
          .register(email, password)
          .then((response) => {
            context.redirect("#/articles/dashboard");
          })
          .catch((e) => console.error(e));
      }
    },
  },
};
