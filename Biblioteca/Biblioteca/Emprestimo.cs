using System;

namespace Biblioteca
{
    public class Emprestimo
    {
        public Socio PessoaEmprestante { get; }
        public Livro LivroEmprestado { get; }
        public DateTime DataEmprestimo { get; }
        public DateTime DataDevolucao { get; }

        public Emprestimo(Socio socio, Livro livro, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            PessoaEmprestante = socio;
            LivroEmprestado = livro;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
        }
    }
}



