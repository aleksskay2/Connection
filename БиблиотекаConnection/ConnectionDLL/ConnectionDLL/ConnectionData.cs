using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Data.Common;

namespace ConnectionDLL
{
    public class ConnectionData :IConnection
    {
        private SqlConnection connection;

        private SqlDataAdapter adapter;

        private DataSet dataSet;

        public List<string> TableNames { get; set; }

        public DataTable DisplayNames { get; set; }

        public List<string> Names { get; set; }
     

        // первый конструктор, вызывается при входе в Connection
        public ConnectionData (string conString, string userLogin)
        {
            this.OpenConnection(conString);
            SqlCommand com = new SqlCommand("GetNames", connection);
            com.CommandType = CommandType.StoredProcedure;
            userLogin = this.ModifyName(userLogin);
            com.Parameters.AddWithValue("@userLogin", userLogin);
            com.ExecuteNonQuery();
            DataTable Names = new DataTable();
            adapter = new SqlDataAdapter(com);
            adapter.Fill(Names);             
            this.DisplayNames = Names;

            List<string> list = new List<string>();

            com = new SqlCommand("select * from dbo.GetTables()", connection);
            com.CommandType = CommandType.Text;
            Names = new DataTable();
            adapter = new SqlDataAdapter(com);
            adapter.Fill(Names);
            foreach(DataRow row in Names.Rows)
            {
                list.Add(row["TableName"].ToString());
            }
            this.TableNames = list;
            com.Dispose();
        }

        // Вторая форма конструктора
        // Вызывается при регистрация нового пользователя.
        public ConnectionData (string ConnectionString)
        {
            this.OpenConnection(ConnectionString);
            List<string> list = new List<string>();
            SqlCommand com;
            com = new SqlCommand("GetNamesLogins", connection);
            com.CommandType = CommandType.StoredProcedure;
            DataTable Names;
            Names = new DataTable();
            adapter = new SqlDataAdapter(com);
            adapter.Fill(Names);
            foreach (DataRow row in Names.Rows)
            {
                list.Add(row["UserLogin"].ToString());
            }
            this.Names = list;
        }

        // Открытие соединения с базой FirstBas
        public bool OpenConnection(string ConString)
        {
            connection = new SqlConnection(ConString);
            try
            {
                connection.Open();                
            }
            
            catch(Exception exp)
            {
                   MessageBox.Show(exp.Message, "Ошибка соединения с базой данных");
               return false;
            }
            return true;

        }

        // выбираем сообщения из таблицы
        public DataSet SelData (string sql1)
        {
            try
            {
                SqlCommand com = new SqlCommand(sql1, connection);
                adapter = new SqlDataAdapter(com);
                dataSet = new DataSet();
                adapter.Fill(dataSet, "firstTable");
                
            }

            catch (SqlException exp)
            {
                MessageBox.Show(exp.Message, "Ошибка");
            }     
            return dataSet;           
            
        }

        // В richTextBox будут показаны сообщения 
        //Iuser -это тот кто за компом пишет.
        //remoteUser - удаленный пользователь, который вам отвечает.
        //  
        public void GetMessages (RichTextBox richTextBox, string Iuser, string remoteUser)
        {            

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
               
                if (row["Users"].ToString() == Iuser)
                {
                    richTextBox.SelectionAlignment = HorizontalAlignment.Right;
                    richTextBox.AppendText(row["UserText"].ToString() + "\r\n" + "\r\n");
                }
                if (row["Users"].ToString() == remoteUser)
                {
                    richTextBox.SelectionAlignment = HorizontalAlignment.Left;
                    richTextBox.AppendText(row["UserText"].ToString() + "\r\n" + "\r\n");
                }            
            }            
        }

        // Получение имен для выбора в lbUser
        

        public void SendMessage(string nameProc,  string UserText,
            string iUser )
        {
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "INS_" + nameProc;
            com.Parameters.AddWithValue("@Users", iUser);
            com.Parameters.AddWithValue("@UserText", UserText);
            com.ExecuteNonQuery();
        }

        // Добавление данные в таблицу Logins
        public void AddLogins( string photoFilePath )
        {
            byte[] photo = GetPhoto(photoFilePath);
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            com.CommandText = "";
        }

