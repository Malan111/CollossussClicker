using UnityEngine;
using UnityEngine.UI;

public class SystemCurrency : MonoBehaviour
{
    #region SIngleton:SystemCurrency

    public static SystemCurrency Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [SerializeField] private Text textCoinMenu;
    [SerializeField] private Text textRubyMenu;

    public float coinMenu;
    private float rubyMenu;

    private void  OnValidate()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetFloat("MenuCoin", 10000);
        coinMenu = PlayerPrefs.GetFloat("MenuCoin");
        rubyMenu = PlayerPrefs.GetFloat("MenuGold");
        textCoinMenu.text = coinMenu.ToString();
        textRubyMenu.text = rubyMenu.ToString();
    }

    public void UseCoins(int amount)
    {
        coinMenu -= amount;
        PlayerPrefs.SetFloat("MenuCoin", coinMenu);
        textCoinMenu.text = coinMenu.ToString();
    }

    public bool HasEnoughCoins(int amount)
    {
        return (coinMenu >= amount);
    }

}
