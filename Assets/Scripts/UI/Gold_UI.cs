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

        [SerializeField]
        private GoldCounter GoldCounter;

        void Awake()
        {
            if (GoldCounter == null)
            {
                Debug.LogError("No Gold Counter Assigned.",gameObject);
            }
            GoldCounter.OnGoldAdded += RefreshGold;
            GoldCounter.OnGoldRemoved += RefreshGold;

        }

        private void RefreshGold(int obj)
        {
            UITextMeshPro.text = string.Format("GOLD: {0}", GoldCounter.GetGold);
        }
        private void OnDestroy()
        {
            GoldCounter.OnGoldAdded -= RefreshGold;
            GoldCounter.OnGoldRemoved -= RefreshGold;
        }
     
    }
}