using System;
using System.Collections.Generic;

namespace Session22.Dapper.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string AddressText { get; set; }


    }
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public int AddressId { get; set; }
        public int PersonId { get; set; }
        public string AddressLine { get; set; }
    }
}
