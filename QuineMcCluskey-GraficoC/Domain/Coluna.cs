using System.Collections.Generic;

namespace QuineMcCluskey_GraficoC.Domain
{
    public class Coluna
    {
        public bool Marcado;

        public string Variaveis;

        public List<int> Mintermos;
        
        public Coluna()
        {
            Mintermos = new List<int>();
            
            Marcado = false;
        }
    }
}
