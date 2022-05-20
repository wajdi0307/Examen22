using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ServiceMembre : Service<Membre>, IServiceMembre
    {
        public ServiceMembre(IUnitOfWork utw) : base(utw)
        {

        }

        public List<Joueur> ListeJoueurTrophee(Trophee t)
        {
            IDataBaseFactory dbf = new DataBaseFactory();
            IUnitOfWork uow = new UnitOfWork(dbf);
            IcontratService cs = new ContratService(uow);
            return cs.GetMany(c => (t.DateTrophee - c.DateContrat).
            TotalDays < c.DureeMois * 30).
            Select(c => c.Membre).OfType<Joueur>().ToList();

        }
    }
    }
