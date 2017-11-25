class userSignup{
  constructor(username="",email="",password=""){
    this.username = username,
    this.email = email,
    this.password = password
  }
}
function isValid(data){
  if(!data.username && !data.email){
    main.notify("Error:","UserName or Email is not empty.");
    return false;
  }
  if(data.username && data.username.length <2){
    main.notify("Error:","UserName is invalid");
    return false;
  }
  if(data.email && main.RegEmail.test(data.email)){
    main.notify("Error:","Email is invalid");
    return false;
  }
  if(!data.password || data.password < 6){
    main.notify("Error:","Password is invalid.");
    return false;
  }
  return true;
}
function signin(){
  let username = $("input[name=username]").val();
  var data = new userSignup(
    username.includes("@") ? "" : username,
    !username.includes("@") ? "" : username,
    $("input[name=password]").val()
  );
  console.log(data);
  if(!isValid(data)){
    main.endProcess(".sign-box");
    return false;
  }
  main.ajaxPromise("/api/user/signin","POST",data)
  .then((a) => {
    if(a){
      main.endProcess(".sign-box");
      localStorage.setItem('bear',a);
      main.navigate("");
    }else {
      main.notify("Error","Sign in fail.");
    }
  },(a)=>{
    main.endProcess(".sign-box");
    main.notify("Error","Sign in fail.");
  })
}
$(document).ready(function() {
  $("button.signin").click(function(event) {
    main.startProcess(".sign-box");
    signin();
    return false;
  });
  $("input").keypress(function(e) {
    if(e.key==="Enter"){
      main.startProcess(".sign-box");
      signin();
      return false;
    }
  });
});
