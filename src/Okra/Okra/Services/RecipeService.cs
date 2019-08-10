using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Okra.Models;
using Okra.Repositories;

namespace Okra.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ILocalDataBaseRepository localDataBaseRepository;

        public RecipeService(ILocalDataBaseRepository localDataBaseRepository)
        {
            this.localDataBaseRepository = localDataBaseRepository;
        }

        public Task<List<Recipe>> All()
            => Task.Run(() => localDataBaseRepository.GetAll());

        public Task Favorite(Recipe recipe)
        => Task.Run(() => localDataBaseRepository.Add(recipe));

        public Task<List<Recipe>> GetRecipesAsync()
        {
            return Task.Run(async () =>
            {
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://pos-up-avancado.herokuapp.com/recipes/");
                var content = await response.Content.ReadAsStringAsync();
                var recipes = JsonConvert.DeserializeObject<List<Recipe>>(content);
                return recipes;
            });


        }

        public Task RemoveFavorite(Recipe recipe)
        => Task.Run(() => localDataBaseRepository.Delete(recipe));
    }
}
