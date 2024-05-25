using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BGS.ProgrammerTask.Inventory
{
    public class Outfit : MonoBehaviour
    {
        [SerializeField]
        private OutfitSlot[] _outfitSlots;



        public OutfitSlot[] GetOutfitSlots { get { return _outfitSlots; } }
        public void EquipOutfit(Equipable item)
        {

            var Slot = GetOutfitSlot(item.GetEquipablePart);
            if (Slot == null)
                return;

            Slot.EquipItem(item);

        }

        private OutfitSlot GetOutfitSlot(OutfitParts index)
        {
            if (index >= OutfitParts.COUNT)
            {
                Debug.LogError("OutfitPart asked is not existent.");
                return null;
            }
            return _outfitSlots[(int)index];
        }

        public enum OutfitParts
        {
            HEAD = 0,
            TORSO = 1,
            PELVIS = 2,
            SHOULDER_L = 3,
            ELBOW_L = 4,
            WRIST_L = 5,
            SHOULDER_R = 6,
            ELBOW_R = 7,
            WRIST_R = 8,
            LEG_L = 9,
            BOOT_L = 10,
            LEG_R = 11,
            BOOT_R = 12,
            HAND_L = 13,
            HAND_R = 14,
            COUNT = 15
        }

    }

}