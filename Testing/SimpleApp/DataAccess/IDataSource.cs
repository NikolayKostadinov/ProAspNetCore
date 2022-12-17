using SimpleApp.Models;

namespace SimpleApp.DataAccess
{
    public interface IDataSource
    {
        IEnumerable<Product> Products { get; }
    }
}
