using BGS.ProgrammerTask.Inventory;
using System;
using System.Collections;
using UnityEngine;

namespace BGS.ProgrammerTask.UI
{
    public class Gold_UI : MonoBehaviour
    {
        [SerializeField]
        private TMPro.TextMeshProUGUI UITextMeshPro;


        void Start()
        {
            GoldCounter.Instance.OnGoldAdded += RefreshGold;
            GoldCounter.Instance.OnGoldRemoved += RefreshGold;

        }

        private void RefreshGold(int obj)
        {
            UITextMeshPro.text = string.Format("GOLD: {0}", GoldCounter.Instance.GetGold);
        }
        private void OnDestroy()
        {
            GoldCounter.Instance.OnGoldAdded -= RefreshGold;
            GoldCounter.Instance.OnGoldRemoved -= RefreshGold;
        }
     
    }
}