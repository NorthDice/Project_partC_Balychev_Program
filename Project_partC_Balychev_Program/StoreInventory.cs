using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partC_Balychev_Program
{

    public delegate void InventoryHandler(string message);

    public class StoreInventory : IEnumerable<StoreItem>, ICollection, Iinvoice
    {
        private List<StoreItem> items;

        private InventoryHandler? _del;

        public StoreInventory()
        {
            items = new List<StoreItem>();
            _del = (message) => Console.WriteLine(message);
        }

        public StoreInventory(List<StoreItem> item)
        {
            items = item;
            _del = (message) => Console.WriteLine(message);
        }

        public int Count => items.Count;

        public bool IsSynchronized => ((ICollection)items).IsSynchronized;

        public object SyncRoot => ((ICollection)items).SyncRoot;

        public StoreItem this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        public void Add(StoreItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");
            }

            _del.Invoke($"Item was succesfully adedd.");

            items.Add(item);
        }

        public void Clear()
        {
            if (!items.Any())
            {
                throw new ArgumentNullException();
            }
            _del.Invoke($"Removing {items.Count} items.");
            items.Clear();
        }

        public bool Contains(StoreItem item)
        {
            return items.Contains(item);
        }

        public void SortByPrice()
        {
            items.Sort((item1, item2) => item1.Price.CompareTo(item2.Price));
        }

        public StoreInventory Filtration(Func<StoreItem, bool> type)
        {
            return new StoreInventory(items.Where(type).ToList());
        }

        public IEnumerator<StoreItem> GetEnumerator()
        {
            return ((IEnumerable<StoreItem>)items).GetEnumerator();
        }

        public bool Remove(StoreItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");
            }

            if (!items.Contains(item))
            {
                throw new ArgumentException("Item not found in the inventory.", nameof(item));
            }

            _del.Invoke($"Item was succesfully removed.");
            return items.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)items).GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            items.CopyTo((StoreItem[])array, index);
        }

        public void RegisterHandler(InventoryHandler del)
        {
            _del = del;
        }

        public string GetStorageInfo()
        {
            string info = string.Empty;

            foreach (var item in items)
            {
                info += item.ToString() + '\n';
            }

            return info;
        }
    }
}