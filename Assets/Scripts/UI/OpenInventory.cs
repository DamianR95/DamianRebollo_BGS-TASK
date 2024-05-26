using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGS.ProgrammerTask.UI
{
    using BGS.ProgrammerTask.Utilities;
    using UnityEngine;

    public class OpenInventory : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _inventoryPanel;
        [SerializeField]
        private float _fadeDuration = .1f;

        private void Start()
        {
            _inventoryPanel.gameObject.SetActive(false);
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                ToggleMenu();
            }

            if (Input.GetKeyDown(KeyCode.Escape) && _inventoryPanel.gameObject.activeSelf)
            {
                CloseMenu();
            }
        }

        public void ToggleMenu()
        {
            // _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
            if (!_inventoryPanel.gameObject.activeSelf)
            {
                StartCoroutine(Utils.FadeCanvasGroup(_inventoryPanel, 0f, 1f, _fadeDuration));
            }
            else
            {
                StartCoroutine(Utils.FadeCanvasGroup(_inventoryPanel, 1f, 0f, _fadeDuration));
            }
            UIHoverPopup.Instance.ClosePopUp();
        }

        public void OpenMenu()
        {
            if (_inventoryPanel.gameObject.activeSelf)
                return;
            StartCoroutine(Utils.FadeCanvasGroup(_inventoryPanel, 0f, 1f, _fadeDuration));
        }
        public void CloseMenu()
        {
            // _inventoryPanel.SetActive(false);
            StartCoroutine(Utils.FadeCanvasGroup(_inventoryPanel, 1f, 0f, _fadeDuration));
            UIHoverPopup.Instance.ClosePopUp();

        }
    }

}
