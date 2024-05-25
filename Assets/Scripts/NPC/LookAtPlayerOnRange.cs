using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BGS.ProgrammerTask.NPC
{
    public class LookAtPlayerOnRange : MonoBehaviour
    {
        [SerializeField]
        private Transform _pivotToRotate;
        [SerializeField]
        private Interactable _interactable;
        [SerializeField]
        public Transform _player;
        [SerializeField]
        public float _lerpSpeed = 15f;

        private bool isPlayerInRange = false;
        private float targetScaleX;
        private bool isRotating;

        private void Awake()
        {
            _interactable.OnPlayerRangeChange += OnPlayerRangeChange;
            targetScaleX = _pivotToRotate.localScale.x;

        }

        private void OnPlayerRangeChange(bool isInRange)
        {
            isPlayerInRange = isInRange;

        }
      


        void Update()
        {
            if (!isPlayerInRange) 
                return;

            if (_player.position.x < transform.position.x)
            {
                targetScaleX = -1;
            }
            else if (_player.position.x > transform.position.x)
            {
                targetScaleX = 1;
            }

            if (!isRotating)
            {
                StartCoroutine(RotateToTarget());
            }
        }
        private IEnumerator RotateToTarget()
        {
            isRotating = true;

            while (Mathf.Abs(transform.localScale.x - targetScaleX) > 0.01f)
            {
                float newScaleX = Mathf.Lerp(_pivotToRotate.localScale.x, targetScaleX, Time.deltaTime * _lerpSpeed);
                _pivotToRotate.localScale = new Vector3(newScaleX, _pivotToRotate.localScale.y, _pivotToRotate.localScale.z);
                yield return null;
            }

            _pivotToRotate.localScale = new Vector3(targetScaleX, transform.localScale.y, transform.localScale.z);
            isRotating = false;
        }
    }
}

