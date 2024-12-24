using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class OfferWindowData
{
    [field: SerializeField] public string WindowHeader { get; private set; }
    [field: SerializeField] public string WindowDescription { get; private set; }
    [field: SerializeField] public Resource[] Resources { get; private set; }
    [field: SerializeField, OnValueChanged(nameof(EditorCalculatePrice))]
    public float PriceWithOutDiscount { get; private set; }
#if UNITY_EDITOR
    [ReadOnly] 
    public float priceWithDiscount;
#endif
    [field: SerializeField, Range(0f, 1f), OnValueChanged(nameof(EditorCalculatePrice))]
    public float Discount { get; private set; }
    [field: SerializeField] public Sprite MainIcon { get; private set; }
    
    public float GetPrice()
    {
        return Discount == 0 ? PriceWithOutDiscount : PriceWithOutDiscount * Discount;
    }
    
#if UNITY_EDITOR
    private void EditorCalculatePrice()
    {
        priceWithDiscount = GetPrice();
    }
#endif    
}