using System;

namespace pdouelle.GenericController
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GenericControllerEntityAttribute : Attribute
    {
        public Type Dto { get; set; }
        public Type QueryList { get; set; }
        public Type QueryById { get; set; }
        public Type Create { get; set; }
        public Type Update { get; set; }
        public Type Patch { get; set; }
        public Type Delete { get; set; }
    }
}