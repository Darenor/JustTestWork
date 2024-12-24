using UnityEngine;

public class OfferWindowCollectionController
{
    private readonly OffersCollection _offersData;
    private readonly OffersCollectiveView _offerWindowCollectiveView;

    public OfferWindowCollectionController(OffersCollection offersData, OffersCollectiveView offerWindowCollectiveView)
    {
        _offersData = offersData;
        _offerWindowCollectiveView = offerWindowCollectiveView;
    }
    public void Init()
    {
        _offerWindowCollectiveView.Show(_offersData);
    }
    public void Dispose()
    {
        _offerWindowCollectiveView.Dispose();
    }
}

