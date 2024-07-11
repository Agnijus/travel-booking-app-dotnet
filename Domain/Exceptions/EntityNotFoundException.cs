
namespace Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityName, object key)
           : base($"Entity {entityName} with key {key} was not found.")
        {
        }

        public EntityNotFoundException(string entityName)
            : base($"No entities of type {entityName} were found.")
        {
        }
    }
}
