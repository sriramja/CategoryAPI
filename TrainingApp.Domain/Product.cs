using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrainingApp.Domain
{
    public class Product
    {
        [Key]
        public int ProductRowID { get; set; }
        [Required(ErrorMessage = "Product ID is must")]
        public string ProductID { get; set; }
        [Required(ErrorMessage = "Product Name is must")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Manufacturer is must")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "Price is must")]
        public int Price { get; set; }
        [ForeignKey("CategoryRowID")]
        public int CategoryRowID { get; set; }
        public Category Category { get; set; }

    }
}
