using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class ReceipeIngredient
    {
        public int UniqId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string UserName { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
