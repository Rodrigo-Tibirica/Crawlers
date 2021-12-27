using FluentScheduler;
using System;


namespace crawler
{
    public class Configuracao : Registry
    {
        public Configuracao()
        {
            Schedule<Rastreador>()
                .NonReentrant()
                .ToRunOnceAt(DateTime.Now.AddSeconds(3))
                .AndEvery(2).Seconds();
        }

        
    }
}
