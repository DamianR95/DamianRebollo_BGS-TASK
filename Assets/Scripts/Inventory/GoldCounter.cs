using BGS.ProgrammerTask.UI;
using BGS.ProgrammerTask.Utilities;
using System.Collections;
using UnityEngine;

namespace BGS.ProgrammerTask.Inventory
{
    public class GoldCounter : MonoBehaviour
    {
        [SerializeField]
        private int _gold;
        public System.Action<int> OnGoldAdded;
        public System.Action<int> OnGoldRemoved;

        private static GoldCounter instance;

        public static GoldCounter Instance => instance;
        private void Awake()
        {
            if(instance != null && instance != this) {
                Debug.LogWarning("A second GoldCounter is present.", gameObject);
                return;
            }
            instance = this;
        }

        public int GetGold { get { return _gold; } }

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

            _gold += amount;
            if (OnGoldAdded != null)
                Utils.CallAction(OnGoldAdded.GetInvocationList(), amount);
        }

        public void RemoveGold(int amount)
        {
            _gold -= amount;
            if (OnGoldRemoved != null)
                Utils.CallAction(OnGoldRemoved.GetInvocationList(), amount);
        }

    }
}