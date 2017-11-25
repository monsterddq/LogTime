class userSignUp{
  constructor(username,email,password,repeatpassword, creation_date,last_update_date){
    this.username = username || "",
    this.email = email || "",
    this.password = password || "",
    this.repeatpassword = repeatpassword || "",
    this.creation_date = (new Date()).toLocaleString(),
    this.last_update_date = (new Date()).toLocaleString()
  }
}
function signup(){
  var data = new userSignUp(
    $("input[name=username]").val(),
    $("input[name=email]").val(),
    $("input[name=password]").val(),
    $("input[name=repeatpassword]").val()
  );
  if(!isValid(data)) return false;
  main.ajaxPromise("/api/user/signup","POST",data)
  .then((a) => {
    let message = a.code === "002" ? "Email or UserName" : "";
    main.handleResult(a.code,message);
  })
}
function isValid(data){
  if(data.username.length<2){
    $.notify({
        title: "Warn:",
        message: "UserName is invalid"
    });
    return false;
  }
  if(!RegEmail.test(data.email)){
    $.notify({
        title: "Warn:",
        message: "Email is invalid"
    });
    return false;
  }
  if(data.password.length<6)  {
    $.notify({
        title: "Warn:",
        message: "Password is invalid"
    });
    return false;
  }
  if(data.password!==data.repeatpassword){
    $.notify({
        title: "Warn:",
        message: "Password does not match"
    });
    return true;
  }
  return true;
}

$(document).ready(function() {
  $("button[type=button]").click(function(event) {
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
