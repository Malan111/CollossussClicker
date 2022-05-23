using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Database/Boss", fileName = "Bosses")]
public class EnemyDatabase : ScriptableObject
{
    [SerializeField, HideInInspector] private List<EnemyData> enemyList;

    [SerializeField] private EnemyData currentEnemy;

    private int currentIndex = 0;

    public void AddElement()
    {
        if (enemyList == null)
            enemyList = new List<EnemyData>();

        currentEnemy = new EnemyData();
        enemyList.Add(currentEnemy);
        currentIndex = enemyList.Count - 1;
    }

    public EnemyData GetNext()
    {
        if (currentIndex < enemyList.Count - 1)
            currentIndex++;
        currentEnemy = this[currentIndex];
        return currentEnemy;
    }

    public EnemyData GetPrev()
    {
        if (currentIndex > 0)
            currentIndex--;
        currentEnemy = this[currentIndex];
        return currentEnemy;
    }

    public void ClearDatabase()
    {
        enemyList.Clear();
        enemyList.Add(new EnemyData());
        currentEnemy = enemyList[0];
        currentIndex = 0;
    }

    public EnemyData GetRandomElemnt()
    {
        int random = Random.Range(0, enemyList.Count);
        return enemyList[random];
    }


    public void RemoveCurrentIndex()
    {
        if(currentIndex > 0)
        {
            currentEnemy = enemyList[--currentIndex];
            enemyList.RemoveAt(++currentIndex);
        }
        else
        {
            enemyList.Clear();
            currentEnemy = null;
        }
    }

    public EnemyData this[int index]
    {
        get
        {
            if (enemyList != null && index >= 0 && index < enemyList.Count)
                return enemyList[index];
            return null;
        }

        set
        {
            if (enemyList == null)
                enemyList = new List<EnemyData>();
            if (index >= 0 && index < enemyList.Count && value != null)
                enemyList[index] = value;
            else Debug.LogError("Выход за границы массива, либо переданное значение = null");
        }
    }

}


[System.Serializable]
public class EnemyData
{
    [Tooltip("Индекс босса")]
    [SerializeField] private int Index;
    public int MainIndex
    {
        get { return Index; }
        protected set { }
    }


    [Tooltip("Изображение")]
    [SerializeField] private Sprite mainSprite;
    public Sprite MainSprite
    {
        get { return mainSprite; }
        protected set { }
    }

    [Space]
    [Tooltip("Здоровье босса")]
    [SerializeField] private float health;
    public float HealthBoss
    {
        get { return health; }
        protected set { }
    }


    [Tooltip("Броня босса")]
    [SerializeField] private float armor;
    public float ArmorBoss
    {
        get { return armor; }
        protected set { }
    }

    [Space]

    [Tooltip("Сопротивление босса")]
    [SerializeField] private float r_fire;
    [SerializeField] private float r_frozen;
    [SerializeField] private float r_electric;
    [SerializeField] private float r_poison;
    public float ResistanceFire
    {
        get { return r_fire; }
        protected set { }
    }
    public float ResistanceFrozen
    {
        get { return r_frozen; }
        protected set { }
    }
    public float ResistanceElec
    {
        get { return r_electric; }
        protected set { }
    }
    public float ResistancePoison
    {
        get { return r_poison; }
        protected set { }
    }

    [Space]

    [Tooltip("Основной урон босса")]
    [SerializeField] private float basicDamage;
    public float BasicDamage
    {
        get { return basicDamage; }
        protected set { }
    }


    [Tooltip("Доп. урон босса")]
    [SerializeField] private float d_fire;
    [SerializeField] private float d_frozen;
    [SerializeField] private float d_electric;
    [SerializeField] private float d_poison;
    public float DamageFire
    {
        get { return d_fire; }
        protected set { }
    }
    public float DamageFrozen
    {
        get { return d_frozen; }
        protected set { }
    }
    public float DamageElec
    {
        get { return d_electric; }
        protected set { }
    }
    public float DamagePoison
    {
        get { return d_poison; }
        protected set { }
    }

}
