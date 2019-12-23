﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Shop
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filename = "BillInfo.yaml";
            if (args.Length == 1)
                filename = args[0];
            
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            YAMLFile manager = new YAMLFile(sr, filename);
            BillGenerator res = manager.getData(new TXTBuilder());
            Console.WriteLine(res.createBill());
            sr.Close();
            fs.Close();
            Console.ReadKey();
        }

        public static string makeBill(TextReader sr)
        {
            //FileStream fs = new FileStream(filename, FileMode.Open);
            //StreamReader sr = new StreamReader(fs);

            // read customer
            string line = sr.ReadLine();
            string[] result = line.Split(':');
            string name = result[1].Trim();
            // read bonus
            line = sr.ReadLine();
            result = line.Split(':');
            int bonus = Convert.ToInt32(result[1].Trim());
            Customer customer = new Customer(name, bonus);
            BillGenerator b = new BillGenerator(customer, new TXTBuilder());
            line = sr.ReadLine();
            result = line.Split(':');
            int goodsQty = Convert.ToInt32(result[1].Trim());
            Goods[] g = new Goods[goodsQty];
            for (int i = 0; i < g.Length; i++)
            {
                do
                {
                    line = sr.ReadLine();
                } while (line.StartsWith("#"));
                result = line.Split(':');
                result = result[1].Trim().Split();
                string type = result[1].Trim();

                switch (type)
                {
                    case "REG":
                        g[i] = new RegularGoods(result[0]);
                        break;
                    case "SAL":
                        g[i] = new SalesGoods(result[0]);
                        break;
                    case "SPO":
                        g[i] = new SpecialGoods(result[0]);
                        break;
                }
            }
            do
            {
                line = sr.ReadLine();
            } while (line.StartsWith("#"));
            result = line.Split(':');
            int itemsQty = Convert.ToInt32(result[1].Trim());
            for (int i = 0; i < itemsQty; i++)
            {
                do
                {
                    line = sr.ReadLine();
                } while (line.StartsWith("#"));
                result = line.Split(':');
                result = result[1].Trim().Split();
                int gid = Convert.ToInt32(result[0].Trim());
                double price = Convert.ToDouble(result[1].Trim());
                int qty = Convert.ToInt32(result[2].Trim());
                b.addGoods(new Item(g[gid - 1], qty, price));
            }
            string bill = b.createBill();
            return bill;
        }
    }
}
