using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Sale
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "user name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "price is required")]
        [Display(Name = "user price")]
        public int price { get; set; }
        [Required(ErrorMessage = "contact_number is required")]
        [Display(Name = "user Age")]
        public string contact_Number { get; set; }
        [Required(ErrorMessage = "size is required")]
        [Display(Name = "user size")]

        public string size { get; set; }
    }
}