using DefaultNamespace.Inventory.Interface;
using UnityEngine;

namespace DefaultNamespace.Inventory.Configs
{
    [CreateAssetMenu(fileName = nameof(ItemConfig), menuName = "Inventory/Items")]
    public class ItemConfig: ScriptableObject, IItem
    {
        public string Name => _name;
        public Sprite Icon => _icon;

        public UpgadeType Type => _upgadeType;

        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private UpgadeType _upgadeType;
    }
}