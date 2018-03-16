import {
  Get,
  GetAsync,
  Post,
  PostAsync
} from '../utils/wxRequest';

let env = "-test" //-dev 或者 -test
const baseUrl = 'https://monkey.leftins.com/api/'
/**
 * 获取轮播图列表接口
 * @param  {[type]} params [description]
 * @return {[type]}        [description]
 */
const getShufflings = () => GetAsync({}, baseUrl + "services/app/Shuffling/GetPagedShufflings")
/**
 * 获取任务列表
 * @param  {[type]} params [description]
 * @return {[type]}        [description]
 */
const getTasks = params => PostAsync(params, baseUrl + "task/list")
const GetAuthInfo = params => PostAsync(params, baseUrl + "TokenAuth/WeChatAuthenticate")

module.exports = {
  getShufflings,
  getTasks,
  GetAuthInfo
}
