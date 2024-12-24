using System;
using Scripts.Test;
using UnityEngine;
using Random = UnityEngine.Random;

public class StartPoint : MonoBehaviour, IDisposable
{
    [SerializeField] private OfferContainerMap _offerContainer;
    [SerializeField] private OffersCollectiveView _prefabView;
    [SerializeField] private Transform _parentView;
    [SerializeField] private StartView _startView;
    private StartController _startController;
    private OfferWindowCollectionController _offerWindowCollectionController;
    private StartModel _startModel;

    private void Start()
    {
        _startModel = new StartModel();
        _startController = new StartController(_startModel, _startView);

        _startController.ShowCollectionIntent += ShowOfferCollection;
        
        _startController.Init();
    }
    private void ShowOfferCollection()
    {
        _startController.Hide();
        OffersCollectiveView instance = Instantiate(_prefabView, _parentView);
        
        var offerWindowDatas = new OfferContainer[_startModel.OfferCount];
        var collection = _offerContainer.value.collection;
        
        for (int i = 0; i < offerWindowDatas.Length; i++)
        {
            var randomValue = Random.Range(0, collection.Count);
            offerWindowDatas[i] = collection[randomValue];
        }


        OffersCollection offersCollection = new OffersCollection(offerWindowDatas);
        _offerWindowCollectionController = new OfferWindowCollectionController(offersCollection, instance);
        _offerWindowCollectionController.Init();
    }

    private void OnDestroy()
    {
        Dispose();
        _startController?.Dispose();
        _offerWindowCollectionController?.Dispose();

    }
    public void Dispose()
    {
        _startController.ShowCollectionIntent -= ShowOfferCollection;
    }
}
