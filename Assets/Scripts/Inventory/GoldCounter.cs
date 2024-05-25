using BGS.ProgrammerTask.UI;
using BGS.ProgrammerTask.Utilities;
using System.Collections;
using UnityEngine;

namespace BGS.ProgrammerTask.Inventory
{
    public class GoldCounter : MonoBehaviour
    {
        [SerializeField]
        private int Gold;
        public System.Action<int> OnGoldAdded;
        public System.Action<int> OnGoldRemoved;

        public static GoldCounter instance;

        private void Awake()
        {
            if(instance != null && instance != this) {
                Debug.LogWarning("A second GoldCounter is present.", gameObject);
                return;
            }
            instance = this;
        }

        public int GetGold { get { return Gold; } }

        public static void _AddGold(int amount)
        {
            instance.AddGold(amount);
        }

        public static void _RemoveGold(int amount)
        {
            instance.RemoveGold(amount);
        }

        public void AddGold(int amount)
        {

            Gold += amount;
            if (OnGoldAdded != null)
                Utils.CallAction(OnGoldAdded.GetInvocationList(), amount);
        }

        public void RemoveGold(int amount)
        {
            Gold -= amount;
            if (OnGoldRemoved != null)
                Utils.CallAction(OnGoldRemoved.GetInvocationList(), amount);
        }

    }
}