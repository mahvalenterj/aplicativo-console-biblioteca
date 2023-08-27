using Biblioteca;
using System;

class Program
{
    static void Main()
    {
        ServicosBiblioteca servicosBiblioteca = new ServicosBiblioteca();
        Menu menu = new Menu(servicosBiblioteca);
        menu.BemVindo();
    }
}
