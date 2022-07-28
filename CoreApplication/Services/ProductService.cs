using CoreApplication.Models;
using System.Data.SqlClient;

namespace CoreApplication.Services
{
    public class ProductService
    {
        private static string connectionString = "appaz400.database.windows.net";
        private static string userName = "sangappa";
        private static string passWord = "Honda@123456";
        private static string dataBase = "appDb";


        private SqlConnection GetSqlConnection()
        {
            var _builder=new SqlConnectionStringBuilder();
            _builder.DataSource = connectionString;
            _builder.UserID = userName;
            _builder.Password = passWord;
            _builder.InitialCatalog = dataBase;

            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            List<Product> _product_lst = new List<Product>();
            string _statement = "SELECT ProductID,ProductName,Quantity from Products";
            SqlConnection _connection = GetSqlConnection();

            _connection.Open();

            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);

            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Product _product = new Product()
                    {
                        ProductId = _reader.GetInt32(0),
                        ProductName = _reader.GetString(1),
                        Quantity = _reader.GetInt32(2)
                    };

                    _product_lst.Add(_product);
                }
            }
            _connection.Close();
            return _product_lst;
        }



    }

    
}
