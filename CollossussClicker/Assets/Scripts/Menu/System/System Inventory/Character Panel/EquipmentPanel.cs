using System;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
	public EquipmentSlot[] EquipmentSlots;
	[SerializeField] Transform equipmentSlotsParent;

	public event Action<BaseItemSlot> OnPointerEnterEvent;
	public event Action<BaseItemSlot> OnPointerExitEvent;
	public event Action<BaseItemSlot> OnRightClickEvent;

	private void Start()
	{
		for (int i = 0; i < EquipmentSlots.Length; i++)
		{
			EquipmentSlots[i].OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
			EquipmentSlots[i].OnPointerExitEvent += slot => OnPointerExitEvent(slot);
			EquipmentSlots[i].OnRightClickEvent += slot => OnRightClickEvent(slot);
		}
	}

	private void OnValidate()
	{
		EquipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
	}

	public bool AddItem(EquippableItem item, out EquippableItem previousItem)
	{
		for (int i = 0; i < EquipmentSlots.Length; i++)
		{
			if (EquipmentSlots[i].EquipmentType == item.EquipmentType)
			{
				previousItem = (EquippableItem)EquipmentSlots[i].Item;
				EquipmentSlots[i].Item = item;
				EquipmentSlots[i].Amount = 1;
				return true;
			}
		}
		previousItem = null;
		return false;
	}

	public bool RemoveItem(EquippableItem item)
	{
		for (int i = 0; i < EquipmentSlots.Length; i++)
		{
			if (EquipmentSlots[i].Item == item)
			{
				EquipmentSlots[i].Item = null;
				EquipmentSlots[i].Amount = 0;
				return true;
			}
		}
		return false;
	}
}
