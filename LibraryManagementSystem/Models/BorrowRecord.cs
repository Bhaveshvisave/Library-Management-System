using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        [ForeignKey("MemberId")]
        public Member? Member { get; set; }

        [ForeignKey("BookId")]
        public Book? Book { get; set; }
    }
}
