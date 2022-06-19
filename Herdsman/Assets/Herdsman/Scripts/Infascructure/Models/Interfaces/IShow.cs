
namespace Infrastructure.Models
{
    public interface IShow<TResult>
    {
        TResult Show();
    }
}
