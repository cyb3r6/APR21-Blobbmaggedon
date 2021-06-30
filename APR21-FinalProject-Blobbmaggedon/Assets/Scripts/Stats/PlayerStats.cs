using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    
    public override void Start()
    {
        base.Start();
    }

    public void OnWeaponPickUp(Weapon weapon)
    {
        // add the weapon damage modifier
        if(weapon != null)
        {
            damage.AddModifier(weapon.damageModifier);
        }
    }

    public void OnWeaponDrop(Weapon weapon)
    {
        // remove the weapon damage modifier
        if (weapon != null)
        {
            damage.RemoveModifier(weapon.damageModifier);
        }
    }
}
