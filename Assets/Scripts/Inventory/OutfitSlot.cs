using BGS.ProgrammerTask.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BGS.ProgrammerTask.Inventory
{
    [Serializable]
    public class OutfitSlot
    {
        [SerializeField]
        private SpriteRenderer _sprRenderer;
        private Equipable equipedItem;

        public void EquipItem(Equipable newItem)
        {
            equipedItem = newItem;
            RefreshAppearance();

        }
        public void UnequipItem()
        {
            equipedItem = null;
            RefreshAppearance();
        }

        public void EquipItem(Draggable d)
        {
            if (d is Equipable_UI)
            {
                EquipItem(((Equipable_UI)d).GetEquipable);
            }
        }

        public void UnequipItem(Draggable d)
        {
            UnequipItem();
        }
        void RefreshAppearance()
        {
            if (equipedItem != null)
            {

                _sprRenderer.sprite = equipedItem.GetEquipedSprite;
            }
            else
            {
                _sprRenderer.sprite = null;
            }
        }
    }
}