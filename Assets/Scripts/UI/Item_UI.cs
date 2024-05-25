using BGS.ProgrammerTask.Inventory;
using UnityEngine.UI;
namespace BGS.ProgrammerTask.UI
{
    class Item_UI : Draggable
    {
        public Image myImage;

        private Item _item;
        public Item GetItem { get { return _item; } }
        public virtual void Setup(DropZone originDropZone, Item i)
        {
            _item = i;
            gameObject.name = _item.GetName() + "_UI";
            myImage.sprite = i.MySprite;
            originalDropZone = originDropZone;
            originalDropZone.AddDraggable(this);

        }
    }
}