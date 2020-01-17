using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;

namespace MuranoTest.Models
{
    public class DBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = "Data Source=(LocalDb)\\MSSQLLocalDb;Initial Catalog=UserProfile;Integrated Security=True;Pooling=False";
            con = new SqlConnection(constring);
        }

        public List<OneRow> GetItemsList()
        {
            connection();

            string query = "SELECT  Persons.id as PersonsId," +
                "                   Name, " +
                "                   Age, " +
                "                   City," +
                "                   Employees.id as EmployeesId," +
                "                   Salary," +
                "                   Managers.id as ManagersId," +
                "                   KPI," +
                "                   Bonus" +
                "                   FROM Persons" +
                "                   LEFT JOIN Employees on Employees.toPersonsId = Persons.id" +
                "                   LEFT JOIN Managers on Managers.toEmplid = Employees.id";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            List<OneRow> iList = new List<OneRow>();

            foreach (DataRow dr in dt.Rows)
            {
                iList.Add(new OneRow
                {
                    PersonsId = Convert.ToString(dr["PersonsId"]),
                    Name = Convert.ToString(dr["Name"]),
                    Age = Convert.ToString(dr["Age"]),
                    City = Convert.ToString(dr["City"]),
                    EmployeesId = Convert.ToString(dr["EmployeesId"]),
                    Salary = Convert.ToString(dr["Salary"]),
                    ManagersId = Convert.ToString(dr["ManagersId"]),
                    KPI = Convert.ToString(dr["KPI"]),
                    Bonus = Convert.ToString(dr["Bonus"])
                });
            }
            return iList;
        }

        public bool UpdateItem(List<OneRow> iList)
        {
            connection();
            SqlCommand cmd = new SqlCommand("SELECT 1", con);
            con.Open();
            int flag;
            flag = 1;
            foreach (OneRow sp in iList)
            {
                if (sp.PersonsId != null && flag >= 1)
                {
                    cmd.CommandText = "UPDATE Persons SET Name = '" + sp.Name.ToString() + "', age =" + sp.Age.ToString() + ", city ='" + sp.City.ToString() + "' WHERE id=" + sp.PersonsId.ToString();
                    flag = cmd.ExecuteNonQuery();
                }

                if (sp.EmployeesId != null && flag >= 1)
                {
                    cmd.CommandText = "UPDATE Employees SET Salary =" + sp.Salary.ToString() + " WHERE ID =" + sp.EmployeesId.ToString();
                    flag = cmd.ExecuteNonQuery();
                }

                if (sp.ManagersId != null && flag >= 1)
                {
                    cmd.CommandText = "UPDATE Managers SET Kpi =" + sp.KPI.ToString() + ", Bonus =" + sp.Bonus.ToString() + " WHERE ID =" + sp.ManagersId.ToString();
                    flag = cmd.ExecuteNonQuery();
                }
            }

            con.Close();

            if (flag >= 1)
                return true;
            else
                return false;
        }
    }
}
