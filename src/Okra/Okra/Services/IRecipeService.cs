using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Okra.Models;

namespace Okra.Services
{
    public interface IRecipeService
    {
        Task Favorite(Recipe recipe);
        Task RemoveFavorite(Recipe recipe);
        Task<List<Recipe>> All();
        Task<List<Recipe>> GetRecipesAsync();
    }
}
