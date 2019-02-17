using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPatternApp.Domain.Entities
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key, Column(Order = 1)]
        public int OrderID { get; set; }
        [Key, Column(Order = 2)]
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public Order Orders { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}