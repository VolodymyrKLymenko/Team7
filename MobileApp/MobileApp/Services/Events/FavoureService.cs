using MobileApp.Models.Events;
using MobileApp.Services.LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Services.Events
{
    class FavoureService : ServiceBase
    {
        public FavoureService() : base()
        {
            prefix = "Event";
        }

        public async Task<int> AddItemAsync(EventResponse item)
        {
            var result = DependencyService.Get<EventsLiteDBService>().InsertEventToFavoure(item);

            return result;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var result = DependencyService.Get<EventsLiteDBService>().RemoveEventFromFavoure(id);

            return result;
        } 

        public async Task<IEnumerable<EventResponse>> GetItemsAsync(bool forceRefresh = false)
        {
            var result = DependencyService.Get<EventsLiteDBService>().GetFavoureEvents();

            return result ?? new List<EventResponse>();
        }
    }
}
