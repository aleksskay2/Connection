using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectionDLL;
using Microsoft.Win32;

namespace Connection
{
    public partial class fmLogin : Form
    {
        public static  string FirstTable;
        public static bool Online = false;
        public fmLogin()
        {
            InitializeComponent();
        }

        public static ConnectionData conData;
           
        private void fmLogin_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage =
                InputLanguage.FromCulture(new System.Globalization.CultureInfo("En-Us"));

            RegistryKey currentUser = Registry.CurrentUser;
            RegistryKey registryKey = currentUser.OpenSubKey("Connection");
            string check = "";

            if (registryKey.GetValue("Checked") != null)
                check = registryKey.GetValue("Checked").ToString();
            if ((check != ""))
                if (check == "true")
                    chbRimember.Checked = true;
                else
                {
                    chbRimember.Checked = false;
                }
            string login = "";
            if (registryKey.GetValue("Login") != null)
            login = registryKey.GetValue("Login").ToString();

            if (chbRimember.Checked && !(login=="") )
            {
                tbLogin.Text = login;
                tbPassword.Text = registryKey.GetValue("Password").ToString();
                registryKey.Close();
            }
           
        }

        public static void Open()
        {
            //string connectionString = "Data Source=WIN-C8OVOKMLI3T;" +
            //    " Initial Catalog=FirstBas;Integrated Security=True;" +
            //     "MultipleActiveResultSets = true; ";
            //conData = new ConnectionData(connectionString);



            //conData.OpenConnection("workstation id=ConBase.mssql.somee.com;packet size=4096;user id=aleksskay_SQLLogin_1;pwd=cq2j8tthtc;data source=ConBase.mssql.somee.com;persist security info=False;initial catalog=ConBase");

            // Последняя подходящая.
           

            conData = new
                ConnectionData("Data Source = (localdb)\\MSSQLLocalDB;  Initial Catalog = FirstBas; " +
                "Integrated Security  = true; MultipleActiveResultSets = true; ");


            // через инет

            //conData = new
            //    ConnectionData(" Data Source = SQL7002.site4now.net; "+
            //    "Initial Catalog = DB_A47392_aleksskay; User Id = DB_A47392_aleksskay_admin;"+
            //    " Password = Redredred123; MultipleActiveResultSets = true; ;");

        }

        private void OpenEnter()
        {
            //string connectionString =
            //   "Data Source = WIN-C8OVOKMLI3T; Initial Catalog = FirstBas;" +
            //    " Integrated Security  = true; MultipleActiveResultSets = true; ";

            string connectionString =
              "Data Source = (localdb)\\MSSQLLocalDB;  Initial Catalog = FirstBas; " +
                "Integrated Security  = true; MultipleActiveResultSets = true; ";


            conData = new ConnectionData(connectionString, tbLogin.Text);
            string login = conData.ModifyName(tbLogin.Text);
            conData.ChangeOnline(login, 1);
         
            //conData.OpenConnection("workstation id=Personal3.mssql.somee.com;packet size=4096;  " +
            //    " user id=aleksskay_SQLLogin_1;pwd=cq2j8tthtc; "
            //   + " data source=Personal3.mssql.somee.com;persist security info=False; " +
            //   "initial catalog=Personal3");


        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            RegistryKey currentUser = Registry.CurrentUser;
            RegistryKey connectionLogin = currentUser.CreateSubKey("Connection");

            if (chbRimember.Checked)
            {
                connectionLogin.SetValue("Checked", "true");
                connectionLogin.SetValue("Login", tbLogin.Text);
                connectionLogin.SetValue("Password", tbPassword.Text);
                connectionLogin.Close();
            }
            else
            {
                connectionLogin.SetValue("Checked", "false");
            }

            OpenEnter();                
            string table = conData.CheckAccount(tbLogin.Text, tbPassword.Text);
            FirstTable = table;
 
            if (table != "")
            {
                fmMain form = new fmMain();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ошибка неверный пароль или логин!", 
                    "Ошибка", MessageBoxButtons.OK);
            }
            
        }

        private void laRegistration_Click(object sender, EventArgs e)
        {
            fmRegistrate formReg = new fmRegistrate();
            formReg.ShowDialog();
        }
    }
}
