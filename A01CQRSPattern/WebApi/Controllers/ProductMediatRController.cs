using CommandsMediatR = Application.CommandsMediatR;
using QueriesMediatR = Application.QueriesMediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Common;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMediatRController : ApiController
    {

        private readonly IMediator _mediator;

        public ProductMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<ProductController>
        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductsByName(string name)
        {
            var response = await _mediator.Send(new QueriesMediatR.GetProductsByNameQuery { Name = name });
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetOutOfStockProducts()
        {
            var response = await _mediator.Send(new QueriesMediatR.FindOutOfStockProductsQuery());
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CommandsMediatR.AddNewProductCommand command)
        {
            var response = await _mediator.Send(command);
            return NoContent();
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProductCurrentStockAsync(CommandsMediatR.UpdateProductCurrentStockCommand command)
        {
            var response = await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProductUnitPriceAsync(CommandsMediatR.UpdateProductUnitPriceCommand command)
        {
            var response = await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(CommandsMediatR.DeleteProductCommand command)
        {
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
