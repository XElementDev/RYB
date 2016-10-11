namespace XElement.DesignPatterns.CreationalPatterns.FactoryMethod
{
    public interface IFactory<TOut>
    {
        TOut Get();
    }
}
