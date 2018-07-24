using Castle.Windsor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.IOCContainer.Proxies
{
    public interface IDbContextAcessor<T>
    {
        DbContext dbContext { get; set; }
        T Db { get; }
    }
}
