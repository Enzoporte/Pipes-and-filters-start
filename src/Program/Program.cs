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

            string picturePath1 = @"luke.jpg";
            IPicture picture1 = provider.GetPicture(picturePath1);

            string picturePath2 = @"beer.jpg";
            IPicture picture2 = provider.GetPicture(picturePath2);

            FilterCognitivoCondicional filtroCondicional = new FilterCognitivoCondicional(picturePath1);
            IFilter filtroNegativo = new FilterNegative();
            IFilter filtroGreyscale = new FilterGreyscale();
            IFilter twitterFilter = new TwitterFilter("SubidaATwitter");
            IFilter filtroBlur = new FilterBlurConvolution();
            IFilter saveFilter = new FilterSaveImage("holaaaaaaaa");


            IPipe ultimoPipe = new PipeNull();
            IPipe quintoPipe = new PipeSerial(filtroNegativo, ultimoPipe);
            IPipe cuartoPipe = new PipeSerial(twitterFilter, ultimoPipe);
            IPipe pipeCondicional = new PipeBoolFork(filtroCondicional, quintoPipe, cuartoPipe);
            IPipe tercerPipe = new PipeSerial(filtroBlur, pipeCondicional);
            IPipe segundoPipe = new PipeSerial(saveFilter, tercerPipe);
            IPipe primerPipe = new PipeSerial(filtroGreyscale, segundoPipe);

            IPicture image1 = primerPipe.Send(picture1);
            provider.SavePicture(image1, @"LukeLocardo.jpg");

            //IPicture image2 = primerPipe.Send(picture2);
            //provider.SavePicture(image2, @"Cervezoide.jpg");


        }
    }
}
