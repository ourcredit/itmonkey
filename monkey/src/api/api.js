import {
  wxRequest
} from '../utils/wxRequest';

let env = "-test" //-dev 或者 -test
const baseUrl = 'https://monkey.leftins.com/api/services/app/'
/**
 * 获取轮播图列表接口
 * @param  {[type]} params [description]
 * @return {[type]}        [description]
 */
const getShufflings = () => wxRequest({}, baseUrl + "Shuffling/GetPagedShufflings")
/**
 * 获取任务列表
 * @param  {[type]} params [description]
 * @return {[type]}        [description]
 */
const getTasks = params => wxRequest(params, baseUrl + "task/list")

module.exports = {
  getShufflings,
  getTasks
}
