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

        public Outfit GetOutfit {  get { return _playerOutfit; } }
        public DropZone[] GetEquipSlots {  get { return _equipSlots; } }

        public DropZone GetEquipSlot(Outfit.OutfitParts o)
        {
            return _equipSlots[(int)o];
        } 
    
    

        private void Awake()
        {
            if (_playerOutfit == null)
                return;

            Setup(_playerOutfit);
        }

        void Setup(Outfit outfit)
        {
            var slots = outfit.GetOutfitSlots;
            string part = string.Empty;
            for (int i = 0; i < _equipSlots.Length; i++)
            {
                part = ((Outfit.OutfitParts)i).ToString();

                if (i >= (int)Outfit.OutfitParts.HAND_L)
                    part = "HAND";

                _equipSlots[i].draggableTag = part;
                _equipSlots[i].OnReceiveDraggable += slots[i].EquipItem;
                _equipSlots[i].OnRemoveDraggable += slots[i].UnequipItem;

                _equipSlots[i].AddDraggable(Utils.InstanceUI_Element(Equipable_UIPrefab, _equipSlots[i], _startingItem[i]));
            }
        }
    }
}