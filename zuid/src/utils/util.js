function getCurrentTime() {
  var keep = "";
  var date = new Date();
  var y = date.getFullYear();
  var m = date.getMonth() + 1;
  m = m < 10 ? "0" + m : m;
  var d = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
  var h = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
  var f = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
  var s = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
  keep = y + "" + m + "" + d + "" + h + "" + f + "" + s;
  return keep; //  20160614134947
}

function objLength(input) {
  var type = toString(input);
  var length = 0;
  if (type !== "[object Object]") {
    // throw "输入必须为对象{}！"
  } else {
    for (var key in input) {
      if (key !== "number") {
        length++;
      }

    }
  }
  return length;
}
// 验证是否是手机号码
function vailPhone(number) {
  let flag = false;
  let myreg = /^(((13[0-9]{1})|(14[0-9]{1})|(17[0]{1})|(15[0-3]{1})|(15[5-9]{1})|(18[0-9]{1}))+\d{8})$/;
  if (number.length !== 11) {
    flag = false;
  } else if (!myreg.test(number)) {
    flag = false;
  } else {
    flag = true;
  }
  return flag;
}

// 浮点型除法
function div(a, b) {
  var c, d, e = 0,
    f = 0;
  try {
    e = a.toString().split(".")[1].length;
  } catch (g) {}
  try {
    f = b.toString().split(".")[1].length;
  } catch (g) {}
  return c = Number(a.toString().replace(".", "")),
    d = Number(b.toString().replace(".", "")),
    mul(c / d, Math.pow(10, f - e));
}
// 浮点型加法函数
function accAdd(arg1, arg2) {
  var r1, r2, m;
  try {
    r1 = arg1.toString().split(".")[1].length;
  } catch (e) {
    r1 = 0;
  }
  try {
    r2 = arg2.toString().split(".")[1].length;
  } catch (e) {
    r2 = 0;
  }
  m = Math.pow(10, Math.max(r1, r2));
  return ((arg1 * m + arg2 * m) / m).toFixed(2);
}
// 浮点型乘法
function mul(a, b) {
  var c = 0,
    d = a.toString(),
    e = b.toString();
  try {
    c += d.split(".")[1].length;
  } catch (f) {}
  try {
    c += e.split(".")[1].length;
  } catch (f) {}
  return Number(d.replace(".", "")) * Number(e.replace(".", "")) / Math.pow(10, c);
}

//  遍历对象属性和值
function displayProp(obj) {
  var names = "";
  for (var name in obj) {
    names += name + obj[name];
  }
  return names;
}
//  去除字符串所有空格
function sTrim(text) {
  return text.replace(/\s/ig, "")
}
// 去除所有:
function replaceMaohao(txt) {
  return txt.replace(/\\:/ig, "")
}
module.exports = {
  getCurrentTime: getCurrentTime,
  objLength: objLength,
  displayProp: displayProp,
  sTrim: sTrim,
  replaceMaohao: replaceMaohao,
  vailPhone: vailPhone,
  div: div,
  mul: mul,
  accAdd: accAdd
}
