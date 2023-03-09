using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void basamak1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        public string dec_to_bin(int sayi)
        {
            string gecici2 = null;
            string str = null;
            int  bolum = 0, kalan = 0;

            while (sayi > 1)
            {
                kalan = sayi % 2;
                str = str + kalan.ToString();
                sayi = sayi / 2;

            }
            str = str + sayi.ToString();
            Char[] temp = new char[str.Length];
            int i = str.Length - 1; ;
            for (int j = 0; j < str.Length; j++)
            {

                temp[j] = str[i];
                i--;
            }

            for (int j = 0; j < temp.Length; j++)
                gecici2 = gecici2 + temp[j];
            return gecici2;

        }
        private string  dec_to_oct(int sayi)
        {
            string gecici=null;
            string str = null;
            int bolum = 0, kalan = 0;

            while (sayi > 7)
            {
                kalan = sayi % 8;
                str = str + kalan.ToString();
                sayi = sayi / 8;

            }
            str = str + sayi.ToString();

            Char[] temp = new char[str.Length];
            int i = str.Length - 1; ;
            for (int j = 0; j < str.Length; j++)
            {

                temp[j] = str[i];
                i--;
            }

            for (int j = 0; j < temp.Length; j++)
                gecici = gecici + temp[j];
           
            return gecici;
        }
        public string dec_to_Hex(string sayi)
        {
            string gecici4 = null;
            bool flag = false;
            int temp2 = int.Parse(sayi);

            string str = null;
            int bolum = 0;string kalan = "0";

            while (temp2 > 16)
            {
                kalan = (temp2 % 16).ToString();
                kalan = HexFonk(kalan);
                str = str + kalan.ToString();
                temp2 = temp2 / 16;
                flag = true;             //str 8FB
            }
            (sayi) = temp2.ToString();
            if (flag == false)
            {
                sayi = HexFonk(sayi.ToString());
                return sayi;

            }
            sayi = HexFonk(sayi.ToString());
            str = str + sayi.ToString();

            Char[] temp = new char[str.Length];
            int i = str.Length - 1; ;
            for (int j = 0; j < str.Length; j++)
            {

                temp[j] = str[i];
                i--;
            }

            for (int j = 0; j < temp.Length; j++)
                gecici4+= temp[j]; 
            return gecici4;

        }
        private string  HexFonk(string kalan)
        {
            if (kalan == "10")kalan = "A";
            if (kalan == "11") kalan = "B";
            if (kalan == "12") kalan = "C";
            if (kalan == "13") kalan = "D";
            if (kalan == "14")kalan= "E";   
                if (kalan == "15") kalan = "F";

            return kalan;
        }
        
       

    


        private string bin_to_dec(string s)
        {
            string gecici3 = null; ;
            int toplam = 0, carpan = 1;
            for (int i = s.Length; i >= 1; i--)
            {
                toplam += int.Parse(s[i - 1].ToString()) * carpan;
                carpan = carpan * 2;
            }
            gecici3 = toplam.ToString();
            return gecici3;
        }
        private string oct_to_dec(string s)
        {
            string gecici3 = null; ;
            int toplam = 0, carpan = 1;
            for (int i = s.Length; i >= 1; i--)
            {
                toplam += int.Parse(s[i - 1].ToString()) * carpan;
                carpan = carpan * 8;
            }
            gecici3 = toplam.ToString();
            return gecici3;
        }
        private string hex_to_dec(string s)
        {
            string gecici3 = null; ;
            int toplam = 0, carpan = 1;
            for (int i = s.Length; i >= 1; i--)
            {
                toplam += int.Parse(s[i - 1].ToString()) * carpan;
                carpan = carpan * 16;
            }
            gecici3 = toplam.ToString();
            return gecici3;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();textBox2.Clear();basamak1.ResetText(); basamak2.ResetText();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (basamak1.Text == "10'lu(Decimal)" && basamak2.Text == "2'li(Binary)")
            {
                textBox2.Clear();
                textBox2.Text = dec_to_bin(int.Parse(textBox1.Text));
            }
            else if (basamak1.Text == "10'lu(Decimal)" && basamak2.Text == "8'li(Octal)")
            {
                textBox2.Clear();
                textBox2.Text = dec_to_oct(int.Parse(textBox1.Text));

            }
            else if (basamak1.Text == "10'lu(Decimal)" && basamak2.Text == "16'lı(HexaDecimal)")
            {
                textBox2.Clear();
                textBox2.Text = dec_to_Hex(textBox1.Text);

            }
            else if (basamak1.Text == "2'li(Binary)" && basamak2.Text == "16'lı(HexaDecimal)")
            {

                if (checkfonk(textBox1.Text, 2) == 1)
                    textBox2.Text = dec_to_Hex(bin_to_dec(textBox1.Text));
                else { MessageBox.Show("Geçersiz Karakter"); textBox2.Clear(); }
            }
            else if (basamak1.Text == "2'li(Binary)" && basamak2.Text == "8'li(Octal)")
            {
                if (checkfonk(textBox1.Text, 2) == 1)
                    textBox2.Text = dec_to_oct(int.Parse(bin_to_dec(textBox1.Text)));
                else { MessageBox.Show("Geçersiz Karakter"); textBox2.Clear(); }
            }
            else if (basamak1.Text == "2'li(Binary)" && basamak2.Text == "10'lu(Decimal)")
            {
                if (checkfonk(textBox1.Text, 2) == 1)
                    textBox2.Text = bin_to_dec(textBox1.Text);
                else { MessageBox.Show("Geçersiz Karakter"); textBox2.Clear(); }
            }
            else if (basamak1.Text == "8'li(Octal)" && basamak2.Text == "10'lu(Decimal)")
            {
                if (checkfonk(textBox1.Text, 8) == 1)
                    textBox2.Text = oct_to_dec(textBox1.Text);
                else { MessageBox.Show("Geçersiz Karakter"); textBox2.Clear(); }
            }
            else if (basamak1.Text == "8'li(Octal)" && basamak2.Text == "16'lı(HexaDecimal)")
            {
                if (checkfonk(textBox1.Text, 8) == 1)
                    textBox2.Text = dec_to_Hex(oct_to_dec(textBox1.Text));
                else { MessageBox.Show("Geçersiz Karakter"); textBox2.Clear(); }
            }
            else if (basamak1.Text == "8'li(Octal)" && basamak2.Text == "2'li(Binary)")
            {
                if (checkfonk(textBox1.Text, 8) == 1)
                    textBox2.Text = dec_to_bin(int.Parse(oct_to_dec(textBox1.Text)));
                else { MessageBox.Show("Geçersiz Karakter"); textBox2.Clear(); }
            }
            else if (basamak1.Text == "16'lı(HexaDecimal)" && basamak2.Text == "10'lu(Decimal)")
            {
                textBox2.Text = hex_to_dec(textBox1.Text);
            }
            else if (basamak1.Text == "16'lı(HexaDecimal)" && basamak2.Text == "8'li(Octal)")
            {
                textBox2.Text = dec_to_oct(int.Parse(hex_to_dec(textBox1.Text)));
            }
            else if (basamak1.Text == "16'lı(HexaDecimal)" && basamak2.Text == "2'li(Binary)")
            {
                textBox2.Text = dec_to_bin(int.Parse(hex_to_dec(textBox1.Text)));
            }
            else if (basamak1.Text == "8'li(Octal)" && basamak2.Text == "8'li(Octal)")
            {
                if (checkfonk(textBox1.Text, 8) == 1) textBox2.Text = textBox1.Text; else MessageBox.Show("Geçersiz Karakter!");
            }
            else if (basamak1.Text == "2'li(Binary)" && basamak2.Text == "2'li(Binary)")
            {
                if (checkfonk(textBox1.Text, 2) == 1) textBox2.Text = textBox1.Text; else MessageBox.Show("Geçersiz Karakter!");
            }
            else if (basamak1.Text == "10'lu(Decimal)" && basamak2.Text == "10'lu(Decimal)")
            {textBox2.Text = textBox1.Text;}
            else if (basamak1.Text == "16'lı(HexaDecimal)" && basamak2.Text == "16'lı(HexaDecimal)")
            { textBox2.Text = textBox1.Text; }



        }
        public int checkfonk(string a, int taban)
        { int sayac= 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (Convert.ToInt16(a[i].ToString() ) < taban)
                { sayac++;  }

            }
            if (sayac == a.Length) return 1;
            else return 0;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label5.Text = dt.ToString("f");          

        }

        private void basamak2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
