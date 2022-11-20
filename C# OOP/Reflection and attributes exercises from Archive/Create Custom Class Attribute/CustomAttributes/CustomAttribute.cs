using System;

namespace InfernoInfinity.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CustomAttribute : Attribute
    {
        public string Author { get; private set; }
        public int Revision { get; private set; }
        public string Description { get; private set; }
        public string Reviewers { get; private set; }

        public CustomAttribute()
        {
            Author = "Pesho";
            Revision = 3;
            Description = "Used for C# OOP Advanced Course - Enumerations and Attributes.";
            Reviewers = "Pesho, Svetlio";
        }
    }
}
