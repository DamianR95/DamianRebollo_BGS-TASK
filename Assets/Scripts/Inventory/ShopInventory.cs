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
            GetDropZone.OnAttemptToRemoveDraggable += OnAttemptToRemoveDraggable;
            GetDropZone.AddConditionForRemove(hasEnoughGold);

        }

        private void OnAttemptToRemoveDraggable(Draggable draggable)
        {
            if (draggable is Equipable_UI equipable) {
                HoldingItemValue = equipable.GetItem.GetValue;
            }
        }

        Func<bool> condition1 = () => true;
        int requiredGold = 30;
        Func<bool> hasEnoughGold = () => GoldCounter.Instance.GetGold >= HoldingItemValue;
        private void OnReceiveDraggable(Draggable d)
        {
            if (d is Item_UI)
            {
                //int sellValue = Mathf.RoundToInt((float)(((Item_UI)d).GetItem.GetValue) * sellValueMultiplier);
                int buyValue = ((Item_UI)d).GetItem.GetValue;

                GoldCounter._AddGold(buyValue);
            }


        }

        static int HoldingItemValue; 
         
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