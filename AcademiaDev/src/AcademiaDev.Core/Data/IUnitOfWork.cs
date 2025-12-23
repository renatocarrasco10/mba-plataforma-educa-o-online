using System.Threading.Tasks;

namespace AcademiaDev.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
