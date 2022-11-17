using System.Collections.Generic;

namespace Features.Inventory
{
    internal interface IInventoryModel
    {
        IReadOnlyList<string> EquippedItems { get; }
        void EquipItem(string itemId);
        void UnequipItem(string item);
        bool IsEquipped(string itemId);
    }


    internal class InventoryModel
    {
        private readonly List<string> _equipeddItems = new();
        private IReadOnlyList<string> EquippedItems => _equipeddItems;

        public void EquipItem(string itemId)
        {
            if (!IsEquipped(itemId))
            {
                _equipeddItems.Add(itemId);
            }
        }

        public void UnequipItem(string itemId)
        {
            if (IsEquipped(itemId))
            {
                _equipeddItems.Remove(itemId);
            }
        }

        public bool IsEquipped(string itemId) =>
            _equipeddItems.Contains(itemId);
    }
}
