using AcademiaDev.Core.DomainObjects;

namespace AcademiaDev.GestaoConteudo.Domain
{
    public class Curso : Entity, IAggregateRoot
    {
        public string Nome { get; private set; } = string.Empty;
        public string ConteudoProgramatico { get; private set; } = string.Empty;
        public decimal Valor { get; private set; }

        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }

        private readonly List<Aula> _aulas = new();
        public IReadOnlyCollection<Aula> Aulas => _aulas;

        public Curso(string nome, string conteudoProgramatico, decimal valor)
        {
            Nome = nome;
            ConteudoProgramatico = conteudoProgramatico;
            Valor = valor;
            Ativo = true;
            DataCadastro = DateTime.Now;

            Validar();
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AdicionarAula(Aula aula)
        {
            _aulas.Add(aula);
        }

        public void RemoverAula(Aula aula)
        {
            if (_aulas.Exists(a => a.Id == aula.Id))
            {
                _aulas.RemoveAll(a => a.Id == aula.Id);
            }
        }

        private void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "Nome do curso não pode ser vazio.");
            Validacoes.ValidarSeVazio(ConteudoProgramatico, "Conteúdo programático não pode ser vazio.");
            Validacoes.ValidarSeMenorQue(Valor, 0, "O valor do curso deve ser maior que zero.");
            Validacoes.ValidarSeIgual(Valor, Decimal.Zero, "O valor do curso deve ser maior que zero.");
        }
    }
}
