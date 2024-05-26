using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace BGS.ProgrammerTask.Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
    public class Item : ScriptableObject
    {
        [SerializeField]
        private string _name = "Item";
        [SerializeField]
        private string _desc = "This is an item.";
        [SerializeField]
        private Sprite _spr;
        [SerializeField]
        private int _value = 1;

        public string GetName { get { return _name; } }
        public string GetDescription { get { return _desc; } }
        public Sprite GetSprite { get { return _spr; } }
        public int GetValue { get { return _value; } }

        public void Setup(string name, Sprite sprite)
        {
            _name = name;
            _spr = sprite;
        }
        public virtual void Use()
        {

        }

    }
}
