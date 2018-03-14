import {
  wxRequest
} from '../utils/wxRequest';

let env = "-test" //-dev 或者 -test
const baseUrl = 'https://monkey.leftins.com/api/services/app/'

/**
 * 获取发现好商品接口
 * @param  {[type]} params [description]
 * @return {[type]}        [description]
 */
const getDiscoverList = (params) => wxRequest(params, baseUrl + '/goods/list?cateidOne=1&cateidTwo=0&price=0&sales=2');

//微信的jscode换取sessionKey
const wxJsCode2Session = (params) => wxRequest(params, baseUrl + "/api/wechat/jscode2session");
const user2session = (params) => wxRequest(params, baseUrl + "/api/wechat/user2session?jsoncallback=?");

//商品接口---begin
//首页发现商品接口
const hostGoodsList = (params) => wxRequest(params, baseUrl + '/api/home/hostGoodsList');
const getHomeDisvocerList = (params) => wxRequest(params, baseUrl + '/api/mall/discoverList');
//查询商品列表
const getGoodsList = (params) => wxRequest(params, baseUrl + '/api/mall/searchGoodsList');

//查询商品详情信息
const goodsDetail = (params) => wxRequest(params, baseUrl + '/api/mall/goods');
//商品加入购物车
const addCart = (params) => wxRequest(params, baseUrl + '/api/mall/goodsCart/add');
//用户的购物车商品列表
const cartList = (params) => wxRequest(params, baseUrl + '/api/mall/goodsCart/list');
//购物车的商品选中状态
const cartCheck = (params) => wxRequest(params, baseUrl + '/api/mall/goodsCart/check');
//购物车的商品选中状态(全选)
const cartCheckAll = (params) => wxRequest(params, baseUrl + '/api/mall/goodsCart/checkAll');
//购物车的商品删除
const cartDel = (params) => wxRequest(params, baseUrl + '/api/mall/goodsCart/delete');
//购物车的商品数量更新
const cartUpdateNum = (params) => wxRequest(params, baseUrl + '/api/mall/goodsCart/updateNum');
//直接购买商品
const preOrder = (params) => wxRequest(params, baseUrl + '/api/mall/goodsOrder/commitData');

//支付前生成订单
const saveByCart = (params) => wxRequest(params, baseUrl + '/api/mall/goodsOrder/saveByCart');

//支付统一下单
const toPay = (params) => wxRequest(params, baseUrl + '/wepay/toPay');

//商品收藏
const goodsFavorite = (params) => wxRequest(params, baseUrl + '/api/mall/goodsFavorite/add');

//商品收藏删除
const goodsUnFavorite = (params) => wxRequest(params, baseUrl + '/api/mall/goodsFavorite/delete');

//商品是否已收藏
const goodsIsFavorite = (params) => wxRequest(params, baseUrl + '/api/mall/goodsFavorite/goodsIsFavorite');

//商品接口---end

//用户相关信息--begin
//用户的当天签到信息
const userSginInfo = (params) => wxRequest(params, baseUrl + '/api/userSign/signInfo');
const doSign = (params) => wxRequest(params, baseUrl + '/api/userSign/doSign');
//获取最近七天签到情况
const getSignDate = (params) => wxRequest(params, baseUrl + '/api/userSign/getSignDate');

//用户积分信息
const pointInfo = (params) => wxRequest(params, baseUrl + '/api/userPoint/pointInfo');

//用户足迹信息
const browseInfo = (params) => wxRequest(params, baseUrl + '/api/userBrowse/browseInfo');
//添加用户足迹
const addBrowser = (params) => wxRequest(params, baseUrl + '/api/userBrowse/add');
//添加用户足迹
const delUserBrowser = (params) => wxRequest(params, baseUrl + '/api/userBrowse/delete');

//用户收藏的商品
const favoriteInfo = (params) => wxRequest(params, baseUrl + '/api/goodsFavorite/favoriteInfo');

//用户消息
const messageInfo = (params) => wxRequest(params, baseUrl + '/api/systemMessage/messageInfo');

