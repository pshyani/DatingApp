﻿using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeIngredient = new HashSet<RecipeIngredient>();
        }

        public int UniqId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredient { get; set; }
    }
}
