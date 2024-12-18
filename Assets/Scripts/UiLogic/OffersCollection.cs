using System;
using UnityEngine;

[Serializable]
public class OffersCollection
{
    public readonly OfferWindowData[] OfferWindowDatas;

    public OffersCollection(OfferWindowData[] offerWindowDatas)
    {
        OfferWindowDatas = offerWindowDatas;
    }
}