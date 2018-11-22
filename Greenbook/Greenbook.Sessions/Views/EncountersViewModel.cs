using System.Collections.Generic;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.Sessions
{
    public class EncountersViewModel : BaseListViewModel<Encounter>
    {
        private readonly Session _session;

        public EncountersViewModel(Session session)
        {
            _session = session;

            foreach (var encounter in session.Encounters) Items.Add(encounter);
        }

        protected override IEnumerable<Encounter> GetItems()
        {
            return _session.Encounters;
        }

        protected override void OnAdd(Encounter obj)
        {
            base.OnAdd(obj);

            _session.Encounters.Add(obj);

            OnPropertyChanged(nameof(Items));
        }

        protected override void OnRemove(Encounter obj)
        {
            base.OnRemove(obj);

            _session.Encounters.Remove(obj);

            OnPropertyChanged(nameof(Items));
        }

        protected override void OnInsert(object obj)
        {
            var encounter = new Encounter();

            OnAdd(encounter);
        }
    }
}