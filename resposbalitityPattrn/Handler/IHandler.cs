using System;
using System.Collections.Generic;

namespace startingTestconsoleApp
{
    public interface IHandler<T> where T : class
    {
        IHandler<T> SetNext(IHandler<T> next);
        object Handle(T request);
    }
}