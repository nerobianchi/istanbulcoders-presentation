using System.Data;
using System.Data.SqlClient;

namespace IstanbulCoders.IntegrationTests
{
	public class BookRepositoryHelper
	{
		public static void InsertOneBook()
		{
			SqlCommand command = new SqlCommand();
			command.CommandText = "insert into dbo.Book(Id) values('1')";
			command.CommandType = CommandType.Text;
			command.Connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;Initial Catalog=deneme;Integrated Security=True");

			using (command)
			{
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();

					command.ExecuteNonQuery();
				}
			}
		}

		public static void InitializeBookTable()
		{
			SqlCommand command = new SqlCommand();
			command.CommandText = @"if object_id('dbo.Book') >0
begin
drop table dbo.Book
end
create table dbo.Book
(
	Id varchar(30) not null
)

";
			command.CommandType = CommandType.Text;
			command.Connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;Initial Catalog=deneme;Integrated Security=True");

			using (command)
			{
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();

					command.ExecuteNonQuery();
				}
			}
		}

		public static void InsertTwoBooks()
		{
			SqlCommand command = new SqlCommand();
			command.CommandText = @"
insert into dbo.Book(Id) values('1')
insert into dbo.Book(Id) values('2')
";
			command.CommandType = CommandType.Text;
			command.Connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;Initial Catalog=deneme;Integrated Security=True");

			using (command)
			{
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();

					command.ExecuteNonQuery();
				}
			}
		}
	}
}