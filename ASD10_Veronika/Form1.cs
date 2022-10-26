using System.Globalization;

namespace ASD10_Veronika
{
    public partial class Form1 : Form
    {
        private Lab10 _array;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var correctSizeNumber =
                Convert.ToInt32(
                    string.IsNullOrEmpty(textBox2.Text)
                        ? "10"
                        : textBox2.Text
                );

            _array = new Lab10(correctSizeNumber);
            PrintArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _array.DevideMax();
            PrintArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _array.SwapBehindMin();
            PrintArray();
        }
        private void PrintArray(int? posOfFound = null)
        {
            richTextBox1.Clear();
            for (int i = 0; i < _array.Count; i++)
            {
                string stringToAdd = i == _array.Count - 1
                        ? _array.Numbers.Last().ToString("F4")
                        : $"{_array[i]} ,";

                if (i == posOfFound)
                {
                    SetColor(stringToAdd);
                    continue;
                }
                richTextBox1.AppendText(stringToAdd);
            }
        }

        private void SetColor(string i)
        {
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.AppendText(i);
            richTextBox1.SelectionColor = Color.Black;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out var numberToFind);
            int indexOfSearchable = _array.IndexOfSearcheble(numberToFind);

            if (indexOfSearchable == -1)
            {
                richTextBox1.AppendText(Environment.NewLine + "Array not contain this element");
                return;
            }

            PrintArray(indexOfSearchable);
        }
    }
}