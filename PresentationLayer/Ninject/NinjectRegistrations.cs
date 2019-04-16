using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfaces;
using BLL;

namespace PresentationLayer.Ninject
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IService>().To<Services>();
        }
    }
}