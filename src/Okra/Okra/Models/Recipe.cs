using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Okra.Models
{
    public sealed class Recipe : BaseModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("steps")]
        public string Steps { get; set; }

        [JsonProperty("picture_path")]
        public string PicturePath { get; set; }

        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        [JsonProperty("author_path")]
        public string AuthorPath { get; set; }

        [JsonIgnore]
        public List<Picture> Pictures { get; set; }

        [JsonIgnore]
        public Author Author { get; set; }

        [JsonIgnore]
        public bool IsFavorite { get; set; }

        public static Recipe Create(string title
            , string steps
            , string picturePath
            , string authorName)
            => new Recipe
            {
                Title = title,
                Steps = steps,
                PicturePath = picturePath,
                AuthorName = authorName
            };
    }
}
