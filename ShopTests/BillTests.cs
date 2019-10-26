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
            desk = new RegularGoods("School Desk");
            chair = new SalesGoods("Comfortable chair");
            pencil = new SpecialGoods("Cheap pencil");
            student = new Customer("Chumakoff", 0);
            basket = new Bill(student);
            //basket.addGoods(new Item(desk, 1, 65.99)); // one desk
            //basket.addGoods(new Item(chair, 4, 14.50)); // 4 chairs for student and his friends
            //basket.addGoods(new Item(pencil, 20, 0.39)); // a lot of cheap pencils 
            //cases.Add("mixed", basket);
            
        }
        

        [Test]
        public void goodsTest()
        {
            Goods g = new RegularGoods("test");
            Type myobj = typeof(RegularGoods);
            Assert.AreEqual(myobj, g.GetType());
        }

        [Test]
        public void mixedCheckoutTest()
        {
            basket.addGoods(new Item(desk, 1, 65.99)); // one desk
            basket.addGoods(new Item(chair, 4, 14.50)); // 4 chairs for student and his friends
            basket.addGoods(new Item(pencil, 20, 0.39)); // a lot of cheap pencils 
            string actual = basket.statement();
            string expected = "Счет для Chumakoff\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSchool Desk\t\t65,99\t1\t65,99\t0\t65,99\t3\n\tComfortable chair\t\t14,5\t4\t58\t0,58\t57,42\t0\n\tCheap pencil\t\t0,39\t20\t7,8\t0,04\t7,76\t0\nСумма счета составляет 131,17\nВы заработали 3 бонусных балов";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void regularSingleCheckoutTest()
        {
            basket.addGoods(new Item(desk, 1, 65.99)); // one desk for 65.99$        
            string actual = basket.statement();
            string expected = "Счет для Chumakoff\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSchool Desk\t\t65,99\t1\t65,99\t0\t65,99\t3\nСумма счета составляет 65,99\nВы заработали 3 бонусных балов";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void regularMultipleCheckoutTest()
        {
            basket.addGoods(new Item(desk, 3, 65.99)); // tree desks for 65.99$       
            string actual = basket.statement();
            string expected = "Счет для Chumakoff\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSchool Desk\t\t65,99\t3\t197,97\t5,94\t192,03\t9\nСумма счета составляет 192,03\nВы заработали 9 бонусных балов";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void saleSingleCheckoutTest()
        {
            basket.addGoods(new Item(chair, 1, 10)); // one chair for 10$
            string actual = basket.statement();
            string expected = "Счет для Chumakoff\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tComfortable chair\t\t10\t1\t10\t0\t10\t0\nСумма счета составляет 10\nВы заработали 0 бонусных балов";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void saleMultipleCheckoutTest()
        {
            basket.addGoods(new Item(chair, 5, 10)); // 5 chairs for 10$
            string actual = basket.statement();
            string expected = "Счет для Chumakoff\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tComfortable chair\t\t10\t5\t50\t0,5\t49,5\t0\nСумма счета составляет 49,5\nВы заработали 0 бонусных балов";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void saleMultipleExpensiveCheckoutTest()
        {
            basket.addGoods(new Item(chair, 5, 100)); // 5 chairs for 100$
            string actual = basket.statement();
            string expected = "Счет для Chumakoff\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tComfortable chair\t\t100\t5\t500\t5\t495\t5\nСумма счета составляет 495\nВы заработали 5 бонусных балов";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void specialCheckoutTest()
        {
            basket.addGoods(new Item(pencil, 5, 0.10)); // 5 pencils for 10 cents
            string actual = basket.statement();
            string expected = "Счет для Chumakoff\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCheap pencil\t\t0,1\t5\t0,5\t0\t0,5\t0\nСумма счета составляет 0,5\nВы заработали 0 бонусных балов";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void specialDiscountCheckoutTest()
        {
            basket.addGoods(new Item(pencil, 11, 0.10)); // 5 pencils for 10 cents
            string actual = basket.statement();
            string expected = "Счет для Chumakoff\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCheap pencil\t\t0,1\t11\t1,1\t0,01\t1,09\t0\nСумма счета составляет 1,09\nВы заработали 0 бонусных балов";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void specialExpenciveDiscountCheckoutTest()
        {
            basket.addGoods(new Item(desk, 20, 50)); // 20 desks for 50$
            string actual = basket.statement();
            string expected = "Счет для Chumakoff\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSchool Desk\t\t50\t20\t1000\t30\t970\t50\nСумма счета составляет 970\nВы заработали 50 бонусных балов";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void bonusWithdraw()
        {
            pencil = new SpecialGoods("Cheap pencil");
            student = new Customer("Chumakoff", 17);
            basket = new Bill(student);
            basket.addGoods(new Item(desk, 20, 50)); // 20 desks for 50$
            string actual = basket.statement();
            string expected = "Счет для Chumakoff\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSchool Desk\t\t50\t20\t1000\t30\t953\t50\nСумма счета составляет 953\nВы заработали 50 бонусных балов";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void negativeBonusWithdraw()
        {
            pencil = new SpecialGoods("Cheap pencil");
            student = new Customer("Chumakoff", 3000);
            basket = new Bill(student);
            basket.addGoods(new Item(desk, 20, 50)); // 20 desks for 50$
            string actual = basket.statement();
            string expected = "Счет для Chumakoff\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSchool Desk\t\t50\t20\t1000\t30\t0\t50\nСумма счета составляет 0\nВы заработали 50 бонусных балов";
            Assert.AreEqual(actual, expected);
        }

    }
}
