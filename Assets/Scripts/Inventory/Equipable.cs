using BGS.ProgrammerTask.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BGS.ProgrammerTask
{
    [CreateAssetMenu(fileName = "Equipable", menuName = "ScriptableObjects/Equipable", order = 1)]
    public class Equipable : Item
    {
        [SerializeField]
        private Outfit.OutfitParts _equipablePart;
        [SerializeField]
        private Sprite _equippedSpr;

        public Sprite GetEquipedSprite
        {
            get
            {
                if (_equippedSpr != null)
                    return _equippedSpr;
                else
                    return GetSprite;
            }
        }

        public virtual void Setup(string name, Sprite sprite, Sprite equipSprite)
        {
            base.Setup(name, sprite);
            _equippedSpr = equipSprite;
        }

        public Outfit.OutfitParts GetEquipablePart { get { return _equipablePart; } }
        public Outfit.OutfitParts SetEquippablePart { set { _equipablePart = value; } }
    }
}