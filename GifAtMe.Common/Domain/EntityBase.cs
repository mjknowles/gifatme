using System.Collections.Generic;

namespace GifAtMe.Common.Domain
{
    /// <summary>
    /// http://dotnetcodr.com/2013/09/16/a-model-net-web-service-based-on-domain-driven-design-part-2-ddd-basics/
    ///
    /// An entity is an object with a unique ID. This unique ID
    /// is the most important property of an entity: it helps distinguish
    /// between two otherwise identical objects.
    ///
    /// IdType can be an int, string, guid, etc.
    /// </summary>
    /// <typeparam name="IdType"></typeparam>
    public abstract class EntityBase<IdType>
    {
        public IdType Id { get; set; }

        // Use a list to store an entities broken business rules
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();

        // Define an equals methods so that calling objects
        // can determine if two entities are the same
        public override bool Equals(object entity)
        {
            return entity != null
                && entity is EntityBase<IdType>
                && this == (EntityBase<IdType>)entity; // use the defined equals operator
        }

        // Override gethashcode since we've overridden Equals. If two entities
        // are Equal, they must return the same HashCode value
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<IdType> entity1, EntityBase<IdType> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<IdType> entity1, EntityBase<IdType> entity2)
        {
            return (!(entity1 == entity2));
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        public IEnumerable<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        /// <summary>
        /// Entities need to validate themselves when insertions or updates are executed
        /// </summary>
        protected abstract void Validate();
    }
}