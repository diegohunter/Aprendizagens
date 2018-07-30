using AutoMapper;
using AutoMapper.Mappers;
using GenericCrud.Config;
using GenericCrud.Config.ClassScan;
using GenericCrud.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace COAD.CORPORATIVO.Config
{
    public class MapperEngineWrapper
    {
        private IMapper Mapper { get; set; }
        private Profile profile {get; set;}
               
        public MapperEngineWrapper()
        {
            Init();
        }
        
        public MapperEngineWrapper(GenericProfile cfgProfileConfig = null)
        {
            Init(cfgProfileConfig);
        }

        public MapperEngineWrapper(string namespaces , Assembly assembly)
        {
            Init(null, namespaces, assembly);
        }

        public MapperEngineWrapper(GenericProfile cfgProfileConfig = null, string namespaces = null, Assembly assembly = null)
        {
            Init(cfgProfileConfig, namespaces, assembly);
        }

        public void Init(GenericProfile cfgProfileConfig = null, string namespaces = null, Assembly assembly = null)
        {
            if (cfgProfileConfig != null)
            {
                var config = new MapperConfiguration(cfg => {
                        cfg.AddProfile(cfgProfileConfig);
                    
                        if (!string.IsNullOrWhiteSpace(namespaces) && assembly != null)
                        {
                            IEnumerable<Type> scannedClasses = ClassScanner.ScanNameSpaceForMapperAnnotations(assembly, namespaces);

                            AnnotationConfigurationStore annotadedConfig = new AnnotationConfigurationStore();
                            annotadedConfig.Configuration = cfg;
                            annotadedConfig.AddTypes(scannedClasses);
                        }
                });
                Mapper = config.CreateMapper();
            }
        }

        public T Convert<T>(object val)
        {
            return Mapper.Map<T>(val);
        }

        public T Convert<S, T>(S val)
        {
            return Mapper.Map<S, T>(val);
        }
    }
}
