using AutoMapper;
using AutoMapper.Mappers;
using COAD.CORPORATIVO.Config;
using GenericCrud.Config;
using GenericCrud.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Coad.GenericCrud.Mapping
{
    public static class MapperWrapper
    {
        public static IDictionary<string, Mapper> automapperProfile = new Dictionary<string, Mapper>();

        public static T Convert<T>(object val)
        {
            return Mapper.Map<T>(val);
        }

        public static T Convert<S,T>(S val)
        {
            return Mapper.Map<S,T>(val);
        }

        public static MapperEngineWrapper BuildMapperEngineWrapper(GenericProfile cfgProfileConfig = null, string namespaces = null, Assembly assembly = null)
        {
            return new MapperEngineWrapper(cfgProfileConfig, namespaces, assembly);
        }
    }
    
}