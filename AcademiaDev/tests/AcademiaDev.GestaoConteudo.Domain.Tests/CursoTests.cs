using AcademiaDev.Core.DomainObjects;

namespace AcademiaDev.GestaoConteudo.Domain.Tests
{
    public class CursoTests
    {
        [Fact(DisplayName = "Novo Curso com propriedades corretas")]
        [Trait("Categoria", "Gestão de Conteudo - Curso")]
        public void Curso_Criar_DeveCriarCursoComPropriedadesCorretas()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = 100;
            // Act
            var curso = new Curso(nome, conteudoProgramatico, valor);
            // Assert
            Assert.Equal(nome, curso.Nome);
            Assert.Equal(conteudoProgramatico, curso.ConteudoProgramatico);
            Assert.NotEqual(Guid.Empty, curso.Id);
        }

        [Fact(DisplayName = "Novo Curso com Nome em branco")]
        [Trait("Categoria", "Gestão de Conteudo - Curso")]
        public void Curso_Criar_DeveLancarExcecaoParaNomeVazio()
        {
            // Arrange
            var nome = string.Empty;
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = 100;
            // Act & Assert
            var ex = Assert.Throws<DomainException>(() =>
                                new Curso(nome, conteudoProgramatico, valor));

            Assert.StartsWith("Nome do curso não pode ser vazio.", ex.Message);
        }

        [Fact(DisplayName = "Novo Curso com Conteúdo Programatico em branco")]
        [Trait("Categoria", "Gestão de Conteudo - Curso")]
        public void Curso_Criar_DeveLancarExcecaoParaConteudoProgramaticoVazio()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = string.Empty;
            var valor = 100;
            // Act & Assert
            var ex = Assert.Throws<DomainException>(() =>
                                new Curso(nome, conteudoProgramatico, valor));

