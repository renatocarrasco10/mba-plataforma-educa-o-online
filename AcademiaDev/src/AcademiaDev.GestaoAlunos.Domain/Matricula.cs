using AcademiaDev.Core.DomainObjects;


namespace AcademiaDev.GestaoAlunos.Domain
{
    public class Matricula: Entity
    {
        public Guid CursoId { get; private set; }
        public DateTime DataMatricula { get; private set; }
        public MatriculaStatus MatriculaStatus { get; private set; }

        
        private readonly List<Aula> _historicoAprendizado;
        public IReadOnlyCollection<Aula> HistoricoAprendizado => _historicoAprendizado;

        public Certificado Certificado { get; private set; }

        public Matricula(Guid cursoId)
        {
            CursoId = cursoId;
            DataMatricula = DateTime.Now;
            MatriculaStatus = MatriculaStatus.AguardandoPagamento;
            _historicoAprendizado = new List<Aula>();
        }

        // EF Rel.
        public Aluno Aluno { get; private set; }
    }

}
