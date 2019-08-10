namespace Okra.Models
{
    public sealed class Picture : BaseModel
    {
        public string Path { get; set; }

        public static Picture Create(string path)
            => new Picture
            {
                Path = path
            };
    }
}