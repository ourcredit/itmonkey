 class Chat {
   constructor(guid, props = {}) {
     this.msgArr = [];
     this.props = {
       //  url: "wss://monkey.leftins.com?guid=" + guid,
       url: "wss://monkey.leftins.com/ws",
       header: {
         'content-type': 'application/json'
       },
       //  protocols: ['protocol1'],
       method: "GET"
     }
     Object.assign(this.props, props);
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
