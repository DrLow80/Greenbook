﻿using System.Collections.Generic;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.Sessions
{
    public class EncountersViewModel : BaseListViewModel<Encounter>
    {
        private Session _session;

        public EncountersViewModel(Session session)
        {
            _session = session;

            foreach (var encounter in session.Encounters)
            {
                Items.Add(encounter);
            }
        }

        protected override IEnumerable<Encounter> GetItems()
        {
            return _session.Encounters;
        }

        protected override void OnAdd(Encounter obj)
        {
            base.OnAdd(obj);

            _session.Encounters.Add(obj);
        }

        protected override void OnRemove(Encounter obj)
        {
            base.OnRemove(obj);

            _session.Encounters.Remove(obj);
        }

        protected override void OnInsert(object obj)
        {
            Encounter encounter = new Encounter();

            OnAdd(encounter);
        }
    }
}