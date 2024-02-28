namespace Common.Modules.ABAC
{
    // Enforces access control decisions made by the Policy Decision Point.
    public class PolicyEnforcementPoint
    {
        private PolicyDecisionPoint _pdp;

        public PolicyEnforcementPoint(PolicyDecisionPoint pdp)
        {
            _pdp = pdp;
        }

        // Enforces the decision for a given access request.
        public bool Enforce(Subject subject, Resource resource, Action action)
        {
            return _pdp.Decide(subject, resource, action);
        }
    }
}
