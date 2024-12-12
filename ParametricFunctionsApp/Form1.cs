using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ParametricFunctionsApp
{
    public partial class Form1 : Form
    {
        private FunctionContainer container = new FunctionContainer();

        public Form1()
        {
            InitializeComponent();
            InitializeFunctions();
        }

        private void InitializeFunctions()
        {
            container.AddFunction(new SinFunction());
            container.AddFunction(new SquareFunction());
            container.AddFunction(new ExponentialFunction());
            UpdateFunctionList();
        }

        private void UpdateFunctionList()
        {
            listBoxFunctions.Items.Clear();
            foreach (var func in container.GetAllFunctions())
            {
                listBoxFunctions.Items.Add(func.Name);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (listBoxFunctions.SelectedIndex == -1)
            {
                MessageBox.Show("Оберіть функцію!");
                return;
            }

            var selectedFunction = container.GetAllFunctions().ElementAt(listBoxFunctions.SelectedIndex);

            if (double.TryParse(txtInputX.Text, out double x))
            {
                double result = selectedFunction.Calculate(x);
                MessageBox.Show($"Результат: {result}");
            }
            else
            {
                MessageBox.Show("Введіть коректне значення X!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Додати логіку для додавання нової функції
            // Відкрити вікно для вибору типу функції
            using (var form = new AddFunctionForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var selectedFunction = form.SelectedFunction;
                    container.AddFunction(selectedFunction);
                    UpdateFunctionList();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBoxFunctions.SelectedIndex == -1)
            {
                MessageBox.Show("Оберіть функцію для видалення!");
                return;
            }

            var selectedFunction = container.GetAllFunctions().ElementAt(listBoxFunctions.SelectedIndex);
            container.RemoveFunction(selectedFunction);
            UpdateFunctionList();
        }
        private void btnCalculateRange_Click(object sender, EventArgs e)
        {
            if (container.GetAllFunctions().Count() == 0)
            {
                MessageBox.Show("Контейнер порожній. Додайте функції для обчислення.");
                return;
            }

            // Введення діапазону значень
            double startX, endX, step;
            if (!GetRangeValues(out startX, out endX, out step))
            {
                return; // Невірний діапазон
            }

            // Обчислення результатів
            var results = new List<string>();
            foreach (var function in container.GetAllFunctions())
            {
                results.Add($"Функція: {function.Name}");
                for (double x = startX; x <= endX; x += step)
                {
                    double result = function.Calculate(x);
                    results.Add($"x = {x:F2}, y = {result:F2}");
                }
                results.Add(""); // Пропуск між функціями
            }

            // Вивід результатів
            ShowResults(results);
        }

        // Діалог для введення діапазону
        private bool GetRangeValues(out double startX, out double endX, out double step)
        {
            startX = endX = step = 0;

            using (var form = new Form2())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    startX = form.StartX;
                    endX = form.EndX;
                    step = form.Step;

                    // Умови перевірки
                    if (step > 0 && startX <= endX)
                    {
                        return true; // Коректні дані
                    }
                    else
                    {
                        MessageBox.Show("Крок має бути більше 0, а початкове значення менше або дорівнює кінцевому.");
                       

                        return false;
                    }
                }
            }

            return false; // Діалог закритий без підтвердження
        }


        // Вивід результатів
        private void ShowResults(IEnumerable<string> results)
        {
            var resultForm = new ResultsForm(results);
            resultForm.ShowDialog();
        }


    }
}
