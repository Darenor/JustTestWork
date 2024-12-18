using UnityEngine;

public class OffersCollectiveView : MonoBehaviour
{
    [SerializeField] private OfferWindowView _prefab;
    [SerializeField] private Transform _parent;

    public void Show(OffersCollection collection)
    {
        foreach (OfferWindowData offerWindowData in collection.OfferWindowDatas)
        {
            OfferWindowView instance = Instantiate(_prefab, _parent);
            instance.OpenOffer(offerWindowData);
        }
    }
    public void Dispose()
    {
        
    }
}