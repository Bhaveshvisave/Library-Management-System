// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Hide Success Message After 3 Seconds
document.addEventListener("DOMContentLoaded", function () {
    const successMessage = document.getElementById("SuccessMessage");

    if (successMessage && successMessage.style.display !== "none") {
        setTimeout(() => {
            successMessage.style.display = "none"; // Hide success message
            location.reload(); // ✅ Refresh the page only after hiding the message
        }, 3000); // Wait for 3 seconds
    }
});

// Enable DarkMode
let isDarkMode = localStorage.getItem("darkMode") === "true";

function applyDarkMode() {
    const navbar = document.getElementById("navbar");
    const darkModeIcon = document.getElementById("darkModeIcon");
    const table = document.querySelector("table");
    const footer = document.getElementById("footer");
    const inputs = document.querySelectorAll("input, select, textarea"); // Select all form fields

    if (isDarkMode) {
        document.body.style.backgroundColor = "#1f1f1f";
        document.body.style.color = "#e8e8e8";

        if (navbar) {
            navbar.classList.remove("bg-light");
            navbar.classList.add("bg-dark", "navbar-dark");
        }

        if (table) {
            table.classList.remove("table-light");
            table.classList.add("table-dark", "table-bordered");
        }

        if (footer) {
            footer.classList.remove("bg-light", "text-dark");
            footer.classList.add("bg-dark", "text-light");
        }

        // ✅ Change Input, Select, and Textarea Text Color in Dark Mode
        inputs.forEach(input => {
            input.style.backgroundColor = "#333"; // Dark gray background
            input.style.color = "white"; // White text
            input.style.border = "1px solid #777"; // Subtle border for visibility
        });

        // ✅ Update Dark Mode Icon
        if (darkModeIcon) {
            darkModeIcon.src = "/day-mode.png";
            darkModeIcon.alt = "Light Mode";
        }
    } else {
        document.body.style.backgroundColor = "white";
        document.body.style.color = "black";

        if (navbar) {
            navbar.classList.remove("bg-dark", "navbar-dark");
            navbar.classList.add("bg-light");
        }

        if (table) {
            table.classList.remove("table-dark", "table-bordered");
            table.classList.add("table-light");
        }

        if (footer) {
            footer.classList.remove("bg-dark", "text-light");
            footer.classList.add("bg-light", "text-dark");
        }

        // ✅ Reset Input, Select, and Textarea Styles in Light Mode
        inputs.forEach(input => {
            input.style.backgroundColor = "white"; // Default white background
            input.style.color = "black"; // Black text
            input.style.border = "1px solid #ccc"; // Light border
        });

        // ✅ Update Light Mode Icon
        if (darkModeIcon) {
            darkModeIcon.src = "/moon.png";
            darkModeIcon.alt = "Dark Mode";
        }
    }
}

// ✅ Ensure Dark Mode Applies on Page Load
document.addEventListener("DOMContentLoaded", applyDarkMode);

// Function to toggle dark mode
function darkmode() {
    isDarkMode = !isDarkMode;
    localStorage.setItem("darkMode", isDarkMode);
    applyDarkMode();
}
