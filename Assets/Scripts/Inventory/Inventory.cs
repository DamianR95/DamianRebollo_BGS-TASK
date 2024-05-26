using BGS.ProgrammerTask.UI;
using BGS.ProgrammerTask.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BGS.ProgrammerTask.Inventory
{
    public class Inventory : MonoBehaviour
    {

        public GameObject Equipable_UIPrefab;

        [SerializeField]
        private DropZone _zone;

        [SerializeField]
        private Equipable[] _startingItem;
        public DropZone GetDropZone {  get { return _zone; } }

        protected virtual void Awake()
        {
            for (int i = 0; i < _startingItem.Length; i++)
            {
                _zone.AddDraggable(Utils.InstanceUI_Element(Equipable_UIPrefab, _zone, _startingItem[i]));
            }
        }
    }
}