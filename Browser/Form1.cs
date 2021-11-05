using System;
using System.Windows.Forms;

namespace Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This function will be called when the exit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This browser was made by Brandon");
        }

        // On click web control will show page
        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation has ended";
        }

        // This is the core function that will perform all navigation and post processing
        private void NavigateToPage()
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            toolStripStatusLabel1.Text = "Navigation has started";
            webBrowser1.Navigate(textBox1.Text);
        }

        // This function will fire everytime a key is pressed and released
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( e.KeyChar == (char)ConsoleKey.Enter)
            {
                NavigateToPage();
            }
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if ( e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
            
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
