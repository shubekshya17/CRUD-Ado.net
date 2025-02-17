using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DotnetLab6.Pages
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }
    public class DisplayPersonModel : PageModel
    {
        public List<Person> PersonList { get; set; } = new List<Person>();
        public void OnGet()
        {
            string constr = "server=localhost;user=root;password=;database=ncc";
            MySqlConnection conn = new MySqlConnection(constr);
            conn.Open();
            string sql = "SELECT * from person";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Person person = new Person();
                person.Id = reader.GetInt32("Id");
                person.Name = reader.GetString("Name");
                person.PhoneNo = reader.GetString("Phone");
                person.Email = reader.GetString("Email");
                PersonList.Add(person);
            }
            conn.Close();
        }
    }
}
