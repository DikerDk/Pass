using Shoping.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DAL.IRepositories
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(int id);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiceItem(int id);
    }
}
