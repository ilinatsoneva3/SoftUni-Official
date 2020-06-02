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
  this.get("#/ideas/dashboard", controllers.ideas.get.dashboard);
  this.get("#/ideas/create", controllers.ideas.get.create);
  this.get("#/ideas/details/:ideaId", controllers.ideas.get.details);
  this.get("#/ideas/edit/:ideaId", controllers.ideas.get.edit);
  this.get("#/ideas/like/:ideaId", controllers.ideas.put.like);

  this.get("#/ideas/close/:ideaId", controllers.ideas.del.close);

  this.post("#/ideas/create", controllers.ideas.post.create);
  this.post("#/ideas/edit/:ideaId", controllers.ideas.put.edit);
  this.put("#/ideas/comment/:ideaId", controllers.ideas.put.comment);
});

(() => {
  app.run("#/home");
})();
