using System;
using UnityEngine;
using UnityEngine.UI;

public class CntrlBattle : MonoBehaviour
{
    [SerializeField] private GameObject Star1;
    [SerializeField] private GameObject Star2;
    [SerializeField] private GameObject Star3;

    [SerializeField] private GameObject p_Victory;
    [SerializeField] private GameObject p_Defeat;

    [SerializeField] private Slider sliderHero;
    [SerializeField] private Slider sliderBoss;

    [SerializeField] private Text textHero;
    [SerializeField] private Text textBoss;

    [Tooltip("Хар-ки босса")]
    [SerializeField] private EnemyDatabase enemySettings; //настройки босса в SO
    [SerializeField] private GameObject prefabBoss;

    [Tooltip("Хар-ки героя")]
    [SerializeField] private CharacterSO characterSettings;

    private int _index = 0;
    private int _indexLevel = 0;
    private int _result;

    private float _hpHero;
    private float _damageHero;
    private float _hpBoss;
    private float _hpHeroStart;
    private float _damageBoss;


    //стартовые хар-ки для босса и героя
    public void Start()
    {
        _index = PlayerPrefs.GetInt("changeLevel");

        _indexLevel = _index;
        PlayerPrefs.SetInt("NowLevel", _indexLevel);

        prefabBoss.GetComponent<Image>().sprite = enemySettings[_index].MainSprite;

        //Stats boss
        CalculateStats(_index);

        sliderBoss.maxValue = _hpBoss;
        sliderHero.maxValue = _hpHero;

        _hpHeroStart = _hpHero;

        Debug.Log("DamageBoss: " + _damageBoss);
        Debug.Log("DamageHero: " + _damageHero);

    }


    //обновляет значения сцены
    private void Update()
    {
        textBoss.text = Math.Ceiling(_hpBoss) + " HP";
        textHero.text = Math.Ceiling(_hpHero) + " HP";

        sliderBoss.value = _hpBoss;
        sliderHero.value = _hpHero;
    }


    //подсчитывает значения урона по боссу&герою
    public void OnClickDamage()
    {
        _hpBoss -= _damageHero;
        _hpHero -= _damageBoss;
    }



    //SaveGame && EndGame запихнуть в отдельный скрипт и сверху [SerializeField] перемнные не забыть!!!
    //сохраняет игру(значения голды)
    public void SaveGame()
    {
        PlayerPrefs.SetInt("BattleCoin", _index);
    }


    //определяет EndGame
    public void EndGame()
    {
        //Win
        if (_hpBoss <= 0)
        {
            CalculateStarUI();
            SaveResultStar();
            _index++;
            p_Victory.SetActive(true);
        }

        //Lose
        if (_hpHero <= 0)
        {
            CalculateStarUI();
            SaveResultStar();
            PlayerPrefs.SetInt("changeLevel", _index);
            p_Defeat.SetActive(true);
        }
    }

