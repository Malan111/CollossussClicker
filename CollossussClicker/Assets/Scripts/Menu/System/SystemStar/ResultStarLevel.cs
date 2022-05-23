using UnityEngine.UI;
using UnityEngine;

public class ResultStarLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] Levels;
    [SerializeField] private Sprite star, noStar;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {

            if (PlayerPrefs.HasKey("Stars" + i))
            {
                //Если уровень не пройден хотя бы на одну звезду, то следующий уровень не будет доступен
                if(PlayerPrefs.GetInt("Stars" + i) > 0)
                {
                    //Levels[i + 1].SetActive(true);
                }
                else
                {
                    //Levels[i + 1].SetActive(false);
                }

                if (PlayerPrefs.GetInt("Stars" + i) == 1)
                {
                    Levels[i].transform.GetChild(0).GetComponent<Image>().sprite = star;
                    Levels[i].transform.GetChild(1).GetComponent<Image>().sprite = noStar;
                    Levels[i].transform.GetChild(2).GetComponent<Image>().sprite = noStar;
                }
                else if (PlayerPrefs.GetInt("Stars" + i) == 2)
                {
                    Levels[i].transform.GetChild(0).GetComponent<Image>().sprite = star;
                    Levels[i].transform.GetChild(1).GetComponent<Image>().sprite = star;
                    Levels[i].transform.GetChild(2).GetComponent<Image>().sprite = noStar;
                }
                else if (PlayerPrefs.GetInt("Stars" + i) == 3)
                {
                    Levels[i].transform.GetChild(0).GetComponent<Image>().sprite = star;
                    Levels[i].transform.GetChild(1).GetComponent<Image>().sprite = star;
                    Levels[i].transform.GetChild(2).GetComponent<Image>().sprite = star;
                }
                else if (PlayerPrefs.GetInt("Stars" + i) == 0)
                {
                    Levels[i].transform.GetChild(0).GetComponent<Image>().sprite = noStar;
                    Levels[i].transform.GetChild(1).GetComponent<Image>().sprite = noStar;
                    Levels[i].transform.GetChild(2).GetComponent<Image>().sprite = noStar;
                }
            }
            else
            {
                Levels[i].transform.GetChild(0).gameObject.SetActive(false);
                Levels[i].transform.GetChild(1).gameObject.SetActive(false);
                Levels[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }
}
