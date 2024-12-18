using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OfferWindowView : MonoBehaviour
{
    public event Action PriceButtonClicked;
    
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _priceWithDiscount;
    [SerializeField] private TextMeshProUGUI _discountAmount;
    [SerializeField] private GameObject _discount;
    [SerializeField] private Button _priceButton;
    [SerializeField] private ResourceView[] _resourceViews;

    public void Init() =>
        _priceButton.onClick.AddListener(Buy);
    public void Dispose() =>
        _priceButton.onClick.RemoveListener(Buy);
    
    public void OpenOffer(OfferWindowData offerWindowData)
    {
        _headerText.text = offerWindowData.WindowHeader;
        _descriptionText.text = offerWindowData.WindowDescription;
        _image.sprite = offerWindowData.MainIcon;

        for (int i = 0; i < _resourceViews.Length; i++)
        {
            if (offerWindowData.Resources.Length > i)
            {
                _resourceViews[i].Show(offerWindowData.Resources[i]);
            }
            else
            {
                _resourceViews[i].Hide();
            }
        }

        _price.text = $"{offerWindowData.Price}";

        if (offerWindowData.Discount > 0f)
        {
            _priceWithDiscount.text = $"{offerWindowData.PriceWithoutDiscount}";
            _discountAmount.text = $"{offerWindowData.Discount:P}";
        }
    }
    
    private void Buy() =>
        PriceButtonClicked?.Invoke();
}