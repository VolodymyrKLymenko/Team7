using MobileApp.Models.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services.Events
{
    class EventsService : ServiceBase
    {
        public EventsService() : base()
        {
            prefix = "events";
        }

        public async Task<IEnumerable<EventResponse>> GetItemsAsync(bool forceRefresh = false)
        {
            var json = await Get("");

            if (!string.IsNullOrEmpty(json))
            {
                var result = Deserialize<IEnumerable<EventResponse>>(json);

                return result;
            }
            else
            {
                return new List<EventResponse>();
            }
        }
    }
}
