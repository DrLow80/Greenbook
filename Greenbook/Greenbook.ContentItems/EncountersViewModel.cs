using System.Collections.Generic;
using Greenbook.Domain;
using Greenbook.Entities;

namespace Greenbook.ContentItems
{
    public class EncountersViewModel : BaseListViewModel<Encounter>
    {
        private ContentItem _contentItem;

        public EncountersViewModel(ContentItem contentItem)
        {
            _contentItem = contentItem;

            foreach (var encounter in contentItem.Encounters)
            {
                Items.Add(encounter);
            }
        }

        protected override IEnumerable<Encounter> GetItems()
        {
            return _contentItem.Encounters;
        }

        protected override void OnAdd(Encounter obj)
        {
            base.OnAdd(obj);

            _contentItem.Encounters.Add(obj);
        }

        protected override void OnRemove(Encounter obj)
        {
            base.OnRemove(obj);

            _contentItem.Encounters.Remove(obj);
        }

        protected override void OnInsert(object obj)
        {
            Encounter encounter = new Encounter();

            OnAdd(encounter);
        }
    }
}