using System.Drawing;
using CognitiveCoreUCU;
namespace CompAndDel.Filters
{
    public class FilterCognitivoCondicional : IFilter
    {
        public string Path { get; set; }
        public bool TieneCara { get; set; }
        public FilterCognitivoCondicional(string imagePath)
        {
            this.Path = imagePath;
            this.TieneCara = false;
        }
        public IPicture Filter(IPicture image)
        {
            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(Path);
            if(cog.FaceFound) {TieneCara = true;}
            return image;
        }
    }
}