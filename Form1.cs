using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_3_g
{
    public partial class Form1 : Form
    {
        public string[] strings = new string[14]
        {
            "Fist line",
            "Second line",
            "Third line",
            "Fourth line",
            "Fifth line",
            "Sixth line",
            "Seventh line",
            "Eighth line",
            "Ninth line",
            "Tenth line",
            "Eleven line",
            "Twelve line",
            "Thirteenth line",
            "Forteenth line"
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void writeBtn_Click(object sender, EventArgs e)
        {
            StreamWriter fileStream = new StreamWriter("strings.txt", false);
            foreach(string s in strings)
            {
                fileStream.WriteLine(s);
            }
            fileStream.Close();
        }

        private string[] readFromFile(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            List<string> strings = new List<string>();

            while(reader.Peek() != -1)
            {
                strings.Add(reader.ReadLine());
            }
            reader.Close();

            return strings.ToArray();
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox.CreateGraphics();
            string[] strings = readFromFile("strings.txt");

            Font font1 = new Font("Imprint MT Shadow", 24, FontStyle.Regular);
            Font font2 = new Font("Arial Black", 18, FontStyle.Bold);
            Font font3 = new Font("Corbel", 66, FontStyle.Italic);

            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            StringBuilder stringBuilder3 = new StringBuilder();

            StringFormat stringFormat1 = new StringFormat();
            stringFormat1.Alignment = StringAlignment.Near;
            stringFormat1.LineAlignment = StringAlignment.Far;

            StringFormat stringFormat2 = new StringFormat();
            stringFormat2.Alignment = StringAlignment.Center;
            stringFormat2.LineAlignment = StringAlignment.Far;

            StringFormat stringFormat3 = new StringFormat();
            stringFormat3.Alignment = StringAlignment.Near;
            stringFormat3.FormatFlags = StringFormatFlags.DirectionVertical;
            stringFormat3.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < 6; i++)
            {
                stringBuilder1.AppendLine(strings[i]);
            }

            for (int i = 6; i < 13; i++)
            {
                stringBuilder2.AppendLine(strings[i]);
            }

            for (int i = 13; i < 14; i++)
            {
                stringBuilder3.AppendLine(strings[i]);
            }

            string string1 = stringBuilder1.ToString();
            string string2 = stringBuilder2.ToString();
            string string3 = stringBuilder3.ToString();

            g.DrawString(string1, font1, Brushes.Black, 500, 250, stringFormat1);
            g.DrawString(string2, font2, Brushes.Red, 110, 250, stringFormat2);
            g.DrawString(string3, font3, Brushes.Green, 900, 0, stringFormat3);

            font1.Dispose();
            font2.Dispose();
            font3.Dispose();
            stringFormat1.Dispose();
            stringFormat2.Dispose();
            stringFormat3.Dispose();
            g.Dispose();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox.CreateGraphics();
            g.Clear(Color.FromKnownColor(KnownColor.Control));
            g.Dispose();
        }
    }
}
