using PropertyChanged;
using System;

namespace Greenbook.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}