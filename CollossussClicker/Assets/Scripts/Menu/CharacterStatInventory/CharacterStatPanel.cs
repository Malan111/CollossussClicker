using UnityEngine;
using UnityEngine.UI;

public class CharacterStatPanel : MonoBehaviour
{
    [SerializeField] private Text valueHealth;
    [Space]
    [SerializeField] private Text valueDamage;
    [Space]
    [SerializeField] private Text valueDFire;
    [SerializeField] private Text valueDFrozen;
    [SerializeField] private Text valueDPoison;
    [SerializeField] private Text valueDElectric;
    [Space]
    [SerializeField] private Text valueArmor;
    [Space]
    [SerializeField] private Text valueRFire;
    [SerializeField] private Text valueRFrozen;
    [SerializeField] private Text valueRPoison;
    [SerializeField] private Text valueRElectric;
    [Space]
    [SerializeField] private CharacterSO characterSO;


    private void Update()
    {
        characterSO.HealthHero = float.Parse(valueHealth.text);

        characterSO.DamageHero = float.Parse(valueDamage.text);

        characterSO.DamageFireHero = float.Parse(valueDFire.text);
        characterSO.DamageFrozenHero = float.Parse(valueDFrozen.text);
        characterSO.DamagePoisonHero = float.Parse(valueDPoison.text);
        characterSO.DamageElectricHero = float.Parse(valueDElectric.text);

        characterSO.ArmorHero = float.Parse(valueArmor.text);

        characterSO.ResistanceFireHero = float.Parse(valueRFire.text);
        characterSO.ResistanceFrozenHero = float.Parse(valueRFrozen.text);
        characterSO.ResistancePoisonHero = float.Parse(valueRPoison.text);
        characterSO.ResistanceElectricHero = float.Parse(valueRElectric.text);
    }


}
