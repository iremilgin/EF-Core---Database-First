using ErdinçHocaÖdevÇözümAss13.Models;

namespace ErdinçHocaÖdevÇözümAss13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MSNDBContext dbContext;
        private void btnGirişYap_Click(object sender, EventArgs e)
        {
           dbContext= new MSNDBContext();
            if(string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrEmpty(txtSifre.Text))
            {
                MessageBox.Show("Bütün bilgileri giriniz.");
            }
            else
            {
                User user = dbContext.Users.FirstOrDefault(a=> a.Email == txtMail.Text);
                if(user != null) 
                {
                    if(user.Password == txtSifre.Text)
                    {
                        MessageBox.Show("Giriş Başarılı");
                    }
                    else
                    {
                        MessageBox.Show("Şifre Yanlıştır.");
                    }
                }
                else
                {
                    MessageBox.Show("Mail adresi yanlış. \n Kayıtlı değilseniz kaydolun.");
                }
            }
        }

        private void lblKaydolLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn sign = new SignIn();
            sign.ShowDialog();
        }
    }
}