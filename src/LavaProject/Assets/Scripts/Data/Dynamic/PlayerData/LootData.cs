using System;

namespace Data.Dynamic.PlayerData
{
    [Serializable]
    public class LootData
    {
        public event Action IsAmountChanged;
        public int Collected;
        
        public void Collect(int amount)
        {
            Collected += amount;
            IsAmountChanged?.Invoke();
        }
    }
}