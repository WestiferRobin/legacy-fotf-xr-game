using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    public int Level { get; set; }
    public string Name { get; set; }
    public Palette Palette { get; set; }
    public Stats Stats { get; set; }
    private Dictionary<BodyArmor, Item> Wrists { get; }
    private Dictionary<BodyArmor, Enhancement> Armor { get; }
    private Dictionary<WeaponUnitType, Weapon> Weapons { get; } 

    public void UpdateWristItem(BodyArmor key, Item value)
    {
        if (Wrists.ContainsKey(key)) Wrists[key] = value;
        else if (key == BodyArmor.LeftArm 
            || key == BodyArmor.RightArm)
        {
            Wrists.Add(key, value);
        }
    }

    public void UpdateArmorEnhancement(BodyArmor key, Enhancement value)
    {
        if (Armor.ContainsKey(key)) Armor[key] = value;
        else if (key == BodyArmor.Head 
            || key == BodyArmor.Torso 
            || key == BodyArmor.LeftArm)
        {
            Armor.Add(key, value);
        }
    }

    public void UpdateWeapons(WeaponUnitType key, Weapon value)
    {
        if (Weapons.ContainsKey(key)) Weapons[key] = value;
        else if (key == WeaponUnitType.Primary 
            || key == WeaponUnitType.Secondary)
        {
            Weapons.Add(key, value);
        }
    }


    public Unit(string name = "", Palette palette = null, Stats stats = null)
    {
        this.Level = 1;
        this.Name = name;
        this.Palette = palette;
        this.Stats = stats;

        this.Wrists = new Dictionary<BodyArmor, Item>();
        this.Armor = new Dictionary<BodyArmor, Enhancement>();
        this.Weapons = new Dictionary<WeaponUnitType, Weapon>();
    }


    public void LevelUp()
    {
        this.Level++;
    }
}
