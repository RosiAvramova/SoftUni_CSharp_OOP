using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    class InjectAttribute : Attribute
    {
    }
}
