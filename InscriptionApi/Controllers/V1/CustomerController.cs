using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ni_Soft.InscriptionApi.Business.Interfaces;
using Ni_Soft.InscriptionApi.Business.Models;
using Ni_Soft.InscriptionApi.Contracts.Requests;
using Ni_Soft.InscriptionApi.Contracts.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ni_Soft.InscriptionApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;
        private ILogger<CustomerController> _logger;
        public CustomerController(
            ICustomerService service,
            ILogger<CustomerController> logger)
        {
            _service = service;
            _logger = logger;
            _mapper = MappingConfig.Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerResponse>))]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetCustomers(HttpContext.RequestAborted);
            if (result == null)
            {
                return StatusCode(404, "No customers found in the list");
            }
            var customer = result.Select(r => _mapper.Map<CustomerResponse>(r));
            return Ok(customer);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerResponse))]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _service.GetCustomer(id, HttpContext.RequestAborted);
            if (result == null)
            {
                return StatusCode(404, "Customer not found");
            }
            var customer = _mapper.Map<CustomerResponse>(result);
            
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerResponse))]
        public async Task<IActionResult> Post([FromBody] CustomerRequest request)
        {
            var model = _mapper.Map<Customer>(request);
            var result = await _service.AddCustomer(model, HttpContext.RequestAborted);
            if (result == null)
            {
                return StatusCode(500, "Failed to add customer");
            }
            var customer = _mapper.Map<CustomerResponse>(result);
            return Ok(customer);
        }
    }
}
