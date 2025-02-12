# Library Management System

The Library Management System is a web-based application designed to manage the details of books, members, and borrow records in a library. It allows administrators to add new books, register new members, and track the borrowing and returning of books. This system simplifies library management and enhances the efficiency of maintaining records.

## Key Features

- **Book Management**: Add, update, and manage book records, including title, author, ISBN, and published date.
- **Member Management**: Add, update, and manage member records with name, email, and phone details.
- **Borrow Record Management**: Track borrow records, including borrow date, return date, and member details.
- **Database Integration**: Data is stored in a Microsoft SQL Server database using Entity Framework Core (Database First Approach).
- **Responsive Design**: The system is fully responsive and accessible on multiple devices (desktop, tablet, and mobile).
- **Modern User Interface**: Uses Bootstrap for a professional and user-friendly interface.

## Project Structure

<pre>
LibraryManagementSystem/
│
├── Controllers/
│   └── HomeController.cs        # Home page controller
│   └── BooksController.cs       # Book management controller
│   └── MembersController.cs     # Member management controller
│   └── BorrowRecordsController.cs # Borrow record management controller
│
├── Models/
│   └── Book.cs                  # Book model class
│   └── Member.cs                # Member model class
│   └── BorrowRecord.cs          # Borrow record model class
│
├── Views/
│   ├── Home/
│   │   └── Index.cshtml         # Home page view
│   ├── Books/
│   │   └── Index.cshtml         # Book management view
│   │   └── Edit.cshtml          # Edit book view
│   ├── Members/
│   │   └── Index.cshtml         # Member management view
│   │   └── Edit.cshtml          # Edit member view
│   ├── BorrowRecords/
│   │   └── Index.cshtml         # Borrow record management view
│   │   └── Edit.cshtml          # Edit borrow record view
│   └── Shared/
│       └── _Layout.cshtml       # Layout page (includes site-wide header, footer, and styles)
│
├── wwwroot/
│   ├── css/
│   │   └── site.css             # Custom CSS styles
│   ├── js/
│   │   └── site.js              # Custom JavaScript functionality
│   └── images/
│       └── logo.png             # Logo for the system
│
└── README.md                    # Project README file
</pre>

## Technologies Used

#### Frontend:

- HTML5
- CSS3
- Bootstrap 5
- JavaScript

#### Backend:

- ASP.NET Core
- ASP.NET MVC
- Entity Framework Core (Database First Approach)
- Microsoft SQL Server (Database)

## How to Run the Project

1. Clone the repository:

   ```bash
   git clone https://github.com/Bhaveshvisave/Library-Management-System.git
   ```

2. Open the project: Navigate to the project directory and open the solution file(.sln) in Visual Studio.

3. Restore NuGet packages:

   Run the following command in Package Manager Console (PMC):
   
   ```bash
   Update-Package -reinstall
   ```

4. Run the application: Press `F5` to build and run the application locally.

5. Browse through the pages:

    - **Home**: View the home page with general information.
    - **Book Management**: Manage book details from the `Books` section.
    - **Member Management**: Manage member details from the `Members` section.
    - **Borrow Records**: View and manage borrow records from the `BorrowRecords` section.

## Features to be Added 

- Role-based access control (Admin, Member).
- Enhanced search functionality for books and members.
- Email notifications for overdue books.

## Contributing

Contributions are always welcome! If you'd like to add new features, fix bugs, or suggest improvements, feel free to fork the repository and submit a pull request.

### Steps to Contribute

1. Fork the repository.

2. Create your feature branch:

    ```bash
   git checkout -b feature/your-feature
    ```

4. Commit your changes:

    ```bash
   git commit -m 'Add your feature'
    ```

6. Push to the branch:

    ```bash
   git push origin feature/your-feature
    ```

8. Create a Pull Request (PR) on GitHub.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

---

## Contact

For any inquiries or support, feel free to contact me via:

Email: bhaveshrvisave@gmail.com

GitHub: Bhaveshvisave

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![ForTheBadge built-with-love](http://ForTheBadge.com/images/badges/built-with-love.svg)](https://GitHub.com/Bhaveshvisave/)
