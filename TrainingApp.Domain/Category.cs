using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingApp.Domain
{
    public class Category
    {
        [Key]
        public int CategoryRowID { get; set; }
        [Required(ErrorMessage = "Category ID is must")]
        public string CategoryID { get; set; }
        [Required(ErrorMessage = "Category Name is must")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Base Price is must")]
        public int BasePrice { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

