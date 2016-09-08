using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web2.Repository.Interfaces
{
    public interface IAnnonceRepository<T> : IDisposable
    {
        /// <summary>
        /// Adds a new item. The item needs a company as owner. The company needs to be verified before adding
        /// </summary>
        /// <param name="newItem"></param>
        T AddItem(T newItem);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="olditem"></param>
        /// <param name="updatedItem"></param>
        /// <returns></returns>
        T UpdateItem(T updatedItem);

        /// <summary>
        /// Gets a specific item.
        /// </summary>
        /// <param name="itemid"></param>
        /// <returns></returns>
        T GetItem(int itemid);

        /// <summary>
        /// Deletes an item. Should move it to a deleted database
        /// </summary>
        /// <param name="item"></param>
        void DeleteItem(T item);

        /// <summary>
        /// Gets all items belonging to a company
        /// </summary>
        /// <param name="vatnumber"></param>
        /// <returns></returns>
        List<T> GetItemsForCompany(string vatnumber);

        /// <summary>
        /// Gets all items sold by a company
        /// </summary>
        /// <param name="vatnumber"></param>
        /// <returns></returns>
        List<T> GetSoldItemsForCompany(string vatnumber);

        /// <summary>
        /// Gets all items deleted by a company
        /// </summary>
        /// <param name="vatnumber"></param>
        /// <returns></returns>
        List<T> GetDeletedItemsForCompany(string vatnumber);
    }
}
