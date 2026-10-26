using ABP.Demo1.Bases;
using ABP.Demo1.Entities;
using ABP.Demo1.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ABP.Demo1.Products
{
    public class ProductsAppService : BaseAppService, IProductsAppService
    {
        private readonly IRepository<Product, int> repository;

        public ProductsAppService(IRepository<Product, int> repository)
        {
            this.repository = repository;
        }

        public async Task<ProductDto> CreateProductAsync(AddOrEditProductDto input)
        {
            // validation
            var validateResult = new AddOrEditProductValidator().Validate(input);

            if (!validateResult.IsValid)
            {
                var exception = GetValidationException(validateResult);
                throw exception;
            }

            var product = ObjectMapper.Map<AddOrEditProductDto, Product>(input);
            var inserted = await repository.InsertAsync(product, autoSave: true);
            return ObjectMapper.Map<Product, ProductDto>(inserted);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var existingProduct = await repository.GetAsync(id);

            if (existingProduct is null)
                return false;

            await repository.DeleteAsync(existingProduct);
            return true;
        }

        public async Task<PagedResultDto<ProductDto>> GetAllProductsAsync(GetProductListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
                input.Sorting = nameof(Product.Id);

            var products = await repository
                .WithDetailsAsync(p => p.Category)
                .Result
                .AsQueryable()
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(),
                    p => p.NameAr.Contains(input.Filter) ||
                    p.NameEn.Contains(input.Filter))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                // Use 'System.Linq.Dynamic.Core' namespace to remove error from OrderBy(), this allows OrderBy to take string, not lambda exp.
                .OrderBy(input.Sorting)
                // ABP installed with no EF Core package installed, so you need to install 'Microsoft.EntityFrameworkCore' or make custom repository, not relay on built-in one..
                .ToListAsync();

            var totalCount = input.Filter is null
                ? await repository.CountAsync()
                : await repository.CountAsync(p => p.NameAr.Contains(input.Filter) ||
                                            p.NameEn.Contains(input.Filter));

            return new PagedResultDto<ProductDto>
            {
                Items = ObjectMapper.Map<List<Product>, List<ProductDto>>(products),
                TotalCount = totalCount
            };
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var product = await repository
                .WithDetailsAsync(p => p.Category)
                .Result
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                //throw new ArgumentNullException(nameof(product));
                // or using domain exception [defined in domain layer]  -  in fact isn't a real domain exception, due to it is not related to business like balance exceeded exception is a business domain exception
                throw new ProductNotFoundException(id);

            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(AddOrEditProductDto input)
        {
            // validation
            var validateResult = new AddOrEditProductValidator().Validate(input);

            if (!validateResult.IsValid)
            {
                var exception = GetValidationException(validateResult);
                throw exception;
            }

            var existingProduct = await repository.GetAsync(input.Id);

            if (existingProduct is null)
                throw new ProductNotFoundException(input.Id);

            var product = ObjectMapper.Map<AddOrEditProductDto, Product>(input, existingProduct);
            var updated = await repository.UpdateAsync(product, autoSave: true);
            return ObjectMapper.Map<Product, ProductDto>(updated);
        }
    }
}
