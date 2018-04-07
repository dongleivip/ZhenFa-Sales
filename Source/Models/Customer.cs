using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Customer 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Customer Name must be provided")]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        public string Company { get; set; }

        public string Telephone { get; set; }
    }
}
