﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItMonkey.Products.Dtos;
using ItMonkey.Models;

namespace ItMonkey.Products
{
    /// <summary>
    /// Product应用层服务的接口方法
    /// </summary>
    public interface IProductAppService : IApplicationService
    {
        /// <summary>
        /// 获取Product的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ProductListDto>> GetPagedProducts(GetProductsInput input);

        /// <summary>
        /// 通过指定id获取ProductListDto信息
        /// </summary>
        Task<ProductListDto> GetProductByIdAsync(EntityDto<Guid> input);

        /// <summary>
        /// 导出Product为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetProductsToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetProductForEditOutput> GetProductForEdit(NullableIdDto<Guid> input);

        /// <summary>
        /// 修改商品状态
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ModifyProductState(EntityDto<Guid> input);
        //todo:缺少Dto的生成GetProductForEditOutput
        /// <summary>
        /// 添加或者修改Product的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateProduct(CreateOrUpdateProductInput input);

        /// <summary>
        /// 删除Product信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteProduct(EntityDto<Guid> input);

        /// <summary>
        /// 批量删除Product
        /// </summary>
        Task BatchDeleteProductsAsync(List<Guid> input);
    }
}
