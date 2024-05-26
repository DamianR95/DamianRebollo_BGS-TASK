using BGS.ProgrammerTask.Inventory;
using BGS.ProgrammerTask.UI;
using System;
using UnityEngine;

namespace BGS.ProgrammerTask.SFX
{
    public class Equip_SFX : MonoBehaviour
    {
        [SerializeField]
        private AudioSource sfx;

        [SerializeField]
        private EquipableInventory _equipableInventory;
        void Start()
        {
            for (int i = 0; i < _equipableInventory.GetEquipSlots.Length; i++)
            {
                _equipableInventory.GetEquipSlots[i].OnReceiveDraggable += PlaySfx;
            }  
        }
        private void PlaySfx(Draggable d)
        {
            sfx.Play();
        }
        private void OnDestroy()
        {
            for (int i = 0; i < _equipableInventory.GetEquipSlots.Length; i++)
            {
                _equipableInventory.GetEquipSlots[i].OnReceiveDraggable -= PlaySfx;
            }
        }
    }
}

