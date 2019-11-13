using System;
using System.Collections.Generic;

namespace BlogWebSiteAPI.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            RecipeIngredient = new HashSet<RecipeIngredient>();
        }

        public int UniqId { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public byte[] UserName { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredient { get; set; }
    }
}
