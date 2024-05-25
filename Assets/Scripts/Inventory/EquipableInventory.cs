using BGS.ProgrammerTask.UI;
using System.Collections;
using UnityEngine;
using BGS.ProgrammerTask.Utilities;
namespace BGS.ProgrammerTask.Inventory
{
    public class EquipableInventory : MonoBehaviour
    {
        [SerializeField]
        private DropZone[] _equipSlots;

        [SerializeField]
        private Equipable[] _startingItem;
        [SerializeField]
        private Outfit _playerOutfit;

        public GameObject Equipable_UIPrefab;

        private void Awake()
        {
            if (_playerOutfit == null)
                return;

            Setup(_playerOutfit);
        }

        void Setup(Outfit outfit)
        {
            var slots = outfit.GetOutfitSlots();

            for (int i = 0; i < _equipSlots.Length; i++)
            {
                _equipSlots[i].draggableTag = ((Outfit.OutfitParts)i).ToString();
                _equipSlots[i].OnReceiveDraggable += slots[i].EquipItem;
                _equipSlots[i].OnRemoveDraggable += slots[i].UnequipItem;

                _equipSlots[i].AddDraggable(Utils.InstanceUI_Element(Equipable_UIPrefab, _equipSlots[i], _startingItem[i]));
            }
        }
    }
}