public interface IHandler<T> where T : Command
{
    Task<ResultComand> HandlerAsync(T command);
}