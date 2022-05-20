using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ContratService : Service<Contrat>, IcontratService
    {
        public ContratService(IUnitOfWork utw) : base(utw)
        {

        }
    }
}
