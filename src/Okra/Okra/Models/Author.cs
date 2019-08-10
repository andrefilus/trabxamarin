namespace Okra.Models
{
    public sealed class Author : BaseModel
    {
        public string Name { get; set; }
        public Picture Avatar { get; set; }

        public static Author Create(string name, Picture avatar)
            => new Author
            {
                Name = name,
                Avatar = avatar
            };
    }
}