using System.Collections;
using UnityEngine;
using Kryz.CharacterStats;

[CreateAssetMenu(menuName = "Item Effects/Stat Buff")]
public class StatBuffItemEffect : UsableItemEffect
{
	public int AgilityBuff;
	public float Duration;

	public override void ExecuteEffect(UsableItem parentItem, Character character)
	{
		StatModifier statModifier = new StatModifier(AgilityBuff, StatModType.Flat, parentItem);
		character.Armor.AddModifier(statModifier);
		character.UpdateStatValues();
		character.StartCoroutine(RemoveBuff(character, statModifier, Duration));
	}

	public override string GetDescription()
	{
		return "Grants " + AgilityBuff + " Agility for " + Duration + " seconds.";
	}

	private static IEnumerator RemoveBuff(Character character, StatModifier statModifier, float duration)
	{
		yield return new WaitForSeconds(duration);
		character.Armor.RemoveModifier(statModifier);
		character.UpdateStatValues();
	}
}
