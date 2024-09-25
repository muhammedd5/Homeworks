DROP TABLE Kitaplar;
CREATE TABLE Kitaplar (
KitapID INT PRIMARY KEY IDENTITY(1,1),
KitapAdi NVARCHAR(100) NOT NULL,
Yazar NVARCHAR(100) NOT NULL,
YayınYili INT NOT NULL,
SayfaSayisi INT NULL,
ISBN NVARCHAR(20) NULL
);

INSERT INTO Kitaplar (KitapAdi, Yazar, YayınYili) VALUES
('Lolita', 'Vladimir Nabokov', 2010),
('Muhteşem Gatsby', 'Marcel Proust', 2005),
('Ulysses', 'James Joyce',1990),
('Dublinliler', 'James Joyce',1800),
('Yüzyıllık Yalnızlık', 'Gabriel Garcia Marquez',1750),
('Ses ve Öfke', 'William Faulkner',1980),
('Deniz Feneri', 'Virginia Woolf',1989),
('Bütün Hikayeler', 'Flannery O’Connor',2000),
('Solgun Ateş', 'Vladimir Nabokov',2000),
('Anna Karenina ', 'Leo Tolstoy',2006),
('Middlemarch', 'George Eliot',1998),
('Moby-Dick', 'Herman Melville',2007),
('Büyük Umutlar', 'Charles Dickens',1881),
('Suç ve Ceza', 'Fyodor Dostoyevsky',1800),
('Emma', 'Jane Austen',1789),
('Diyaloglar', 'Platon',2001),
('Şölen - Dostluk', 'PLaton',1980),
('Patasana', 'Ahmet Ümit',1999),
('Beyaz Diş', 'Jack London',1789),
('Düello', 'Anton Çehov',1995)

SELECT KitapAdi, Yazar, YayınYili
FROM Kitaplar;

SELECT KitapAdi, Yazar
FROM Kitaplar
WHERE YayınYili > 2000;

SELECT KitapAdi, Yazar
FROM Kitaplar
WHERE Yazar = 'Platon';


DROP TABLE Dergiler;
CREATE TABLE Dergiler(
DergiID INT PRIMARY KEY IDENTITY(1,1),
DergiAdi NVARCHAR(100) Not NULL,
Yayinci NVARCHAR(100) NOT NULL,
YayinTarihi INT NOT NULL,
Sayi INT NOT NULL
);

DROP TABLE IF EXISTS Dergiler;
CREATE TABLE Dergiler (
    DergiID INT PRIMARY KEY IDENTITY(1,1),
    DergiAdi NVARCHAR(100) NOT NULL,
    Yayinci NVARCHAR(100) NOT NULL,  
    YayinTarihi INT NULL,
    Sayi INT NULL
);
INSERT INTO Dergiler (DergiAdi, Yayinci) VALUES
('Birikim', 'Birikim'),
('Bilim ve Teknik', 'Tübitak'),
('Derin Tarih', 'Albayrak'),
('Erkekçe', 'Gelişim Yayınları'),
('Tempo', 'Doğan Yayın');

DROP TABLE IF EXISTS DVDler;
CREATE TABLE DVDler (
    DVDID INT PRIMARY KEY IDENTITY(1,1),
    DVDAdi NVARCHAR(100) NOT NULL,
    Yönetmen NVARCHAR(100) NOT NULL,
    YayınYılı INT NULL, 
    Sure INT NULL        
);

INSERT INTO DVDler (DVDAdi, Yönetmen) VALUES
('Organize İşler', 'Yılmaz Erdoğan'),
('Recep İvedik 2', 'Şahan Gökbakar'),
('GORA', 'Cem Yılmaz'),
('Kolonya Cumhuriyeti', 'Murat Kepez'),
('Yol Arkadaşım', 'İbrahim Büyükak');

DROP TABLE IF EXISTS Ogrenciler;
CREATE TABLE Ogrenciler (
    OgrenciID INT PRIMARY KEY,
    Ad VARCHAR(50),
    Soyad VARCHAR(50),
    BolumID INT
);

INSERT INTO Ogrenciler (OgrenciID, Ad, Soyad, BolumID) VALUES
(1, 'Berk', 'Yılmaz', 1),
(2, 'Alina', 'Kara', 2),
(3, 'Mehmet', 'Öztürk', 1),
(4, 'Melisa', 'Demir', 3),
(5, 'Hasan', 'Çelik', 2);

