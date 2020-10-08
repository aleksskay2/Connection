using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDLL
{
    public interface IConnection
    {
        void SendMessage(string nameProc, string usetTetx, string iUser);
        string CheckAccount(string userLogin, string userPassword);
        void AddPhoto(string userLogin, byte[] photo);
    }
}
