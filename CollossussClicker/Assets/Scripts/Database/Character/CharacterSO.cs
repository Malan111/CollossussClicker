using UnityEngine;

[CreateAssetMenu(menuName = "Database/Character", fileName = "Character")]
public class CharacterSO : ScriptableObject
{
    /*
     * Здоровье
     * Армор
     * Урон
     * 
     * Урон от огня
     * Урон от мороза
     * Урон от яда
     * Урон от электричества
     * 
     * Сопротивление от огня
     * Сопротивление от мороза
     * Сопротивление от яда
     * Сопротивление от электричества 
     * 
     */

    /*---------------Basic------------*/
    [Tooltip("Здоровье героя")]
    [SerializeField] protected float health;
    public float HealthHero
    {
        get { return health; }
        set { health = value; }
    }


    [Tooltip("Урон")]
    [SerializeField] private float damage;
    public float DamageHero
    {
        get { return damage; }
         set { damage = value; }
    }


    [Tooltip("Броня")]
    [SerializeField] private float armor;
    public float ArmorHero
    {
        get { return armor; }
         set { armor = value; }
    }
    [Space]
    /*---------------Damage-----------*/
    [Space]

    [Tooltip("Урон от огня")]
    [SerializeField] private float damageFire;
    public float DamageFireHero
    {
        get { return damageFire; }
         set { damageFire = value; }
    }

    [Tooltip("Урон от мороза")]
    [SerializeField] private float damageFrozen;
    public float DamageFrozenHero
    {
        get { return damageFrozen; }
         set { damageFrozen = value; }
    }

    [Tooltip("Урон от яда")]
    [SerializeField] private float damagePoison;
    public float DamagePoisonHero
    {
        get { return damagePoison; }
         set { damagePoison = value; }
    }

    [Tooltip("Урон от элекстричества")]
    [SerializeField] private float damageElectric;
    public float DamageElectricHero
    {
        get { return damageElectric; }
         set { damageElectric = value; }
    }

    [Space]
    /*---------------Resistance-----------*/
    [Space]

    [Tooltip("Сопротивление от огня")]
    [SerializeField] private float resistanceFire;
    public float ResistanceFireHero
    {
        get { return resistanceFire; }
         set { resistanceFire = value; }
    }

    [Tooltip("Сопротивление от мороза")]
    [SerializeField] private float resistanceFrozen;
    public float ResistanceFrozenHero
    {
        get { return resistanceFrozen; }
         set { resistanceFrozen = value; }
    }

    [Tooltip("Сопротивление от яда")]
    [SerializeField] private float resistancePoison;
    public float ResistancePoisonHero
    {
        get { return resistancePoison; }
         set { resistancePoison = value; }
    }

    [Tooltip("Сопротивление от электричества")]
    [SerializeField] private float resistanceElectric;
    public float ResistanceElectricHero
    {
        get { return resistanceElectric; }
         set { resistanceElectric = value; }
    }   
}
