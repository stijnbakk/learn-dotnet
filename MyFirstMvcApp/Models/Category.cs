using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMvcApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Category name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("Display order")]
        [Range(1,100, ErrorMessage = "Your order can't be lower than 1, or higher than 100")]
        public int DisplayOrder { get; set; }
    }
}