using System;

namespace Biblioteca
{
    public class Pessoa
    {
        public string Nome { get; }
        public int Idade { get; }
        public string Endereco { get; }

        public Pessoa(string nome, int idade, string endereco)
        {
            Nome = nome;
            Idade = idade;
            Endereco = endereco;
        }
    }
}
