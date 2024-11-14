﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }
		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_productService.TProductNameByMaxPrice());
		}
		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNameByMinPrice());
		}
		[HttpGet("ProductPriceByHamburger")]
		public IActionResult ProductPriceByHamburger()
		{
			return Ok(_productService.TProductPriceByHamburger());
		}
		[HttpGet("ProductCountByHamburger")]
		public IActionResult ProductCountByHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}
		[HttpGet("ProductCountByDrink")]
		public IActionResult ProductCountByDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}
		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}
        [HttpGet("ProductPriceBySteakBurger")]
        public IActionResult ProductPriceBySteakBurger()
        {
            return Ok(_productService.TProductPriceBySteakBurger());
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            });
            return Ok(values.ToList());
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(values);
            return Ok("Ürün Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün Silindi");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(values);
            return Ok("Ürün Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(_mapper.Map<GetProductDto>(value));
        }
    }
}
