namespace Library.App.DI
{
    public interface IFactory<T>
    {
        T Create();
    }
}
