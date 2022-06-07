using System;

namespace MarketWatch.Server.Exceptions
{

    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityName, int idEntity) : base(CustomMessage(entityName, idEntity))
        {
        }
        
        public EntityNotFoundException(string entityName, string parameter) : base(CustomMessage(entityName, parameter))
        {
        }
        private static string CustomMessage(string entityName, params object[] args)
        {
            return $"{entityName}({args}) not found";
        }
    }
}