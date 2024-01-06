using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstTodoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Task title")]
        [MaxLength(30)]
        public string Title { get; set; }
    }
}