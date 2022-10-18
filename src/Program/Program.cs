using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            IPipe tercerPipe = new PipeNull();
            IFilter filtroNegativo = new FilterNegative();
            IPipe segundoPipe = new PipeSerial(filtroNegativo, tercerPipe);
            IFilter filtroGreyscale = new FilterGreyscale();
            IPipe primerPipe = new PipeSerial(filtroGreyscale, segundoPipe);

            IPicture image = primerPipe.Send(picture);

            provider.SavePicture(image, @"LukeLocardo.jpg");

        }
    }
}
