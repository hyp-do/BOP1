using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace C969___BOP1
{
    
    public partial class LoginForm : Form
    {
        private StreamWriter logWriter;
        string logFileName = "BOP1Log.txt";

        
        //public void verifyUserNameAndPassword(string userName, string password)
        // {
        //     var context = new U05EiVEntities();

        //     var userNameAndPasswordQuery = context.users
        //      .Where(u => u.userName.Equals(userName) && u.password.Equals(password)).FirstOrDefault(); // Simplifies this LINQ statement and makes it more readable
        // }

        public LoginForm()
        {
            InitializeComponent();

            FileStream logMaker = new FileStream(logFileName, FileMode.Append, FileAccess.Write);
            logWriter = new StreamWriter(logMaker);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(((string.IsNullOrEmpty(textBoxUserName.Text) == true) || (string.IsNullOrWhiteSpace(textBoxUserName.Text) == true)) && ((string.IsNullOrEmpty(textBoxPassword.Text) == true) || (string.IsNullOrWhiteSpace(textBoxPassword.Text) == true)))
            {
                MessageBox.Show(GlobalStrings.emptyUserOrPass);
                textBoxUserName.BackColor = System.Drawing.Color.LightSalmon;
                textBoxPassword.BackColor = System.Drawing.Color.LightSalmon;
                logWriter.WriteLine(DateTime.UtcNow.ToString("u") + " FAILED Login Attempt");
            }
            else if (string.IsNullOrEmpty(textBoxUserName.Text) == true)
            {
                MessageBox.Show(GlobalStrings.emptyUserOrPass);
                textBoxUserName.BackColor = System.Drawing.Color.LightSalmon;
                logWriter.WriteLine(DateTime.UtcNow.ToString("u") + " FAILED Login Attempt");
            }
            else if (string.IsNullOrEmpty(textBoxPassword.Text) == true)
            {
                MessageBox.Show(GlobalStrings.emptyUserOrPass);
                textBoxPassword.BackColor = System.Drawing.Color.LightSalmon;
                logWriter.WriteLine(DateTime.UtcNow.ToString("u") + " FAILED Login Attempt");
            }
            else if (string.IsNullOrWhiteSpace(textBoxUserName.Text) == true)
            {
                MessageBox.Show(GlobalStrings.emptyUserOrPass);
                textBoxPassword.BackColor = System.Drawing.Color.LightSalmon;
                logWriter.WriteLine(DateTime.UtcNow.ToString("u") + " FAILED Login Attempt");
            }
            else if (string.IsNullOrWhiteSpace(textBoxPassword.Text) == true)
            {
                MessageBox.Show(GlobalStrings.emptyUserOrPass);
                textBoxPassword.BackColor = System.Drawing.Color.LightSalmon;
                logWriter.WriteLine(DateTime.UtcNow.ToString("u") + " FAILED Login Attempt");
            }
            else
            {
                //verifyUserNameAndPassword(textBoxUserName.Text, textBoxPassword.Text);

                var loginContext = new U05EiVEntities();

                var userNameAndPasswordQuery = loginContext.users
                 .Where(u => u.userName.Equals(textBoxUserName.Text) && u.password.Equals(textBoxPassword.Text)).FirstOrDefault(); // Simplifies this LINQ statement and makes it more readable

                if (!(userNameAndPasswordQuery == null))
                {
                    this.Hide();
                    logWriter.WriteLine(DateTime.UtcNow.ToString("o") + " SUCCESS, User " + textBoxUserName.Text + " Logged in.");
                    MainForm mainForm = new MainForm();
                    Helper.CurrentUser = textBoxUserName.Text;
                    mainForm.Show();
                    logWriter.Close();
                }
                else
                {
                    MessageBox.Show(GlobalStrings.userPassError);
                    logWriter.WriteLine(DateTime.UtcNow.ToString("o") + " FAILED Login Attempt");
                    textBoxUserName.BackColor = System.Drawing.Color.LightSalmon;
                    textBoxPassword.BackColor = System.Drawing.Color.LightSalmon;
                }

            }
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            textBoxUserName.BackColor = System.Drawing.Color.White;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.BackColor = System.Drawing.Color.White;
        }
    }
}
