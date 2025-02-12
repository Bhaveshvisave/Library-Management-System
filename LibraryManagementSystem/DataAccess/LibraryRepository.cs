using Microsoft.Data.SqlClient;
using LibraryManagementSystem.Models;


namespace LibraryManagementSystem.DataAccess
{
    public class LibraryRepository
    {
        private readonly string _connectionString;

        public LibraryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // BOOK METHODS
        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Books", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = (int)reader["Id"],
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            ISBN = reader["ISBN"].ToString(),
                            PublishedDate = (DateTime)reader["PublishedDate"]
                        });
                    }
                }
            }
            return books;
        }

        public void AddBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Books (Title, Author, ISBN, PublishedDate) VALUES (@Title, @Author, @ISBN, @PublishedDate)", connection);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@ISBN", book.ISBN);
                command.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Books SET Title = @Title, Author = @Author, ISBN = @ISBN, PublishedDate = @PublishedDate WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@ISBN", book.ISBN);
                command.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
                command.Parameters.AddWithValue("@Id", book.Id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteBook(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Books WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", bookId);
                command.ExecuteNonQuery();
            }
        }

        // MEMBER METHODS
        public List<Member> GetMembers()
        {
            var members = new List<Member>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Members", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        members.Add(new Member
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString()
                        });
                    }
                }
            }
            return members;
        }

        public void AddMember(Member member)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Members (Name, Email, Phone) VALUES (@Name, @Email, @Phone)", connection);
                command.Parameters.AddWithValue("@Name", member.Name);
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@Phone", member.Phone);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateMember(Member member)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Members SET Name = @Name, Email = @Email, Phone = @Phone WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Name", member.Name);
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@Phone", member.Phone);
                command.Parameters.AddWithValue("@Id", member.Id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteMember(int memberId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Delete related borrow records first for avoid conflict
                var command = new SqlCommand("DELETE FROM BorrowRecords WHERE MemberId = @MemberId", connection);
                command.Parameters.AddWithValue("@MemberId", memberId);
                command.ExecuteNonQuery();

                // Then delete the member
                command = new SqlCommand("DELETE FROM Members WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", memberId);
                command.ExecuteNonQuery();
            }
        }

        // BORROW RECORD METHODS
        public List<BorrowRecord> GetBorrowRecords()
        {
            var records = new List<BorrowRecord>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"
        SELECT 
        br.Id, br.BookId, br.MemberId, br.BorrowDate, br.ReturnDate,
        b.Title AS BookTitle, m.Name AS MemberName
        FROM BorrowRecords br
        JOIN Books b ON br.BookId = b.Id
        JOIN Members m ON br.MemberId = m.Id", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        records.Add(new BorrowRecord
                        {
                            Id = (int)reader["Id"],
                            BookId = (int)reader["BookId"],
                            MemberId = (int)reader["MemberId"],
                            BorrowDate = (DateTime)reader["BorrowDate"],
                            ReturnDate = (DateTime)reader["ReturnDate"],
                            //ReturnDate = reader["ReturnDate"] as DateTime,
                            Book = new Book { Title = reader["BookTitle"].ToString() },  // Set Book Title
                            Member = new Member { Name = reader["MemberName"].ToString() }
                        });
                    }
                }
            }
            return records;
        }


        public void AddBorrowRecord(BorrowRecord record)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO BorrowRecords (BookId, MemberId, BorrowDate, ReturnDate) VALUES (@BookId, @MemberId, @BorrowDate, @ReturnDate)", connection);
                command.Parameters.AddWithValue("@BookId", record.BookId);
                command.Parameters.AddWithValue("@MemberId", record.MemberId);
                command.Parameters.AddWithValue("@BorrowDate", record.BorrowDate);
                command.Parameters.AddWithValue("@ReturnDate", (object?)record.ReturnDate ?? DBNull.Value);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateBorrowRecord(BorrowRecord record)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE BorrowRecords SET BookId = @BookId, MemberId = @MemberId, BorrowDate = @BorrowDate, ReturnDate = @ReturnDate WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@BookId", record.BookId);
                command.Parameters.AddWithValue("@MemberId", record.MemberId);
                command.Parameters.AddWithValue("@BorrowDate", record.BorrowDate);
                command.Parameters.AddWithValue("@ReturnDate", (object?)record.ReturnDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@Id", record.Id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteBorrowRecord(int recordId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM BorrowRecords WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", recordId);
                command.ExecuteNonQuery();
            }
        }
    }
}
