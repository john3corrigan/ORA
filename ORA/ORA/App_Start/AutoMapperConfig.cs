using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace ORA.App_Start
{
    public class AutoMapperConfig
    {
        public static void ConfigMaps()
        {
            Mapper.Initialize(cfg =>
            {

            });
        }
    }
}