DROP TABLE IF EXISTS OduncAlmalar;
CREATE TABLE OduncAlmalar(
    OgrencıID INT PRIMARY KEY IDENTITY(1,1),
    KitapID INT NOT NULL,
    DergiID INT NULL,
    DVDID INT NOT NULL,
    OduncTarihi DATE NULL
);

INSERT INTO OduncAlmalar (KitapID, DergiID, DVDID, OduncTarihi) VALUES
(3, 1, 1, '2024-03-14'),
(7, 5, 2, '2024-02-12'),
(15, 3, 5, '2024-09-19'),
(19, 5, 3, '2024-09-15'),
(1, 4, 4, '2024-04-10'),
(5, 2, 1, '2024-03-14'),
(15, 1, 3, '2024-09-29'),
(10, 1, 4, '2024-09-01'),
(5, 3, 2, '2024-09-17'),
(14, 2, 2, '2024-09-07');

SELECT
O.AD AS Ad,
O.AD AS Soyad,
K.KitapAdi
FROM
Ogrenciler O
JOIN
OduncAlmalar OA ON O.OgrenciID = OA.OgrencıID
JOIN Kitaplar K ON OA.KitapID = K.KitapID;

SELECT 
    Ogrenciler.Ad AS OgrenciAd, 
    Ogrenciler.Soyad AS OgrenciSoyad, 
    Dergiler.DergiAdi, 
    Dergiler.Yayinci
FROM 
    OduncAlmalar
JOIN 
    Ogrenciler ON OduncAlmalar.OgrencıID = Ogrenciler.OgrenciID
JOIN 
    Dergiler ON OduncAlmalar.DergiID = Dergiler.DergiID

WHERE 
Dergiler.DergiID IS NOT NULL;

SELECT
    Ogrenciler.OgrenciID,
    Ogrenciler.Ad,
    Ogrenciler.Soyad

FROM

    Ogrenciler
LEFT JOIN
OduncAlmalar ON Ogrenciler.OgrenciID = OduncAlmalar.OgrencıID
WHERE
OduncAlmalar.OgrencıID IS NULL;


SELECT 
    Kitaplar.KitapAdi AS MateryalAdi, 
    COUNT(OduncAlmalar.KitapID) AS OduncAlmaSayisi
FROM 
    Kitaplar
LEFT JOIN 
    OduncAlmalar ON Kitaplar.KitapID = OduncAlmalar.KitapID
GROUP BY 
    Kitaplar.KitapAdi

UNION ALL

SELECT 
    Dergiler.DergiAdi AS MateryalAdi, 
    COUNT(OduncAlmalar.DergiID) AS OduncAlmaSayisi
FROM 
    Dergiler
LEFT JOIN 
    OduncAlmalar ON Dergiler.DergiID = OduncAlmalar.DergiID
GROUP BY 
    Dergiler.DergiAdi

UNION ALL


SELECT 
    DVDler.DVDAdi AS MateryalAdi, 
    COUNT(OduncAlmalar.DVDID) AS OduncAlmaSayisi
FROM 
    DVDler
LEFT JOIN 
    OduncAlmalar ON DVDler.DVDID = OduncAlmalar.DVDID
GROUP BY 
    DVDler.DVDAdi;

SELECT
KitapAdi,
Yazar,
YayınYili
FROM 
    Kitaplar
ORDER BY 
    YayınYili ASC
OFFSET 0 ROWS
-- FETCH NEXT 3 ROWS ONLY;
FETCH NEXT 5 ROWS ONLY;

SELECT
Ogrenciler.Ad,
Ogrenciler.Soyad,
Kitaplar.KitapAdi,
Dergiler.DergiAdi,
DVDler.DVDAdi,
OduncAlmalar.OduncTarihi

FROM
Ogrenciler
LEFT JOIN
OduncAlmalar ON Ogrenciler.OgrenciID = OduncAlmalar.OgrencıID
LEFT JOIN
 Kitaplar ON OduncAlmalar.KitapID = Kitaplar.KitapID
LEFT JOIN 
    Dergiler ON OduncAlmalar.DergiID = Dergiler.DergiID
LEFT JOIN 
    DVDler ON OduncAlmalar.DVDID = DVDler.DVDID
WHERE 
Ogrenciler.Ad = 'Berk' AND Ogrenciler.Soyad = 'Yılmaz';