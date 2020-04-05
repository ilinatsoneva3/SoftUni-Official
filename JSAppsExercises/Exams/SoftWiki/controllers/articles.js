import extend from "../utils/context.js";
import models from "../models/index.js";
import docModifier from "../utils/doc-modifier.js";
import sorter from "../utils/sorter.js";

export default {
  get: {
    dashboard(context) {
      models.articles.getAll().then((response) => {
        const articles = response.docs.map(docModifier);
        const JSArticles = sorter(articles, "JavaScript");
        const cSharpArticles = sorter(articles, "C#");
        const pythonArticles = sorter(articles, "Python");
        const javaArticles = sorter(articles, "Java");

        context.JSArticles = JSArticles;
        context.cSharpArticles = cSharpArticles;
        context.pythonArticles = pythonArticles;
        context.javaArticles = javaArticles;

        extend(context).then(function () {
          this.partial("../view/articles/dashboard.hbs");
        });
      });
    },
    create(context) {
      extend(context).then(function () {
        this.partial("../view/articles/create.hbs");
      });
    },
    details(context) {
      const { articleId } = context.params;

      models.articles
        .get(articleId)
        .then((response) => {
          const articles = docModifier(response);

          Object.keys(articles).forEach((key) => {
            context[key] = articles[key];
          });

          context.canEdit =
            articles.creator === localStorage.getItem("userEmail");

          extend(context).then(function () {
            this.partial("../view/articles/details.hbs");
          });
        })
        .catch((err) => console.error(err));
    },
    edit(context) {
      extend(context).then(function () {
        context.id = context.params.articleId;
        this.partial("../view/articles/edit.hbs");
      });

      const { articleId } = context.params;

      models.articles.get(articleId).then((response) => {
        const data = response.data();
        const form = document.getElementsByTagName("form")[0];

        Object.entries(data).map(([inputName, value]) => {
          if (!form.elements.namedItem(inputName)) {
            return;
          }

          form.elements.namedItem(inputName).value = value;
        });
      });
    },
  },
  post: {
    create(context) {
      const data = {
        ...context.params,
        creator: localStorage.getItem("userEmail"),
        uid: localStorage.getItem("userId"),
      };

      models.articles
        .create(data)
        .then((response) => {
          context.redirect("#/articles/dashboard");
        })
        .catch((e) => console.error(e));
    },
  },
  del: {
    close(context) {
      const { articleId } = context.params;

      models.articles.del(articleId).then((response) => {
        context.redirect("#/articles/dashboard");
      });
    },
  },
  put: {
    edit(context) {
      const { articleId } = context.params;
      const article = {
        ...context.params,
        uid: localStorage.getItem("userEmail"),
      };

      models.articles
        .put(articleId, article)
        .then((response) => {
          context.redirect("#/articles/dashboard");
        })
        .catch((error) => console.error(error));
    },
  },
};
