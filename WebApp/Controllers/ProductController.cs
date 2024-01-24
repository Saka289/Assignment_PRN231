using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Models.Dto;
using Repository.Repository.IRepository;
using Service.Service.IService;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICustomerService customerService, IMapper mapper)
        {
            _productService = productService;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> Get()
        {
            var result = _productService.GetAllProduct();
            if (result != null)
            {
                return Ok(_mapper.Map<List<ProductDto>>(result));
            }
            return NotFound();
        }

        [HttpGet("GetProduct")]
        public ActionResult<List<ProductDto>> GetProduct()
        {
            var result = _productService.GetProducts();
            if (result != null)
            {
                return Ok(_mapper.Map<List<ProductDto>>(result));
            }
            return NotFound();
        }

        [HttpGet("GetAllCusomter")]
        public ActionResult<List<CustomerDto>> GetAllCusomter()
        {
            var result = _customerService.GetAllCustomer();
            if (result != null)
            {
                return Ok(_mapper.Map<List<CustomerDto>>(result));
            }
            return NotFound();
        }

        [HttpGet("GetCustomer")]
        public ActionResult<List<CustomerDto>> GetCustomer()
        {
            List<Customer> result = _customerService.GetCustomer();
            if (result != null)
            {
                return Ok(_mapper.Map<List<CustomerDto>>(result));
            }
            return NotFound();
        }


        [HttpGet("GetOrder")]
        public ActionResult<List<CustomerDto>> GetOrder()
        {
            var result = _customerService.GetOrder();
            if (result != null && result.Count > 0)
            {
                return Ok(_mapper.Map<List<CustomerDto>>(result));
            }
            return NotFound(null);
        }

        [HttpDelete("DeleteOrder/{id:int}")]
        public IActionResult DeleteOrder(string id)
        {
            var result = _customerService.DeleteOrder(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("UpdateDiscount")]
        public IActionResult UpdateDiscount(string id, [FromBody] int discount)
        {
            var result = _customerService.UpdateDiscount(id, discount);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
