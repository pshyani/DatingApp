using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
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

        public virtual ICollection<RecipeIngredient> RecipeIngredient { get; set; }
    }
}
