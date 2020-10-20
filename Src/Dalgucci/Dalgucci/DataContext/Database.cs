using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Dalgucci
{

    public class Database 
    {
        OracleConnection conn = null;

        public  Database()
        {
            string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=SF1team;Password=1234;";
            conn = new OracleConnection(strConn);
            conn.Open();
        }

        public void InsertMember(string MemberID, string Password, string User_name, string Tel, string RRN, string Address, string Email)
        {
            try
            {
                // 명령 객체 생성
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                cmd.CommandText = $"insert into user_table values ('{MemberID}','{Password}','{User_name}','{Tel}','{RRN}','{Address}','{Email}')";
                cmd.ExecuteNonQuery();

                //conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public bool Sign_in(string MemberID, string Password)
        {
            try
            {
                // 명령 객체 생성
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                cmd.CommandText = $"select count(*) from user_table where user_id = '{MemberID}' and pwd = '{Password}'";
                //int r = cmd.ExecuteNonQuery();
                OracleDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                var s = rdr["COUNT(*)"];
                int o = Convert.ToInt32(s);
                return o > 0 ? true : false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Login_state(string MemberID, string Password, string User_name, string Tel, string RRN, string Address, string Email)
        {
            try
            {
                // 명령 객체 생성
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                cmd.CommandText = $"insert into user_table values ('{MemberID}','{Password}','{User_name}','{Tel}','{RRN}','{Address}','{Email}')";
                cmd.ExecuteNonQuery();

                //conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void update()
        {
            // 오라클 연결
            //
            try
            {
                

                // 명령 객체 생성
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                cmd.CommandText = "insert into product values (1236,'bbbb','205',1)";
                cmd.ExecuteNonQuery();

                //conn.Close();
            }
            catch (Exception ex)
            {
                int ttt = 0;
            }

        }
    }
}
