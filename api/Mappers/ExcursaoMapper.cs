using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Classes;

namespace api.Mappers
{
    public class ExcursaoMapper
    {
        public static Excursao ExcursaoToClasses(Models.Excursao excursao_model)
        {
            return new Excursao
            {
                excursao = excursao_model
            };
        }
    }
}