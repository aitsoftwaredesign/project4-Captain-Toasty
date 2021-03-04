using UnityEngine;
using MySql.Data.MySqlClient;
public class SQLConnector : MonoBehaviour
{
    MySqlConnection connection;
    // Use this for initialization 
    void Start()
    {
  //      SetupSQLConnection();
     //   TestDB();
      //  CloseSQLConnection();
    }
    private void SetupSQLConnection()
    {
        if (connection == null)
        {
            string connectionString = "SERVER=localhost;" + "DATABASE=projectData;" + "UID=newuser;" + "pwd=12345; persistsecurityinfo=True;";
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                Debug.LogError("MySQL Error: " + ex.ToString());
            }
        }
    }
    private void CloseSQLConnection()
    {
        if (connection != null)
        {
            connection.Close();
        }
    }
    public void TestDB()
    {
        string commandText = string.Format("select * from barleyTable;");
        if (connection != null)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            try
            {

                //Execute the query 
                MySqlDataReader sdr = command.ExecuteReader();

                ////Retrieve data from table and Display result
                while (sdr.Read())
                {
                    float yield = (float)sdr[name];
                    Debug.Log(name + ": " + yield);
                }
                command.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Debug.LogError("MySQL error: " + ex.ToString());
            }
        }
    }
}