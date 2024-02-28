namespace Common.Modules.ABAC
{
    // Represents a generic attribute with a name and value.
    public class Attribute
    {
        private string _name;
        private string _value;

        public string Name { get => _name; set => _name = value; }
        public string Value { get => _value; set => _value = value; }
    }

    // Represents a subject (e.g., a user) with a list of attributes.
    public class Subject
    {
        private List<Attribute> _attributes = new List<Attribute>();

        public List<Attribute> Attributes { get => _attributes; set => _attributes = value; }
    }
}
