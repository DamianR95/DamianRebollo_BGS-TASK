using BGS.ProgrammerTask.Inventory;
using System;
using UnityEngine;

namespace BGS.ProgrammerTask.SFX
{
    public class GoldChange_SFX : MonoBehaviour
    {
        [SerializeField]
        private AudioSource sfx;
        void Start()
        {
            GoldCounter.Instance.OnGoldAdded += RefreshGold;
            GoldCounter.Instance.OnGoldRemoved += RefreshGold;
        }
        private void RefreshGold(int obj)
        {
            sfx.Play();
        }
        private void OnDestroy()
        {
            GoldCounter.Instance.OnGoldAdded -= RefreshGold;
            GoldCounter.Instance.OnGoldRemoved -= RefreshGold;
        }
    }
}

