using System;
namespace iWishApp.ViewModels
{
	public class AddAffirmationsViewModel
	{

        [Required(ErrorMessage = "The name of the affirmation is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The category of the affirmation is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "The text of the affirmation is required.")]
        public string Text { get; set; }
    }
}

