const host = "http://localhost:56676";
const RegEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
const RegPhone = /^[0]{1}[1,9]{1}[0-9]{8,9}$/;
const link = {
  "": "/",
  "signin" : "/sign-in.html",
  "signup": "/signup.html"
}
var main = {
  now: new Date(),
  navigate: function(location = "") {
    setTimeout(()=>{window.location.href = link[location];},1000);
  },
  ajaxPromise: function(url,method,data){
    return new Promise((resolve, reject)=>{
      $.ajax({
        xhrFields: {
          withCredentials: true
        },
        header: {
          'Authorization': `Bearer ${localStorage.getItem('bear')}`
        },
        url: `${host}${url}`,
        type: method || "GET",
        dataType: 'json',
        data: data || ""
      })
      .done(function(result,status,xhr) {
        resolve(result,status,xhr);
      })
      .fail(function(xhr,status,error) {
        console.log('xhr',xhr);
        console.log('status',status);
        console.log('error',error);
        main.notify("Error","Proccess fail.");
        reject(xhr,status,error);
      });
    })
  },
  handleResult: function(code, message = ""){
    switch (code) {
      case "404":
        $.notify({
            title: "Warn:",
            message: "Not found this link."
        });
        break;
      case "401":
        $.notify({
            title: "Unauthenticate",
            message: "Can not access this link or get data."
        });
        break;
      case "001":
        $.notify({
            title: "Data is invalid",
            message: message
        });
        break;
      case "002":
        $.notify({
            title: "Duplicate data",
            message: message
        });
        break;
      case "003":
        main.notify("Warn","UserName or Email is not find.");
        break;
      case "004":
        main.notify("Warn","Password is not match.");
        break;
      case "200":
        $.notify({
            title: "Success",
            message: message
        });
        break;
      default:
    }
  },
  startProcess: function(selector){
    $(selector).block({
      message: '<div class="blockui-default-message"><i class="fa fa-circle-o-notch fa-spin"></i><h6>We are processing your request. <br> Please be patient.</h6></div>',
      overlayCSS:  {
        background: 'rgba(142, 159, 167, 0.8)',
        opacity: 1,
        cursor: 'wait'
      },
      css: {
        width: '50%'
      },
      blockMsgClass: 'block-msg-default'
    });
  },
  endProcess: function(selector){
    $(selector).unblock();
  },
  notify: function(title,message){
    $.notify({
        title: title,
        message: message
    });
  },
}