//用户手机绑定
const registerUser = (params) => wxRequest(params, baseUrl + '/api/userCenter/register');
//发送短信
const sendRandCode = (params) => wxRequest(params, baseUrl + '/api/sms/send');

//用户是否绑定手机号
const getUserInfo = (params) => wxRequest(params, baseUrl + '/api/userCenter/getUserInfo');

//用户收货地址
const getUserAddress = (params) => wxRequest(params, baseUrl + '/api/receiverInfo/list');

//保存用户收货地址
const saveAddress = (params) => wxRequest(params, baseUrl + '/api/receiverInfo/saveOrUpdate');

//用户收货地址根据id查询
const receiverInfoById = (params) => wxRequest(params, baseUrl + '/api/receiverInfo/receiverInfoById');

//根据Id删除收货地址
const delUserAddress = (params) => wxRequest(params, baseUrl + '/api/receiverInfo/operation');

//查询关键字保存
const addSearchKeyword = (params) => wxRequest(params, baseUrl + '/api/searchkeyword/add');
//查询关键字列表
const searchKeywordList = (params) => wxRequest(params, baseUrl + '/api/searchkeyword/list');
//查询关键字清除
const clearSearchKeyword = (params) => wxRequest(params, baseUrl + '/api/searchkeyword/clear');

//查询我的订单
const getMyOrderList = (params) => wxRequest(params, baseUrl + '/api/mall/goodsOrder/getMyOrderList');

//查询我的订单数量
const getMyOrderSize = (params) => wxRequest(params, baseUrl + '/api/mall/goodsOrder/getMyOrderSize');

//根据订单号查询详情
const getOrderInfo = (params) => wxRequest(params, baseUrl + '/api/mall/goodsOrder/getOrderDetail');

//根据订单号查询详情
const getPayOrderDetail = (params) => wxRequest(params, baseUrl + '/api/mall/goodsOrder/getPayOrderDetail');

//根据订单号查询详情
const editOrderInfo = (params) => wxRequest(params, baseUrl + '/api/mall/goodsOrder/opt');

//根据订单号查询物流
const orderExpressInfo = (params) => wxRequest(params, baseUrl + '/api/orderExpress/orderExpressInfo');

//查询用户的已订购产品
const goodsUserOrderList = (params) => wxRequest(params, baseUrl + '/api/mall/goodsOrder/goodsUserOrderList');

//退货操作
const refundApply = (params) => wxRequest(params, baseUrl + '/api/mall/refund/saveRefundApply');

//用户相关信息--end

//商品分类--begin
//一级分类
const rootCtegoryList = (params) => wxRequest(params, baseUrl + '/api/mall/rootCtegoryList');
//二级三级分类
const childGoodsCatetoryList = (params) => wxRequest(params, baseUrl + '/api/mall/childGoodsCatetoryList');
//商品分类--end

//查询广告列表
const getAdList = (params) => wxRequest(params, baseUrl + '/api/adverts/list');

module.exports = {
  hostGoodsList,
  getDiscoverList,
  getHomeDisvocerList,
  getGoodsList,
  goodsDetail,
  wxJsCode2Session,
  user2session,
  userSginInfo,
  doSign,
  addCart,
  cartList,
  cartCheck,
  cartCheckAll,
  cartDel,
  cartUpdateNum,
  preOrder,
  refundApply,
  pointInfo,
  browseInfo,
  addBrowser,
  delUserBrowser,
  favoriteInfo,
  messageInfo,
  registerUser,
  sendRandCode,
  getUserInfo,
  getUserAddress,
  saveAddress,
  receiverInfoById,
  getUserAddress,
  addSearchKeyword,
  searchKeywordList,
  clearSearchKeyword,
  getMyOrderList,
  saveByCart,
  toPay,
  rootCtegoryList,
  childGoodsCatetoryList,
  getOrderInfo,
  editOrderInfo,
  goodsUserOrderList,
  orderExpressInfo,
  delUserAddress,
  goodsFavorite,
  goodsUnFavorite,
  goodsIsFavorite,
  getMyOrderSize,
  getPayOrderDetail,
  getAdList,
  getSignDate

}
