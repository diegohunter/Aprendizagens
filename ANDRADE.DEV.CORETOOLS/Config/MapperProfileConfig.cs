using AutoMapper;
using GenericCrud.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Config
{
    public class MapperProfileConfig
    {
        public MapperProfileConfig()
        {

        }

        public MapperProfileConfig(MapperConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public MapperConfiguration Configuration { get; set; }
    }
}
