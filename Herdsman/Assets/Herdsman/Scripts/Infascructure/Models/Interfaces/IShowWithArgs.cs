
namespace Infrastructure.Models
{
    public interface IShowWithArgs<TResult, TArgs>
    {
        TResult Show(TArgs args);
    }
}
