namespace startingTestconsoleApp.Handler
{
    public abstract class AbstractHandler<T>: IHandler<T> where T : class
    {
        private IHandler<T> Next { get; set; }

          public IHandler<T> SetNext(IHandler <T> next) 
        {
            Next = next;
            return Next;
        }
        public virtual object Handle(T request)
        {
           return this.Next?.Handle(request);
        }
    }
}