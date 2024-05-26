using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGS.ProgrammerTask.UI
{
    using BGS.ProgrammerTask.NPC;
    using BGS.ProgrammerTask.Utilities;
    using UnityEngine;

    public class OpenShop : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _shopPanel;
        [SerializeField]
        private OpenInventory _inventoryPanel;
        [SerializeField]
        private Interactable _interactable;
        private float fadeDuration = .1f;

        private void Start()
        {
            _interactable.OnInteract += OpenMenu;
            _shopPanel.gameObject.SetActive(false); 
        }

        private void OnDestroy()
        {
            _interactable.OnInteract -= OpenMenu;

        }
        void Update()
        {
            if ((Input.GetKeyDown(KeyCode.I) ||Input.GetKeyDown(KeyCode.Escape)) && _shopPanel.gameObject.activeSelf)
            {
                CloseMenu();
            }
            if(!_interactable.PlayerIsInRange && _shopPanel.gameObject.activeSelf)
            {
                CloseMenu();
            }
        }

        void OpenMenu()
        {
            StartCoroutine(Utils.FadeCanvasGroup(_shopPanel, 0f, 1f, fadeDuration));

            _inventoryPanel.OpenMenu();
        }

        void CloseMenu()
        {
            StartCoroutine(Utils.FadeCanvasGroup(_shopPanel, 1f, 0f, fadeDuration));

            _inventoryPanel.CloseMenu();
            UIHoverPopup.Instance.ClosePopUp();

        }
    }

}
