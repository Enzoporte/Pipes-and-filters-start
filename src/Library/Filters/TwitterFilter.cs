using System;
using TwitterUCU;
namespace CompAndDel
{
    public class TwitterFilter : IFilter
    {
        public TwitterFilter(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public IPicture Filter(IPicture image)
        {
            PictureProvider p = new PictureProvider();
            p.SavePicture(image, @$"{Name}.jpg");
            TwitterImage twitterImage = new TwitterImage();
            Console.WriteLine(twitterImage.PublishToTwitter($"- {Name} -",@$"{Name}.jpg"));
            return image;
        }
    }
}