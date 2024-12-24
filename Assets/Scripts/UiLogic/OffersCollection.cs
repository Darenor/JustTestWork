using System;
using Scripts.Test;
using UnityEngine;

[Serializable]
public class OffersCollection
{
    public readonly OfferContainer[] OfferWindowDatas;

    public OffersCollection(OfferContainer[] offerWindowDatas)
    {
        OfferWindowDatas = offerWindowDatas;
    }
}