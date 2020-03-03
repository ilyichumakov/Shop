using System;
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
            YAMLFile manager = new YAMLFile(sr);
            BillGenerator res = manager.getData(new TXTBuilder());
            return res.createBill();
        }
    }
}
