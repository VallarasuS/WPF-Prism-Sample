using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfoCapture.Sample.Data;
using InfoCapture.Sample.DataService;
using System.Linq;
using Moq;
using System.Collections.ObjectModel;

namespace InfoCapture.Sample.UnitTesting
{
    [TestClass]
    public class InfoCaptureTest
    {
        [TestMethod]
        public void TestSignUp()
        {
            var newUser = DataFactory.CreateCustomer(-1, "Jenny", "Bluto", "Jenny@Bluto.com", "0987654321");

            var svc = new InfoCaptureDataService();

            svc.AddCustomer(newUser);

            Assert.AreNotEqual(-1, newUser.CustomerID);
        }

        [TestMethod]
        public void TestLogin()
        {
            var newUser = DataFactory.CreateCustomer(-1, "Bluto", "Jenny", "Jenny@Bluto.com", "0987654321");

            var svc = new InfoCaptureDataService();

            svc.AddCustomer(newUser);

            var customer = svc.FindCustomer(newUser.FirstName);

            Assert.AreEqual(customer.FirstName, newUser.FirstName);
        }

        [TestMethod]
        public void TestOrders()
        {
            var svc = new InfoCaptureDataService();

            var product = svc.GetAllProducts().First();

            var quantity = product.Stock;

            var order = DataFactory.CreateOrder(-1, DataFactory.CreateCustomer(1), DateTime.Now, state: OrderState.Placed, prize: product.Prize);

            var entry = DataFactory.CreateOrderEntry(product, 1, null, order);
            order.Entries.Add(entry);

            svc.AddOrder(order);

            Assert.AreNotEqual(-1, order.OrderID);
        }

        [TestMethod]
        public void TestOrderSum()
        {
            var initStock = 3;
            var orderQuantity = 3;
            var prize = 2500;

            Mock<ICustomer> customer = new Mock<ICustomer>();
            customer.SetupAllProperties();

            Mock<IProduct> product = new Mock<IProduct>();
            product.SetupGet(p => p.Stock).Returns(initStock);
            product.SetupGet(p => p.Prize).Returns(prize);

            Mock<IOrder> order = new Mock<IOrder>();
            Mock<IOrderEntry> entry = new Mock<IOrderEntry>();
            entry.SetupGet(e => e.Quantity).Returns(orderQuantity);
            entry.SetupGet(e => e.Product).Returns(product.Object);

            order.SetupGet<ObservableCollection<IOrderEntry>>(o => o.Entries).Returns(new ObservableCollection<IOrderEntry>(new[] { entry.Object }));
            order.SetupGet(o => o.Prize).Returns(order.Object.Entries.Sum(e => e.Product.Prize * e.Quantity));

            Assert.AreEqual(order.Object.Prize , prize * orderQuantity);
        }
    }
}
