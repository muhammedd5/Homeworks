-- Veri tabanını kontrollü bir şekilde oluşturma
USE master
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name= 'LearnifyStockAppDb')
BEGIN
    ALTER DATABASE LearnifyStockAppDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE LearnifyStockAppDb
END
GO

CREATE DATABASE LearnifyStockAppDb
GO

USE LearnifyStockAppDb
GO

-- TABLOLARIN OLUŞTURULMASI
-- Kategoriler tablosunu oluşturma
CREATE TABLE Categories(
    Id INT PRIMARY KEY IDENTITY(1,1),
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME,

    Name NVARCHAR(50) NOT NULL,
    Description NVARCHAR(100) NOT NULL
)
GO

-- Tedarikçiler tablosunu oluşturma
CREATE TABLE Suppliers(
    Id INT PRIMARY KEY IDENTITY(1,1),
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME,

    Name NVARCHAR(100) NOT NULL,
    ContactName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Address NVARCHAR(100) NOT NULL,
    City NVARCHAR(50) NOT NULL,
    Country NVARCHAR(50) NOT NULL
)
GO

-- Ürünler tablosunu oluşturulma
CREATE TABLE Products(
    Id INT PRIMARY KEY IDENTITY(1,1),
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME,

    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    CategoryId INT NOT NULL,
    SupplierId INT NOT NULL,
    StockQuantity INT NOT NULL DEFAULT 0,
    MinimumStockLevel INT NOT NULL DEFAULT 0,
    Price DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Products_Suppliers FOREIGN KEY(SupplierId) REFERENCES Suppliers(Id) ON DELETE CASCADE,

    CONSTRAINT CHK_Products_StockQuantity CHECK (StockQuantity>=0),
    CONSTRAINT CHK_Products_MinimumStockLevel CHECK (MinimumStockLevel>=0),
    CONSTRAINT CHK_Products_Price CHECK (Price>=0)
)
GO

-- Hareket Tipleri tablosunu oluşturma
CREATE TABLE TransactionTypes(
    Id INT PRIMARY KEY IDENTITY(1,1),
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME,

    Name NVARCHAR(20) NOT NULL
)
GO

-- Stok Hareketleri Tablosunu oluşturma
CREATE TABLE StockTransactions(
    Id INT PRIMARY KEY IDENTITY(1,1),
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME,

    ProductId INT NOT NULL,
    TransactionTypeId INT NOT NULL,
    TransactionDate DATETIME NOT NULL DEFAULT GETDATE(),
    Quantity INT NOT NULL DEFAULT 1,
    Note NVARCHAR(MAX),

    CONSTRAINT FK_StockTransactions_Products FOREIGN KEY(ProductId) REFERENCES Products(Id) ON DELETE CASCADE,
    CONSTRAINT FK_StockTransactions_TransactionTypes FOREIGN KEY(TransactionTypeId) REFERENCES TransactionTypes(Id) ON DELETE CASCADE,

    CONSTRAINT CHK_StockTransactions_Quantity CHECK (Quantity>0)
)
GO

-- Müşteriler Tablosunu oluşturma
CREATE TABLE Customers(
    Id INT PRIMARY KEY IDENTITY(1,1),
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME,

    Name NVARCHAR(100) NOT NULL,
    ContactName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Address NVARCHAR(100) NOT NULL,
    City NVARCHAR(50) NOT NULL,
    Country NVARCHAR(50) NOT NULL
)
GO

-- Satışlar tablosunu oluşturma
CREATE TABLE Sales(
    Id INT PRIMARY KEY IDENTITY(1,1),
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME,   

    ProductId INT NOT NULL,
    CustomerId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    SaleDate DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Sales_Products FOREIGN KEY (ProductId) REFERENCES Products(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Sales_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id) ON DELETE CASCADE,

    CONSTRAINT CHK_Sales_Quantity CHECK (Quantity>0),
    CONSTRAINT CHK_Sales_UnitPrice CHECK (UnitPrice>0)
)
GO

