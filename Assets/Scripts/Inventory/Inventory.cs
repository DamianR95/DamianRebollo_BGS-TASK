using BGS.ProgrammerTask.UI;
using BGS.ProgrammerTask.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BGS.ProgrammerTask.Inventory
{
    public class Inventory : MonoBehaviour
    {


        private List<Item> _items = new List<Item>();

        public GameObject Equipable_UIPrefab;

        [SerializeField]
        private DropZone _zone;

        [SerializeField]
        private Equipable[] _startingItem;

        private void Awake()
        {

            for (int i = 0; i < _startingItem.Length; i++)
            {

                _zone.AddDraggable(Utils.InstanceUI_Element(Equipable_UIPrefab, _zone, _startingItem[i]));
            }
        }



    }
}