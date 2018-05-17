using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Abp.Extensions;
using ItMonkey.Authorization;
using Microsoft.EntityFrameworkCore;
using ItMonkey.Products.Dtos;
using ItMonkey.Models;

namespace ItMonkey.Products
{
    /// <summary>
    /// Product应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize(PermissionNames.Pages_Shop_Product)]
    public class ProductAppService : ItMonkeyAppServiceBase, IProductAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Product, Guid> _productRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ProductAppService(IRepository<Product, Guid> productRepository
        )
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// 获取Product的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<ProductListDto>> GetPagedProducts(GetProductsInput input)
        {

            var query = _productRepository.GetAll();
            query = query.WhereIf(!input.Name.IsNullOrWhiteSpace(), c => c.ProductName.Contains(input.Name))
                .WhereIf(input.State.HasValue, c => c.IsActive == input.State.Value)
                .WhereIf(input.Start.HasValue, c => c.CreationTime >= input.Start.Value)
                .WhereIf(input.End.HasValue, c => c.CreationTime < input.End.Value);
            var productCount = await query.CountAsync();

            var products = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var productListDtos = ObjectMapper.Map<List <ProductListDto>>(products);
            var productListDtos = products.MapTo<List<ProductListDto>>();
            return new PagedResultDto<ProductListDto>(
                productCount,
                productListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取ProductListDto信息
        /// </summary>
        public async Task<ProductListDto> GetProductByIdAsync(EntityDto<Guid> input)
        {
            var entity = await _productRepository.GetAsync(input.Id);
            return entity.MapTo<ProductListDto>();
        }
        /// <summary>
        /// 导出Product为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetProductsToExcel(){
        //var users = await UserManager.Users.ToListAsync();
        //var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //await FillRoleNames(userListDtos);
        //return _userListExcelExporter.ExportToFile(userListDtos);
        //}
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetProductForEditOutput> GetProductForEdit(NullableIdDto<Guid> input)
        {
            var output = new GetProductForEditOutput();
            ProductEditDto productEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _productRepository.GetAsync(input.Id.Value);

                productEditDto = entity.MapTo<ProductEditDto>();

                //productEditDto = ObjectMapper.Map<List <productEditDto>>(entity);
            }
            else
            {
                productEditDto = new ProductEditDto();
            }

            output.Product = productEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改Product的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateProduct(CreateOrUpdateProductInput input)
        {

            if (input.Product.Id.HasValue)
            {
                await UpdateProductAsync(input.Product);
            }
            else
            {
                await CreateProductAsync(input.Product);
            }
        }

        /// <summary>
        /// 新增Product
        /// </summary>
        [AbpAuthorize(PermissionNames.Pages_Shop_Product_CreateProduct)]
        protected virtual async Task<ProductEditDto> CreateProductAsync(ProductEditDto input)
        {
            var entity = ObjectMapper.Map<Product>(input);
            entity = await _productRepository.InsertAsync(entity);
            return entity.MapTo<ProductEditDto>();
        }

        /// <summary>
        /// 编辑Product
        /// </summary>
        [AbpAuthorize(PermissionNames.Pages_Shop_Product_EditProduct)]
        protected virtual async Task UpdateProductAsync(ProductEditDto input)
        {
            var entity = await _productRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _productRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 修改商品状态
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task ModifyProductState(EntityDto<Guid> input)
        {
            var product = await _productRepository.FirstOrDefaultAsync(input.Id);
            if (product != null)
            {
                product.IsActive = !product.IsActive;
            }
        }
        /// <summary>
        /// 删除Product信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PermissionNames.Pages_Shop_Product_DeleteProduct)]
        public async Task DeleteProduct(EntityDto<Guid> input)
        {
            await _productRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Product的方法
        /// </summary>
        [AbpAuthorize(PermissionNames.Pages_Shop_Product_BatchDeleteProducts)]
        public async Task BatchDeleteProductsAsync(List<Guid> input)
        {
            await _productRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

