namespace Common.Modules.ABAC
{
    // Represents an action being performed or requested on a resource.
    public class Action
    {
        private string _name;
        // Additional properties can be added to represent various aspects of the action.

        public string Name { get => _name; set => _name = value; }

        // Constructor
        public Action(string name)
        {
            _name = name;
        }

        // Additional methods and properties can be implemented as needed.
    }
}
