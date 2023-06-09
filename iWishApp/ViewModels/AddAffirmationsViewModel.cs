using System;
using System.ComponentModel.DataAnnotations;

namespace iWishApp.ViewModels
{
    public class AddAffirmationsViewModel
    {


        [Required(ErrorMessage = "The text of the affirmation is required.")]

        public string Text { get; set; }

        //public DateTime DateCreated { get; set; }
        //public string Goal { get; set; }
        //public string Actions { get; set; }
        //public string Reflections { get; set; }

    }
}



