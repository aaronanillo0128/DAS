
using System.Data.SqlClient;


 class connection
{
    private static string conString = "Data Source=apbiphbpsdb01;Initial Catalog=PS Digital Audit;Persist Security Info=True;User ID=saa;Password=P@ssw0rd;"; //>>> Insert Constring here!

    public static SqlConnection mysqldb()
    {
        return new SqlConnection(conString);
    }
    public static SqlConnection con = mysqldb();
   }



