using AcademiaDev.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDev.GestaoAlunos.Domain
{
    public class Aluno: Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }

        private readonly List<Matricula> _matriculas;
        public IReadOnlyCollection<Matricula> Matriculas => _matriculas;


        public Aluno(string nome, string email)
        {
            Nome = nome;
            Email = email;
            _matriculas = new List<Matricula>();
        }

        public void Matricular(Matricula matricula)
        {
            _matriculas.Add(matricula);
        }
    }
}
