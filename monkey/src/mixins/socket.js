 class Chat {


   constructor(guid, props = {}) {
     this.msgArr = [];
     this.props = {
       url: "wss://monkey.leftins.com?guid=" + guid,
       header: {
         'content-type': 'application/json'
       },
     }
     Object.assign(this.props, props);
   }
   test() {
     var _self = this;
     wx.connectSocket(_self.props, function (r) {
       console.log(r)
     }, function (e) {
       console.log(e)
     });
   }

   connect() {
     var _self = this;
     return new Promise(function (resolve, reject) {
       wx.connectSocket(_self.props, function (r) {
         resolve(r)
       }, function (e) {
         reject(e)
       });
     })
   }
   open() {
     return new Promise(function (resolve, reject) {
       wx.onSocketOpen(function (r) {
         resolve(r)
       }, function (e) {
         reject(e)
       });
     })
   }
   send(message) {
     return new Promise(function (resolve, reject) {
       wx.sendSocketMessage(message, function (r) {
         resolve(r)
       }, function (e) {
         reject(e)
       });
     })
   }
   receive() {
     return new Promise(function (resolve, reject) {
       wx.onSocketMessage(function (r) {
         resolve(r)
       }, function (e) {
         reject(e)
       });
     })
   }
 }


 export default Chat
