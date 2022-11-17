using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Features.Inventory.Items;
using UnityEngine;

namespace Tool
{


    internal static class ContentDataSourceLoader 
    {
        public static ItemConfig[] LoadItemConfigs(ResourcePath resourcePath)
        {
            var dataSource = ResourcesLoader.LoadObject<ItemConfigDataSource>(resourcePath);
            return dataSource== null ? Array.Empty<ItemConfig>():dataSource.ItemConfigs.ToArray();
        }
     
    }
}