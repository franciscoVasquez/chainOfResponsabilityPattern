namespace startingTestconsoleApp
{
    public interface IHandler<T> where T : class
    {
        IHandler<T> SetNext(IHandler<T> next);
        object Handle(T request);
    }
}