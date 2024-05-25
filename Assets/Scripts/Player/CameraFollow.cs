using UnityEngine;

namespace BGS.ProgrammerTask.Player
{
    using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        public Transform target; // El objetivo que la cámara seguirá (en este caso, el jugador)
        public Vector3 offset; // Offset para ajustar la posición de la cámara en relación con el jugador
        public float smoothSpeed = 0.125f; // Velocidad de suavizado del movimiento de la cámara

        void LateUpdate()
        {
            // Posición deseada de la cámara
            Vector3 desiredPosition = target.position + offset;
            // Posición suavizada de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Actualizar la posición de la cámara
            transform.position = smoothedPosition;
        }
    }

}
