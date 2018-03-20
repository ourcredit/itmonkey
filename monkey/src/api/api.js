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
const getJobs = params => GetAsync(params, baseUrl + "services/app/Job/GetPagedJobs")
const GetAuthInfo = params => PostAsync(params, baseUrl + "TokenAuth/WeChatAuthenticate")

const CreateCustomer = params => PostAsync(params, baseUrl + "services/app/Customer/CreateOrUpdateCustomer")


const CreateJob = params => PostAsync(params, baseUrl + "services/app/Job/CreateOrUpdateJob")

const GetPagedExperience = params => PostAsync(params, baseUrl + "app/CustomerExperience/GetPagedCustomerExperiences")
const ModifyExperience = params => PostAsync(params, baseUrl + "app/CustomerExperience/CreateOrUpdateCustomerExperience")

module.exports = {
  getShufflings,
  getJobs,
  GetAuthInfo,
  CreateCustomer,
  CreateJob,
  GetPagedExperience,
  ModifyExperience
}
