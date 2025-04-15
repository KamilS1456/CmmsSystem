using System;
using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Domain.Entities
{
    public class Order : EntityBase
    {
        public string Name { get; set; }
        public int Nr { get; set; }
        public string Description { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime RequestyDate { get; set; }
        public OrderState OrderState { get; set; }
        public string PaymentDescription { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
