using System;
using System.Windows.Forms;

namespace ParametricFunctionsApp
{
    public partial class AddFunctionForm : Form
    {
        public ParametricFunction SelectedFunction { get; private set; }

        public AddFunctionForm()
        {
            InitializeComponent();
            comboBoxFunctions.SelectedIndex = 0; // Вибір першого елементу
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (comboBoxFunctions.SelectedItem.ToString())
            {
                case "Sin(x)":
                    SelectedFunction = new SinFunction();
                    break;
                case "x^2":
                    SelectedFunction = new SquareFunction();
                    break;
                case "e^x":
                    SelectedFunction = new ExponentialFunction();
                    break;
            }
        }
    }
}
