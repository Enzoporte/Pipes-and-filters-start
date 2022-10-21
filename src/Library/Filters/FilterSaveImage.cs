namespace CompAndDel.Filters
{
    public class FilterSaveImage : IFilter
    {
        public string Name { get; set; }
        public FilterSaveImage(string name)
        {
            this.Name = name;
        }
        public IPicture Filter(IPicture image)
        {
            PictureProvider p = new PictureProvider();
            p.SavePicture(image, @$"{this.Name}.jpg");
            return image;
        }
    }
}