using Common;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace DataAccess.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        private IDatabase myDatabase;
        public CacheRepository(string connectionString) {
            ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(connectionString);
            myDatabase = multiplexer.GetDatabase();
        }

        public List<MenuItem> GetMenus()
        {
            var myList = myDatabase.StringGet("menuitems");
            if (myList.IsNullOrEmpty)
                return new List<MenuItem>(); //empty list
            else
            {
                var myList_fromString = JsonConvert.DeserializeObject<List<MenuItem>>(myList);
                return myList_fromString;
            }
        }

        public void AddMenu( MenuItem  item)
        {
            var myList = GetMenus();//gets menus from cache
            myList.Add(item); //adding a menu to the list of existing menus
            string myjsonstring = JsonConvert.SerializeObject(myList);
            //ultimately storing back the updated list serialized
            myDatabase.StringSet("menuitems",myjsonstring);
        }
    }
}
