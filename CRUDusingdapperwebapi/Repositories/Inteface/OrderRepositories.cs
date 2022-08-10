using CRUDusingdapperwebapi.Model;

namespace CRUDusingdapperwebapi.Repositories.Inteface
{
    public interface IOrderRepositories
    {
        public Task<IEnumerable<Orders>> GetAllOrders();
        // public Task<Orders> GetOrderById(int id);
        public Task<Orders> GetSingleOrde(int id);
        public Task<int> updateNewOrder(Orders order);
        public Task<int> AddNewOrder(Orders orders);
        public Task<int> DelectOrder(int id);



    }
}
