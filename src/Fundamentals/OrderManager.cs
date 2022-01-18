// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderManager.cs" company="bbv Software Services AG">
//   Copyright (c) 2021 bbv Software Services AG. All Rights Reserved.
//   Licensed under the Apache-2.0 License. See http://www.apache.org/licenses/LICENSE-2.0 for license information.
// </copyright>
// <summary>
//   Manages everything related to orders.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundamentals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Manages everything related to orders.
    /// </summary>
    public class OrderManager
    {
        private Dictionary<string, OrderItemCollection> currentOrders = new();

        /// <summary>
        /// Creates and stores a new OrderItemCollection for the customer.
        /// </summary>
        /// <param name="customerName">Name of the customer.</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="customerName"/> is null.
        /// </exception>
        public void CreateNewOrder(string customerName)
        {
            // Check, if customer has already an open order.
            if (this.currentOrders.ContainsKey(customerName))
            {
                return;
            }

            this.currentOrders.Add(customerName, new OrderItemCollection(customerName));
        }

        /// <summary>
        /// Adds the <paramref name="orderItem"/> to the open order collection of customer
        /// <paramref name="customerName"/>.
        /// </summary>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="orderItem">The order item.</param>
        /// <exception cref="KeyNotFoundException">
        /// If there is no open order for customer <paramref name="customerName"/>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="customerName"/> is null.
        /// </exception>
        public void AddItemToOrder(string customerName, OrderItem orderItem)
        {
            this.currentOrders[customerName].OrderItems.Add(orderItem);
        }

        /// <summary>
        /// Calculates the price of all items in the basket of customer
        /// <paramref name="customerName"/>.
        /// </summary>
        /// <param name="customerName">Name of the customer.</param>
        /// <exception cref="KeyNotFoundException">
        /// If there is no open order for customer <paramref name="customerName"/>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="customerName"/> is null.
        /// </exception>
        /// <returns>
        /// The total price of all items ordered by customer.
        /// </returns>
        public decimal GetTotalPriceOfOrder(string customerName)
        {
            return this.currentOrders[customerName].OrderItems.Sum(orderItem => orderItem.Price);
        }
    }
}
