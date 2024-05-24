using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OutfitSlot
{
    [SerializeField]
    private SpriteRenderer _sprRenderer;

    private Equipable _equippedItem;


    //private void Awake()
    //{
    //    if (_sprRenderer == null)
    //        _sprRenderer = GetComponent<SpriteRenderer>(); 
    //}

    public Equipable EquipItem(Equipable newItem) {
        var oldItem = _equippedItem;
        _equippedItem = newItem;
        RefreshAppearance();
        return oldItem;
    }

    void RefreshAppearance()
    {
        _sprRenderer.sprite = _equippedItem.MySprite;
    }

}
