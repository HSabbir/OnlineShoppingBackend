using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingBackend.Data;
using OnlineShoppingBackend.Dtos.Product;
using OnlineShoppingBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProductService(IMapper mapper, DataContext context )
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct)
        {
            ServiceResponse<List<GetProductDto>> serviceResponse = new ServiceResponse<List<GetProductDto>>();
            Product product = _mapper.Map<Product>(newProduct);

            _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();

            serviceResponse.Data = (_context.Product.Select(c => _mapper.Map<GetProductDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int id)
        {
            ServiceResponse<List<GetProductDto>> serviceResponse = new ServiceResponse<List<GetProductDto>>();

            try
            {
                Product product = await _context.Product.FirstAsync(c => c.Id == id);

                _context.Product.Remove(product);

                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Product.Select(c => _mapper.Map<GetProductDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> GetAllProduct()
        {
            ServiceResponse<List<GetProductDto>> serviceResponse = new ServiceResponse<List<GetProductDto>>();
            List<Product> dBProducts = await _context.Product.ToListAsync();
            serviceResponse.Data = serviceResponse.Data = (dBProducts.Select(c => _mapper.Map<GetProductDto>(c))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDto>> GetProductById(int id)
        {
            ServiceResponse<GetProductDto> serviceResponse = new ServiceResponse<GetProductDto>();
            Product dBcharacter = await _context.Product.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetProductDto>(dBcharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updatedProduct)
        {
            ServiceResponse<GetProductDto> serviceResponse = new ServiceResponse<GetProductDto>();

            try
            {
                Product product = await _context.Product.FirstOrDefaultAsync(c => c.Id == updatedProduct.Id);
                product.ProductName = updatedProduct.ProductName;
                product.Price = updatedProduct.Price;
                product.QuantityAvaiable = updatedProduct.QuantityAvaiable;
                product.Image = updatedProduct.Image;
                

                _context.Product.Update(product);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetProductDto>(product);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
