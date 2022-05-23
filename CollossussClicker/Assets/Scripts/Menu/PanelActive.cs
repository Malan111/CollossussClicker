using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActive : MonoBehaviour
{
    [SerializeField] private GameObject panelInventory;
    [SerializeField] private GameObject panelMissions;
    [SerializeField] private GameObject panelPercks;
    [SerializeField] private GameObject panelMiner;

    public void ActiveMenu()
    {
        panelInventory.SetActive(false);
        panelMissions.SetActive(false);
        panelPercks.SetActive(false);
        panelMiner.SetActive(false);
    }
    public void ActiveInventory()
    {
        panelInventory.SetActive(true);
        panelMissions.SetActive(false);
        panelPercks.SetActive(false);
        panelMiner.SetActive(false);
    }
    public void ActiveMissions()
    {
        panelInventory.SetActive(false);
        panelMissions.SetActive(true);
        panelPercks.SetActive(false);
        panelMiner.SetActive(false);
    }
    public void ActivePercks()
    {
        panelInventory.SetActive(false);
        panelMissions.SetActive(false);
        panelPercks.SetActive(true);
        panelMiner.SetActive(false);
    }

    public void ActiveMiners()
    {
        panelInventory.SetActive(false);
        panelMissions.SetActive(false);
        panelPercks.SetActive(false);
        panelMiner.SetActive(true);
    }

}
