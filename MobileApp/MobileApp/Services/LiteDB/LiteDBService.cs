using LiteDB;
using MobileApp.Models.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Services.LiteDB
{
    public partial class LiteDBService : IDisposable
    {
        public readonly LiteDatabase dbContext;

        public ILiteCollection<EventResponse> FavoureEvents
        {
            get
            {
                return dbContext.GetCollection<EventResponse>("FavoureEvents");
            }
        }

        

        public LiteDBService()
        {
            try
            {
                var _dbContext = new LiteDatabase(App.dbConectionString);
                if (_dbContext != null)
                    dbContext = _dbContext;


                var mapper = BsonMapper.Global;
                mapper.TrimWhitespace = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Can't find or create LiteDb database.", ex);
            }
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
