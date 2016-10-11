#region License
// ====================================================
// Project Porcupine Copyright(C) 2016 Team Porcupine
// This program comes with ABSOLUTELY NO WARRANTY; This is free software,
// and you are welcome to redistribute it under certain conditions; See
// file LICENSE, which is part of this source code package, for details.
// ====================================================
#endregion

using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System;
using System.IO;

/// <summary>
/// Manages the creation of body parts for various characters (including enemies).
/// </summary>
public class BodyPartManager : IXmlSerializable {

    ArrayList races = new ArrayList(10);

    /// <summary>
    /// Used to create one of every Race.
    /// </summary>
    /// Might want to make this its own class?
    public void InitializeRaces()
    {
        // Setup XML Reader
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "Data");
        filePath = System.IO.Path.Combine(filePath, "Races.xml");
        string furnitureXmlText = System.IO.File.ReadAllText(filePath);

        XmlTextReader reader = new XmlTextReader(new StringReader(furnitureXmlText));

        readXmlRaces(reader);
        ReadXml(reader);
        reader.Close();
    }

    /// <summary>
    /// Used only for the IXmlSerializable interface.
    /// </summary>
    public XmlSchema GetSchema()
    {
        throw new NotImplementedException();
    }

    public void ReadXml(XmlReader reader)
    {
       while (reader.Read()) {

                    string name = reader.GetAttribute("Name");
                    int number = int.Parse(reader.GetAttribute("number"));
                    int health = int.Parse(reader.GetAttribute("health"));
                    bool gear = bool.Parse(reader.GetAttribute("canHaveGear"));
                    bool hold = bool.Parse(reader.GetAttribute("canHoldObjects"));

                    for (int i = 0; i < number; i++)
                    {
                        string value = name + i.ToString();

                        // TODO: Some sort of code for making the name "Right Hand, Left Hand"?
                        // TODO: Localization
                        BodyPart part = new BodyPart(name, health, gear, hold);
                    }
                }
    }

    public void WriteXml(XmlWriter writer)
    {
        throw new NotImplementedException();
    }

    private void readXmlRaces(XmlReader reader)
    {
        if (reader.GetAttribute("Races") == null)
        {
            return;
        }

        if (reader.ReadToDescendant("Race"))
        {
            do
            {
                races.Add(reader.ReadContentAsString());
                Debug.ULogErrorChannel("BodyPartManager", reader.ReadContentAsString().ToString());             
            }
            while (reader.ReadToNextSibling("Race"));         
        }        
    }
}
