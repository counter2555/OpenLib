SELECT DISTINCT(dbo.Leases.Id), dbo.Leases.BookId, dbo.Leases.Quantity,
                            dbo.Leases.UserId, dbo.Leases.LeaseDate, dbo.Leases.ReturnDate,
                            dbo.Leases.Returned, dbo.Leases.Remarks,

                            (SELECT dbo.Books.ISBN FROM dbo.Books WHERE dbo.Books.Id = dbo.Leases.BookId) as ISBN,
                            (SELECT dbo.Books.Title FROM dbo.Books WHERE dbo.Books.Id = dbo.Leases.BookId) as Title,
                            (SELECT dbo.Users.FirstName FROM dbo.Users WHERE dbo.Users.Id = dbo.Leases.UserId) as FirstName,
                            (SELECT dbo.Users.LastName FROM dbo.Users WHERE dbo.Users.Id = dbo.Leases.UserId) as LastName

FROM dbo.Leases, dbo.Books WHERE dbo.Leases.Returned = 0 AND 
(LOWER(FirstName) LIKE LOWER('ma') OR LOWER(LastName) LIKE LOWER('ma'));
