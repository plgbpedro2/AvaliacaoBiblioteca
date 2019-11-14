using System;

namespace Biblioteca.Domain
{
    public class Livro
    {    
        public int Id { get; set; } 
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Autor { get; set; }
        public int Edicao { get; set; }
        public DateTime DataPublicacao { get; set; }    
        public int Tema { get; set; }
    }
}