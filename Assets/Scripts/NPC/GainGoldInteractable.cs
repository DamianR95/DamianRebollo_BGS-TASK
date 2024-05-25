using BGS.ProgrammerTask.Inventory;
using System.Collections;
using UnityEngine;

namespace BGS.ProgrammerTask.NPC
{
    public class GainGoldInteractable : MonoBehaviour
    {
        [SerializeField]
        private Interactable _interactable;
        [SerializeField]
        public int _goldGain = 20;

        private void Awake()
        {
            _interactable.OnInteract += GetGold;

        }
        private void OnDisable()
        {
            _interactable.OnInteract -= GetGold;

        }

        private void GetGold()
        {
            GoldCounter.Instance.AddGold(_goldGain);
        }
    }
}

