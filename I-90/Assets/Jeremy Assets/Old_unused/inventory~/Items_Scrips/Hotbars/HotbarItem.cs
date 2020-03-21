using UnityEngine;

namespace DapperDino.Items.Hotbars
{

    public abstract class HotbarItem : ScriptableObject
    {
        [Header("Basic Info")]
        [SerializeField] private Sprite icon = null;
        [SerializeField] private new string name = "New Hotbar Item Name";
        [SerializeField] private string itemdescription1 = "newDescription";


        public string Name => name;
        public abstract string ColouredName { get; }
        public Sprite Icon => icon;
        public string Item_Description => itemdescription1;


        public abstract string GetInfoDisplayText();
    }
}
