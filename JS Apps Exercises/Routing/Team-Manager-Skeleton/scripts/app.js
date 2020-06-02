import { handler } from "./handlers.js";

// initialize the application
const app = Sammy("#main", function() {
  // Set handlebars as template engine
  this.use("Handlebars", "hbs");

  // define a 'route'
  this.get("#/", handler.homeHandler);
  this.get("#/home", handler.homeHandler);
  this.get("#/about", handler.aboutHandler);
  this.get("#/login", handler.loginHandler);
  this.post("#/login", () => false);
  this.get("#/register", handler.registerHandler);
  this.post("#/register", () => false);
  this.get("#/logout", handler.logoutHandler);
  this.get("#/catalog", handler.catalogHandler);
  this.post("#/catalog", () => false);
  this.get("#/catalog/:id", handler.catalogById);
  this.post("#/catalog", false);
  this.get("#/edit/:id", handler.editTeam);
  this.post("#/edit/:id", () => false);
  this.get("#/join/:id", handler.joinTeam);
  this.get("#/leave/:id", handler.leaveTeam);
  this.get("#/create", handler.createTeamHandler);
  this.post("#/create", () => false);
});
// start the application
app.run("#/");
