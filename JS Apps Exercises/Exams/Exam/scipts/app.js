import controllers from "../controllers/index.js";

const app = Sammy("#root", function () {
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
  this.get("#/products/dashboard", controllers.products.get.dashboard);
  this.get("#/products/create", controllers.products.get.create);
  this.get("#/products/details/:productId", controllers.products.get.details);
  this.get("#/products/edit/:productId", controllers.products.get.edit);
  this.get("#/products/like/:productId", controllers.products.put.like);

  this.get("#/products/close/:productId", controllers.products.del.close);

  this.post("#/products/create", controllers.products.post.create);
  this.post("#/products/edit/:productId", controllers.products.put.edit);
  this.put("#/products/comment/:productId", controllers.products.put.comment);
});

(() => {
  app.run("#/home");
})();