INSERT INTO Categories (Name, Description)
VALUES
    ('Elektronik', 'Telefon, bilgisayar ve diğer elektronik ürünler'),
    ('Ev Eşyaları', 'Evde kullanılan eşyalar ve mobilyalar'),
    ('Kıyafet', 'Kadın, erkek ve çocuk kıyafetleri'),
    ('Yiyecek & İçecek', 'Gıda ve içecek ürünleri'),
    ('Spor & Outdoor', 'Spor malzemeleri ve açık hava aktiviteleri');
GO

INSERT INTO Suppliers (Name, ContactName, Email, PhoneNumber, Address, City, Country)
VALUES
    ('TechSupply Inc.', 'Ali Yılmaz', 'ali@techsupply.com', '+90 555 123 45 67', 'İstanbul, Avcılar', 'İstanbul', 'Türkiye'),
    ('Furniture World', 'Mehmet Kaya', 'mehmet@furnitureworld.com', '+90 555 234 56 78', 'Ankara, Çankaya', 'Ankara', 'Türkiye'),
    ('ClothShop', 'Fatma Demir', 'fatma@clothshop.com', '+90 555 345 67 89', 'İzmir, Konak', 'İzmir', 'Türkiye'),
    ('Gourmet Foods', 'Zeynep Yüksel', 'zeynep@gourmetfoods.com', '+90 555 456 78 90', 'Antalya, Muratpaşa', 'Antalya', 'Türkiye'),
    ('SportGear', 'Ahmet Sönmez', 'ahmet@sportgear.com', '+90 555 567 89 01', 'Bursa, Nilüfer', 'Bursa', 'Türkiye'),
    ('SuperTech Ltd.', 'Ayşe Çetin', 'ayse@supertech.com', '+90 555 678 90 12', 'İstanbul, Beşiktaş', 'İstanbul', 'Türkiye'),
    ('HomeLux', 'Kadir Çalışkan', 'kadir@homelux.com', '+90 555 789 01 23', 'Konya, Meram', 'Konya', 'Türkiye');
GO

