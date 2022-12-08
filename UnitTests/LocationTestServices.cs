using GMAPI4;
using GMAPI4.Models;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    internal class LocationTestServices
    {
        private IGymServices<Location> service;

        public LocationTestServices(IGymServices<Location> service)
        {
            this.service = service;
        }

        internal List<Location> ReadAll()
        {
            return service.GetAllRows();
        }

        internal Location ReadById(int id)
        {
            return service.GetRowById(id);
        }

        internal void AddItem(Location location)
        {
            service.AddRow(location);
        }

        internal bool UpdateItem(int id, Location location)
        {
            return service.UpdateRow(id, location);
        }

        internal void DeleteItem(Location location)
        {
            service.DeleteRow(location);
        }
    }
}