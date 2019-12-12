using System;
using System.Collections.Generic;

namespace startingTestconsoleApp.Handler
{
    public abstract class AbstractHandler<T>: IHandler<T> where T : class
    {
        public IHandler<T> Next { get; set; }
        public virtual object Handle(T request)
        {
           return this.Next?.Handle(request);
        }

        public IHandler<T> SetNext(IHandler <T> next) 
        {
            Next = next;
            return Next;
        }

    }
}