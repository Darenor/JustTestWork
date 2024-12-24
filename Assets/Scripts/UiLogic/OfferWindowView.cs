using System;
using System.Globalization;
using Scripts.Test;
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
    
    public void OpenOffer(OfferContainer offerContainer)
    {
        var price = offerContainer.GetPrice();
        if (offerContainer.id == OfferContainerId.Book)
        {
            price += 1;
        }
        
        _headerText.text = offerContainer.WindowHeader;
        _descriptionText.text = offerContainer.WindowDescription;
        _image.sprite = offerContainer.MainIcon;

        for (int i = 0; i < _resourceViews.Length; i++)
        {
            if (offerContainer.Resources.Length > i)
            {
                _resourceViews[i].Show(offerContainer.Resources[i]);
            }
            else
            {
                _resourceViews[i].Hide();
            }
        }
        
        _price.text = price.ToString(CultureInfo.CurrentCulture);

        if (!(offerContainer.Discount > 0f))
            return;
        _priceWithDiscount.text = offerContainer.PriceWithOutDiscount.ToString(CultureInfo.CurrentCulture);
        _discountAmount.text = offerContainer.Discount.ToString("P");
    }
    
    private void Buy() =>
        PriceButtonClicked?.Invoke();
}