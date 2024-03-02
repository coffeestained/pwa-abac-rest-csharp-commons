using Common.Modules.ABAC;

namespace Common.Modules;

public class Route : IRoute {

    private Methods _method { get; set; }
    public Methods Method
    {
        get => _method;
        set => _method = value;
    }

    private string _endpoint { get; set; } 
    public string Endpoint
    {
        get => _endpoint;
        set => _endpoint = value;
    }

    private Dictionary<string, object> _bodyValidator { get; set; }
    public Dictionary<string, object> BodyValidator
    {
        get => _bodyValidator;
        set => _bodyValidator = value;
    }


    private Dictionary<string, object> _queryValidator { get; set; }
    public Dictionary<string, object> QueryValidator
    {
        get => _queryValidator;
        set => _queryValidator = value;
    }


    private Action<object, object> _handler { get; set; }
    public Action<object, object> Handler
    {
        get => _handler;
        set => _handler = value;
    }

    private bool _authenticated { get; set; }
    public bool Authenticated
    {
        get => _authenticated;
        set => _authenticated = value;
    }

    private List<ABAC.Attribute> _attributes { get; set; }
    public List<ABAC.Attribute> Attributes
    {
        get => _attributes;
        set => _attributes = value;
    }

    public Route(object config) {
        // Need to create configuration for routes
    }
}

interface IRoute {
    Methods Method { get; set; }
    string Endpoint { get; set; }
    Dictionary<string, object> BodyValidator { get; set; }
    Dictionary<string, object> QueryValidator { get; set; }
    Action<object, object> Handler { get; set; }
    List<ABAC.Attribute> Attributes { get; set; }
    bool Authenticated { get; set; }
}

public enum Methods {
    GET, POST, PATCH, PUT, DELETE, OPTIONS
}