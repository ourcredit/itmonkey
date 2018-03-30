import wepy from 'wepy';
import util from './util';
import tip from './tip'
const Get = async (params = {}, url) => {
  tip.loading();
  let data = params || {};
  let res = await wepy.request({
    url: url,
    method: 'GET',
    data: data,
    header: {
      'Content-Type': 'application/json'
    },
  });
  tip.loaded();
  if (!res.data.success) {
    tip.alert(res.data.error.message);
  }
  return res.data.result;
};
const Post = async (params = {}, url) => {
  let data = params || {};
  tip.loading();
  let res = await wepy.request({
    url: url,
    method: 'POST',
    data: data,
    header: {
      'Content-Type': 'application/json'
    },
  });
  tip.loaded();
  if (!res.data.success) {
    tip.alert(res.data.error.message);
  }
  return res.data.result;
};
const GetAsync = async (params = {}, url) => {
  let data = params || {};
  let res = await wepy.request({
    url: url,
    method: 'GET',
    data: data,
    header: {
      'Content-Type': 'application/json'
    },
  });
  if (!res.data.success) {
    tip.alert(res.data.error.message);
  }
  return res.data;
};
const PostAsync = async (params = {}, url) => {
  let data = params || {};
  let res = await wepy.request({
    url: url,
    method: 'POST',
    data: data,
    header: {
      'Content-Type': 'application/json'
    },
  });
  if (!res.data.success) {
    tip.alert(res.data.error.message);
  }
  return res.data;
};

module.exports = {
  Get,
  GetAsync,
  Post,
  PostAsync
}
