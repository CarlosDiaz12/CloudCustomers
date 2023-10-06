using CloudCustomers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCustomers.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() =>
            new()
            {
                new User() {
                        Id = 1,
                        Name = "Carlos",
                        Address = new Address
                        {
                            Street = "123 Market St",
                            City = "SomeWhere",
                            ZipCode = "213124"
                        },
                        Email = "carlos.cedp@gmail.com"
                },
                 new User() {
                        Id = 1,
                        Name = "Carlos",
                        Address = new Address{
                            Street = "123 Market St",
                            City = "SomeWhere",
                            ZipCode = "213124"
                        },
                        Email = "carlos.cedp@gmail.com"
                 },
                 new User() {
                        Id = 1,
                        Name = "Carlos",
                        Address = new Address{
                            Street = "123 Market St",
                            City = "SomeWhere",
                            ZipCode = "213124"
                        },
                        Email = "carlos.cedp@gmail.com"
                 },
                };
    }
}
