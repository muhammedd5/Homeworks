DROP TABLE IF EXISTS OgrenciKulup;

CREATE TABLE OgrenciKulup(
    OgrenciID INT NOT NULL,
    KulupID INT NOT NULL,
    Rol NVARCHAR(50) NOT NULL,
    KatilimTarihi DATE NULL,
    PRIMARY KEY (OgrenciID, KulupID) 
);

DROP TABLE IF EXISTS Kulupler;
CREATE TABLE Kulupler(
    KulupID INT PRIMARY KEY IDENTITY (1,1),
    KulupAdi NVARCHAR(100) NOT NULL,
    KurulusYili DATE NULL
);

DROP TABLE IF EXISTS Ogrenciler;
CREATE TABLE Ogrenciler (
    OgrenciID INT PRIMARY KEY,
    Ad NVARCHAR(50) NOT NULL,
    Soyad NVARCHAR(50) NOT NULL
);

INSERT INTO Ogrenciler (OgrenciID, Ad, Soyad) VALUES
(1, 'Berk', 'Yılmaz'),
(2, 'Alina', 'Kara'),
(3, 'Mehmet', 'Öztürk'),
(4, 'Melisa', 'Demir'),
(5, 'Hasan', 'Çelik'),
(6, 'Zeynep', 'Yıldız');

INSERT INTO Kulupler (KulupAdi, KurulusYili) VALUES
('Tiyatro Kulübü', '2009-01-01'),
('Müzik Kulübü', '2010-01-01'),
('Spor Kulübü', '2008-01-01'),
('Bilim Kulübü', '2010-01-01'),
('Sanat Kulübü', '2012-01-01');

INSERT INTO OgrenciKulup (OgrenciID, KulupID, Rol, KatilimTarihi) VALUES
(1, 1, 'Başkan', '2023-09-01'),
(2, 1, 'Üye', '2023-09-05'),
(3, 1, 'Sekreter', '2023-09-10'),
(4, 2, 'Başkan', '2023-09-02'),
(5, 2, 'Üye', '2023-09-06'),
(6, 2, 'Sekreter', '2023-09-11'),
(1, 3, 'Üye', '2023-09-01'),
(4, 3, 'Başkan', '2023-09-02'),
(5, 3, 'Üye', '2023-09-03'),
(2, 4, 'Üye', '2023-09-05'),
(3, 4, 'Başkan', '2023-09-06'),
(6, 4, 'Sekreter', '2023-09-07'),
(1, 5, 'Başkan', '2023-09-01'),
(2, 5, 'Üye', '2023-09-03'),
(4, 5, 'Sekreter', '2023-09-05');

SELECT 
    O.Ad, 
    O.Soyad, 
    K.KulupAdi 
FROM 
    OgrenciKulup OK
JOIN 
    Ogrenciler O ON OK.OgrenciID = O.OgrenciID
JOIN 
    Kulupler K ON OK.KulupID = K.KulupID;


SELECT 
    O.Ad, 
    O.Soyad, 
    OK.Rol 
FROM 
    OgrenciKulup OK
JOIN 
    Ogrenciler O ON OK.OgrenciID = O.OgrenciID
JOIN 
    Kulupler K ON OK.KulupID = K.KulupID
WHERE 
    K.KulupAdi = 'Tiyatro Kulübü';

SELECT 
    O.Ad, 
    O.Soyad, 
    K.KulupAdi 
FROM 
    OgrenciKulup OK
JOIN 
    Ogrenciler O ON OK.OgrenciID = O.OgrenciID
JOIN 
    Kulupler K ON OK.KulupID = K.KulupID
WHERE 
    OK.Rol = 'Başkan';

    SELECT 
    K.KulupAdi, 
    COUNT(OK.OgrenciID) AS UyeSayisi 
FROM 
    OgrenciKulup OK
JOIN 
    Kulupler K ON OK.KulupID = K.KulupID
GROUP BY 
    K.KulupAdi;
    
SELECT 
O.Ad, 
O.Soyad, 
K.KulupAdi 
FROM 
OgrenciKulup OK
JOIN 
Ogrenciler O ON OK.OgrenciID = O.OgrenciID
JOIN 
    Kulupler K ON OK.KulupID = K.KulupID
WHERE 
    K.KulupID = (SELECT TOP 1 KulupID FROM Kulupler ORDER BY KatilimTarihi ASC);


SELECT 
    O.Ad, 
    O.Soyad, 
    K.KulupAdi, 
    OK.KatilimTarihi 
FROM 
    OgrenciKulup OK
JOIN 
    Ogrenciler O ON OK.OgrenciID = O.OgrenciID
JOIN 
    Kulupler K ON OK.KulupID = K.KulupID;


SELECT DISTINCT 
    OK.Rol 
FROM 
    OgrenciKulup OK
JOIN 
    Kulupler K ON OK.KulupID = K.KulupID
WHERE 
    K.KulupAdi = 'Müzik Kulübü';

SELECT 
    K.KulupAdi, 
    COUNT(OK.Rol) AS BaşkanSayisi 
FROM 
    OgrenciKulup OK
JOIN 
    Kulupler K ON OK.KulupID = K.KulupID
WHERE 
    OK.Rol = 'Başkan'
GROUP BY 
    K.KulupAdi;

    SELECT 
    O.Ad, 
    O.Soyad, 
    K.KulupAdi, 
    OK.KatilimTarihi 
FROM 
    OgrenciKulup OK
JOIN 
    Ogrenciler O ON OK.OgrenciID = O.OgrenciID
JOIN 
    Kulupler K ON OK.KulupID = K.KulupID
ORDER BY 
    OK.KatilimTarihi DESC 

SELECT 
    O.Ad, 
    O.Soyad, 
    COUNT(OK.KulupID) AS KulupSayisi 
FROM 
    OgrenciKulup OK
JOIN 
    Ogrenciler O ON OK.OgrenciID = O.OgrenciID
GROUP BY 
    O.OgrenciID, O.Ad, O.Soyad
HAVING 
    COUNT(OK.KulupID) > 1;

