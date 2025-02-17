using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace DotnetLab6.Pages
{
    public class DeletePersonModel : PageModel
    {
        public void OnGet(string id)
        {
            string constr = "server=localhost;user=root;password=;database=ncc";
            MySqlConnection conn = new MySqlConnection(constr);
            conn.Open();
            string sql = "DELETE from person where id="+id;

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
           
            conn.Close();
            Response.Redirect("/DisplayPerson");
        }
    }
}
