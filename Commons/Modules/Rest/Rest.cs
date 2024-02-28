namespace Common.Modules;

class Rest : IRest {
    private Route[] _routes;
    public Route[] Routes
    {
        get => _routes;
        set => _routes = value;
    }

    public Rest() 
    {

    }
}

interface IRest {
    Route[] Routes { get; set; }
}