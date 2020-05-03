using System;
using System.Runtime.CompilerServices;

namespace MicroBank.Common.Models
{
    public class BaseEntity<T>
    {
        protected BaseEntity()
        {

        }
        protected BaseEntity(Action<object, string> lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        protected Action<object, string> LazyLoader { get; set; }

        public T Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }

    public static class PocoLoadingExtensions
    {
        public static TRelated Load<TRelated>(
            this Action<object, string> loader,
            object entity,
            ref TRelated navigationField,
            [CallerMemberName] string navigationName = null)
            where TRelated : class
        {
            loader?.Invoke(entity, navigationName);

            return navigationField;
        }
    }

}