        public string ModifyName(string userName)
        {
            string changedUserName = "";

            foreach (char per in userName)
            {
                switch (per)
                {
                    #region
                    case 'а': changedUserName += "a";
                        break;
                    case 'б': changedUserName += "b";
                        break;
                    case 'в': changedUserName += "v";
                        break;
                    case 'г': changedUserName += "g";
                        break;
                    case 'д': changedUserName += "d";
                        break;
                    case 'е': changedUserName += "e";
                        break;
                    case 'ё': changedUserName += "e";
                        break;
                    case 'ж': changedUserName += "j";
                        break;
                    case 'з': changedUserName += "z";
                        break;
                    case 'и': changedUserName += "i";
                        break;
                    case 'й': changedUserName += "y";
                        break;
                    case 'к': changedUserName += "k";
                        break;
                    case 'л': changedUserName += "l";
                        break;
                    case 'м': changedUserName += "m";
                        break;
                    case 'н': changedUserName += "n";
                        break;
                    case 'о': changedUserName += "o";
                        break;
                    case 'п': changedUserName += "p";
                        break;
                    case 'р': changedUserName += "r";
                        break;
                    case 'с': changedUserName += "s";
                        break;
                    case 'т': changedUserName += "t";
                        break;
                    case 'у': changedUserName += "u";
                        break;
                    case 'ф': changedUserName += "f";
                        break;
                    case 'х': changedUserName += "h";
                        break;
                    case 'ц': changedUserName += "c";
                        break;
                    case 'ч': changedUserName += "ch";
                        break;
                    case 'ш': changedUserName += "sh";
                        break;
                    case 'щ': changedUserName += "sh";
                        break;
                    case 'ъ': changedUserName += "z";
                        break;
                    case 'ы': changedUserName += "i";
                        break;
                    case 'ь': changedUserName += "z";
                        break;
                    case 'э': changedUserName += "e";
                        break;
                    case 'ю': changedUserName += "u";
                        break;
                    case 'я': changedUserName += "y";
                        break;

                    //Верхний регистр

                    case 'А': changedUserName += "A";
                        break;
                    case 'Б': changedUserName += "B";
                        break;
                    case 'В': changedUserName += "V";
                        break;
                    case 'Г': changedUserName += "G";
                        break;
                    case 'Д': changedUserName += "D";
                        break;
                    case 'Е': changedUserName += "E";
                        break;
                    case 'Ё': changedUserName += "E";
                        break;
                    case 'Ж': changedUserName += "J";
                        break;
                    case 'З': changedUserName += "Z";
                        break;
                    case 'И': changedUserName += "I";
                        break;
                    case 'Й': changedUserName += "Y";
                        break;
                    case 'К': changedUserName += "K";
                        break;
                    case 'Л': changedUserName += "L";
                        break;
                    case 'М': changedUserName += "M";
                        break;
                    case 'Н': changedUserName += "N";
                        break;
                    case 'О': changedUserName += "O";
                        break;
                    case 'П': changedUserName += "P";
                        break;
                    case 'Р': changedUserName += "R";
                        break;
                    case 'С': changedUserName += "S";
                        break;
                    case 'Т': changedUserName += "T";
                        break;
                    case 'У': changedUserName += "U";
                        break;
                    case 'Ф': changedUserName += "F";
                        break;
                    case 'Х': changedUserName += "H";
                        break;
                    case 'Ц': changedUserName += "C";
                        break;
                    case 'Ч': changedUserName += "CH";
                        break;
                    case 'Ш': changedUserName += "SH";
                        break;
                    case 'Щ': changedUserName += "SH";
                        break;
                    case 'Ъ': changedUserName += "Z";
                        break;
                    case 'Ы': changedUserName += "I";
                        break;
                    case 'Ь': changedUserName += "Z";
                        break;
                    case 'Э': changedUserName += "E";
                        break;
                    case 'Ю': changedUserName += "U";
                        break;
                    case 'Я': changedUserName += "Y";
                        break;
                    #endregion
                }
            }
            return changedUserName;

        }

        public void AddNewUser(string userLogin, string userPassword)
        {
            
            string DisplayName = userLogin;
            userLogin = this.ModifyName(userLogin);
            SqlCommand com = new SqlCommand();
            com.Connection = connection;

            foreach(string table in this.Names)
            {
                com.CommandText = "CREATE TABLE " + userLogin + table +
                      " ( ID" + userLogin + table + "  " + " int IDENTITY(1,1) NOT NULL, " +
                      " Users nvarchar(100) NULL, " +
                      " UserText nvarchar(1000) NULL, " +
                      " AddPhoto  image NULL, " +
                      " UserDate datetime NULL, " +
                      " timeOfRecord datetime NULL DEFAULT (getdate()), " +
                      "CONSTRAINT  PK_" + userLogin + table +
                      " PRIMARY KEY (ID" + userLogin + table + "), )";
                com.ExecuteNonQuery();

                com = new SqlCommand();
                com.Connection = connection;
                com.CommandText = " CREATE PROC INS_" + userLogin + table +
                    " @Users nvarchar(100), @UserText nvarchar(1000) " +
                    " AS " +
                    " INSERT INTO " +userLogin + table + " (Users, UserText) " +
                    " VALUES(@Users, @UserText) " ;
                com.ExecuteNonQuery();
                 // Создание триггера для удаления ранних сообщений.
                com = new SqlCommand();
                com.Connection = connection;
                com.CommandText = "CREATE TRIGGER tr_" +userLogin + table +
                                  " ON "  +userLogin + table+ 
                                  " FOR INSERT " + 
                                  " AS "+ 
                                  " IF (SELECT count(*) from " +userLogin + table + "  ) > 500 " +
                                  " DELETE FROM  " +userLogin + table + 
                                  " where  " +userLogin + table+ ".timeOfRecord  = " +
                                 " (select min(timeOfRecord) " +
                                 " from " +userLogin + table+ "  ) ";
                com.ExecuteNonQuery();                      
            }
           
            com = new SqlCommand("New_User", connection);
            com.Connection = connection;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@userLogin", userLogin);
            com.Parameters.AddWithValue("@userPassword", userPassword);
            com.Parameters.AddWithValue("@DisplayName", DisplayName);
            com.ExecuteNonQuery();
           

        }

