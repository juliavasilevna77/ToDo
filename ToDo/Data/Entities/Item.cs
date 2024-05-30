using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListMVC.Models
{
    public class Item
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please, add title")]
        [StringLength(30)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please, add description")]
        [StringLength(600)]
        public string Description { get; set; }

        [Range(typeof(DateTime), "01.01.1900", "31.12.2999",
            ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime Deadline { get; set; } = DateTime.Now;
        public bool Done { get; set; }
    }
}