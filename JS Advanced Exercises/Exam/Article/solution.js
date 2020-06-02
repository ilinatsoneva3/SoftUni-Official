class Article {
  constructor(title, creator) {
    this.title = title;
    this.creator = creator;
    this._comments = [];
    this._likes = [];
    this._replies = [];
  }

  get likes() {
    if (this._likes.length === 0) {
      return `${this.title} has 0 likes`;
    } else if (this._likes.length === 1) {
      return `${this._likes.toString()} likes this article!`;
    } else {
      return `${this._likes[0]} and ${this._likes.length -
        1} others like this article!`;
    }
  }

  like(username) {
    let user = this._likes.find(x => x === username);
    if (user) {
      throw new Error(`You can't like the same article twice!`);
    }
    if (username === this.creator) {
      throw new Error(`You can't like your own articles!`);
    }
    this._likes.push(username);
    return `${username} liked ${this.title}!`;
  }

  dislike(username) {
    let user = this._likes.find(x => x === username);
    if (!user) {
      throw new Error(`You can't dislike this article!`);
    }
    let index = this._likes.indexOf(user);
    this._likes.splice(index, 1);
    return `${username} disliked ${this.title}`;
  }

  comment(username, content, id) {
    if (id === undefined || id > this._comments.length) {
      let length = this._comments.length;
      let newId = ++length;
      let comment = {
        Id: newId,
        username,
        content,
        replies: []
      };
      this._comments.push(comment);
      return `${username} commented on ${this.title}`;
    }
    if (id >= 1 && id <= this._comments.length) {
      let comment = this._comments.find(x => x.Id === id);
      let length = comment.replies.length;
      let replyId = `${id}.${++length}`;
      let reply = {
        Id: replyId,
        username,
        content
      };
      comment.replies.push(reply);
      return `You replied successfully`;
    }
  }

  toString(sortingType) {
    let result = `Title: ${this.title}\n`;
    result += `Creator: ${this.creator}\n`;
    result += `Likes: ${this._likes.length}\n`;
    result += `Comments:\n`;

    if (sortingType === "asc") {
      for (const comment of this._comments) {
        result += `-- ${comment.Id}. ${comment.username}: ${comment.content}\n`;
        for (const reply of comment.replies) {
          result += `--- ${reply.Id}. ${reply.username}: ${reply.content}\n`;
        }
      }
    } else if (sortingType === "desc") {
      for (let i = this._comments.length - 1; i >= 0; i--) {
        let comment = this._comments[i];
        result += `-- ${comment.Id}. ${comment.username}: ${comment.content}\n`;
        for (let j = comment.replies.length - 1; j >= 0; j--) {
          let reply = comment.replies[j];
          result += `--- ${reply.Id}. ${reply.username}: ${reply.content}\n`;
        }
      }
    } else {
      let sortedArray = this._comments.sort((x, y) =>
        x.username.localeCompare(y.username)
      );

      for (const comment of sortedArray) {
        result += `-- ${comment.Id}. ${comment.username}: ${comment.content}\n`;
        let sortedReplies = comment.replies.sort((x, y) =>
          x.username.localeCompare(y.username)
        );

        for (const reply of sortedReplies) {
          result += `--- ${reply.Id}. ${reply.username}: ${reply.content}\n`;
        }
      }
    }
    return result.trim();
  }
}

let art = new Article("My Article", "Anny");
art.like("John");
art.like("Ivan");
art.like("Steven");
console.log(art.likes);