        // Проверка логина и пароля и определение своей таблицы 
        public string CheckAccount(string userLogin, string userPassword)
        {
            userLogin = this.ModifyName(userLogin);
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "CheckLogin";

            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@ReturnValue", SqlDbType.NVarChar, 100);
            param.Direction = ParameterDirection.ReturnValue;
            com.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@userLogin";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Value = userLogin;
            com.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@userPassword";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Value = userPassword;
            com.Parameters.Add(param);

            com.ExecuteNonQuery();
            return com.Parameters[0].Value.ToString();// название своей таблицы.
        }


      

        public void AddPhoto(string userLogin, byte [] photo)
        {
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "INS_Logins";
            com.Parameters.AddWithValue("@UserLogin", userLogin);
            
            //MemoryStream memStream = new MemoryStream();
           // image.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            
            SqlParameter param = new SqlParameter("@Photo", SqlDbType.VarBinary);
            param.Value = photo;
            com.Parameters.Add(param);
            com.ExecuteNonQuery();         
        }

        public Image ShowPhotoAndStatus ( string userLogin, out string status)
        {                      
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            com.CommandType = CommandType.Text;
            com.CommandText = "Select LichPhoto, UserStatus from Logins where UserLogin = @UserLogin";
            com.Parameters.AddWithValue("@UserLogin", userLogin);
            status = "";
                     
            SqlDataReader reader = com.ExecuteReader();
            Image image;
            try
            {
                
                if ((reader.HasRows))
                {
                    reader.Read();
                    status = reader["UserStatus"].ToString();
                    MemoryStream memStream;
                    memStream = new MemoryStream((byte[])reader["LichPhoto"]);                    
                    return image = Image.FromStream(memStream);                    
                }
                else
                {
                    image = null;
                    return image;
                }
            }
            catch(InvalidCastException exp)
            {
                //MessageBox.Show(exp.Message, "Ошибка отсутствие данных!",
                //    MessageBoxButtons.OK);
                image = null;
            }
            finally
            {
                reader.Close();
            }
           
            return image;                         
        }

        
        // изменение статуса
        public void ChangeStatus(string userLogin, string userStatus)
        {
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Change_Status";
            com.Parameters.AddWithValue("@UserLogin", userLogin);
            com.Parameters.AddWithValue("UserStatus", userStatus);
            com.ExecuteNonQuery();
        }

        // если пользователь онлайн ставим 1,
        // иначе, если пользователь вне сети ставим  0.
        public void ChangeOnline(string userLogin, int online)
        {
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "UPD_UserOnline";
           
            com.Parameters.AddWithValue("@userLogin", userLogin);
            com.Parameters.AddWithValue("@UserOnline", online);
            com.ExecuteNonQuery();
        }

        //Возвратить статус IUser - то есть того, кто зашел
        public string RetStatus(string userLogin)
        {
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            com.CommandType = CommandType.Text;           
            com.CommandText = "select dbo.Ret_Status(@userLogin)";
             com.Parameters.AddWithValue("@UserLogin", userLogin);
            return com.ExecuteScalar().ToString();
        }

        // Узнаем какое значение в поле UserOnline
        public string RetValueOnline (string userLogin)
        {
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "dbo.SEL_Online";
            com.Parameters.AddWithValue("@UserLogin", userLogin);
            return com.ExecuteScalar().ToString();
        }

        // Получаем фото в виде массива байтов
        public  byte[] GetPhoto (string filePath)
        {
            FileStream stream = new FileStream(filePath,
                                FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            byte [] photo = reader.ReadBytes((int)filePath.Length);
            return photo;
        }

        public void CloseConnection()
        {
            connection.Close();
        }

    }
}
