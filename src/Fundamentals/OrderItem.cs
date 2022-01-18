// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderItem.cs" company="bbv Software Services AG">
//   Copyright (c) 2021 bbv Software Services AG. All Rights Reserved.
//   Licensed under the Apache-2.0 License. See http://www.apache.org/licenses/LICENSE-2.0 for license information.
// </copyright>
// <summary>
//   Describes the item of an order.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundamentals
{
    /// <summary>
    /// Describes the item of an order.
    /// </summary>
    public class OrderItem
    {
        private int id;
        private string title;
        private ItemType type;
        private decimal price;

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        /// <summary>
        /// Get or sets the type of the item.
        /// </summary>
        public ItemType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
    }

    /// <summary>
    /// Contains the different types of an item.
    /// </summary>
    public enum ItemType
    {
        /// <summary>
        /// Book items.
        /// </summary>
        Book,

        /// <summary>
        /// Something other.
        /// </summary>
        Other
    }
}