INSERT INTO Products (Name, Description, CategoryId, SupplierId, StockQuantity, MinimumStockLevel, Price)
VALUES
    ('iPhone 14', 'Apple iPhone 14 Pro 128GB', 1, 1, 50, 10, 15000.00),
    ('Samsung Galaxy S22', 'Samsung Galaxy S22 128GB', 1, 1, 40, 8, 14000.00),
    ('MacBook Pro 16"', 'Apple MacBook Pro 16" M1 Pro', 1, 1, 20, 5, 30000.00),
    ('Samsun 55" 4K TV', 'Samsun 55" UHD Smart TV', 1, 2, 15, 3, 9000.00),
    ('Ergonomic Office Chair', 'High-back ergonomic office chair', 2, 2, 100, 20, 5000.00),
    ('Wooden Dining Table', 'Dining table for 6 people', 2, 3, 30, 6, 3500.00),
    ('Cotton T-shirt', 'Basic white cotton T-shirt', 3, 3, 200, 50, 150.00),
    ('Leather Jacket', 'Genuine leather jacket', 3, 3, 70, 10, 1200.00),
    ('Jogging Pants', 'Comfortable jogger pants', 3, 4, 100, 20, 400.00),
    ('Organic Peanut Butter', 'All natural peanut butter', 4, 4, 500, 50, 30.00),
    ('Protein Bar', 'High protein snack bar', 4, 4, 300, 50, 20.00),
    ('Mountain Bike', 'MTB for outdoor activities', 5, 5, 10, 2, 3500.00),
    ('Hiking Backpack', 'Water-resistant hiking backpack', 5, 5, 15, 3, 2500.00),
    ('Yoga Mat', 'Eco-friendly yoga mat', 5, 6, 200, 50, 250.00),
    ('Camping Tent', '4-person camping tent', 5, 6, 30, 5, 4500.00),
    ('Smart Watch', 'Waterproof smart watch', 1, 7, 75, 15, 2200.00),
    ('Bluetooth Speaker', 'Portable Bluetooth speaker', 1, 7, 120, 25, 700.00),
    ('Kitchen Blender', 'Powerful kitchen blender', 2, 2, 50, 10, 1800.00),
    ('Recliner Sofa', '3-seater recliner sofa', 2, 2, 20, 4, 6500.00),
    ('Jeans', 'Slim fit blue jeans', 3, 3, 150, 30, 500.00),
    ('Winter Coat', 'Warm winter coat for men', 3, 3, 60, 10, 2000.00),
    ('Energy Drink', 'High-energy sports drink', 4, 4, 250, 50, 10.00),
    ('Cereal Box', 'Whole grain breakfast cereal', 4, 4, 300, 60, 20.00),
    ('Tennis Racket', 'Pro-level tennis racket', 5, 5, 10, 2, 1200.00),
    ('Camping Stove', 'Portable camping stove', 5, 5, 15, 3, 800.00),
    ('Electric Grill', 'Compact electric grill', 2, 6, 40, 10, 1200.00),
    ('Wine Glasses Set', 'Set of 6 premium wine glasses', 2, 6, 70, 15, 500.00),
    ('Men''s Sneakers', 'Casual running sneakers', 3, 3, 180, 40, 600.00),
    ('Women''s Boots', 'Winter boots for women', 3, 3, 60, 15, 1500.00),
    ('Chocolate Bar', 'Premium dark chocolate', 4, 4, 400, 80, 15.00),
    ('Fruit Juice', '100% natural fruit juice', 4, 4, 300, 60, 12.00),
    ('Cycling Helmet', 'Safety helmet for cycling', 5, 5, 25, 5, 500.00),
    ('Ski Jacket', 'Waterproof ski jacket', 5, 5, 30, 6, 2000.00),
    ('Portable Generator', 'Small portable generator', 2, 6, 10, 2, 3500.00),
    ('Handheld Vacuum', 'Cordless handheld vacuum cleaner', 2, 6, 40, 8, 1200.00),
    ('Guitar', 'Acoustic guitar for beginners', 5, 5, 15, 3, 1800.00),
    ('Camping Chair', 'Foldable camping chair', 5, 6, 90, 20, 350.00),
    ('Skateboard', 'Beginner skateboard', 5, 5, 50, 10, 600.00),
    ('Portable Air Conditioner', 'Mobile air conditioning unit', 2, 6, 20, 4, 5000.00),
    ('Smart Thermostat', 'Smart home thermostat', 2, 6, 25, 5, 1500.00),
    ('Smart Lighting System', 'Smart LED lighting', 2, 6, 40, 8, 1000.00),
    ('Bicycle Lock', 'Heavy-duty bicycle lock', 5, 5, 100, 25, 150.00),
    ('Treadmill', 'Electric treadmill', 5, 5, 10, 2, 5000.00),
    ('Camping Lantern', 'Solar-powered camping lantern', 5, 6, 60, 15, 300.00),
    ('Portable Heater', 'Compact portable heater', 2, 6, 30, 7, 900.00),
        ('Portable Heater2', 'Compact portable heater', 2, 6, 30, 7, 900.00),
            ('Portable Heater3', 'Compact portable heater', 2, 6, 30, 7, 900.00),
                ('Portable Heater4', 'Compact portable heater', 2, 6, 30, 7, 900.00),
                    ('Portable Heater5', 'Compact portable heater', 2, 6, 30, 7, 900.00),
                        ('Portable Heater6', 'Compact portable heater', 2, 6, 30, 7, 900.00),
    ('Camping Table', 'Foldable camping table', 5, 6, 50, 10, 600.00);
GO

INSERT INTO TransactionTypes (Name)
VALUES
    ('Giriş'),
    ('Çıkış');
GO

-- 10 Giriş Kaydı
INSERT INTO StockTransactions (ProductId, TransactionTypeId, TransactionDate, Quantity, Note)
VALUES
    (1, 1, '2022-01-15', 10, 'Stok Girişi'),
    (2, 1, '2022-01-20', 5, 'Stok Girişi'),
    (3, 1, '2022-02-10', 15, 'Stok Girişi'),
    (4, 1, '2022-02-15', 8, 'Stok Girişi'),
    (5, 1, '2022-03-01', 20, 'Stok Girişi'),
    (6, 1, '2022-03-10', 30, 'Stok Girişi'),
    (7, 1, '2022-04-05', 25, 'Stok Girişi'),
    (8, 1, '2022-04-12', 10, 'Stok Girişi'),
    (9, 1, '2022-05-20', 50, 'Stok Girişi'),
    (10, 1, '2022-06-15', 12, 'Stok Girişi');