    private void CalculateStarUI()
    {

        //Debug.Log("HpHeroNow: " + _hpHero);
        //Debug.Log("HpHeroStart: " + _hpHeroStart);

        _result = (int)(_hpHero / _hpHeroStart * 100);

        //Debug.Log("Result STAR PROCENT: " + _result + "%");

        if (_result >= 80)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
        }
        else if (_result >= 50 && _result <= 79)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);

        }
        else if (_result >= 0 && _result <= 49 && _hpHero > 0)
        {
            Star1.SetActive(true);
        }
        else 
        {
            Star1.SetActive(false);
            Star2.SetActive(false);
            Star3.SetActive(false);
        }
        
    }

    private void SaveResultStar()
    {
        if (_result >= 80 && (!PlayerPrefs.HasKey("Stars" + _indexLevel) || PlayerPrefs.GetInt("Stars" + _indexLevel) < 3))
        {
            PlayerPrefs.SetInt("Stars" + _indexLevel, 3);
        }
        else if (_result >= 50 && _result <= 79 && (!PlayerPrefs.HasKey("Stars" + _indexLevel) || PlayerPrefs.GetInt("Stars" + _indexLevel) < 2))
        {
            PlayerPrefs.SetInt("Stars" + _indexLevel, 2);
        }
        else if (_result >= 0 && _result <= 49 && _hpHero > 0 && !PlayerPrefs.HasKey("Stars" + _indexLevel))
        {
            PlayerPrefs.SetInt("Stars" + _indexLevel, 1);
        }
        else if (!PlayerPrefs.HasKey("Stars" + _indexLevel))
        {
            PlayerPrefs.SetInt("Stars" + _indexLevel, 0);
        }

    }


    private void CalculateStats(int ind)
    {

        float _basicHealthBoss;
        float _basicDamageBoss;
        float _basicArmorBoss;

        float _bonusDamageFireBoss;
        float _bonusDamagePoisonBoss;
        float _bonusDamageFrozenBoss;
        float _bonusDamageElectricBoss;

        float _resistanceFireBoss;
        float _resistancePoisonBoss;
        float _resistanceFrozenBoss;
        float _resistanceElectricBoss;

        float _basicHealthHero;
        float _basicDamageHero;
        float _basicArmorHero;

        float _resistanceFireHero;
        float _resistancePoisonHero;
        float _resistanceFrozenHero;
        float _resistanceElectricHero;

        float _bonusDamageFireHero;
        float _bonusDamagePoisonHero;
        float _bonusDamageFrozenHero;
        float _bonusDamageElectricHero;



        _basicHealthBoss = enemySettings[_index].HealthBoss;
        _basicDamageBoss = enemySettings[_index].BasicDamage;
        _basicArmorBoss = enemySettings[_index].ArmorBoss;

        _bonusDamageFireBoss = enemySettings[_index].DamageFire;
        _bonusDamagePoisonBoss = enemySettings[_index].DamagePoison;
        _bonusDamageFrozenBoss = enemySettings[_index].DamageFrozen;
        _bonusDamageElectricBoss = enemySettings[_index].DamageElec;

        _resistanceFireBoss = enemySettings[_index].ResistanceFire;
        _resistancePoisonBoss = enemySettings[_index].ResistancePoison;
        _resistanceFrozenBoss = enemySettings[_index].ResistanceFrozen;
        _resistanceElectricBoss = enemySettings[_index].ResistanceElec;


        _basicHealthHero = characterSettings.HealthHero;
        _basicDamageHero = characterSettings.DamageHero;
        _basicArmorHero = characterSettings.ArmorHero;

        _bonusDamageFireHero = characterSettings.DamageFireHero;
        _bonusDamagePoisonHero = characterSettings.DamagePoisonHero;
        _bonusDamageFrozenHero = characterSettings.DamageFrozenHero;
        _bonusDamageElectricHero = characterSettings.DamageElectricHero;

        _resistanceFireHero = characterSettings.ResistanceFireHero;
        _resistancePoisonHero = characterSettings.ResistancePoisonHero;
        _resistanceFrozenHero = characterSettings.ResistanceFrozenHero;
        _resistanceElectricHero = characterSettings.ResistanceElectricHero;

        
        _bonusDamageFireHero = ((_basicDamageHero * _bonusDamageFireHero) - (_basicArmorBoss * _resistanceFireBoss)) / 100;
        _bonusDamagePoisonHero = ((_basicDamageHero * _bonusDamagePoisonHero) - (_basicArmorBoss * _resistancePoisonBoss)) / 100;
        _bonusDamageFrozenHero = ((_basicDamageHero * _bonusDamageFrozenHero) - (_basicArmorBoss * _resistanceFrozenBoss)) / 100;
        _bonusDamageElectricHero = ((_basicDamageHero * _bonusDamageElectricHero) - (_basicArmorBoss * _resistanceElectricBoss)) / 100;

        if (_bonusDamageFireHero < 0)
        {
            _bonusDamageFireHero = 0;
        }

        if (_bonusDamagePoisonHero < 0)
        {
            _bonusDamagePoisonHero = 0;
        }

        if (_bonusDamageFrozenHero < 0)
        {
            _bonusDamageFrozenHero = 0;
        }

        if (_bonusDamageElectricHero < 0)
        {
            _bonusDamageElectricHero = 0;
        }
        
        _bonusDamageFireBoss = ((_basicDamageBoss * _bonusDamageFireBoss) - (_basicArmorHero * _resistanceFireHero)) / 100;
        _bonusDamagePoisonBoss = ((_basicDamageBoss * _bonusDamagePoisonBoss) - (_basicArmorHero * _resistancePoisonHero)) / 100;
        _bonusDamageFrozenBoss = ((_basicDamageBoss * _bonusDamageFrozenBoss) - (_basicArmorHero * _resistanceFrozenHero)) / 100;
        _bonusDamageElectricBoss = ((_basicDamageBoss * _bonusDamageElectricBoss) - (_basicArmorHero * _resistanceElectricHero)) / 100;

        if (_bonusDamageFireBoss < 0)
        {
            _bonusDamageFireBoss = 0;
        }

        if (_bonusDamagePoisonBoss < 0)
        {
            _bonusDamagePoisonBoss = 0;
        }

        if (_bonusDamageFrozenBoss < 0)
        {
            _bonusDamageFrozenBoss = 0;
        }

        if (_bonusDamageElectricBoss < 0)
        {
            _bonusDamageElectricBoss = 0;
        }


        _basicDamageBoss += _bonusDamageFireBoss + _bonusDamagePoisonBoss + _bonusDamageFrozenBoss + _bonusDamageElectricBoss;
        _basicDamageHero += _bonusDamageFireHero + _bonusDamagePoisonHero + _bonusDamageFrozenHero + _bonusDamageElectricHero;


        _hpHero = _basicHealthHero + _basicHealthHero * (_basicArmorHero / 100);
        _damageHero = _basicDamageHero;

        _hpBoss = _basicHealthBoss + _basicHealthBoss * (_basicArmorBoss / 100);
        _damageBoss = _basicDamageBoss;
    }

}
