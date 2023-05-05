using ErdinçHocaÖdevÇözümAss13.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErdinçHocaÖdevÇözümAss13
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        MSNDBContext dbContext;
        private void btnKaydol_Click(object sender, EventArgs e)
        {
            dbContext = new MSNDBContext();
            if(string.IsNullOrEmpty(txtMailKayit.Text) || string.IsNullOrEmpty(txtSifreKayit.Text) || string.IsNullOrEmpty(txtSifreTekrar.Text)) 
                {
                MessageBox.Show("Lütfen bütün bilgileri giriniz.");
            }
            else
            {
                if(txtSifreKayit.Text== txtMailKayit.Text) 
                { 
                User user = new User();
                user.Email= txtMailKayit.Text;
                user.Password = txtSifreKayit.Text;
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                    MessageBox.Show("Kayıt Başarılı");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Şifreler Uyuşmuyor");
                }
            }
        }
    }
}
