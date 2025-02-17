using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace DotnetLab6.Pages
{
    public class PersonModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string PhoneNo { get; set; }
        [BindProperty]
        public string Email { get; set; }
        public string message = "";
        public void OnPost()
        {
            string constr = "server=localhost;user=root;password=;database=ncc";
            MySqlConnection conn = new MySqlConnection(constr);
            conn.Open();
            string sql = $"insert into person(Name,Phone,Email) values('{Name}','{PhoneNo}','{Email}')";

            //string sql = "insert into person(Name,Phone,Email) values ('Shubekshya','9876543210','test@gmail.com')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery()>0)
            {
                message = "Saved Successfully";
            }
            else
            {
                message = "Failed To Save";
            }   
            conn.Close();

        }
        public void OnGet()
        {
           
        }
    }
}
