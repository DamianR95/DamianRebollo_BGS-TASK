using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGS.ProgrammerTask.UI
{
    using UnityEngine;

    public class OpenInventory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _inventoryPanel;

        private void Start()
        {
            CloseInventory();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                ToggleInventory();
            }

            if (Input.GetKeyDown(KeyCode.Escape) && _inventoryPanel.activeSelf)
            {
                CloseInventory();
            }
        }

        void ToggleInventory()
        {
            _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
            UIHoverPopup.Instance.ClosePopUp();
        }

        void CloseInventory()
        {
            _inventoryPanel.SetActive(false);
            UIHoverPopup.Instance.ClosePopUp();

        }
    }

}
