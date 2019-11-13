using System;
using System.Collections.Generic;

namespace BlogWebSiteAPI.Models
{
    public partial class RecipeIngredient
    {
        public int UniqId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string UserName { get; set; }

        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
    }
}
