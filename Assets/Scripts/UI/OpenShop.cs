using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGS.ProgrammerTask.UI
{
    using BGS.ProgrammerTask.NPC;
    using UnityEngine;

    public class OpenShop : MonoBehaviour
    {
        [SerializeField]
        private GameObject _shopPanel;
        [SerializeField]
        private GameObject _inventoryPanel;
        [SerializeField]
        private Interactable _interactable;
        private void Start()
        {
            _interactable.OnInteract += OpenMenu;
            CloseMenu();
        }

        private void OnDestroy()
        {
            _interactable.OnInteract -= OpenMenu;

        }
        void Update()
        {
            if ((Input.GetKeyDown(KeyCode.I) ||Input.GetKeyDown(KeyCode.Escape)) && _shopPanel.activeSelf)
            {
                CloseMenu();
            }
            if(!_interactable.PlayerIsInRange && _shopPanel.activeSelf)
            {
                CloseMenu();
            }
        }

        void OpenMenu()
        {
            _shopPanel.SetActive(true);
            _inventoryPanel.SetActive(true);
        }

        void CloseMenu()
        {
            _shopPanel.SetActive(false);
            _inventoryPanel.SetActive(false);
            UIHoverPopup.Instance.ClosePopUp();

        }
    }

}
