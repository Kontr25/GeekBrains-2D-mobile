using UnityEngine;
using DefaultNamespace.Inventory.Configs;

namespace DefaultNamespace.Inventory.Interface
{
    public interface IItem
    {
        string Name { get; }
        Sprite Icon { get; }
        UpgadeType Type { get; }
    }
}