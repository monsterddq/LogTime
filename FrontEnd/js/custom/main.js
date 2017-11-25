const host = "http://localhost:56676";
const RegEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
const RegPhone = /^[0]{1}[1,9]{1}[0-9]{8,9}$/;
var main = {
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
      case "200":
        $.notify({
            title: "Success",
            message: message
        });
        break;
      default:

    }
  },
}
