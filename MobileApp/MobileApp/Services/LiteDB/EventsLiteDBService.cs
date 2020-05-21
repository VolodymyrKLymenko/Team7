using LiteDB;
using MobileApp.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services.LiteDB
{
    class EventsLiteDBService : ServiceBase
    {
        public int InsertEventToFavoure(EventResponse _event)
        {
            var collection = liteContext.FavoureEvents;

            var result = collection.Insert(_event);

            return result;
        }

        public bool RemoveEventFromFavoure(int eventId)
        {
            var collection = liteContext.FavoureEvents;

            var result = collection.Delete(new BsonValue(eventId));

            return result;
        }

        public IEnumerable<EventResponse> GetFavoureEvents()
        {
            var collection = liteContext.FavoureEvents;

            return collection.FindAll();
        }

        public int RemoveAll()
        {
            var collection = liteContext.FavoureEvents;

            var result = collection.DeleteMany(_ => true);

            return result;
        }
    }
}
