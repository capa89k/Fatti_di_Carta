using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatti_di_Carta.Utility
{
    class ReceiptItem
    {
        private int id;
        private string title;
        private decimal price;
        public ReceiptItem(int id, string title, decimal price)
        {
            this.id = id;
            this.title = title;
            this.price = price;
        }
        /// <summary>
        /// Access the ID field.
        /// </summary>
        public int Id
        {
            get => this.id;
        }
        /// <summary>
        /// Access the title field.
        /// </summary>
        public string Title
        {
            get => this.title;
        }
        /// <summary>
        /// Access the price field.
        /// </summary>
        public decimal Price
        {
            get => this.price;
        }
    }
}
