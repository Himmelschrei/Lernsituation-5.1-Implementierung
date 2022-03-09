using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zahlensysteme
{
    public partial class Form1 : Form
    {
        Calculation myCalculation = null;
        public Form1()
        {
            InitializeComponent();

            myCalculation = new Calculation(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCalculator_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxBinary.Text) && String.IsNullOrEmpty(textBoxDecimal.Text))
            {
                labelMessage.Text = "Bitte füllen Sie ein Feld aus.";
            } else if (textBoxBinary.TextLength != 0 && textBoxDecimal.TextLength != 0)
            {
                labelMessage.Text = "Eins der Felden muss leer sein.";
            } else if (String.IsNullOrEmpty(textBoxBinary.Text))
            {
                if (myCalculation.checkInt(textBoxDecimal.Text) == false)
                {
                    labelMessage.Text = "Nur Integers eingeben, bitte.";
                } else
                {
                    textBoxBinary.Text = myCalculation.calcToBinary(textBoxDecimal.Text);
                }
            } else if (String.IsNullOrEmpty(textBoxDecimal.Text))
            {
                if (myCalculation.checkInt(textBoxBinary.Text) == false)
                {
                    labelMessage.Text = "Nur Integers eingeben, bitte.";
                }
                else
                {
                    textBoxDecimal.Text = myCalculation.calcToDecimal(textBoxBinary.Text);
                }
            }
        }

        private void labelMessage_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxBinary.Clear();
            textBoxDecimal.Clear();
        }
    }
}
