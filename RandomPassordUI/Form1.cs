using business;
using System.Windows.Forms;

namespace RandomPassordUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string StrValue = textBox1.Text;
                int value = int.Parse(StrValue);
                if (value > 1000)
                {
                    throw new LengthException();
                }
                var randomPass = new RandomsPass(Convert.ToInt32(value));
                textBox2.Text = randomPass.GetPassword();

                listBox1.Items.Add(randomPass.GetPassword());
                this.Controls.Add(listBox1);
                //MessageBox.Show(randomPass.GetPassword());
                textBox1.Text = string.Empty;
            }
            catch (Exception ex)
            {
                if (ex is LengthException)
                {
                    MessageBox.Show("The length can't be more than 1000");
                    textBox1.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Please fill up the message length");
                    textBox2.Text = string.Empty;
                }

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBox2.Text = string.Empty;
            textBox2.ReadOnly = true;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Join(Environment.NewLine, listBox1.SelectedItems.OfType<string>()));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you Sure?", "Clear list", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                listBox1.Items.Clear();
            }


        }
    }
}