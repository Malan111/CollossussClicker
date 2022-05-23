using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveCurrency : MonoBehaviour
{
    [SerializeField] private Text textCoinBattle;
    private float coinBattle;
    private float _coin;

    private void OnValidate()
    {
        coinBattle = 0;
        textCoinBattle.text = coinBattle.ToString();
    }

    public void SaveGold()
    {
        _coin = PlayerPrefs.GetFloat("BattleCoin") + PlayerPrefs.GetFloat("MenuCoin");
        PlayerPrefs.SetFloat("MenuCoin", _coin);
    }

    public void AddCurrency()
    {
        coinBattle += Mathf.Ceil(Random.Range(1f, 3f));
        textCoinBattle.text = coinBattle.ToString();
        
        PlayerPrefs.SetFloat("BattleCoin", coinBattle);
    }
}
