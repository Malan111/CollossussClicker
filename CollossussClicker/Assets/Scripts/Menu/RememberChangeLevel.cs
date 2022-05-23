using UnityEngine;

public class RememberChangeLevel : MonoBehaviour
{
    public int indLevel;
    public void RememberLevel(GameObject objectLevel)
    {
        indLevel = int.Parse(objectLevel.name) - 1;
        PlayerPrefs.SetInt("changeLevel", indLevel);
        PlayerPrefs.SetInt("NowLevel", indLevel);
    }

}
