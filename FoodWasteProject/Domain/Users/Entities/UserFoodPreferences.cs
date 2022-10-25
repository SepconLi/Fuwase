/* User's module - Imborrables
 * Collaboratos:
 * - Fabian Gonzales
 * - Maeva Murcia
 * 
 * - Summary: Implementation of UserFoodPreferences  class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Users.Entities
{
    public class UserFoodPreferences
    {
        //UserFoodPreferences attributes
        public string UserEmail { get; set; }
        public string FoodRestriction { get; set; }


        //UserFoodPreferences Parameterized Constructor
        public UserFoodPreferences(string userEmail, string restriction)
        {
            UserEmail = userEmail;
            FoodRestriction = restriction;
        }
        //UserFoodPreferences Default Constructor
        public UserFoodPreferences()
        {
            UserEmail = "";
            FoodRestriction = "";

        }
    }
}