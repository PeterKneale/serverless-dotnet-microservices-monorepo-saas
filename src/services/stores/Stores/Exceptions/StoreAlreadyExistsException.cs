using System;

namespace Stores.Exceptions
{
    public class StoreAlreadyExistsException: Exception
    {
        public StoreAlreadyExistsException(Guid id):base(message:$"store already exists {id}")
        {
            
        }
    }
}