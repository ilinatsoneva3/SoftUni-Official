import models from "../models/index.js";
import extend from "../utils/context.js";

export default {
  get: {
    login(context) {
      console.log(context);
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
          context.redirect("#/home");
        })
        .catch(e => console.error(e));
    },
    register(context) {
      const { username, password, rePassword } = context.params;

      if (password === rePassword) {
        models.user
          .register(username, password)
          .then(response => {
            context.redirect("#/user/login");
          })
          .catch(e => console.error(e));
      }
    }
  }
};
