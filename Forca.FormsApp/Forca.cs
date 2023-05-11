using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.FormsApp
{
    public class Forca
    {
        private string[] palavras = { "ABACAXI", "BANANA", "MELANCIA", "LARANJA", "MORANGO", "ABACATE", "ACEROLA" };
        public string palavraRandom { get; set; }
        public string palavraCriptografada { get; set; }
        public List<char> LetrasEscolhidas { get; set; }

        public Forca()
        {
            Random random = new Random();
            palavraRandom = palavras[random.Next(palavras.Length)];
            palavraCriptografada = new string('_', palavraRandom.Length);
            LetrasEscolhidas = new List<char>();
        }
    }
}

