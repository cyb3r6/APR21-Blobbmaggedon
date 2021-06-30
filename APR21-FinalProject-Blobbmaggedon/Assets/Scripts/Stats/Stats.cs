using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class to hold stat data
/// like Damage or armor
/// </summary>
[System.Serializable]
public class Stats
{
    public int baseValue;

    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int finalValue = baseValue;

        // looping through all our modifiers
        // adding each modifer to our final value

        modifiers.ForEach(x => finalValue += x);

        return finalValue;
    }

    public void AddModifier(int modifier)
    {
        if(modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}
