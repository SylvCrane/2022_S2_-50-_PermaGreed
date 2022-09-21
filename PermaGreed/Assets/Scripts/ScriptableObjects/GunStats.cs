using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Gun")]
public class GunStats : ScriptableObject
{
    public enum Rarity { Common, Uncommon, Rare, Epic };

    public string gunName;
    public int ammoCount;
    public float damage;
    public bool reload;
    public float range;
    public float reloadDuration;
    public bool hasSpread;
    public float fireRate;
    public float tempAmmo;
    public Rarity gunRarity;
}
