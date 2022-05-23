using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemFontCurrency : MonoBehaviour
{
    [SerializeField] private GameObject text;
    private string textFont;
    private float currencyFont;

    void Start()
    {
        textFont = gameObject.GetComponent<Text>().text;
        currencyFont = float.Parse(textFont);

        if (currencyFont >= 1000 && currencyFont <= 999999)
        {
            currencyFont = currencyFont / 1000;
            text.GetComponent<Text>().text = currencyFont.ToString("0.00") + "K";
        }

    }



}
