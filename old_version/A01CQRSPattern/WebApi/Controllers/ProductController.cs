using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Common;
using Application.Interfaces;
using Application.Queries;
using Domaine.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiController
    {
        private readonly ICommandHandler<AddNewProductCommand> _addNewProductCommandHandler;
        private readonly ICommandHandler<DeleteProductCommand> _deleteProductCommandHandler;
        private readonly ICommandHandler<UpdateProductCurrentStockCommand> _updateProductCurrentStockCommandHandler;
        private readonly ICommandHandler<UpdateProductUnitPriceCommand> _updateProductUnitPriceCommandHandler;
        private readonly IQueryHandler<FindOutOfStockProductsQuery> _findOutOfStockProductsQueryHandler;
        private readonly IQueryHandler<GetProductsByNameQuery>  _getProductsByNameQueryHandler;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ProductController(ICommandHandler<AddNewProductCommand> addNewProductCommandHandler, ICommandHandler<DeleteProductCommand> deleteProductCommandHandler, ICommandHandler<UpdateProductCurrentStockCommand> updateProductCurrentStockCommandHandler, ICommandHandler<UpdateProductUnitPriceCommand> updateProductUnitPriceCommandHandler, IQueryHandler<FindOutOfStockProductsQuery> findOutOfStockProductsQueryHandler, IQueryHandler<GetProductsByNameQuery> getProductsByNameQueryHandler
            , IHttpContextAccessor httpContextAccessor)
        {
            _addNewProductCommandHandler = addNewProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _updateProductCurrentStockCommandHandler = updateProductCurrentStockCommandHandler;
            _updateProductUnitPriceCommandHandler = updateProductUnitPriceCommandHandler;
            _findOutOfStockProductsQueryHandler = findOutOfStockProductsQueryHandler;
            _getProductsByNameQueryHandler = getProductsByNameQueryHandler;
            _httpContextAccessor = httpContextAccessor;


            _commandDispatcher = new CommandDispatcher(_httpContextAccessor.HttpContext.RequestServices);
            _queryDispatcher = new QueryDispatcher(_httpContextAccessor.HttpContext.RequestServices);
        }


        // GET: api/<ProductController>
        [HttpGet("{name}")]
        public IActionResult GetProductsByName(string name)
        {
            var result = _queryDispatcher.Send(new GetProductsByNameQuery { Name=name});
            List<ProductDisplay> response = new List<ProductDisplay>();
            if (result.Count>0)
                foreach (var r in result)
                {
                    response.Add((ProductDisplay)r);
                }
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetOutOfStockProducts()
        {
            var result = _queryDispatcher.Send(new FindOutOfStockProductsQuery());
            List<ProductInventory> response = new List<ProductInventory>();
            if (result.Count > 0)
                foreach (var r in result)
                {
                    response.Add((ProductInventory)r);
                }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(AddNewProductCommand command)
        {
            _commandDispatcher.Send(command);
            return NoContent();
        }

        [HttpPut("[action]")]
        public IActionResult UpdateProductCurrentStock(UpdateProductCurrentStockCommand command)
        {
            _commandDispatcher.Send(command);
            return NoContent();
        }

        [HttpPut("[action]")]
        public IActionResult UpdateProductUnitPrice(UpdateProductUnitPriceCommand command)
        {
            _commandDispatcher.Send(command);
            return NoContent();
        }


        [HttpDelete]
        public IActionResult Delete(DeleteProductCommand command)
        {
            _commandDispatcher.Send(command);
            return NoContent();
        }



    }
}
