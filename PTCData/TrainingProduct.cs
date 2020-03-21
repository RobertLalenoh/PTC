using System;
using System.ComponentModel.DataAnnotations;

namespace PTCData
{
    public class TrainingProduct
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage="ProductName must be filled in")]
        [StringLength(150, MinimumLength =4, ErrorMessage = "ProductName must be greater than 4 and smaller dan 150")]
        public string ProductName { get; set; }
        public DateTime IntroductionDate { get; set; }
        [Required(ErrorMessage = "Url must be filled in")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Price must be filled in")]
        public decimal Price { get; set; }
    }
    
}

