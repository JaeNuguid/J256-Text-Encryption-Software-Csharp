using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J256
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (input.Text == "")
            {
                MessageBox.Show("Please input a plain text/string!", "J256 Text Encryption Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (input.Text.Contains("|J|"))
            {
                MessageBox.Show("Once encrypted with J256, it cannot be re-encrypted again!", "J256 Text Encryption Software", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Main_Encryption me = new Main_Encryption();
                input.Text = me.Encryption(input.Text);
            }


            }

        private void button1_Click(object sender, EventArgs e)
        {
            if (input.Text == ""|| !input.Text.Contains("|J|"))
            {
                MessageBox.Show("Please input an encrypted text(J256)!", "J256 Text Encryption Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Main_Decryption md = new Main_Decryption();
                input.Text = md.Decryption(input.Text);
            }
        }
    }
}
