using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class StartPoint : MonoBehaviour
{
    [SerializeField] private OfferWindowContainer[] _offerContainer;
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
        
        OfferWindowData[] offerWindowDatas = new OfferWindowData[_startModel.OfferCount.Value];
        
        for (int i = 0; i < offerWindowDatas.Length; i++)
        {
            offerWindowDatas[i] = _offerContainer[Random.Range(0, _offerContainer.Length)].OfferData;
        }


        OffersCollection offersCollection = new OffersCollection(offerWindowDatas);
        _offerWindowCollectionController = new OfferWindowCollectionController(offersCollection, instance);
        _offerWindowCollectionController.Init();
    }

    private void OnDestroy()
    {
        _startController.ShowCollectionIntent -= ShowOfferCollection;
        _startController.Dispose();
        _offerWindowCollectionController.Dispose();

    }
}
