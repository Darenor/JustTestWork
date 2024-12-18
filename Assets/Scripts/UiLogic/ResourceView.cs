using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class ResourceView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _amount;
    public void Show(Resource resource)
    {
        gameObject.SetActive(true);
        _image.sprite = resource.sprite;
        _amount.text = resource.Count.ToString();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}