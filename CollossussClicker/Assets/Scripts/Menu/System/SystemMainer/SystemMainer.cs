using UnityEngine;
using UnityEngine.UI;

public class SystemMainer : MonoBehaviour
{
    [SerializeField] private Text textLevel;
    [SerializeField] private Text textCurrency;
    [SerializeField] private Text textGolden;
    [SerializeField] private Button lockedButton;

    [Space]
    [SerializeField] private int indexLevel;


    private int _levelMainer;
    private int _golden;

    private float _currency;
    private float _indexMult = 1.1f;

    private SystemCurrency _useCoin;



    private void Start()
    {
        //PlayerPrefs.SetFloat("CurrencyMainer", 500f);
        //PlayerPrefs.SetInt("GoldenMainer", 5);
        //PlayerPrefs.DeleteKey("LevelMainer");

        _levelMainer = PlayerPrefs.GetInt("LevelMainer");
        _currency = PlayerPrefs.GetFloat("CurrencyMainer");
        _golden = PlayerPrefs.GetInt("GoldenMainer");

        textLevel.text = _levelMainer.ToString();
        textCurrency.text = ((int)_currency).ToString();
        textGolden.text = _golden.ToString();

        LockedLevelUp();
    }

    void LockedLevelUp()
    {
        int level = int.Parse(textLevel.text);

        if (level == 15)
        {
            lockedButton.interactable = false;
        }
    }

    public void OnButtonLevelUp()
    {
        _useCoin.UseCoins((int)_currency);

        //Увеличение уровня
        _levelMainer++;
        PlayerPrefs.SetInt("LevelMainer", _levelMainer);
        textLevel.text = _levelMainer.ToString();

        //Увеличение стоимости
        _currency *= _indexMult * indexLevel;
        PlayerPrefs.SetFloat("CurrencyMainer", _currency);
        textCurrency.text = ((int)_currency).ToString();

        //Увеличение золота
        _golden += (int)(100 * _indexMult) * indexLevel;
        _indexMult += 0.1f;
        PlayerPrefs.SetInt("GoldenMainer", _golden);
        textGolden.text = _golden.ToString();

        LockedLevelUp();
    }

}
