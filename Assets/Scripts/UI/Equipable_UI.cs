using BGS.ProgrammerTask.Inventory;


using UnityEngine.UI;
namespace BGS.ProgrammerTask.UI
{
    class Equipable_UI : Item_UI
    {
        public Equipable GetEquipable { get { return GetItem as Equipable; } }
        public override void Setup(DropZone originDropZone, Item i)
        {
            base.Setup(originDropZone, i);
            draggableTag = GetEquipable.GetEquippablePart.ToString();
        }
    }
}