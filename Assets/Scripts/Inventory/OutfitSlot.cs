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



        private Equipable _equippedItem;


        public void EquipItem(Equipable newItem)
        {
            _equippedItem = newItem;
            RefreshAppearance();

        }
        public void UnequipItem()
        {
            _equippedItem = null;
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
            if (_equippedItem != null)
            {

                _sprRenderer.sprite = _equippedItem.MySprite;
            }
            else
            {
                _sprRenderer.sprite = null;
            }
        }

    }
}