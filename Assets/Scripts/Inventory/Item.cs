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
        private Sprite _spr;
        [SerializeField]
        private int _value = 1;


        public string GetName () { return _name; }

        public virtual void Setup(string name, Sprite sprite)
        {
            _name = name;
            _spr = sprite;
        }

        public Sprite MySprite { get { return _spr; } }

        public virtual void Use()
        {

        }

    }
}
