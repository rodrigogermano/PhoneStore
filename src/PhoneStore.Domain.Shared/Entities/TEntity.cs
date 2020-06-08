using System;

namespace PhoneStory.Domain.Shared.Entities
{
    public abstract class TEntity
    {        
        protected TEntity()
        {            
            this.Created = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime Created { get; private set; }
    }
}
