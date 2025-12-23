using AcademiaDev.Core.DomainObjects;

namespace AcademiaDev.GestaoAlunos.Domain.Tests
{
    public class AlunoTests
    {
        [Fact(DisplayName = "Novo Aluno com propriedades corretas")]
        [Trait("Categoria", "Gestão de Alunos - Matricula")]
        public void Aluno_Matricula_DeveMatricularComPropriedadesCorretas()
        {
            //Arrange
            var nome = "Renato Carrasco";
            var email = "renato@gmail.com";
            var aluno = new Aluno(nome, email);

            var cursoId = Guid.NewGuid();
            var matricula = new Matricula(cursoId);

            // Act
            aluno.Matricular(matricula);
            // Assert

            Assert.NotNull(aluno.Matriculas);
            Assert.Single(aluno.Matriculas);

            var matriculaAluno = aluno.Matriculas.First();

            Assert.Equal(cursoId, matriculaAluno.CursoId);
            Assert.Equal(MatriculaStatus.AguardandoPagamento, matriculaAluno.MatriculaStatus);


        }

        
    }
}
