using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
   public  interface IServiceEquipe : IService<Equipe>
    {
        public Double SommeRecompense(Equipe e);

         List<Entraineur> ListEntraineurEquipe(Equipe e);
        public DateTime Premiertrophee(Equipe e);
    }
}
