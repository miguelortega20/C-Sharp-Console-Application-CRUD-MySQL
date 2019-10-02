using System;
using MySql.Data.MySqlClient;


namespace CRUD1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C#: Conectando con MySQL");

            try{

                string connectionString;
                connectionString = "server=localhost;port=3306;uid=root;pwd='';database=crud;charset=utf8;SslMode=none;";
                MySqlConnection con = new MySqlConnection(connectionString);

                con.Open();
                Console.WriteLine("Conection is " + con.State.ToString() + Environment.NewLine);


                MySqlCommand com = con.CreateCommand();

                //3.-Mostrar TABLA
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "SELECT * FROM usuarios";

                MySqlDataReader rd = com.ExecuteReader();

                string str ="[id]\t[idUser]\t[nombre]\t[password]" + Environment.NewLine;

                if(rd.HasRows){

                    while (rd.Read())
                    {
                        str += Convert.ToString(rd.GetInt32(0)) + "\t" + rd.GetString(1) + "\t" + rd.GetString(2) + "\t\t" + rd.GetString(3) + 
                        Environment.NewLine;
                    }
                    rd.Close();
                }
                
                Console.WriteLine(str);

                con.Close();
                Console.WriteLine("Conection is " + con.State.ToString() + Environment.NewLine);

            }catch(MySql.Data.MySqlClient.MySqlException ex){
                Console.Write("Error: " + ex.Message.ToString());
            }

            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }
    }
}
