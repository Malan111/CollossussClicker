using UnityEngine;
using Kryz.CharacterStats;

public class Character : MonoBehaviour
{
    public CharacterStat Strength;
    public CharacterStat Agility;
    public CharacterStat Intelligence;
    public CharacterStat Vitality;

    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;

    private void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromInventory;
    }

    private void EquipFromInventory(Item item)
    {
        if(item is EquipmentItem)
        {
            Equip((EquipmentItem)item);
        }
    }

    private void UnequipFromInventory(Item item)
    {
        if (item is EquipmentItem)
        {
            Unequip((EquipmentItem)item);
        }
    }

    public void Equip(EquipmentItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquipmentItem previousItem;
            if(equipmentPanel.AddItem(item,out previousItem))
            {
                if(previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
                
        }
    }

    public void Unequip(EquipmentItem item)
    {
        if(!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }
}
