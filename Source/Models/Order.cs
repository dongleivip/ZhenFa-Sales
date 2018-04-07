using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Order must provides a Customer")]
        [ForeignKey("Id")]
        public Customer Customer { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedTime { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        public string Delivery { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
