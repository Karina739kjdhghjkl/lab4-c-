using System;
using System.Windows.Forms;

namespace ParametricFunctionsApp
{
    public partial class Form2 : Form
    {
        public double StartX { get; private set; }
        public double EndX { get; private set; }
        public double Step { get; private set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Перевірка числових значень
            if (double.TryParse(txtStartX.Text, out double startX) &&
                double.TryParse(txtEndX.Text, out double endX) &&
                double.TryParse(txtStep.Text, out double step) &&
                step > 0 && startX <= endX)
            {
                StartX = startX;
                EndX = endX;
                Step = step;
                DialogResult = DialogResult.OK; // Підтвердження введення
            }
            else
            {
                MessageBox.Show("Введіть коректні числові значення:\n- Крок має бути більше 0\n- Початкове значення ≤ кінцевого.");
                DialogResult = DialogResult.None; // Не закривати форму
            }
        }



    }
}
