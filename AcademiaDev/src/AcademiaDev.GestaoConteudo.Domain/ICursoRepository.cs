using AcademiaDev.Core.Data;

namespace AcademiaDev.GestaoConteudo.Domain
{
    public interface ICursoRepository: IRepository<Curso>
    {
        Task<IEnumerable<Curso>> ObterTodos();
        Task<Curso> ObterPorId(Guid id);
        Task<IEnumerable<Aula>> ObterAulasPorCurso(int codigo);
        
        void Adicionar(Curso produto);
        void Atualizar(Curso produto);

    }
}
