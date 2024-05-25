
using BGS.ProgrammerTask.Utilities;
using System;
using UnityEngine;

namespace BGS.ProgrammerTask.NPC
{

    public class Interactable : MonoBehaviour
    {
        private bool isPlayerInRange = false;
        [SerializeField]
        public KeyCode _interactKey = KeyCode.E;

        public System.Action OnInteract;
        public System.Action<bool> OnPlayerRangeChange;

        public bool PlayerIsInRange => isPlayerInRange;
        void Update()
        {
            if (isPlayerInRange && Input.GetKeyDown(_interactKey))
            {
                Interact();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            isPlayerInRange = true;
            if (OnPlayerRangeChange != null)
                Utils.CallAction(OnPlayerRangeChange.GetInvocationList(), isPlayerInRange);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            isPlayerInRange = false;
            if (OnPlayerRangeChange != null)
                Utils.CallAction(OnPlayerRangeChange.GetInvocationList(), isPlayerInRange);
        }

        private void Interact()
        {
            if (OnInteract != null)
                Utils.CallAction(OnInteract.GetInvocationList());
        }
    }

}
