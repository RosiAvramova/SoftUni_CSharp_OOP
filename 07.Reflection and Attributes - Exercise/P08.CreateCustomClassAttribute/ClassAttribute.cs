using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CreateCustomClassAttribute
{
    [AttributeUsage(AttributeTargets.Class)]

    public class ClassAttribute : Attribute
    {
        public ClassAttribute(string author, int revision, string description,params string[] reviewers)
        {
           this.Author = author;
           this.Revision = revision;
           this.Description = description;
           this.Reviewers = reviewers;
        }

        public string Author { get; private set; }

        public int Revision { get; private set; }

        public string Description { get; set; }

        public string[] Reviewers  { get; private set; }
    }
}
