using System;

namespace Biblioteca
{
    public class Emprestimo
    {
        public Pessoa PessoaEmprestadora { get; }
        public Livro LivroEmprestado { get; }
        public DateTime DataEmprestimo { get; }
        public DateTime DataDevolucao { get; }

        public Emprestimo(Pessoa pessoa, Livro livro, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            PessoaEmprestadora = pessoa;
            LivroEmprestado = livro;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
        }
    }
}



