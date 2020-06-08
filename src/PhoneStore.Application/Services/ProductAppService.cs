using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using PhoneStore.Application.Cqrs.Commands;
using PhoneStore.Application.Protos;
using PhoneStory.Domain.Entities;
using PhoneStory.Domain.Interfaces.Mediator;
using PhoneStory.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneStore.Application
{
    public class ProductAppService : ProductsBuf.ProductsBufBase
    {
        private readonly ILogger<ProductAppService> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        public ProductAppService(
            ILogger<ProductAppService> logger,
            IProductRepository productRepository,            
            IMapper mapper,
            IMediatorHandler bus
            )
        {
            _logger = logger;
            _productRepository = productRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public override async Task<Empty> AddProduct(ProductBuf request, ServerCallContext context)
        {

            var _product = new CellPhone(request.DisplayName, request.Description, request.Price, 250, PhoneStory.Domain.Shared.Enums.EColor.Black, "", request.Photo);
            _product.SetDimensions(request.Length, request.Width, request.Depth);
            _bus.Enqueue<AddProductCommand>(new AddProductCommand { Product = _product }, AddProductCommand.CommandQueueName);

            return new Empty();
        }

        public override async Task<Empty> UpdateProduct(ProductBuf request, ServerCallContext context)
        {
            var _product = new CellPhone(request.DisplayName, request.Description, request.Price, 250, PhoneStory.Domain.Shared.Enums.EColor.Black, "", request.Photo);
            _bus.Enqueue<UpdateProductCommand>(new UpdateProductCommand { Product = _product }, AddProductCommand.CommandQueueName);

            return new Empty();
        }

        public override async Task<Empty> DeleteProduct(DeleteProductBuf request, ServerCallContext context)
        {
            var _product = (CellPhone)_productRepository.ReadById(Guid.Parse(request.Id));
            _bus.Enqueue<DeleteProductCommand>(new DeleteProductCommand { Product = _product }, DeleteProductCommand.CommandQueueName);

            return new Empty();
        }

        public override async Task<ProductsReply> GetAllProducts(Empty request, ServerCallContext context)
        {
            var _products = _productRepository.ReadAll();
            var _data = _mapper.Map<List<ProductBuf>>(_products);

            var _result = new ProductsReply();
            _result.Products.AddRange(_data);

            return await Task.FromResult(_result);
        }       
    }
}
