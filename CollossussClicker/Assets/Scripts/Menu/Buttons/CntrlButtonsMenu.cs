using UnityEngine;
using UnityEngine.SceneManagement;

public class CntrlButtonsMenu : MonoBehaviour
{
    public void ClickBattle()
    {
        SceneManager.LoadScene("Battle");
    }

    public void ClickBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void OffPanel(GameObject panel)
    {
        panel.SetActive(false);
    }

}
