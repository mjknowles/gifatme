using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
