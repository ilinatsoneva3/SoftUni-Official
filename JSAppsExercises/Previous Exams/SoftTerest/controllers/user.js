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
    profile(context) {
      models.ideas.getAll().then((response) => {
        const ideas = response.docs
          .map(docModifier)
          .filter((idea) => idea.uid === localStorage.userId)
          .map((idea) => idea.title);

        context.ideas = ideas;
        context.number = ideas.length;
        extend(context).then(function () {
          this.partial("../view/user/profile.hbs");
        });
      });
    },
  },

  post: {
    login(context) {
      const { username, password } = context.params;

      models.user
        .login(username, password)
        .then((response) => {
          context.user = response;
          context.username = response.email;
          context.isLoggedIn = true;
          context.id = response.uid;
          context.redirect("#/ideas/dashboard");
        })
        .catch((e) => console.error(e));
    },
    register(context) {
      const { username, password, repeatPassword } = context.params;

      if (password === repeatPassword) {
        models.user
          .register(username, password)
          .then((response) => {
            context.redirect("#/user/login");
          })
          .catch((e) => console.error(e));
      }
    },
  },
};
