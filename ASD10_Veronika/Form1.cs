using System.Globalization;

namespace ASD10_Veronika
{
    public partial class Form1 : Form
    {
        private List<double> _array;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var correctSizeNumber =
                Convert.ToInt32(
                    string.IsNullOrEmpty(textBox2.Text)
                        ? "10"
                        : textBox2.Text
                );

            _array = Enumerable.Range(0, Convert.ToInt32(correctSizeNumber))
                .Select(n => (double)Random.Shared.Next(-50, 50))
                .OrderBy(i => i)
                .ToList();

            PrintArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DevideMax();
            PrintArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwapBehindMin();
            PrintArray();
        }
        public void PrintArray(int? posOfFound = null)
        {
            //richTextBox1.Clear();
            for (int i = 0; i < _array.Count; i++)
            {
                string stringToAdd = i == _array.Count - 1
                        ? _array.Last().ToString("F4")
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
            int indexOfSearchable = IndexOfSearcheble(numberToFind);

            if (indexOfSearchable == -1)
            {
                richTextBox1.AppendText(Environment.NewLine + "Array not contain this element");
                return;
            }

            PrintArray(indexOfSearchable);
        }
        private void SwapBehindMin()
        {
            (_array[1], _array[2]) = (_array[2], _array[1]);
        }
        private void DevideMax()
        {
            double absSumOfNeg = Math.Abs(_array.TakeWhile(x => x < 0).Sum());
            _array[^1] = _array.Last() / absSumOfNeg;
        }

        private int IndexOfSearcheble(int number)
        {
            richTextBox1.Clear();
            var (min, max) = (0, _array.Count - 1);
            var logAboutSearch = string.Empty;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                logAboutSearch += $"min: {min} , middle: {mid}, max: {max}\n";
                richTextBox1.AppendText(logAboutSearch);

                 Task.Delay(1000);

                logAboutSearch = string.Empty;

                if (number == _array[mid])
                {
                    return mid;
                }

                if (number < _array[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }

                
                //Thread.Sleep(2000);
            }

            return -1;
        }
    }
}