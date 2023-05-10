using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using iWishApp.Controllers;
using iWishApp.Models;
using iWishApp.Data;
namespace iWishApp.ViewModels
{
    public class BlogEntryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }

        public string Category { get; set; }

        public List<string> Tags { get; set; }


    }
}

