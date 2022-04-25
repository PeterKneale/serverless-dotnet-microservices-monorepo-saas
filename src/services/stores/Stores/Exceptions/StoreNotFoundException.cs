using System;

namespace Stores.Exceptions
{
    public class StoreNotFoundException: Exception
    {
        public StoreNotFoundException(Guid id):base(message:$"store not found {id}")
        {
            
        }
    }
}