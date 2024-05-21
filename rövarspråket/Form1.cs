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
            timer1.Start();
        }

        private void main()
        {
            string input = textBox1.Text; 
            string pattern = "[b-df-hj-np-tv-z]"; // sätter mönstret till alla bokstäver förutom vokaler
            string result = Regex.Replace(input, pattern, ReplaceKonsonant, RegexOptions.IgnoreCase); // Byter ut konsonanterna i textbox1
            textBox2.Text = result; // skriver ut resultatet i textbox2
        }

        static string ReplaceKonsonant(Match match)
        {
            string Konsonant = match.Value; 
            return Konsonant + "o" + Konsonant.ToLower();
            // tar bokstaven och sätter den framför och bakom ett 'o', t.ex b -> bob
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            main();
        }
    }
}
