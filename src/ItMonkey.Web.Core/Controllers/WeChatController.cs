using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using ItMonkey.Models;
using ItMonkey.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItMonkey.Controllers
{
    /// <summary>
    /// 微信支付
    /// </summary>
    public class WeChatController:ItMonkeyControllerBase
    {
        private readonly IRepository<Order,long> _orderRepository;

        public WeChatController(IRepository<Order, long> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// 通知
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Notify()
        {
            var memoryStream = new MemoryStream();
            Request.Body.CopyTo(memoryStream);
            WxPayData notifyData =await GetNotifyData(memoryStream);

            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData t = new WxPayData();
                t.SetValue("return_code", "FAIL");
                t.SetValue("return_msg", "支付结果中微信订单号不存在");
              await  Response.WriteAsync(t.ToXml());
            }
            var code = notifyData.GetValue("return_code").ToString();
            var rcode = notifyData.GetValue("result_code").ToString();
            if (code.ToUpper().Equals("SUCCESS") && rcode.ToUpper().Equals("SUCCESS"))
            {
                var num = notifyData.GetValue("out_trade_no").ToString();
                var order = await _orderRepository.FirstOrDefaultAsync(c => c.OrderNum.Equals(num));
                if (order != null)
                {
                    if (!order.PayState)
                    {
                        order.WeChatOrder = notifyData.GetValue("transaction_id").ToString();
                        order.PayState = true;
                        await _orderRepository.UpdateAsync(order);
                    }
                    WxPayData res = new WxPayData();
                    res.SetValue("return_code", "SUCCESS");
                    res.SetValue("return_msg", "OK");
                    Response.Clear();
                    await Response.WriteAsync(res.ToXml());
                }
            }
           
            else
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "第三方订单不存在");
                Response.Clear();
               await Response.WriteAsync(res.ToXml());
            }
            return Ok();
        }
        /// <summary>
        /// 接收从微信支付后台发送过来的数据并验证签名
        /// </summary>
        /// <returns>微信支付后台返回的数据</returns>
        private async Task<WxPayData>  GetNotifyData(Stream stram)
        {
            //接收从微信后台POST过来的数据
            System.IO.Stream s = stram;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();
            //转换数据格式并验证签名
            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(builder.ToString());
            }
            catch (Exception ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
              await Response.WriteAsync(res.ToXml());
            }
            return data;
        }

        /// <summary>
        /// 在线预支付
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> LinePay(InsertOrderInput input)
        {
           var order = new Order
            {
                OpenId = input.OpenId,
                OrderType = "购买",
                OrderNum = Guid.NewGuid().ToString("N"),
                PayState = false,
                Price = input.Price
            };
          
            JsApiPay jsApiPay = new JsApiPay
            {
                Openid = input.OpenId,
                TotalFee = input.Price
            };
            await _orderRepository.InsertOrUpdateAsync(order);
            jsApiPay.GetUnifiedOrderResult(order.OrderNum, "猿人币购买", "猿人币购买");
            var param = jsApiPay.GetJsApiParameters();
            return param;
        }
    }
}
