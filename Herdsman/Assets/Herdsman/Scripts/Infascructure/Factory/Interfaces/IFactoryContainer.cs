
namespace Infrastructure.Factory
{
    public interface IFactoryContainer
    {
        IFactory Register<TFactory>(IFactory factory) where TFactory : IFactory;

        TFactory Get<TFactory>() where TFactory : IFactory;
    }
}
