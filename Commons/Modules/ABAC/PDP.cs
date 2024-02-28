namespace Common.Modules.ABAC
{
    // Responsible for making access control decisions by evaluating policies.
    public class PolicyDecisionPoint
    {
        private List<Policy> _policies = new List<Policy>();

        public List<Policy> Policies { get => _policies; set => _policies = value; }

        // Decides whether access should be granted based on policies.
        public bool Decide(Subject subject, Resource resource, Action action)
        {
            foreach (var policy in Policies)
            {
                if (policy.Evaluate(subject, resource, action))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
