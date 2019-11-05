using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkout;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test_Single()
        {
            CheckoutMain instance = new CheckoutMain();

            Item input = new Item();
            input.Name = "A";
            instance.Scan(input);

            Assert.AreEqual(50, instance.Total());
        }

        [TestMethod]
        public void Test_MultipleSingle()
        {
            CheckoutMain instance = new CheckoutMain();

            Item input1 = new Item();
            input1.Name = "A";
            instance.Scan(input1);

            Item input2 = new Item();
            input2.Name = "B";
            instance.Scan(input2);

            Item input3 = new Item();
            input3.Name = "C";
            instance.Scan(input3);

            Assert.AreEqual(100, instance.Total());
        }

        [TestMethod]
        public void Test_Discount()
        {
            CheckoutMain instance = new CheckoutMain();

            Item input1 = new Item();
            input1.Name = "A";
            instance.Scan(input1);

            Item input2 = new Item();
            input2.Name = "A";
            instance.Scan(input2);

            Item input3 = new Item();
            input3.Name = "A";
            instance.Scan(input3);

            Assert.AreEqual(130, instance.Total());
        }

        [TestMethod]
        public void Test_DiscountWithRemainders()
        {
            CheckoutMain instance = new CheckoutMain();

            Item input1 = new Item();
            input1.Name = "A";
            instance.Scan(input1);

            Item input2 = new Item();
            input2.Name = "A";
            instance.Scan(input2);

            Item input3 = new Item();
            input3.Name = "A";
            instance.Scan(input3);

            Item input4 = new Item();
            input4.Name = "A";
            instance.Scan(input4);

            Assert.AreEqual(180, instance.Total());
        }

        [TestMethod]
        public void Test_MultipleDiscounts()
        {
            CheckoutMain instance = new CheckoutMain();

            Item input1 = new Item();
            input1.Name = "A";
            instance.Scan(input1);

            Item input2 = new Item();
            input2.Name = "A";
            instance.Scan(input2);

            Item input3 = new Item();
            input3.Name = "A";
            instance.Scan(input3);

            Item input4 = new Item();
            input4.Name = "B";
            instance.Scan(input4);

            Item input5 = new Item();
            input5.Name = "B";
            instance.Scan(input5);

            Assert.AreEqual(175, instance.Total());
        }

        [TestMethod]
        public void Test_MultipleDiscountsWithRemainders()
        {
            CheckoutMain instance = new CheckoutMain();

            Item input1 = new Item();
            input1.Name = "A";
            instance.Scan(input1);

            Item input2 = new Item();
            input2.Name = "A";
            instance.Scan(input2);

            Item input3 = new Item();
            input3.Name = "A";
            instance.Scan(input3);

            Item input4 = new Item();
            input4.Name = "B";
            instance.Scan(input4);

            Item input5 = new Item();
            input5.Name = "B";
            instance.Scan(input5);

            Item input6 = new Item();
            input6.Name = "B";
            instance.Scan(input6);

            Assert.AreEqual(205, instance.Total());
        }

        [TestMethod]
        public void Test_BadItem()
        {
            CheckoutMain instance = new CheckoutMain();

            Item input1 = new Item();
            input1.Name = "A";
            instance.Scan(input1);

            Item input2 = new Item();
            input2.Name = "Failing";
            instance.Scan(input2);

            Assert.AreEqual(50, instance.Total());
        }
    }
}
