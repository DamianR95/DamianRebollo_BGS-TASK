using BGS.ProgrammerTask.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace BGS.ProgrammerTask.NPC
{
    public class InteractPopUpCaller : MonoBehaviour
    {
        [SerializeField]
        private Interactable _interactable;
        [SerializeField]
        private CanvasGroup _popupCanvasGroup;
        [SerializeField]
        private float fadeDuration = 0.5f;
        private void Awake()
        {
            _interactable.OnPlayerRangeChange += OnPlayerRangeChange;
            _popupCanvasGroup.gameObject.SetActive(false);
        }
        private void OnDestroy()
        {
            _interactable.OnPlayerRangeChange -= OnPlayerRangeChange;

        }

        private void OnPlayerRangeChange(bool isInRange)
        {
            if (isInRange)
            {
                ShowPopup();
            }else
            {
                HidePopup();
            }
        }


        void ShowPopup()
        {
            StartCoroutine(Utils.FadeCanvasGroup(_popupCanvasGroup, 0f, 1f, fadeDuration));
        }

        void HidePopup()
        {
            StartCoroutine(Utils.FadeCanvasGroup(_popupCanvasGroup, 1f, 0f, fadeDuration));
        }
    }
}

