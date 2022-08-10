using CRUDusingdapperwebapi.Model;
using CRUDusingdapperwebapi.Repositories.Inteface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingdapperwebapi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepositories _orderRepo;
        public OrdersController(IOrderRepositories orderRepo)
        {
            _orderRepo = orderRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetOreders()
        {
            var orders = await _orderRepo.GetAllOrders();

            return Ok(orders);
        }
        [HttpGet("{id}")]
       public async Task<IActionResult> GetSingleOrder(int id)
       {
            var orders = await _orderRepo.GetSingleOrde(id);

            return Ok(orders);
       }
        [HttpPut]
        public async Task<IActionResult> AddOrders(Orders orders)
        {
            var result = await _orderRepo.updateNewOrder(orders);
            if(result ==1)
            {
                return StatusCode(200, string.Format("Record Inserted Successfuly with compnay Id {0}", result));
            }
            else
                return StatusCode(409, "The request could not be processed because of conflict in the request");
        }
        [HttpPost]
        public async Task<IActionResult> AddNewOrder(Orders orders)
        {
            var result = await _orderRepo.AddNewOrder(orders);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderRepo.DelectOrder(id);
            if(result==1)
            {
               return StatusCode(200, string.Format("Order deleted Ok"));
            }
            else
            {
                return StatusCode(409, "The request could not be processed because of conflict in the request");
            }
        }
    }
}
