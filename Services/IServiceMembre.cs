using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
   public  interface IServiceMembre : IService<Membre>
    {
      List<Joueur> ListeJoueurTrophee(Trophee t);
    }
}
