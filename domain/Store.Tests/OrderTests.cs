﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests
{
    
    public class OrderTests
    {

        [Fact]
        public void Order_WithNullItems_ThrowsArgumentNullException()
        {
           Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }


        [Fact]
        public void TotalCount_WithEmptyItems_ReturrnZero()
        {
            var order = new Order(1, new OrderItem[0]);
            Assert.Equal(0, order.TotalCount);
        }


        [Fact]
        public void TotalPrice_WithEmptyItems_ReturrnZero()
        {
            var order = new Order(1, new OrderItem[0]);
            Assert.Equal(0m, order.TotalPrice);
        }


        [Fact]
        public void TotalCount_WithNonEmptyItems_CalculateToaolCount()
        {
            var order = new Order(1, new[]
            {
            new OrderItem(1,3,10m),
            new OrderItem(2,5,100m),
            });
            Assert.Equal(3 + 5, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithNonEmptyItems_CalculateToaolCount()
        {
            var order = new Order(1, new[]
            {
            new OrderItem(1,3,10m),
            new OrderItem(2,5,100m),
            });
            Assert.Equal(3 * 10m + 5*100m, order.TotalPrice);
        }

        [Fact]
        public void GetItem_WithNonExistingItem_ThrowsInvalidOperationException()
        {

            var order = new Order(1, new[]
            {
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });


            Assert.Throws<InvalidOperationException>(() =>
            {
                order.GetItem(100);
            });
        }

        [Fact]
        public void AddOrUpdateItem_WithExistingItem_UpdatesCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });

            var book = new Book(1, null, null, null, null, 0m);

            // добавление 10 книг с ID = 1 
            order.AddOrUpdateItem(book, 10);

            Assert.Equal(13,order.GetItem(1).Count);
        }


        [Fact]
        public void AddOrUpdateItem_WithNonExistingItem_AddCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });

            var book = new Book(3, null, null, null, null, 0m);

            // добавление 20 книг с ID = 3 
            order.AddOrUpdateItem(book, 20);

            Assert.Equal(20, order.GetItem(3).Count);
        }

        [Fact]
        public void RemoveItem_WithNonExistingItem_ThrowsInvalidOperationException()
        {

            var order = new Order(1, new[]
            {
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });


            Assert.Throws<InvalidOperationException>(() =>
            {
                order.RemoveItem(3);
            });
        }

        [Fact]
        public void RemoveItem_WithExistingItem_RemoveItems()
        {

            var order = new Order(1, new[]
            {
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });

            order.RemoveItem(1);

            Assert.Equal(1, order.Items.Count);
        }

    }
}
