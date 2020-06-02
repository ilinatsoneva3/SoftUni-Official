import controllers from "../controllers/index.js";

const app = Sammy("#root", function () {
  this.use("Handlebars", "hbs");

  //home
  this.get("#/", controllers.user.get.login);
  this.get("#/home", controllers.user.get.login);

  //user

  this.get("#/user/login", controllers.user.get.login);
  this.get("#/user/register", controllers.user.get.register);

  this.post("#/user/login", controllers.user.post.login);
  this.post("#/user/register", controllers.user.post.register);
  this.get("#/user/logout", controllers.user.get.logout);

  //treks
  this.get("#/articles/dashboard", controllers.articles.get.dashboard);
  this.get("#/articles/create", controllers.articles.get.create);
  this.get("#/articles/details/:articleId", controllers.articles.get.details);
  this.get("#/articles/edit/:articleId", controllers.articles.get.edit);

  this.get("#/articles/close/:articleId", controllers.articles.del.close);

  this.post("#/articles/create", controllers.articles.post.create);
  this.post("#/articles/edit/:articleId", controllers.articles.put.edit);
});

(() => {
  app.run("#/home");
})();
