internal class PlaceResourcesInStockpile : IState
{
    private readonly Patron _patron;

    public PlaceResourcesInStockpile(Patron gatherer)
    {
        _patron = gatherer;
    }

    public void Tick()
    {
        if (_patron.Take())
            _patron.StockPile.Add();
    }

    public void OnEnter() { }

    public void OnExit() { }
}