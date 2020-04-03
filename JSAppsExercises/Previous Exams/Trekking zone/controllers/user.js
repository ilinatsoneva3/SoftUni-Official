import models from "../models/index.js";
import extend from "../utils/context.js";
import docModifier from "../utils/doc-modifier.js";

export default {
  get: {
    login(context) {
      extend(context).then(function() {
        this.partial("../view/user/login.hbs");
      });
    },
    register(context) {
      extend(context).then(function() {
        this.partial("../view/user/register.hbs");
      });
    },
    logout(context) {
      models.user.logout().then(response => {
        context.redirect("#/home");
      });
    },
    profile(context) {
      models.treks.getAll().then(response => {
        const treks = response.docs.map(docModifier).forEach(element => {
          console.log(element);
        });
      });

      extend(context).then(function() {
        this.partial("../view/user/profile.hbs");
      });
    }
  },

  post: {
    login(context) {
      const { username, password } = context.params;

      models.user
        .login(username, password)
        .then(response => {
          context.user = response;
          context.username = response.email;
          context.isLoggedIn = true;
          context.id = response.uid;
          context.likes = 0;
          context.redirect("#/treks/dashboard");
        })
        .catch(e => console.error(e));
    },
    register(context) {
      const { username, password, rePassword } = context.params;

      if (password === rePassword) {
        models.user
          .register(username, password)
          .then(response => {
            context.redirect("#/home");
          })
          .catch(e => console.error(e));
      }
    }
  }
};
