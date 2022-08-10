using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDusingdapperwebapi.Model
{
    [Table("tOrder")]
    public class Orders
    {
        [Key]
        public long  Id { get; set; }
        public string custName { get; set; }
        public long mobileNo { get; set; }
        public string shippingAddress { get; set; }
        public string billingAddress { get; set; }
        public long totalorderAmmount { get; set; }
    }
}
