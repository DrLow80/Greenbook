using System.Collections.Generic;

namespace Greenbook.Entities
{
    public class Session
    {
        public string Name { get; set; }

        public List<Encounter> Encounters { get; set; } = new List<Encounter>();
    }
}