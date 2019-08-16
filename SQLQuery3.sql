SELECT dbo.Books.Quantity-SUM(dbo.Leases.Quantity) FROM dbo.Books, dbo.Leases 
WHERE dbo.Books.Id = dbo.Leases.BookId