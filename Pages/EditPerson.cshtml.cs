using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System;

namespace DotnetLab6.Pages
{
    public class EditPersonModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string PhoneNo { get; set; }
        [BindProperty]
        public string Email { get; set; }
        public string message = "";
        public void OnGet(string id)
        {
            string constr = "server=localhost;user=root;password=;database=ncc";
            MySqlConnection conn = new MySqlConnection(constr);
            conn.Open();
            string sql = "SELECT * from person Where id="+id;

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Id = reader.GetInt32("Id");
                Name = reader.GetString("Name");
                PhoneNo = reader.GetString("Phone");
                Email = reader.GetString("Email");
            }
            conn.Close();
        }
        public void OnPost(string id)
        {
            string constr = "server=localhost;user=root;password=;database=ncc";
            MySqlConnection conn = new MySqlConnection(constr);
            conn.Open();
            string sql = $"Update person set name='{Name}',phone='{PhoneNo}',email='{Email}' Where id=" + id;

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                message = "Saved Successfully";
            }
            else
            {
                message = "Failed To Save";
            }
            conn.Close();
            Response.Redirect("/DisplayPerson");
        }
    }
}
