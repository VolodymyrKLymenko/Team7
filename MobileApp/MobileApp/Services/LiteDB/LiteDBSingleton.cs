using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Services.LiteDB
{
    public static class LiteDBSingleton
    {
        static LiteDBService liteDBService;

        public static LiteDBService Get()
        {
            if (liteDBService == null)
            {
                liteDBService = new LiteDBService();
            }

            return liteDBService;
        }
    }
}
