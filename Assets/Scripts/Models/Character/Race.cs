using UnityEngine;
using System.Collections;
using System;
using System.Xml;

public class Race : IPrototypable {

    private ArrayList bodyParts = new ArrayList(10);

    public Race() { }

    public Race(string name, ArrayList bodyParts, string description = "N/A")
    {
        this.Name = name;
        this.bodyParts = bodyParts;
        this.Description = description;
    }

    private Race(Race other)
    {
        Name = other.Name;
        bodyParts = other.bodyParts;
        Description = other.Description;
    }

    public Race Clone()
    {
        return new Race(this);
    }

    public string Type { get; set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public ArrayList BodyParts
    {
    get
        {
            return bodyParts;
        }
    }
   
    // TODO: Flush this out more.
    public void ReadXmlPrototype(XmlReader parentReader)
    {
        Name = parentReader.GetAttribute("name");
    }

    // TODO: Flush this out more.
    public void WriteXml(XmlWriter writer)
    {
        writer.WriteAttributeString("name", Name);
    }
}
