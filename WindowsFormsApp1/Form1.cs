using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TurkishTCValidator.TC_Online_Validator _Validator = new TurkishTCValidator.TC_Online_Validator();
            _Validator.OnValidationResult += _Validator_OnValidationResult;

            for (int i = 0; i < 50; i++)
            {
                _Validator.CallValidator(0000000000, "NAME", "LASTNAME", 1992, "CALBACKDATA" + i);
            }

        }

        private void _Validator_OnValidationResult(bool result, object yourSentObject)
        {
            Console.WriteLine(result.ToString() + " " + yourSentObject);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TurkishTCValidator.TC_Online_Validator _Validator = new TurkishTCValidator.TC_Online_Validator();
            var result = _Validator.ValidateForeigner(99999999999, "NAME", "LASTNAME", 1992, 01, 01);
            MessageBox.Show(result.ToString());
        }
    }
}
