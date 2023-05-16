using System;
using System.Collections.Generic;
using System.Text;
using P01.Logger.Layouts.Contracts;

public class LayoutFatory : ILayoutFactory
{
    public ILayout CreateLayout(string type)
    {
        string typeToLower = type.ToLower();

        switch (typeToLower)
        {
            case "simplelayout":
                return new SimpleLayout();
            case "xmllayout":
                return new XmlLayout();
            default:
                throw new ArgumentException("Invalid layout type");
        }
    }
}

