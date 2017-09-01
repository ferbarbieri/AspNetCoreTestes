using Newtonsoft.Json;
using System;

namespace Domain.Models
{
    public abstract class Entity : IEquatable<Entity>
    {
        /// <summary>
        /// Identificador da entidade
        /// </summary>
        [JsonProperty(Order = -2)] // Garante que será serializado primeiro
        public int Id { get; protected set; }

        [JsonIgnore] // Não deve serializar
        public bool IsDeleted { get; protected set; }

        [JsonIgnore] // Não deve serializar
        public DateTime CreationDate { get; protected set; }

        public void Delete()
        {
            IsDeleted = true;
        }

        protected Entity()
        {
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }

        public bool Equals(Entity obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
                return false;

            return Equals(obj as Entity);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}
