using UnityEngine;

[CreateAssetMenu(menuName = "Database/Character", fileName = "Character")]
public class CharacterSO : ScriptableObject
{
    /*
     * ��������
     * �����
     * ����
     * 
     * ���� �� ����
     * ���� �� ������
     * ���� �� ���
     * ���� �� �������������
     * 
     * ������������� �� ����
     * ������������� �� ������
     * ������������� �� ���
     * ������������� �� ������������� 
     * 
     */

    /*---------------Basic------------*/
    [Tooltip("�������� �����")]
    [SerializeField] protected float health;
    public float HealthHero
    {
        get { return health; }
        set { health = value; }
    }


    [Tooltip("����")]
    [SerializeField] private float damage;
    public float DamageHero
    {
        get { return damage; }
         set { damage = value; }
    }


    [Tooltip("�����")]
    [SerializeField] private float armor;
    public float ArmorHero
    {
        get { return armor; }
         set { armor = value; }
    }
    [Space]
    /*---------------Damage-----------*/
    [Space]

    [Tooltip("���� �� ����")]
    [SerializeField] private float damageFire;
    public float DamageFireHero
    {
        get { return damageFire; }
         set { damageFire = value; }
    }

    [Tooltip("���� �� ������")]
    [SerializeField] private float damageFrozen;
    public float DamageFrozenHero
    {
        get { return damageFrozen; }
         set { damageFrozen = value; }
    }

    [Tooltip("���� �� ���")]
    [SerializeField] private float damagePoison;
    public float DamagePoisonHero
    {
        get { return damagePoison; }
         set { damagePoison = value; }
    }

    [Tooltip("���� �� ��������������")]
    [SerializeField] private float damageElectric;
    public float DamageElectricHero
    {
        get { return damageElectric; }
         set { damageElectric = value; }
    }

    [Space]
    /*---------------Resistance-----------*/
    [Space]

    [Tooltip("������������� �� ����")]
    [SerializeField] private float resistanceFire;
    public float ResistanceFireHero
    {
        get { return resistanceFire; }
         set { resistanceFire = value; }
    }

    [Tooltip("������������� �� ������")]
    [SerializeField] private float resistanceFrozen;
    public float ResistanceFrozenHero
    {
        get { return resistanceFrozen; }
         set { resistanceFrozen = value; }
    }

    [Tooltip("������������� �� ���")]
    [SerializeField] private float resistancePoison;
    public float ResistancePoisonHero
    {
        get { return resistancePoison; }
         set { resistancePoison = value; }
    }

    [Tooltip("������������� �� �������������")]
    [SerializeField] private float resistanceElectric;
    public float ResistanceElectricHero
    {
        get { return resistanceElectric; }
         set { resistanceElectric = value; }
    }   
}
