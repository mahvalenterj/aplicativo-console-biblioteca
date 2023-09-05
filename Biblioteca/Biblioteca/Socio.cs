using System;

namespace Biblioteca
{
    public class Socio
    {
        public string Nome { get; }
        public int Idade { get; }
        public string Endereco { get; }

        public Socio(string nome, int idade, string endereco)
        {
            Nome = nome;
            Idade = idade;
            Endereco = endereco;
        }
    }
}
