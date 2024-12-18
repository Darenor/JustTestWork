using System;

public class StartController
{
    public event Action ShowCollectionIntent;
    
    private readonly StartModel _model;
    private readonly StartView _view;

    public StartController(StartModel model, StartView view)
    {
        _model = model;
        _view = view;
    }

    public void Init()
    {
        _view.InputFieldChanged += UpdateModel;
        _view.ShowButtonClicked += ShowOfferCollection;
        _view.Initialize();
    }
    private void ShowOfferCollection()
    {
        ShowCollectionIntent?.Invoke();
    }
    
    public void Hide()
    {
        _view.gameObject.SetActive(false);
    }

    public void Dispose()
    {
        _view.InputFieldChanged -= UpdateModel;
        _view.ShowButtonClicked -= ShowOfferCollection;
    }
    private void UpdateModel(int offerCount)
    {
        _model.OfferCount = offerCount;
    }
    
}