-- 11 Çıkış Kaydı
INSERT INTO StockTransactions (ProductId, TransactionTypeId, TransactionDate, Quantity, Note)
VALUES
    (1, 2, '2022-07-05', 5, 'Satış Çıkışı'),
    (2, 2, '2022-07-10', 3, 'Satış Çıkışı'),
    (3, 2, '2022-08-05', 8, 'Satış Çıkışı'),
    (4, 2, '2022-08-10', 4, 'Satış Çıkışı'),
    (5, 2, '2022-09-01', 10, 'Satış Çıkışı'),
    (6, 2, '2022-09-15', 12, 'Satış Çıkışı'),
    (7, 2, '2022-10-05', 5, 'Satış Çıkışı'),
    (8, 2, '2022-10-20', 3, 'Satış Çıkışı'),
    (9, 2, '2022-11-05', 20, 'Satış Çıkışı'),
    (10, 2, '2022-11-15', 4, 'Satış Çıkışı'),
    (5, 2, '2022-12-10', 5, 'Satış Çıkışı');
GO

INSERT INTO Customers (Name, ContactName, Email, PhoneNumber, Address, City, Country)
VALUES
    ('John Doe', 'John Doe', 'john.doe@gmail.com', '+90 555 111 22 33', 'Kadıköy, İstanbul', 'İstanbul', 'Türkiye'),
    ('Jane Smith', 'Jane Smith', 'jane.smith@gmail.com', '+90 555 222 33 44', 'Beyoğlu, İstanbul', 'İstanbul', 'Türkiye'),
    ('Ali Yıldız', 'Ali Yıldız', 'ali.yildiz@gmail.com', '+90 555 333 44 55', 'Ankara, Çankaya', 'Ankara', 'Türkiye'),
    ('Fatma Demir', 'Fatma Demir', 'fatma.demir@gmail.com', '+90 555 444 55 66', 'İzmir, Konak', 'İzmir', 'Türkiye'),
    ('Mustafa Tekin', 'Mustafa Tekin', 'mustafa.tekin@gmail.com', '+90 555 555 66 77', 'Antalya, Muratpaşa', 'Antalya', 'Türkiye'),
    ('Ayşe Çetin', 'Ayşe Çetin', 'ayse.cetin@gmail.com', '+90 555 666 77 88', 'Bursa, Nilüfer', 'Bursa', 'Türkiye'),
    ('Mehmet Özdemir', 'Mehmet Özdemir', 'mehmet.ozdemir@gmail.com', '+90 555 777 88 99', 'Konya, Meram', 'Konya', 'Türkiye'),
    ('Emine Aksoy', 'Emine Aksoy', 'emine.aksoy@gmail.com', '+90 555 888 99 00', 'İstanbul, Beşiktaş', 'İstanbul', 'Türkiye'),
    ('Okan Kızıl', 'Okan Kızıl', 'okan.kizil@gmail.com', '+90 555 999 00 11', 'İzmir, Bornova', 'İzmir', 'Türkiye'),
    ('Deniz Aydoğan', 'Deniz Aydoğan', 'deniz.aydogan@gmail.com', '+90 555 101 11 22', 'İstanbul, Kadıköy', 'İstanbul', 'Türkiye'),
    ('Büşra Sarı', 'Büşra Sarı', 'busra.sari@gmail.com', '+90 555 202 22 33', 'Antalya, Kepez', 'Antalya', 'Türkiye'),
    ('Serkan Yılmaz', 'Serkan Yılmaz', 'serkan.yilmaz@gmail.com', '+90 555 303 33 44', 'Ankara, Altındağ', 'Ankara', 'Türkiye');
