using System;

namespace GifAtMe.Common.Domain
{
    /// <summary>
    /// Represents a business rule of the domain.
    /// Description useful for debugging and logging.
    /// </summary>
    public class BusinessRule
    {
        private string _ruleDescription;

        public BusinessRule(string ruleDescription)
        {
            _ruleDescription = ruleDescription;
        }

        public String RuleDescription
        {
            get
            {
                return _ruleDescription;
            }
        }
    }
}