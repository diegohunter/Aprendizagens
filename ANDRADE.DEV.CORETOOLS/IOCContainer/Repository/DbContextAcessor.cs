using Castle.MicroKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.IOCContainer.Proxies
{
    public class DbContextAcessor : DbContextAcessor<DbContext>
    {
        public DbContextAcessor(IKernel kernel) : base(kernel)
        {
        }
    }

    public class DbContextAcessor<T> : IDbContextAcessor<T> , IDisposable where T : DbContext
    {
        private readonly IKernel kernel;
        private bool IsDisposed = false;

        public DbContextAcessor(IKernel kernel)
        {
            this.kernel = kernel;
        }

        private DbContext _db;
        public string ProfileName { get; set; }

        
        public DbContext dbContext
        {
            get
            {
                if (IsDisposed == false)
                {
                    if (string.IsNullOrWhiteSpace(ProfileName))
                        return (DbContext)kernel.Resolve<T>();
                    else
                        return (DbContext)kernel.Resolve<T>(ProfileName);
                }
                return null;
            }
            set
            {
                
            }
        }


        /// <summary>
        /// Devolve a instância do DBContext 
        /// </summary>
        public T Db { 
            get {

                return (T)dbContext;
            } 
             private set { } 
        }

        /// <summary>
        /// Devolve a instância do DBContext Fazendo o Cast Especificado
        /// </summary>
        public TCast DbAs<TCast>() where TCast : DbContext
        {
            if(dbContext != null)
                return (TCast)dbContext;
             return null;
        }

        /// <summary>
        /// Faz um cast de TODO o objeto Acessor
        /// </summary>
        /// <typeparam name="TDestiny"></typeparam>
        /// <returns></returns>
        public DbContextAcessor<TDestiny> Cast<TDestiny>() where TDestiny : DbContext
        {
            var dbAcessor =  kernel.Resolve<DbContextAcessor<TDestiny>>();
            dbAcessor.ProfileName = this.ProfileName;

            return dbAcessor;
        }

        public void Dispose()
        {
            this.IsDisposed = true;
        }
    }
}
