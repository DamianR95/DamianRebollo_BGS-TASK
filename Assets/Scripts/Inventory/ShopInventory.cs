using BGS.ProgrammerTask.UI;
using System;
using System.Collections;
using UnityEngine;

namespace BGS.ProgrammerTask.Inventory
{
    public class ShopInventory : Inventory
    {
        [SerializeField]
        private float sellValueMultiplier = .5f;
        protected override void Awake()
        {
            base.Awake();

            GetDropZone.OnRemoveDraggable += OnRemoveDraggable;
            GetDropZone.OnReceiveDraggable += OnReceiveDraggable;

        }

        private void OnReceiveDraggable(Draggable d)
        {
            if (d is Item_UI)
            {
                int sellValue = Mathf.RoundToInt((float)(((Item_UI)d).GetItem.GetValue) * sellValueMultiplier);
                GoldCounter._AddGold(sellValue);
            }


        }

        private void OnRemoveDraggable(Draggable d)
        {
            if (d is Item_UI)
            {
                int buyValue = ((Item_UI)d).GetItem.GetValue;
                GoldCounter._RemoveGold(buyValue);
            }
        }
    }
}