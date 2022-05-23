using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CntrlButtonsBattle : MonoBehaviour
{
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnTime()
    {
        Time.timeScale = 1f;
    }

    public void OffTime()
    {
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Battle");
    }

    public void OnPanelLevel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void OffPanelLevel(GameObject panel)
    {
        panel.SetActive(false);
    }


}
