using System.Collections;
using System.Collections.Generic;
using Features.Inventory.Items;
using UnityEngine;
[CreateAssetMenu(fileName = nameof(ItemConfigDataSource),menuName = "Configs/"+ nameof(ItemConfigDataSource))]
internal class ItemConfigDataSource : ScriptableObject
{
   [SerializeField] private ItemConfig[] _itemConfigs;

   public IReadOnlyList<ItemConfig> ItemConfigs => _itemConfigs;
}
