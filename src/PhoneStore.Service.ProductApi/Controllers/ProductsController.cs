using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Infra.BlobStorage;
using PhoneStore.Service.ProductApi.ViewModel;
using Productsbuf;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using static Productsbuf.ProductsBuf;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneStore.Service.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProductsBufClient _productsBufClient;
        private readonly IBlobStorageService _blobStorageService;

        public ProductsController(
            IMapper mapper,
            ProductsBufClient productsBufClient,
            IBlobStorageService blobStorageService
            )
        {
            _mapper = mapper;
            _productsBufClient = productsBufClient;
            _blobStorageService = blobStorageService;
        }
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {

            try
            {
                var response = await _productsBufClient.GetAllProductsAsync(new Empty());

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }           
        }

        // POST api/<ProductsController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateProductViewModel data)
        {
            try
            {
                if(!string.IsNullOrEmpty(data.Photo))
                    data.Photo = await _blobStorageService.Save(data.Photo);

                var _createProduct = _mapper.Map<ProductBuf>(data);
                await _productsBufClient.AddProductAsync(_createProduct);

                return Accepted();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }            
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] UpdateProductViewModel data)
        {

            try
            {
                var _updateProduct = _mapper.Map<ProductBuf>(data);                
                await _productsBufClient.UpdateProductAsync(_updateProduct);

                return Accepted();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id)
        {

            try
            {
                var _deleteProduct = new DeleteProductBuf() { Id = id };
                await _productsBufClient.DeleteProductAsync(_deleteProduct);

                return Accepted();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
