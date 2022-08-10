using CRUDusingdapperwebapi.Context;
using CRUDusingdapperwebapi.Model;
using CRUDusingdapperwebapi.Repositories.Inteface;
using Dapper;

namespace CRUDusingdapperwebapi.Repositories
{
    public class OrderRepositories : IOrderRepositories
    {
        private readonly DapperContex _context;
        public OrderRepositories(DapperContex context)
        {
            _context = context;
        }

        public async Task<int> updateNewOrder(Orders order)
        {
            int result = 0;
            var query = @"update tOrder set 
    custName=@custName,mobileNo=@mobileNo,shippingAddress=@shippingAddress,billingAddress=@billingAddress where Id=@id";
            using(var connection=_context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, order);

                return result;
            }
        }

        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            var query = "select * from tOrder";

            using (var connection=_context.CreateConnection())
            {
                var orders = await connection.QueryAsync<Orders>(query);

                return orders.ToList();
            }
            
        }

        public async Task<Orders> GetSingleOrde(int id)
        {
            var query = "select * from tOrder where Id=@id";
            using(var connection=_context.CreateConnection())
            {
                var order = await connection.QueryAsync<Orders>(query, new { id = id });

                return order.FirstOrDefault();
            }
          
        }

        public async Task<int> AddNewOrder(Orders orders)
        {
            int result = 0;
            var query = "insert into tOrder (custName,mobileNo,shippingAddress,billingAddress,totalorderAmmount) values (@custName,@mobileNo,@shippingAddress,@billingAddress,@totalorderAmmount)";
            using(var connection= _context.CreateConnection())
            {
                result = await connection.QuerySingleAsync<int>(query, orders);

                return result;

                    
            }

        }

        public async Task<int> DelectOrder(int id)
        {
            int result = 0;
            var query = "delete from tOrder where Id=@id";
            using(var connection=_context.CreateConnection())
            {
             result = await connection.ExecuteAsync(query, new { id = id });
                return result;
            }

        }
    }
}
