using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace pdouelle.GenericController
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (GenericTypesForController genericTypesForController in IncludedGenericControllerEntities
                .GetIncludedEntities())
            {
                var typeName = genericTypesForController.Entity.Name + "sController";

                if (feature.Controllers.All(t => t.Name != typeName))
                {
                    TypeInfo controllerType = typeof(GenericController<,,,,,,,>)
                        .MakeGenericType
                        (
                            genericTypesForController.Entity,
                            genericTypesForController.Dto,
                            genericTypesForController.QueryList,
                            genericTypesForController.QueryById,
                            genericTypesForController.Create,
                            genericTypesForController.Update,
                            genericTypesForController.Patch,
                            genericTypesForController.Delete
                        )
                        .GetTypeInfo();
                    feature.Controllers.Add(controllerType);
                }
            }
        }
    }
}