import {
    Get,
    GetAsync,
    Post,
    PostAsync
  } from "../utils/wxRequest";
  
  let env = "-test" //-dev 或者 -test
  const baseUrl = "https://monkey.leftins.com/api/"
  /**
   * 获取轮播图列表接口
   * @param  {[type]} params [description]
   * @return {[type]}        [ddescription]
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
  const CreateJob = params => PostAsync(params, baseUrl + "services/app/Job/CreateJobAsync")
  const GetPagedExperience = params => GetAsync(params, baseUrl + "services/app/CustomerExperience/GetPagedCustomerExperiences")
  const ModifyExperience = params => PostAsync(params, baseUrl + "services/app/CustomerExperience/CreateOrUpdateCustomerExperience")
  const GetMyJobs = params => GetAsync(params, baseUrl + "services/app/Job/GetMyJobs")
  const GetMyCreateJobs = params => GetAsync(params, baseUrl + "services/app/Job/GetMyCreateJobs")
  const GetFamilyChildsAsync = params => GetAsync(params, baseUrl + "services/app/Customer/GetFamilyChildsAsync")
  const JoinJob = params => PostAsync(params, baseUrl + "services/app/Job/JoinJob")
  const GetJobCustomers = params => GetAsync(params, baseUrl + "services/app/Job/GetJobCustomersTask")
  const VilidateJober = params => PostAsync(params, baseUrl + "services/app/Job/VilidateJober")
  const GetMessageAsync = params => GetAsync(params, baseUrl + "services/app/Customer/GetMessageAsync")
  
  module.exports = {
    getShufflings,
    getJobs,
    GetAuthInfo,
    CreateCustomer,
    CreateJob,
    GetPagedExperience,
    ModifyExperience,
    GetMyJobs,
    GetMyCreateJobs,
    GetFamilyChildsAsync,
    JoinJob,
    GetJobCustomers,
    VilidateJober,
    GetMessageAsync
  }
  