using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections;

namespace DES
{
    public partial class DES : Form
    {
        Algorithm Algorithm;
         
        public DES()
        {
            InitializeComponent();
            Algorithm = new Algorithm();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var Button = sender as Button;
            if (Button == null) return;
            
                switch (Button.Name)
                {
                    case "Encrypt":
                        if (keyText != null && keyText.Text.Length == 8)
                        {
                            Algorithm = new Modes(GetBitArray(OT.Text), keyText.Text);
                            Algorithm.Encryption();
                            ET.Text = Algorithm.GetText(Algorithm.BitArrayET);
                            GenError.Visible = true;
                        }
                        else
                            MessageBox.Show("Ошибка! Ключ не задан или задан неверно (8 символов)");
                        break;
                    case "Decryption":
                        if (keyText != null && keyText.Text.Length == 8)
                        {
                            PosErr.Visible = false;
                            Algorithm = new Modes(GetBitArray(ET.Text), keyText.Text);
                            Algorithm.Decryption();
                            DT.Text = Algorithm.GetText(Algorithm.BitArrayDT);
                        }
                        else
                            MessageBox.Show("Ошибка! Ключ не задан или задан неверно (длина 8 символов)");
                        break;
                    case "Generate":
                        keyText.Text = Encoding.GetEncoding(1251).GetString(GenerateKey());
                        break;
                    case "GenError":
                        Algorithm = new Modes(GetBitArray(ET.Text), keyText.Text);
                        Random rand = new Random();
                        var randnum = rand.Next(0, Algorithm.BitArrayET.Length);
                        PosErr.Text = "Случайная ошибка в бите №" + (randnum+1) + ",\n(байт №" + (int)(randnum/8 + 1) + ", блок №" + (int)(randnum / 64 + 1) + ")";
                        PosErr.Visible = true;
                        Algorithm.BitArrayET[randnum] = !Algorithm.BitArrayET[randnum];
                        Algorithm.Decryption();
                        DT.Text = Algorithm.GetText(Algorithm.BitArrayDT);
                    break;
                }
        }

        private void TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            try
            {
                switch (textBox.Name)
                {
                    case "OT":
                        if (textBox != null)
                        {
                            Count1.Text = textBox.Text.Length.ToString();
                        }
                        break;
                    case "ET":
                        if (textBox != null)
                        {
                            Count2.Text = textBox.Text.Length.ToString();
                            Count2.Visible = true;
                        }
                        if (textBox.Text.Length == 0)
                        {
                            Count2.Visible = false;
                        }
                        break;
                    case "DT":
                        if (textBox != null)
                        {
                            Count3.Text = textBox.Text.Length.ToString();
                            Count3.Visible = true;
                        }
                        if (textBox.Text.Length == 0)
                        {
                            Count3.Visible = false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private byte[] GenerateKey()
        {
            Random rand = new Random();
            byte[] Key = new byte[8];
            Modes Modes = new Modes();
            byte T = Convert.ToByte(rand.Next(0, 99));
            for (var i = 0; i < 8; i++)
            {
                var TypeSim = rand.Next(1, 4);
                switch (TypeSim)
                {
                    case 1:
                        Key[i] = Convert.ToByte(rand.Next((int)'0', (int)'9'));
                        break;
                    case 2:
                        Key[i] = Convert.ToByte(rand.Next((int)'a', (int)'z'));
                        break;
                    case 3:
                        Key[i] = Convert.ToByte(rand.Next((int)'A', (int)'Z'));
                        break;
                }     
            }
            return Key;
        }
        private void modeCheckedChanged(object sender, EventArgs e)
        {
            var CheckedChanged = sender as RadioButton;
            if (CheckedChanged == null) return;
            if  (CheckedChanged.Checked)
            switch (CheckedChanged.Name)
            {
                case "ECB" : 
                    Algorithm.Mode=Algorithm.Modes.ECB;
                    break;
                case "CBC": 
                    Algorithm.Mode=Algorithm.Modes.CBC;
                    break;
            }
        }

        private string GetBitArrayText(string Text)
        {
            var aByte = Encoding.GetEncoding(1251).GetBytes(Text);
            BitArray aBit = new BitArray(aByte);
            string Str = "";
            for (var iBit = 0; iBit < aBit.Length; iBit++)
            {
                Str += aBit[iBit] ? "1" : "0";
            }
            return Str;
        }
        private string GetBitArrayText(BitArray aBitText)
        {
            string Str = "";
            for (var iBit = 0; iBit < aBitText.Length; iBit++)
            {
                Str += aBitText[iBit] ? "1" : "0";
            }
            return Str;
        }

        private BitArray GetBitArray(string Text)
        {
            var aByte = Encoding.GetEncoding(1251).GetBytes(Text);
            return new BitArray(aByte); 
        }
    }
}
