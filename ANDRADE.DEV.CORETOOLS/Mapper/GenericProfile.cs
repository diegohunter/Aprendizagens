using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Mapper
{
    public abstract class GenericProfile : Profile
    {
        public GenericProfile()
        {
            
        }

        public abstract void Configure(MapperConfiguration Configure);
        // Usado apenas para ser extendido como profile do automapper
    }
}
