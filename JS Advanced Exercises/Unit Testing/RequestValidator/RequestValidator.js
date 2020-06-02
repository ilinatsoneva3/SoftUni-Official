function validator(obj = {}) {
    let methods = ["GET", "POST", "DELETE", "CONNECT"];
    let uriValidation = /^[\w.]+$/;
    let httpVersion = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];
    let messageValidation = /^[^<>\\&'"]*$/;

    if (!(obj.method && methods.includes(obj.method))) {
        throw new Error("Invalid request header: Invalid Method");
    } else if (!(obj.uri && (uriValidation.test(obj.uri) || obj.uri==="*"))){
        throw new Error("Invalid request header: Invalid URI");
    } else if(!(obj.version && httpVersion.includes(obj.version))){
        throw new Error("Invalid request header: Invalid Version");
    } else if(!(obj.hasOwnProperty("message") && (messageValidation.test(obj.message) || obj.message ==''))){
        throw new Error("Invalid request header: Invalid Message");
    }

    return obj;
};