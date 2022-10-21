using CompAndDel.Filters;
namespace CompAndDel.Pipes
{
    public class PipeBoolFork : IPipe
    {
        public IPipe PipeFalse {get;set;}
        public IPipe PipeTrue {get;set;}
        public FilterCognitivoCondicional FiltroCondicional {get; set;}

        public PipeBoolFork(FilterCognitivoCondicional filtroCondicional, IPipe pipeFalse, IPipe pipeTrue)
        {
            this.FiltroCondicional = filtroCondicional;
            this.PipeFalse = pipeFalse;
            this.PipeTrue = pipeTrue;
        }

        public IPicture Send(IPicture picture)
        {
            this.FiltroCondicional.Filter(picture);
            if (FiltroCondicional.TieneCara)
            {
                return this.PipeTrue.Send(picture);
            }
            return this.PipeFalse.Send(picture);
        }
    }
}