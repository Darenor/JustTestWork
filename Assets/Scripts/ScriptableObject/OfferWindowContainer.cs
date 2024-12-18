using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "New Offer Window", menuName = "Offer Window Container", order = 51)]

public class OfferWindowContainer : ScriptableObject
{
    [field: SerializeField] public OfferWindowData OfferData { get; private set; }
}
