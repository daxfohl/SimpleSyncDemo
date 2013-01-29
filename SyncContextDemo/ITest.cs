namespace SyncContextDemo
{
    public interface ITest<out T>
    {
        T Run();
    }
}