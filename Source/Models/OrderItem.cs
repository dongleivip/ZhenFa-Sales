using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Item Name must be provided")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Price must be provided")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Item Count must be provided")]
        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        public string Specification { get; set; }

        [Required(ErrorMessage = "Item must belongs to an Order")]
        public Order Order { get; set; }
    }
}
