using BGS.ProgrammerTask.Inventory;
using UnityEngine;
namespace BGS.ProgrammerTask.UI
{
    public class EquipableRightClickHandler : RightClickHandler
    {
        [SerializeField]
         private EquipableInventory inventory;
        protected override void Apply(Draggable d)
        {
            if (d != null  && d is Equipable_UI equipable)
            {
                if (_myZone.myDraggables.Contains(d))
                {
                    Outfit.OutfitParts part = equipable.GetEquipable.GetEquipablePart;
                    if (part == Outfit.OutfitParts.HAND_L || part == Outfit.OutfitParts.HAND_R) {

                        if (inventory.GetEquipSlot(part).IsFull) {
                            part = Outfit.OutfitParts.HAND_R;
                        }
                        if (inventory.GetEquipSlot(part).IsFull)
                        {
                            part = Outfit.OutfitParts.HAND_L;
                        }
                    }
                    inventory.GetEquipSlot(part).AddDraggable(d);
                }
                else {
                    for (int i = 0; i < inventory.GetEquipSlots.Length; i++) {
                        if (inventory.GetEquipSlots[i].myDraggables.Contains(d)) {
                            _myZone.AddDraggable(d);
                            break;
                        }
                    }
                }
            }
        }
    }
}
