class userSignUp{
  constructor(username,email,password,repeatpassword, creation_date,last_update_date){
    this.username = username || "",
    this.email = email || "",
    this.password = password || "",
    this.repeatpassword = repeatpassword || "",
    this.creation_date = main.now.toLocaleString(),
    this.last_update_date = main.now.toLocaleString()
  }
}
function isValid(data,type){
  if(data.username.length<2){
    main.notify("Warn","UserName is invalid");
    return false;
  }
  if(!data.email || !RegEmail.test(data.email)){
    main.notify("Warn","Email is invalid");
    return false;
  }
  if(!data.password || data.password.length<6)  {
    main.notify("Warn","Password is invalid");
    return false;
  }
  if(data.password!==data.repeatpassword){
    main.notify("Warn","Password does not match");
    return false;
  }
  return true;
}
function signup(){
  var data = new userSignUp(
    $("input[name=username]").val(),
    $("input[name=email]").val(),
    $("input[name=password]").val(),
    $("input[name=repeatpassword]").val()
  );
  if(!isValid(data)){
    main.endProcess(".signup");
    return false;
  }
  main.ajaxPromise("/api/user/signup","POST",data)
  .then((a) => {
    main.endProcess(".signup");
    let message = a.code === "002" ? "Email or UserName" : "";
    main.handleResult(a.code,message);
    if(a.code==="200") main.navigate("signin");
  })
}
$(document).ready(function() {
  $("button[type=button]").click(function(event) {
    main.startProcess(".signup");
    signup();
    return false;
  });
  $("input").keypress(function(e) {
    if(e.key=="Enter"){
      signup();
      return false;
    }
  });
});
