using System;
using UnityEngine;

[Serializable]
public class OfferWindowData
{
    [field: SerializeField] public string WindowHeader { get; private set; }
    [field: SerializeField] public string WindowDescription { get; private set; }
    [field: SerializeField] public Resource[] Resources { get; private set; }
    [field: SerializeField] public float Price { get; private set; }
    [field: SerializeField, Range(0f, 1f)] public float Discount { get; private set; }
    [field: SerializeField] public Sprite MainIcon { get; private set; }
    
    public float PriceWithoutDiscount => Price * (1 + Discount);
    
}