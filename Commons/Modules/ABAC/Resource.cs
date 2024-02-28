namespace Common.Modules.ABAC
{
    // Represents a resource with various attributes for access control decisions.
    public class Resource
    {
        private string _id;
        private string _type;
        // Additional properties can be added as needed.

        public string Id { get => _id; set => _id = value; }
        public string Type { get => _type; set => _type = value; }

        // Constructor
        public Resource(string id, string type)
        {
            _id = id;
            _type = type;
        }

        // Additional methods and properties can be implemented as needed.
    }
}
