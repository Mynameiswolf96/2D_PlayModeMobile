using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Features.Inventory.Items
{

    internal interface IItemRepository
    {
        IReadOnlyDictionary<String,IItem> Items { get; }
    }

    internal class ItemsRepository : BaseRepository<string,IItem,ItemConfig>
    {
        public ItemsRepository(IEnumerable<ItemConfig> configs) : base(configs)
        {
        }

        protected override IItem CreateItem(ItemConfig config) => 
            new Item
        (
            config.Id,
            new ItemInfo(
                config.Title,
                config.Icon)
        );

        protected override string GetKey(ItemConfig config) => config.Id;
    }
}
