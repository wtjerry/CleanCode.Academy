// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderItemCollection.cs" company="bbv Software Services AG">
//   Copyright (c) 2021 bbv Software Services AG. All Rights Reserved.
//   Licensed under the Apache-2.0 License. See http://www.apache.org/licenses/LICENSE-2.0 for license information.
// </copyright>
// <summary>
//   Represents the basket of an customer with all his/her order items.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Fundamentals
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the shopping basket of an customer with all his/her order items.
    /// </summary>
    internal class OrderItemCollection
    {
        private string _customerName;

        /// <summary>
        /// The order items.
        /// </summary>
        internal List<OrderItem> OrderItems;

        /// <summary>
        /// The Constructor.
        /// </summary>
        /// <param name="customerName">customerName.</param>
        public OrderItemCollection(string customerName)
        {
            _customerName = customerName;
            this.OrderItems = new List<OrderItem>();
        }
    }
}