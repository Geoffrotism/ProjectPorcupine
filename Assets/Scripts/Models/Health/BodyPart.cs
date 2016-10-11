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

public class BodyPart {

    #region Parameters
    // The body part name.
    public string name;

    // The gear that is equiped.
    private Gear equipedGear;

    // The Health object associated with this body part.
    private Health health;
    
    private bool canHaveGear;

    // Do we want the max objects held to be one? (hands can equip gloves but also hold something like a gun.)
    // Can this body part hold an object.
    private bool canHoldObjects;

    #endregion

    public BodyPart(string name, float maxHealth, bool canHaveGear, bool canHoldObjects)
    {
        // Should we check if the name is a correct body part?
        this.name = name;
        this.health = new Health(maxHealth);
        this.canHaveGear = canHaveGear;
        this.canHoldObjects = canHoldObjects;
    }

    #region Getters/Setters 
    /// <summary>
    /// Can this body part equip gear.
    /// </summary>
    public bool CanHaveGear
    {
        get
        {
            return canHaveGear;
        }
    }

   /// <summary>
   /// Can this body part hold an object.
   /// </summary>
    public bool CanHoldObjects
    {
        get
        {
            return canHaveGear;
        }
    }

    public Gear EquipedGear
    {
        get
        {
            return equipedGear;
        }
        set
        {
            // TODO: Might need to add code to ensure that gear that is ALREADY equiped gets placed onto
            // the ground when this new gear is equiped.
            equipedGear = value;
        }
    }
    #endregion

    /// <summary>
    /// Does this body part have gear equiped?
    /// </summary>
    /// <returns>True if there is already gear equiped. </returns>
    public bool hasGearEquiped()
    {
        if (equipedGear != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}