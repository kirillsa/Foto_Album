﻿using DAL;
using DAL.Interfaces;
using Ninject.Modules;

namespace BLL.Infrastructure
{
    public class Injection : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EF_UnitOfWork>();
        }
    }
}
