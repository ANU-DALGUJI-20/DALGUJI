﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using System.Security.Cryptography;

namespace Dalgucci.Controllers
{
    
    public class Test
    {
        private string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=SF1team;Password=1234;";

        public void update()
        {
            // 오라클 연결
            //OracleConnection conn = new OracleConnection(strConn);
            try
            {
                OracleConnection conn = new OracleConnection(strConn);
                conn.Open();

                // 명령 객체 생성
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                cmd.CommandText = "insert into product values (1236,'bbbb','205',1)";
                cmd.ExecuteNonQuery();

                //conn.Close();
            }
            catch( Exception ex )
            {
                int ttt = 0;
            }

        }
    }
}
