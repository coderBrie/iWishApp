using System;
using System.ComponentModel.DataAnnotations;

namespace iWishApp.Models
{
    public class Affirmations
    {
        
        
            public int Id { get; set; }
            static private int nextId = 1;

        //    [Required(ErrorMessage = "The name of the affirmation is required.")]
        //public string Name { get; set; }
        //public string Category { get; set; }
        [Required(ErrorMessage = "affirmation is required.")]
        public string Text { get; set; }
        //public DateTime DateCreated { get; set; }
        //public string Goal { get; set; }
        //public string Actions { get; set; }
        //public string Reflections { get; set; }




        public Affirmations()
            {

            }


        //string goal, string actions, string reflections
            public Affirmations( string text) : this()
        {
            //Name = name;
            //Category = category;
            Text = text;
            //Goal = goal;
            //Actions = actions;
            //Reflections = reflections;

            }
        }

    }

