using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopLib;
using System.IO;

namespace ShopForms
{
    public partial class Form1 : Form
    {
        private string View;
        private string FilePath;
        private Dictionary<RadioButton, string> views;
        
        public Form1()
        {
            InitializeComponent();
            views = new Dictionary<RadioButton, string>();
            views.Add(radioHTML, "HTML");
            views.Add(radioText, "TXT");
            View = "TXT";
            openFileDialog1.Filter = "YAML Files | *.yaml";
            saveFileDialog1.Filter = "Viewable docs | *.txt;*.html";
        }

        private void radioText_CheckedChanged(object sender, EventArgs e)
        {
            View = views[(RadioButton)sender];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            FilePath = openFileDialog1.FileName;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(FilePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            YAMLFile manager = new YAMLFile(sr, FilePath);
            BillGenerator res;
            switch (View)
            {
                case "TXT":
                    res = manager.getData(new TXTBuilder());
                    break;
                case "HTML":
                    res = manager.getData(new HTMLBuilder());
                    break;
                default:
                    throw new ArgumentException("no such view");
            }
            string output = res.createBill();
            sr.Close();
            fs.Close();
            saveFileDialog1.FileName = "bill." + View.ToLower();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string target = saveFileDialog1.FileName;
                if (File.Exists(target))
                {
                    File.Delete(target);
                }
                StreamWriter w = new StreamWriter(target);
                w.WriteLine(output);
                w.Close();
                MessageBox.Show("Чек успешно сохранен", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FilePath = "";
                button2.Enabled = false;
            }
        }
    }
}
