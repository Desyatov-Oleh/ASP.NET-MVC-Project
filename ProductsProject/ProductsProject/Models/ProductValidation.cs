using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsProject.Models
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
        [Bind(Exclude = "ProductId")]
        public class ProductMetadata
        {
            [ScaffoldColumn(false)]
            public int ProductId { get; set; }

            [DisplayName("Name")]
            [Required(ErrorMessage = "Product name is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [StringLength(50)]
            public string Name { get; set; }

            [DisplayName("Quantity")]
            [Required(ErrorMessage = "Product quantity is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [StringLength(50)]
            public string Quantity { get; set; }

            [DisplayName("Price")]
            [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
            [Required(ErrorMessage = "Product price is required")]
            [Range(0.01, 10000, ErrorMessage = "Product price must be between 0.01 and 10000")]
            public decimal Price { get; set; }


        }
    }
}