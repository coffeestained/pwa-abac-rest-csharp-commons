namespace Commons.Modules;

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
    private Route[] Routes { get; set; }
}