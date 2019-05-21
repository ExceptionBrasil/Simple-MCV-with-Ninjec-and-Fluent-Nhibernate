using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace appTeste.Factorys
{
    public class SessionFactory
    {
        private static ISessionFactory session = BuildSession();

        private static ISessionFactory BuildSession()
        {
            //Configure
            Configuration cfg = new Configuration();
            cfg.Configure();

            //Mapeamento 
            return Fluently.Configure(cfg)
                .Mappings(x => x.FluentMappings.AddFromAssembly(
                    Assembly.GetExecutingAssembly()
                    )).BuildSessionFactory();


        }

        public static ISession OpenSession()
        {
            return session.OpenSession();
        }
    }
}