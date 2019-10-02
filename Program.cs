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

                //1.- MySQL INTER INTO
                com.CommandText = "INSERT INTO usuarios(idUser,nombre,password) VALUES('mmel','Mel','Ayala')";
                com.ExecuteNonQuery();
                Console.WriteLine("--Registro Insertado! Presione cualquier tecla para ver el resultado ...");
                Console.ReadKey();
                
                //2.- MYSQL UPDATE
                com.CommandText = "UPDATE usuarios SET idUser = 'miguel20', nombre = 'Miguel Angel', password = 'miguel@cuentas' WHERE id = 2";
                com.ExecuteNonQuery();
                Console.WriteLine("--Registro Actualizado! Presione cualquier tecla para ver el resultado ...");
                Console.ReadKey();

                //3.- MYSQL DELETE
                com.CommandText = "DELETE FROM usuarios WHERE id = 5";
                com.ExecuteNonQuery();
                Console.WriteLine("--Registro Borrado! Presione cualquier tecla para ver el resultado ...");
                Console.ReadKey();

                //4.-Read || MYSQL SELECT (FROM WHERE)
                com.CommandType = System.Data.CommandType.Text;
                // com.CommandText = "SELECT * FROM usuarios WHERE id = 1";
                // com.CommandText = "SELECT * FROM usuarios WHERE id NOT IN(1,4)";
                // com.CommandText = "SELECT * FROM usuarios WHERE nombre LIKE '%Miguel%'";
                // com.CommandText = "SELECT * FROM usuarios WHERE nombre LIKE '%Miguel%'";
                com.CommandText = "SELECT * FROM usuarios";

                MySqlDataReader rd = com.ExecuteReader();

                string str ="[id]\t[idUser]\t[nombre]\t[password]" + Environment.NewLine;

                if(rd.HasRows){

                    while (rd.Read())
                    {
                        str += Convert.ToString(rd.GetInt32(0)) + "\t" + rd.GetString(1) + "\t" + rd.GetString(2) + "\t\t" + rd.GetString(3) + 
                        Environment.NewLine;
                    }
                    Console.WriteLine(str);
                    rd.Close();
                }
                else{
                    Console.WriteLine("-->Lo siento, Registro no encontrado!<---\n");
                }

                rd.Close();
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