            Assert.StartsWith("Conteúdo programático não pode ser vazio.", ex.Message);
        }

        [Fact(DisplayName = "Novo Curso com valor zerado")]
        [Trait("Categoria", "Gestão de Conteudo - Curso")]
        public void Curso_Criar_DeveLancarExcecaoParaValorZero()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = 0;
            // Act & Assert
            var ex = Assert.Throws<DomainException>(() =>
                                new Curso(nome, conteudoProgramatico, valor));
            Assert.StartsWith("O valor do curso deve ser maior que zero.", ex.Message);
        }

        [Fact(DisplayName = "Novo Curso com valor negativo")]
        [Trait("Categoria", "Gestão de Conteudo - Curso")]
        public void Curso_Criar_DeveLancarExcecaoParaValorNegativo()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = -5;
            // Act & Assert
            var ex = Assert.Throws<DomainException>(() =>
                                new Curso(nome, conteudoProgramatico, valor));
            Assert.StartsWith("O valor do curso deve ser maior que zero.", ex.Message);
        }

        [Fact(DisplayName = "Novo Curso Status Ativo")]
        [Trait("Categoria", "Gestão de Conteudo - Curso")]
        public void Curso_Criar_DeveDefinirAtivoComoTrue()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = 100;
            // Act
            var curso = new Curso(nome, conteudoProgramatico, valor);
            // Assert
            Assert.True(curso.Ativo);
        }

        [Fact(DisplayName = "Curso Ativar")]
        [Trait("Categoria", "Gestão de Conteudo - Curso")]
        public void Curso_Ativar_DeveDefinirAtivoComoTrue()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = 100;
            var curso = new Curso(nome, conteudoProgramatico, valor);
            curso.Desativar();
            // Act
            curso.Ativar();
            // Assert
            Assert.True(curso.Ativo);
        }


        [Fact(DisplayName = "Curso Desativar")]
        [Trait("Categoria", "Gestão de Conteudo - Curso")]
        public void Curso_Ativar_DeveDefinirInativoComoFalse()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = 100;
            var curso = new Curso(nome, conteudoProgramatico, valor);
            curso.Ativar();
            // Act
            curso.Desativar();
            // Assert
            Assert.False(curso.Ativo);
        }


        [Fact(DisplayName = "Adicionar Aula com propriedades corretas")]
        [Trait("Categoria", "Gestão de Conteudo - Aula")]
        public void Curso_AdicionarAula_DeveAdicionarAulaComSucesso()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = 100;
            var curso = new Curso(nome, conteudoProgramatico, valor);
            var aula = new Aula("Introdução ao C#", "Visão geral da linguagem C#.", TimeSpan.FromMinutes(30), "Slides");

            // Act
            curso.AdicionarAula(aula);
            // Assert
            Assert.Single(curso.Aulas);
            var aulaAdicionada = curso.Aulas.First();
            Assert.Equal(aula.Titulo, aulaAdicionada.Titulo);
            Assert.Equal(aula.Conteudo, aulaAdicionada.Conteudo);
            Assert.Equal(aula.Duracao, aulaAdicionada.Duracao);
            Assert.Equal(aula.Material, aulaAdicionada.Material);

        }

        [Fact(DisplayName = "Adicionar Aula com Título em branco")]
        [Trait("Categoria", "Gestão de Conteudo - Aula")]
        public void Curso_AdicionarAula_DeveLancarExcecaoParaTituloVazio()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = 100;
            var curso = new Curso(nome, conteudoProgramatico, valor);
            // Act & Assert
            var ex = Assert.Throws<DomainException>(() =>
                                curso.AdicionarAula(new Aula(string.Empty, "Conteúdo", TimeSpan.FromMinutes(30), "Material")));
            Assert.StartsWith("Título da aula não pode ser vazio.", ex.Message);
        }

        [Fact(DisplayName = "Adicionar Aula com Conteúdo em branco")]
        [Trait("Categoria", "Gestão de Conteudo - Aula")]
        public void Curso_AdicionarAula_DeveLancarExcecaoParaConteudoVazio()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = 100;
            var curso = new Curso(nome, conteudoProgramatico, valor);
            // Act & Assert
            var ex = Assert.Throws<DomainException>(() =>
                                curso.AdicionarAula(new Aula("Título", string.Empty, TimeSpan.FromMinutes(30), "Material")));
            Assert.StartsWith("Conteúdo da aula não pode ser vazio.", ex.Message);
        }

        [Fact(DisplayName = "Adicionar Aula com duração zerada")]
        [Trait("Categoria", "Gestão de Conteudo - Aula")]
        public void Curso_AdicionarAula_DeveLancarExcecaoParaDuracaoZero()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = 100;
            var curso = new Curso(nome, conteudoProgramatico, valor);
            // Act & Assert
            var ex = Assert.Throws<DomainException>(() =>
                                curso.AdicionarAula(new Aula("Título", "Conteúdo", TimeSpan.FromMinutes(0), "Material")));
            Assert.StartsWith("A duração da aula deve ser maior que zero.", ex.Message);
        }

        [Fact(DisplayName = "Adicionar Aula com duração negativa")]
        [Trait("Categoria", "Gestão de Conteudo - Aula")]
        public void Curso_AdicionarAula_DeveLancarExcecaoParaDuracaoNegativa()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = 100;
            var curso = new Curso(nome, conteudoProgramatico, valor);
            // Act & Assert
            var ex = Assert.Throws<DomainException>(() =>
                                curso.AdicionarAula(new Aula("Título", "Conteúdo", TimeSpan.FromMinutes(-5), "Material")));
            Assert.StartsWith("A duração da aula deve ser maior que zero.", ex.Message);
        }

        [Fact(DisplayName = "Remover Aula")]
        [Trait("Categoria", "Gestão de Conteudo - Aula")]
        public void Curso_RemoverAula_DeveRemoverAulaComSucesso()
        {
            // Arrange
            var nome = "Curso de C#";
            var conteudoProgramatico = "Aprenda C# do básico ao avançado.";
            var valor = 100;
            var curso = new Curso(nome, conteudoProgramatico, valor);
            var aula = new Aula("Introdução ao C#", "Visão geral da linguagem C#.", TimeSpan.FromMinutes(30), "Slides");
            curso.AdicionarAula(aula);
            // Act
            curso.RemoverAula(aula);
            // Assert
            Assert.Empty(curso.Aulas);
        }


    }
}