GO
INSERT INTO Sales (ProductId, CustomerId, Quantity, UnitPrice, SaleDate)
VALUES
    (1, 1, 1, 15000.00, '2022-01-15'),
    (1, 2, 2, 15000.00, '2023-01-05'),
    (1, 3, 1, 15000.00, '2024-01-01'),

    (2, 4, 2, 14000.00, '2022-01-20'),
    (2, 5, 1, 14000.00, '2023-03-01'),

    (3, 6, 1, 30000.00, '2022-02-10'),
    (3, 7, 2, 30000.00, '2023-05-15'),
    (3, 8, 1, 30000.00, '2024-01-15'),

    (4, 9, 3, 9000.00, '2022-02-15'),
    (4, 10, 2, 9000.00, '2023-02-10'),

    (5, 11, 2, 5000.00, '2022-03-01'),
    (5, 12, 1, 5000.00, '2023-04-20'),

    (6, 1, 1, 3500.00, '2022-03-10'),
    (6, 1, 1, 3500.00, '2023-06-05'),
    (6, 1, 1, 3500.00, '2024-03-01'),

    (7, 2, 3, 250.00, '2022-04-05'),
    (7, 2, 2, 250.00, '2023-05-10'),

    (8, 3, 2, 1200.00, '2022-04-12'),
    (8, 3, 1, 1200.00, '2023-06-01'),

    (9, 4, 1, 1000.00, '2022-05-20'),

    (10, 4, 1, 800.00, '2022-06-15'),

    (11, 5, 2, 1800.00, '2022-07-01'),
    (11, 5, 1, 1800.00, '2023-02-01'),

    (12, 6, 1, 2200.00, '2022-07-10'),

    (13, 6, 3, 500.00, '2022-07-15'),

    (14, 7, 1, 2000.00, '2022-08-05'),
    (14, 7, 1, 2000.00, '2023-01-25'),

    (15, 8, 2, 1200.00, '2022-08-10'),

    (16, 9, 1, 3500.00, '2022-08-20'),
    (16, 10, 1, 3500.00, '2023-04-01'),

    (17, 11, 2, 6500.00, '2022-09-01'),

    (18, 12, 1, 1500.00, '2022-09-10'),

    (19, 11, 3, 2000.00, '2022-09-15'),
    (19, 11, 1, 2000.00, '2023-03-15'),

    (20, 12, 1, 3000.00, '2022-09-30'),

    (21, 12, 2, 1800.00, '2022-10-10'),

    (22, 7, 1, 1200.00, '2022-10-15'),

    (23, 8, 2, 4000.00, '2022-10-20'),

    (24, 9, 3, 2200.00, '2022-11-01'),

    (25, 10, 1, 5000.00, '2022-11-05'),

    (26, 1, 1, 3500.00, '2022-11-10'),

    (27,2, 2, 5000.00, '2022-11-15'),
    (27, 3, 1, 5000.00, '2023-07-10'),

    (28, 4, 2, 2500.00, '2022-11-20'),

    (29, 5, 3, 1500.00, '2022-12-01'),

    (30, 6, 1, 2000.00, '2022-12-10'),

    (31, 7, 2, 1000.00, '2022-12-15'),

    (32, 8, 3, 600.00, '2022-12-20'),

    (33, 9, 1, 1200.00, '2023-01-05'),

    (34, 10, 2, 3500.00, '2023-01-15'),
    (34, 11, 1, 3500.00, '2024-02-05'),

    (35, 12, 1, 2200.00, '2023-01-25'),

    (36, 1, 1, 1500.00, '2023-02-01'),

    (37, 7, 3, 1800.00, '2023-02-10'),

    (38, 3, 2, 3000.00, '2023-02-20'),

    (39, 3, 1, 2500.00, '2023-02-28'),

    (40, 3, 1, 4000.00, '2023-03-05'),

    (41, 4, 2, 4500.00, '2023-03-10'),

    (42, 4, 3, 1500.00, '2023-03-15'),

    (43, 6, 2, 300.00, '2023-03-20'),

    (44, 6, 1, 2000.00, '2023-04-01'),

    (45, 6, 3, 1500.00, '2023-04-05'),

    (46, 9, 1, 3500.00, '2023-04-10'),

    (47, 8, 2, 4000.00, '2023-04-15'),

    (48, 8, 1, 500.00, '2023-05-01'),

    (49, 6, 3, 800.00, '2023-05-05'),

    (50, 7, 1, 3500.00, '2023-05-10');



