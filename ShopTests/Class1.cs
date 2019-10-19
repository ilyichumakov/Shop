using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Shop;

namespace ShopTests
{
    [TestFixture]
    public class Tests
    {
        Goods desk;
        Goods chair;
        Goods pencil;
        Customer student;
        Bill basket;

        [SetUp]
        public void CreateObjects()
        {
            desk = new Goods("School Desk", Goods.REGULAR);
            chair = new Goods("Comfortable chair", Goods.SALE);
            pencil = new Goods("Marker Blackboard", Goods.SPECIAL_OFFER);
            student = new Customer("Chumakoff", 0);
            basket = new Bill(student);
            basket.addGoods(new Item(desk, 1, 65.99)); // one desk
            basket.addGoods(new Item(chair, 4, 14.50)); // 4 chairs for student and his friends
            basket.addGoods(new Item(pencil, 20, 0.39)); // a lot of cheap pencils
            
        }
        

        [Test]
        public void GoodsTest()
        {            
            int type = desk.getPriceCode();
            Assert.AreEqual(type, 0);
        }

    }
}
