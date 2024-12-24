using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.Test
{
    using System;
    
    [Serializable]
    public class OfferContainer
    {
        public string name;
        public int id;

        public string WindowHeader;
        public string WindowDescription;
        public Resource[] Resources;
        [OnValueChanged(nameof(EditorCalculatePrice))]
        public float PriceWithOutDiscount;
#if UNITY_EDITOR
        [ReadOnly] 
        public float priceWithDiscount;
#endif
        [field: Range(0f, 1f)]
        [OnValueChanged(nameof(EditorCalculatePrice))]
        public float Discount;
        public Sprite MainIcon;
    
        public float GetPrice()
        {
            return Discount == 0 ? PriceWithOutDiscount : PriceWithOutDiscount * (1 - Discount);
        }
    
#if UNITY_EDITOR
        private void EditorCalculatePrice()
        {
            priceWithDiscount = GetPrice();
        }
#endif    
    }
}
