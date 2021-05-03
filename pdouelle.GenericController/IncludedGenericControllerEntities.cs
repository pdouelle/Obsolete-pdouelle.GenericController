using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace pdouelle.GenericController
{
    public static class IncludedGenericControllerEntities
    {
        public static Assembly[] Assemblies { get; set; }

        public static List<GenericTypesForController> GetIncludedEntities()
        {
            var typeList = new List<GenericTypesForController>();

            foreach (Assembly assembly in Assemblies)
            {
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    var customAttribute = (GenericControllerEntityAttribute) type
                        .GetCustomAttributes(typeof(GenericControllerEntityAttribute))
                        .FirstOrDefault();
                    
                    if (customAttribute != null)
                    {
                        typeList.Add(new GenericTypesForController
                        {
                            Entity = type,
                            Dto = customAttribute.Dto,
                            QueryList = customAttribute.QueryList,
                            QueryById = customAttribute.QueryById,
                            Create = customAttribute.Create,
                            Update = customAttribute.Update,
                            Patch = customAttribute.Patch,
                            Delete = customAttribute.Delete
                        });
                    }
                }
            }

            return typeList;
        }
    }
}