using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IstanbulCoders
{
	public class BookRepository
	{
		public List<Book> List()
		{
			SqlCommand command = new SqlCommand();
			command.CommandText = "select * from dbo.Book";
			command.CommandType = CommandType.Text;
			command.Connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;Initial Catalog=deneme;Integrated Security=True");

			List<Book> list = null;
			using (command)
			{
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();

					SqlDataReader sqlDataReader = command.ExecuteReader();
					DataTable dataTable = new DataTable();
					dataTable.Load(sqlDataReader);

					if (dataTable.Rows.Count > 0)
					{
						list = new List<Book>(dataTable.Rows.Count);
					}

					foreach (DataRow dataRow in dataTable.Rows)
					{
						list.Add(new Book() { Id = dataRow["Id"].ToString() });
					}
				}
			}

			return list;
		}
	}
}