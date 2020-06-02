import extend from "../utils/context.js";
import models from "../models/index.js";
import docModifier from "../utils/doc-modifier.js";

export default {
  get: {
    dashboard(context) {
      models.ideas.getAll().then((response) => {
        const ideas = response.docs.map(docModifier);

        context.ideas = ideas;

        extend(context).then(function () {
          this.partial("../view/ideas/dashboard.hbs");
        });
      });
    },
    create(context) {
      extend(context).then(function () {
        this.partial("../view/ideas/create.hbs");
      });
    },
    details(context) {
      const { ideaId } = context.params;

      models.ideas
        .get(ideaId)
        .then((response) => {
          const ideas = docModifier(response);

          Object.keys(ideas).forEach((key) => {
            context[key] = ideas[key];
          });

          context.canComment =
            ideas.creator === localStorage.getItem("userEmail");

          extend(context).then(function () {
            this.partial("../view/ideas/details.hbs");
          });
        })
        .catch((err) => console.error(err));
    },
    edit(context) {
      extend(context).then(function () {
        context.id = context.params.ideaId;
        this.partial("../view/ideas/edit.hbs");
      });

      const { ideaId } = context.params;

      models.ideas.get(ideaId).then((response) => {
        const data = response.data();
        const form = document.getElementsByClassName("create-idea")[0];

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
        likes: 0,
        comments: [],
      };

      console.log(context);

      if (data.title.length > 6 && data.description.length > 10) {
        models.ideas
          .create(data)
          .then((response) => {
            context.redirect("#/ideas/dashboard");
          })
          .catch((e) => console.error(e));
      }
    },
  },
  del: {
    close(context) {
      const { ideaId } = context.params;

      models.ideas.del(ideaId).then((response) => {
        context.redirect("#/ideas/dashboard");
      });
    },
  },
  put: {
    edit(context) {
      const { ideaId } = context.params;
      const idea = {
        ...context.params,
        uid: localStorage.getItem("userEmail"),
      };

      models.ideas
        .put(ideaId, idea)
        .then((response) => {
          context.redirect("#/ideas/dashboard");
        })
        .catch((error) => console.error(error));
    },
    like(context) {
      const { ideaId } = context.params;

      models.ideas
        .get(ideaId)
        .then((response) => {
          const idea = docModifier(response);
          idea.likes = +idea.likes + 1;

          models.ideas.put(ideaId, idea).then((response) => {
            context.redirect(`#/ideas/details/${ideaId}`);
          });
        })
        .catch((error) => console.error(error));
    },
    comment(context) {
      const { ideaId, newComment } = context.params;

      models.ideas
        .get(ideaId)
        .then((response) => {
          const idea = docModifier(response);

          let comment = `${localStorage.getItem("userEmail")} : ${newComment}`;

          idea.comments.push(comment);
          return models.ideas.put(ideaId, idea);
        })
        .then((response) => {
          context.redirect(`#/ideas/details/${ideaId}`);
        });
    },
  },
};
