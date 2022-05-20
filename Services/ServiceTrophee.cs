using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
   public  class ServiceTrophee : Service<Trophee> , IServiceTrophee
    {
        public ServiceTrophee(IUnitOfWork utw) : base(utw)
        {
        }
    }
}
