import controllers from "../controllers/index.js";

const app = Sammy("#root", function() {
  this.use("Handlebars", "hbs");

  //home
  this.get("#/", controllers.home.get.home);
  this.get("#/home", controllers.home.get.home);

  //user

  this.get("#/user/login", controllers.user.get.login);
  this.get("#/user/register", controllers.user.get.register);
  this.get("#/user/profile", controllers.user.get.profile);

  this.post("#/user/login", controllers.user.post.login);
  this.post("#/user/register", controllers.user.post.register);
  this.get("#/user/logout", controllers.user.get.logout);

  //treks
  this.get("#/treks/dashboard", controllers.treks.get.dashboard);
  this.get("#/treks/create", controllers.treks.get.create);
  this.get("#/treks/details/:treksId", controllers.treks.get.details);
  this.get("#/treks/edit/:treksId", controllers.treks.get.edit);
  this.get("#/treks/like/:treksId", controllers.treks.put.like);

  this.get("#/treks/close/:treksId", controllers.treks.del.close);

  this.post("#/treks/create", controllers.treks.post.create);
  this.post("#/treks/edit/:treksId", controllers.treks.put.edit);
});

(() => {
  app.run("#/home");
})();
