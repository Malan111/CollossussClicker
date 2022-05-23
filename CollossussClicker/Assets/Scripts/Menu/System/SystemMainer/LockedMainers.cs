using UnityEngine;

public class LockedMainers : MonoBehaviour
{
    public bool isLockedMainer = false;

    public void LockedMainer()
    {
        if (isLockedMainer)
        {
            gameObject.SetActive(true);
        }
    }

}
