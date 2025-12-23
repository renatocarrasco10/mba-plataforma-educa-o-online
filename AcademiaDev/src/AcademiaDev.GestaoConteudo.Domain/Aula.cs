using AcademiaDev.Core.DomainObjects;

namespace AcademiaDev.GestaoConteudo.Domain
{
    public class Aula: Entity
    {
        public string Titulo { get; private set; } = string.Empty;
        public string Conteudo { get; private set; } = string.Empty;
        public TimeSpan Duracao { get; private set; } 
        public string Material { get; private set; } = string.Empty;

        // EF Rel.
        public Curso? Curso { get; set; }

        public Aula(string titulo, string conteudo, TimeSpan duracao, string material)
        {
            Titulo = titulo;
            Conteudo = conteudo;
            Duracao = duracao;
            Material = material;

            Validar();
        }

        private void Validar()
        {
            Validacoes.ValidarSeVazio(Titulo, "Título da aula não pode ser vazio.");
            Validacoes.ValidarSeVazio(Conteudo, "Conteúdo da aula não pode ser vazio.");
            Validacoes.ValidarSeMenorQue(Convert.ToDecimal(Duracao.TotalSeconds), decimal.Zero, "A duração da aula deve ser maior que zero.");
            Validacoes.ValidarSeIgual(Convert.ToDecimal(Duracao.TotalSeconds), decimal.Zero, "A duração da aula deve ser maior que zero.");
        }
    }
}
