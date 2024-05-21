using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rövarspråket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool block = false;

        private void main() // från svenska till rövarspråket
        {
            string input = textBox1.Text; 
            string pattern = "[b-df-hj-np-tv-z]"; // sätter mönstret till alla bokstäver förutom vokaler
            string result = Regex.Replace(input, pattern, ReplaceSve, RegexOptions.IgnoreCase); // Byter ut konsonanterna i textbox1
            textBox2.Text = result; // skriver ut resultatet i textbox2
        }

        private void main2() // från rövarspråket till svenska
        {
            string input = textBox2.Text;
            string pattern = @"([b-df-hj-np-tv-z])[oO]\1"; // får konsonanter som är följda av ett 'o' och sedan samma konsonant igen
            string result = Regex.Replace(input, pattern, ReplaceRovar, RegexOptions.IgnoreCase); // byter ut rövarspråket till svenska
            textBox1.Text = result; // skriver ut resultatet i textbox1
        }

        static string ReplaceSve(Match match)
        {
            string Konsonant = match.Value; 
            return Konsonant + "o" + Konsonant.ToLower();
            // tar bokstaven och sätter den framför och bakom ett 'o', t.ex b -> bob
        }

        static string ReplaceRovar(Match match)
        {
            string konsonant = match.Groups[1].Value; // vet lowkey inte vad som händer här (fick det från reddit)
            return konsonant;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (block) return; // gör så att fönstrena inte uppdaterar varandra
            block = true;

            main();

            block = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (block) return; // gör så att fönstrena inte uppdaterar varandra
            block = true; 
            
            main2();

            block = false;
        }
    }
}
