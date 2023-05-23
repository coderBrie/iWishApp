using System;
namespace iWishApp.Models
{
    public class Journals
    {


        public int Id { get; set; }
        static private int nextId = 1;

       
        //[Required(ErrorMessage = "affirmation is required.")]
        //public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public string Goals { get; set; }
        public string Actions { get; set; }
        public string Reflections { get; set; }




        public Journals()
        {

        }


        //string goal, string actions, string reflections
        public Journals(string goals, string actions, string reflections) : this()
        {

            //Text = text;
            Goals = goals;
            Actions = actions;
            Reflections = reflections;

        }
    }
}

