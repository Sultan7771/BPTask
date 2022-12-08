using GMAPI4;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    internal class TestServices
    {
        private IGymServices<object> service;

        public TestServices(IGymServices<object> service)
        {
            this.service = service;
        }

        internal List<object> ReadAll()
        {
            return service.GetAllRows();
        }

        internal object ReadById(int id)
        {
            return service.GetRowById(id);
        }

        internal void AddItem(object item)
        {
            service.AddRow(item);
        }

        internal bool UpdateItem(int id, object tempObject)
        {
            return service.UpdateRow(id, tempObject);
        }

        internal void DeleteItem(object tempObject)
        {
            service.DeleteRow(tempObject);
        }
    }
}