using BGS.ProgrammerTask.Inventory;
using UnityEngine;
using UnityEngine.UI;
namespace BGS.ProgrammerTask.UI
{
    public class Item_UI : Draggable
    {
        [SerializeField]
        private Image _myImage;
        private Item _item;
        public Item GetItem { get { return _item; } }
        public virtual void Setup(DropZone originDropZone, Item i)
        {
            _item = i;
            gameObject.name = _item.GetName + "_UI";
            _myImage.sprite = i.GetSprite;
            originDropZone.AddDraggable(this);

        }
    }
}