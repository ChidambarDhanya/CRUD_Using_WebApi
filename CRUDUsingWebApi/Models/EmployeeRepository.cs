using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDUsingWebApi.Controllers;
using System.Data.SqlClient;

namespace CRUDUsingWebApi.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository()
        {
           
        }

        public SqlConnection GetOpenDataConnection(string server, string database, string user, string password)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = database;
            builder.UserID = user;
            builder.Password = password;

            var connection = new SqlConnection(builder.ToString());
            connection.Open();
            return connection;
        }

        public IEnumerable<Employee> GetAll()
        {
         List<Employee> employees = new List<Employee>();

            using (var cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from Details;";
                cmd.Connection = GetOpenDataConnection(".", "Test", "sa", "Install02");
                Employee em; // new Employee();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    em = new Employee();
                    em.fname = reader[0].ToString();
                    em.lname = reader[1].ToString();
                    em.email = reader[2].ToString();
                    em.status = reader[3].ToString();
                    em.id = Convert.ToInt32(reader[4]);
                    employees.Add(em);
                }
                cmd.Connection.Close();
            }
            return employees;
        }

        public Employee Get(int id)
        {
            using (var cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from Details;";
                cmd.Connection = GetOpenDataConnection(".", "Test", "sa", "Install02");
                Employee em; // new Employee();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    em = new Employee();
                    em.fname = reader[0].ToString();
                    em.lname = reader[1].ToString();
                    em.email = reader[2].ToString();
                    em.status = reader[3].ToString();
                    em.id = Convert.ToInt32(reader[4]);
                    if (em.id == id)
                        return em;
                }
                cmd.Connection.Close();
            }
            return null;
            //return employees.Find(s => s.id == id);
        }

        public bool Add(Employee employee)
        {
            bool addResult = false;
            if (employee == null)
            {
                return addResult;
            }

           // int index = employees.FindIndex(s => s.id == employee.id);
            //if (index == -1)
            {
                using (var cmd = new SqlCommand())
                {
                    string status;
                    if (employee.status.Equals("true"))
                        status = "activated";
                    else
                        status="deactivated";
                    cmd.CommandText = "insert into Details(fname,lname,email,status,id) values(@fname,@lname,@email,@status,@id)";
                    cmd.Parameters.AddWithValue("@fname", employee.fname);
                    cmd.Parameters.AddWithValue("@lname", employee.lname);
                    cmd.Parameters.AddWithValue("@email", employee.email);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", employee.id);
                    cmd.Connection = GetOpenDataConnection(".", "Test", "sa", "Install02");
                    int row = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                //employees.Add(employee);
                addResult = true;
                return addResult;
            }
            //else
            //{
            //    return addResult;
            //}
        }

        //public void Remove(int id)
        //{
        //    employees.RemoveAll(s => s.id == id);
        //}

        public bool Update(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("employee");
            }
            //int index = employees.FindIndex(s => s.id == employee.id);
            //if (index == -1)
            //{
            //    return false;
            //}
            //employees.RemoveAt(index);
            //employees.Add(employee);

            using (var cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from Details;";
                cmd.Connection = GetOpenDataConnection(".", "Test", "sa", "Install02");
                Employee em; // new Employee();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    em = new Employee();
                    em.fname = reader[0].ToString();
                    em.email = reader[2].ToString();
                    em.status = reader[3].ToString();
                    em.id = Convert.ToInt32(reader[4]);
                    if (em.id == employee.id)
                    {
                        var cmd_update = new SqlCommand();
                        cmd_update.Connection = GetOpenDataConnection(".", "Test", "sa", "Install02");
                        cmd_update.CommandText = "update Details set fname=@fname, lname=@lname,status=@status,email=@email where id=@id";
                        cmd_update.Parameters.AddWithValue("@fname", employee.fname);
                        cmd_update.Parameters.AddWithValue("@lname", employee.lname);
                        cmd_update.Parameters.AddWithValue("@email", employee.email);
                        cmd_update.Parameters.AddWithValue("@status", employee.status);
                        cmd_update.Parameters.AddWithValue("@id", employee.id);

                        int row = cmd_update.ExecuteNonQuery();
                        if (row != 0)
                        {
                            cmd_update.Connection.Close();
                            cmd.Connection.Close();
                            return true;
                        }
                    }
                }
                cmd.Connection.Close();
            }

            return false;
        }

        public bool Delete(int id)
        {
            //int index = employees.FindIndex(s => s.id == employee.id);
            //if (index == -1)
            //{
            //    return false;
            //}
            //employees.RemoveAt(index);
            //employees.Add(employee);

            using (var cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from Details;";
                cmd.Connection = GetOpenDataConnection(".", "Test", "sa", "Install02");
                Employee em; // new Employee();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    em = new Employee();
                    em.fname = reader[0].ToString();
                    em.email = reader[2].ToString();
                    em.status = reader[3].ToString();
                    em.id = Convert.ToInt32(reader[4]);
                    if (em.id == id)
                    {
                        var cmd_update = new SqlCommand();
                        cmd_update.Connection = GetOpenDataConnection(".", "Test", "sa", "Install02");
                        cmd_update.CommandText = "Delete from Details where id=@id";
                        //cmd_update.Parameters.AddWithValue("@status", employee.status);
                        cmd_update.Parameters.AddWithValue("@id", id);
                        if (em.status.Equals("deactivated"))
                        {
                            int row = cmd_update.ExecuteNonQuery();
                            if (row != 0)
                            {
                                cmd_update.Connection.Close();
                                return true;
                            }
                        }
                    }
                }
                cmd.Connection.Close();
            }

            return false;
        }
    }
}