using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ServiceEquipe : Service<Equipe>, IServiceEquipe
    {
        public ServiceEquipe(IUnitOfWork utw) : base(utw)
        {

        }
        public List<Entraineur> ListEntraineurEquipe (Equipe e)
        {

            return e.Contrats.Select(c => c.Membre).OfType<Entraineur>().ToList();

        }
        public double SommeRecompense(Equipe e)
        {
            double somme = 0;
            foreach (var t in e.Trophees)
            {
                somme = somme + t.Recompense;
            }
            return somme;
        }
        public DateTime Premiertrophee(Equipe e)
        {
            return e.Trophees.Where (t => t.TypeTrophee == "Championnat").OrderBy(t => t.DateTrophee).First().DateTrophee;
        }

    }
}
