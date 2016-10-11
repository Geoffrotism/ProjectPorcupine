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

/// <summary>
/// Manages the creation of body parts for various characters (including enemies).
/// </summary>
public class BodyPartManager {

    public enum PartName {
            head,
            eye,
            hand,
            foot,
            leg,
            arm,
            chest,
            tentacle
    }

    public void InitializeHumanParts(PartName[] characterParts)
    {
        foreach (PartName x in characterParts)
        {
            switch (x.ToString())
            {
                case "hand":
                    BodyPart part = new BodyPart(x.ToString(), 10, true, true);
                    break;
                case "eye":
                break;
            }
        }
    }

}
