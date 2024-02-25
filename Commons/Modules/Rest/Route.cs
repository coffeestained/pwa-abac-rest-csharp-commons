using static Common.Globals.Utils;

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

    private Dictionary<string, Validator> _bodyValidator { get; set; }
    public Dictionary<string, Validator> BodyValidator
    {
        get => _bodyValidator;
        set => _bodyValidator = value;
    }


    private Dictionary<string, Validator> _queryValidator { get; set; }
    public Dictionary<string, Validator> QueryValidator
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


    public Route(object config) {

    }
}

interface IRoute {
    private Methods Method { get; set; }
    private string Endpoint { get; set; }
    private Dictionary<string, Validator>? BodyValidator { get; set; }
    private Dictionary<string, Validator>? QueryValidator { get; set; }
    private Action<object, object> Handler { get; set; }
}

enum Methods {
    GET, POST, PATCH, PUT, DELETE, OPTIONS
}