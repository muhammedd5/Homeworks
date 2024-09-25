DROP TABLE IF EXISTS Maaslar;
DROP TABLE IF EXISTS Personeller;

CREATE TABLE Personeller (
    PersonelID INT PRIMARY KEY IDENTITY(1,1),
    Ad NVARCHAR(50) NOT NULL,
    Soyad NVARCHAR(50) NOT NULL,
    Pozisyon NVARCHAR(50) NOT NULL
);

INSERT INTO Personeller (Ad, Soyad, Pozisyon) VALUES
('Ali', 'Demir', 'Okul Müdürü'),
('Ayşe', 'Yılmaz', 'Öğretmen'),
('Mehmet', 'Kara', 'Öğretmen'),
('Fatma', 'Çelik', 'Sekreter'),
('Mustafa', 'Polat', 'Öğretmen'),
('Zeynep', 'Koç', 'Rehberlik Uzmanı'),
('Emre', 'Aydın', 'Bilgisayar Öğretmeni'),
('Elif', 'Akman', 'Öğretmen'),
('Burak', 'Sönmez', 'Öğretmen'),
('Ceren', 'Yavuz', 'Sekreter');

CREATE TABLE Maaslar (
    MaasID INT PRIMARY KEY IDENTITY(1,1),
    PersonelID INT NOT NULL,
    MaasMiktari DECIMAL(10, 2) NOT NULL,
    GuncellemeTarihi DATE NOT NULL,
    FOREIGN KEY (PersonelID) REFERENCES Personeller(PersonelID)
);

INSERT INTO Maaslar (PersonelID, MaasMiktari, GuncellemeTarihi) VALUES
(1, 10000.00, '2024-01-01'),
(2, 7500.00, '2024-01-01'),
(3, 7500.00, '2024-01-01'),
(4, 5000.00, '2024-01-01'),
(5, 7000.00, '2024-01-01'),
(6, 8000.00, '2024-01-01'),
(7, 8000.00, '2024-01-01'),
(8, 7500.00, '2024-01-01'),
(9, 7500.00, '2024-01-01'),
(10, 5000.00, '2024-01-01');

INSERT INTO Maaslar (PersonelID, MaasMiktari, GuncellemeTarihi) VALUES
(1, 11000.00, '2024-06-01'),
(2, 8000.00, '2024-06-01'),
(3, 7800.00, '2024-06-01'),
(4, 5200.00, '2024-06-01'),
(5, 7200.00, '2024-06-01'),
(6, 8200.00, '2024-06-01'),
(7, 8500.00, '2024-06-01'),
(8, 7600.00, '2024-06-01'),
(9, 7600.00, '2024-06-01'),
(10, 5500.00, '2024-06-01');

SELECT
p.PersonelID,
P.Ad,
p.Soyad,
p.Pozisyon,
m.MaasMiktari,
m.GuncellemeTarihi

FROM
Personeller p 
JOIN
Maaslar m ON p.PersonelID = m.PersonelID
WHERE
m.GuncellemeTarihi = (
    SELECT MAX(GuncellemeTarihi)
    FROM Maaslar
    WHERE PersonelID = P.PersonelID 

);

SELECT
AVG(MaasMiktari) AS OrtalamaMaas
FROM
Maaslar;

SELECT 
    p.Pozisyon,
    MAX(m.MaasMiktari) AS EnYuksekMaas,
    MIN(m.MaasMiktari) AS EnDusukMaas
FROM 
    Personel p
JOIN 
    Maaslar m ON p.PersonelID = m.PersonelID
GROUP BY 
    p.Pozisyon;

SELECT 
AD,
SOYAD,
Pozisyon
FROM
Personeller;

SELECT 
    Pozisyon, 
    COUNT(*) AS PersonelSayisi 
FROM 
    Personeller
GROUP BY 
    Pozisyon;

    SELECT 
    p.PersonelID,
    p.Ad,
    p.Soyad,
    m.MaasMiktari,
    m.GuncellemeTarihi
FROM 
    Personeller p
JOIN 
    Maaslar m ON p.PersonelID = m.PersonelID
WHERE 
    m.GuncellemeTarihi = (
        SELECT MAX(GuncellemeTarihi)
        FROM Maaslar
        WHERE PersonelID = p.PersonelID
    );


SELECT 
PersonelID,
Ad,
Soyad,
Pozisyon
FROM Personeller
WHERE 
Pozisyon = 'Öğretmen';

SELECT 
    p.Ad,
    p.Soyad,
    m.MaasMiktari
FROM 
    Personeller p
JOIN 
    Maaslar m ON p.PersonelID = m.PersonelID
ORDER BY 
    m.MaasMiktari DESC



SELECT 
    m.MaasID,
    m.PersonelID,
    m.MaasMiktari,
    m.GuncellemeTarihi
FROM 
    Maaslar m
WHERE 
    m.PersonelID = 2
ORDER BY 
    m.GuncellemeTarihi ASC;

SELECT 
    p.Pozisyon,
    MAX(m.MaasMiktari) AS EnYuksekMaaş,
    MIN(m.MaasMiktari) AS EnDüşükMaaş
FROM 
    Personeller p
JOIN 
    Maaslar m ON p.PersonelID = m.PersonelID
GROUP BY 
    p.Pozisyon
HAVING 
    COUNT(p.PersonelID) > 3;



    SELECT 
    p.Ad, 
    p.Soyad, 
    m.MaasMiktari, 
    m.GuncellemeTarihi
FROM 
    Personeller p
JOIN 
    Maaslar m ON p.PersonelID = m.PersonelID
WHERE 
    m.GuncellemeTarihi >= DATEADD(MONTH, -6, GETDATE());

SELECT 
    p.Ad, 
    p.Soyad, 
    COUNT(m.MaasID) AS GuncellemeSayisi
FROM 
    Personeller p
JOIN 
    Maaslar m ON p.PersonelID = m.PersonelID
GROUP BY 
    p.PersonelID, p.Ad, p.Soyad
HAVING 
    COUNT(m.MaasID) >= 1;
