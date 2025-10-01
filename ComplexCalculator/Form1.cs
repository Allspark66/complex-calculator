using System.Data;

namespace ComplexCalculator
{
    public partial class Form1 : Form
    {
        string operation = "";
        double firstNumber = 0;
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Number_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (isOperationPerformed || richTextBox1.Text == "0")
            {
                richTextBox1.Clear();
                isOperationPerformed = false;
            }

            richTextBox1.Text += button.Tag.ToString();

        }

        private void button_Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            richTextBox1.Text += button.Tag.ToString();
            isOperationPerformed = false;
        }

        private void button_Special_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string tag = button.Tag.ToString();
            switch (tag)
            {
                case "C":
                    richTextBox1.Clear();
                    break;
                case "CE":
                    if (richTextBox1.Text.Length > 0)
                        richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1);
                    break;
                case "Sqrt":
                    string text = richTextBox1.Text;
                    if (text.Length == 0) return;


                    char[] ops = new char[] { '+', '-', '*', '/' };
                    int lastOp = text.LastIndexOfAny(ops);
                    string lastNumber = lastOp >= 0 ? text.Substring(lastOp + 1) : text;
                    double num = double.Parse(lastNumber);
                    double sqr = Math.Sqrt(num);

                    richTextBox1.Text = (lastOp >= 0 ? text.Substring(0, lastOp + 1) : "") + sqr.ToString();
                    break;




            }
        }

        private void button_Equals_Click(object sender, EventArgs e)
        {
            try
            {
                string expression = richTextBox1.Text;
                DataTable table = new DataTable();
                double result = Convert.ToDouble(table.Compute(expression, ""));
                richTextBox1.Text += "\n= " + result;
                isOperationPerformed = true;
            }
            catch
            {
                richTextBox1.Text = "Error";
                isOperationPerformed = true;
            }
        }
    }
}
