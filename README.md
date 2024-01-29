sql part
-------------------
CREATE TABLE Borrowings (
    BorrowingID INT PRIMARY KEY,
    UserID INT,
    BookID INT,
    BorrowDate DATETIME NOT NULL,
    ReturnDate DATETIME,
    Returned BIT DEFAULT 0,  
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
    CONSTRAINT CK_ReturnDate CHECK (ReturnDate IS NULL OR Returned = 1) -- Ensures consistency between ReturnDate and Returned flag
);
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    UserName VARCHAR(100) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Age INT,
    PhoneNumber NVARCHAR(50),
    CONSTRAINT Unique_Email UNIQUE (Email) -- Ensures email is unique
);
CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    ISBN VARCHAR(13) NOT NULL,
    Availability BIT NOT NULL,
    CONSTRAINT Unique_ISBN UNIQUE (ISBN) -- Ensures ISBN is unique
);

