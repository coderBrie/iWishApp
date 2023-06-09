using System;
using iWishApp.Models;

namespace iWishApp.ViewModels
{
	public class AddJournalEntry
	{


        //[Required(ErrorMessage = "The text of the affirmation is required.")]

        //public string Text { get; set; }

        //public DateTime DateCreated { get; set; }
        public List<Journals> Journals { get; set; }
        public string Goals { get; set; }
        public string Actions { get; set; }
        public string Reflections { get; set; }


    }
}

