using UnityEngine;
using Kryz.CharacterStats;

public enum EquipmentType
{
	Helmet,
	Chest,
	Gloves,
	Boots,
	Weapon1,
	Weapon2,
	Accessory1,
	Accessory2,
}

[CreateAssetMenu(menuName = "Items/Equippable Item")]
public class EquippableItem : Item
{
	public float Health;
	public float Damage;
	public float Armor;
	[Space]
	public float DamageFire;
	public float DamageFrozen;
	public float DamagePoison;
	public float DamageElectric;
	[Space]
	public float ResistanceFire;
	public float ResistanceFrozen;
	public float ResistancePoison;
	public float ResistanceElectric;
	[Space]
	public EquipmentType EquipmentType;

	public override Item GetCopy()
	{
		return Instantiate(this);
	}

	public override void Destroy()
	{
		Destroy(this);
	}

	public void Equip(Character c)
	{
		if (Health != 0)
			c.Health.AddModifier(new StatModifier(Health, StatModType.Flat, this));
		if (Damage != 0)
			c.Damage.AddModifier(new StatModifier(Damage, StatModType.Flat, this));
		if (Armor != 0)
			c.Armor.AddModifier(new StatModifier(Armor, StatModType.Flat, this));


		if (DamageFire != 0)
			c.Damage.AddModifier(new StatModifier(DamageFire, StatModType.PercentMult, this));
		if (DamageFrozen != 0)
			c.Damage.AddModifier(new StatModifier(DamageFrozen, StatModType.PercentMult, this));
		if (DamagePoison != 0)
			c.Damage.AddModifier(new StatModifier(DamagePoison, StatModType.PercentMult, this));
		if (DamageElectric != 0)
			c.Damage.AddModifier(new StatModifier(DamageElectric, StatModType.PercentMult, this));

		if (DamageFire != 0)
			c.DamageFire.AddModifier(new StatModifier(DamageFire, StatModType.PercentAdd, this));
		if (DamageFrozen != 0)
			c.DamageFrozen.AddModifier(new StatModifier(DamageFrozen, StatModType.PercentAdd, this));
		if (DamagePoison != 0)
			c.DamagePoison.AddModifier(new StatModifier(DamagePoison, StatModType.PercentAdd, this));
		if (DamageElectric != 0)
			c.DamageElectric.AddModifier(new StatModifier(DamageElectric, StatModType.PercentAdd, this));

		if (ResistanceFire != 0)
			c.ResistanceFire.AddModifier(new StatModifier(ResistanceFire, StatModType.PercentAdd, this));
		if (ResistanceFrozen != 0)
			c.ResistanceFrozen.AddModifier(new StatModifier(ResistanceFrozen, StatModType.PercentAdd, this));
		if (ResistancePoison != 0)
			c.ResistancePoison.AddModifier(new StatModifier(ResistancePoison, StatModType.PercentAdd, this));
		if (ResistanceElectric != 0)
			c.ResistanceElectric.AddModifier(new StatModifier(ResistanceElectric, StatModType.PercentAdd, this));
	}

	public void Unequip(Character c)
	{
		c.Health.RemoveAllModifiersFromSource(this);

		c.Damage.RemoveAllModifiersFromSource(this);

		c.DamageFire.RemoveAllModifiersFromSource(this);
		c.DamageFrozen.RemoveAllModifiersFromSource(this);
		c.DamagePoison.RemoveAllModifiersFromSource(this);
		c.DamageElectric.RemoveAllModifiersFromSource(this);

		c.Armor.RemoveAllModifiersFromSource(this);

		c.ResistanceFire.RemoveAllModifiersFromSource(this);
		c.ResistanceFrozen.RemoveAllModifiersFromSource(this);
		c.ResistancePoison.RemoveAllModifiersFromSource(this);
		c.ResistanceElectric.RemoveAllModifiersFromSource(this);
	}

	public override string GetItemType()
	{
		return EquipmentType.ToString();
	}
	
	public override string GetDescription()
	{
		sb.Length = 0;
		AddStat(Health, "Health");

		AddStat(Damage, "Damage");

		AddStat(DamageFire, "DamageFire", isPercent: true);
		AddStat(DamageFrozen, "DamageFrozen", isPercent: true);
		AddStat(DamagePoison, "DamagePoison", isPercent: true);
		AddStat(DamageElectric, "DamageElectric", isPercent: true);

		AddStat(Armor, "Armor");

		AddStat(ResistanceFire, "ResistanceFire", isPercent: true);
		AddStat(ResistanceFrozen, "ResistanceFrozen", isPercent: true);
		AddStat(ResistancePoison, "ResistancePoison", isPercent: true);
		AddStat(ResistanceElectric, "ResistanceElectric", isPercent: true);

		return sb.ToString();
	}
	
	private void AddStat(float value, string statName, bool isPercent = false)
	{
		if (value != 0)
		{
			if (sb.Length > 0)
				sb.AppendLine();

			if (value > 0)
				sb.Append("+");

			if (isPercent) {
				sb.Append(value * 100);
				sb.Append("% ");
			} else {
				sb.Append(value);
				sb.Append(" ");
			}
			sb.Append(statName);
		}
	}
}
