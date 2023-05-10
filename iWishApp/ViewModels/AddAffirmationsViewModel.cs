using System;
using System.ComponentModel.DataAnnotations;

namespace iWishApp.ViewModels
{
    public class AddAffirmationsViewModel
    {

        //[Required(ErrorMessage = "The name of the affirmation is required.")]
        //public string Name { get; set; }

        //[Required(ErrorMessage = "The category of the affirmation is required.")]
        //public string Category { get; set; }

        [Required(ErrorMessage = "The text of the affirmation is required.")]

        public string Text { get; set; }
    }
}

    //    public int Id { get; set; }

    //    [Required]
    //    public string Title { get; set; }

    //    [Required]
    //    public string Content { get; set; }

    //    [Display(Name = "Date")]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime DatePosted { get; set; }

    //    public string Category { get; set; }

    //    public List<string> Tags { get; set; }
    


//    public class BlogEntryViewModel
//    {

//    public int Id { get; set; }

//    [Required]
//    public string Title { get; set; }

//    [Required]
//    public string Content { get; set; }

//    [Display(Name = "Date")]
//    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
//    public DateTime DatePosted { get; set; }

//    public string Category { get; set; }

//    public List<string> Tags { get; set; }
//}

//}

