using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : XRGrabInteractable
{
    public Combat combat;

    public int damageModifier = 1;

    public AudioClip weaponHitSound;

    private AudioSource audioSource;

    void Start()
    {
        combat = Player.instance.combat;
        audioSource = GetComponent<AudioSource>();
    }

    public void PickUpWeapon()
    {
        Player.instance.playerstats.OnWeaponPickUp(this);
    }

    public void DropWeapon()
    {
        Player.instance.playerstats.OnWeaponDrop(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.collider.GetComponent<Enemy>();
        if (enemy)
        {
            combat.Attack(enemy.stats, enemy.transform);
            SoundManager.instance.PlaySound(weaponHitSound, audioSource);
        }
    }

}
