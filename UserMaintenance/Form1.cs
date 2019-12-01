using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName; // label1
            button1.Text = Resource1.Add; // button1
            button2.Text = Resource1.WriteInFile;


            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                fullname = textBox1.Text,
                
            };
            users.Add(u);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = Application.StartupPath;
            sfd.DefaultExt = "csv";
            sfd.Filter = "Comma Seperated Values (*.csv)|*.csv";
            sfd.AddExtension = true;

            
                if (sfd.ShowDialog() != DialogResult.OK) return;


                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    foreach (var s in users)
                    {
                        sw.Write(s.ID);
                        sw.Write(";");
                        sw.Write(s.fullname);
                        sw.WriteLine();
                    }
                }
        }
        
    }
}
