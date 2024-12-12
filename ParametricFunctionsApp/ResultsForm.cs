using System.Collections.Generic;
using System.Windows.Forms;

namespace ParametricFunctionsApp
{
    public partial class ResultsForm : Form
    {
        public ResultsForm(IEnumerable<string> results)
        {
            InitializeComponent();
            txtResults.Text = string.Join("\r\n", results);
        }
    }
}
