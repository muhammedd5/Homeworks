use master
go

if DB_ID('PortfolioDb') is not null
begin
    alter database PortfolioDb set single_user with rollback immediate
    drop database PortfolioDb
end
go

create database PortfolioDb collate Turkish_CI_AS
go

use PortfolioDb
go

create table AppSettings(
    Id int primary key identity,
    BrandName nvarchar(100) not null,
    HeroTitle nvarchar(300) not null,
    HeroSubtitle nvarchar(300) not null,
    HeroImageUrl nvarchar(1000) not null,
    AboutText nvarchar(3000) not null,
    AboutImageUrl nvarchar(1000) not null,
    SkillsImageUrl nvarchar(1000) not null,
    AddressText nvarchar(500) not null,
    AddressDistrict nvarchar(100) not null,
    AddressProvince nvarchar(100) not null,
    PhoneNumber nvarchar(20) not null,
    Email nvarchar(100) not null,
    GoogleMap nvarchar(max) not null,
    CreatedDate datetime2(3) not null default getdate(),
    ModifiedDate datetime2(3)
)
go

insert into AppSettings(
    BrandName,
    HeroTitle,
    HeroSubTitle,
    HeroImageUrl,
    AboutText,
    AboutImageUrl,
    SkillsImageUrl,
    AddressText,
    AddressDistrict,
    AddressProvince,
    PhoneNumber,
    Email,
    GoogleMap
) values
    (
        'Cemal Kodyazar',
        'Yazılım Geliştirici',
        'DotNet|Asp.Net Core|Html|Css|JavaScript',
        'http://localhost:5500/ui/img/hero-img.png',
        '<p>Nişantaşı Üniversitesi Acunmedya Akademi bünyesinde Backend Yazılım Eğitimi aldım.</p><p>Aldığım eğitim boyunca çeşitli projeler yaparak kendimi geliştirdim.</p>',
        'http://localhost:5500/ui/img/hero-img.png',
        'http://localhost:5500/ui/img/skills.png',
        'Devasa Plaza Kat 4/5',
        'Ataşehir',
        'İstanbul',
        '+90 554 455 98 57',
        'info@cemalkodyazar.com',
        '<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3012.8621993114325!2d29.105485476112477!3d40.96259752223632!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cabbe7eee803fb%3A0x2f64ecd26d22527a!2sYowa%20Academy!5e0!3m2!1str!2str!4v1729710795753!5m2!1str!2str" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>'
    )
go

create table Socials(
    Id int primary key identity,
    Name nvarchar(50) not null,
    Url nvarchar(1000) not null,
    Icon nvarchar(50) not null,
    IsActive bit not null default 1,
    CreatedDate datetime2(3) not null default getdate(),
    ModifiedDate datetime2(3),
    index idx_IsActive nonclustered (IsActive)
)
go

insert into Socials(Name, Url, Icon)
values 
    ('Github','https://github.com','github'),
    ('LinkedIn','https://linkedin.com','linkedin'),
    ('Medium','https://medium.com','medium'),
    ('X','https://x.com','twitter-x'),
    ('Instagram','https://instagram.com','instagram')
go

create table Skills(
    Id int primary key identity,
    Name nvarchar(100) not null,
    Rate tinyint not null,
    IsActive bit not null default 1,
    CreatedDate datetime2(3) not null default getdate(),
    ModifiedDate datetime2(3),
    index idx_IsActive nonclustered (IsActive)
)
go

insert into Skills(Name,Rate)
values
    ('Html',100),('Css',100),('Asp.Net Core MVC',90),('Asp.Net Core WebAPI',70)
go

create table Services(
    Id int primary key identity,
    Title nvarchar(100) not null,
    Icon nvarchar(100) not null,
    Description nvarchar(1000) not null,
    IsActive bit not null default 1,
    CreatedDate datetime2(3) not null default getdate(),
    ModifiedDate datetime2(3),
    index idx_IsActive nonclustered (IsActive)
)
go

insert into Services(Title, Icon, Description)
values
    ('Web Tasarım','bi-activity','İhtiyacınıza uygun web tasarımı'),
    ('Web Uygulama Geliştirme','bi-bounding-box-circles','Özel projeler'),
    ('Ürün Yönetimi','bi-calendar4-week','Profesyonel ürün yönetimi'),
    ('SEO','bi-broadcast','SEO yönetimi')
go

create table Categories(
    Id int primary key identity,
    Name nvarchar(100) not null,
    IsActive bit not null default 1,
    CreatedDate datetime2(3) not null default getdate(),
    ModifiedDate datetime2(3),
    index idx_IsActive nonclustered (IsActive) 
)
go

insert into Categories(Name)
values ('MVC'),('FrontEnd'),('API')
go

create table Projects(
    Id int primary key identity,
    Name nvarchar(100) not null,
    ImageUrl nvarchar(1000) not null,
    Description nvarchar(1000) not null,
    GithubUrl nvarchar(1000),
    ProjectUrl nvarchar(1000),
    ProjectYear int,
    IsActive bit not null default 1,
    CreatedDate datetime2(3) not null default getdate(),
    ModifiedDate datetime2(3),
    CategoryId int not null foreign key references Categories(Id) on delete cascade,
    index idx_IsActive nonclustered (IsActive)
)
go

insert into Projects(Name,ImageUrl,Description,ProjectYear,CategoryId)
values
    ('Proje 01','http://localhost:5500/ui/img/projects/project1.jpg','Proje 01 Açıklaması',2023,1),
    ('Proje 02','http://localhost:5500/ui/img/projects/project2.jpg','Proje 02 Açıklaması',2023,1),
    ('Proje 03','http://localhost:5500/ui/img/projects/project3.jpg','Proje 03 Açıklaması',2023,2),
    ('Proje 04','http://localhost:5500/ui/img/projects/project4.jpg','Proje 04 Açıklaması',2023,2),
    ('Proje 05','http://localhost:5500/ui/img/projects/project3.jpg','Proje 05 Açıklaması',2023,2),
    ('Proje 06','http://localhost:5500/ui/img/projects/project4.jpg','Proje 06 Açıklaması',2023,2),
    ('Proje 07','http://localhost:5500/ui/img/projects/project1.jpg','Proje 07 Açıklaması',2023,3),
    ('Proje 08','http://localhost:5500/ui/img/projects/project2.jpg','Proje 08 Açıklaması',2023,3),
    ('Proje 09','http://localhost:5500/ui/img/projects/project3.jpg','Proje 09 Açıklaması',2023,3)
go

create table Contacts(
    Id int primary key identity,
    Name nvarchar(100) not null,
    Email nvarchar(100) not null,
    Subject nvarchar(100) not null,
    Message nvarchar(3000) not null,
    IsRead bit not null default 0,
    SendingTime datetime2(3) not null default getdate(),
    ContactId int null foreign key references Contacts(Id) on delete no action
)
go

insert into Contacts(Name,Email,Subject,Message)
values
    ('Sezen Aksu','sezen@gmail.com','Proje Talebi','Son albüm çalışmam için bir web sitesi yaptırmak istiyorum.'),
    ('Ali Cabbar','ali@cabbar.com','SEO Çalışması','Web sitemin SEO çalışmasını yaptırmak istiyorum, teklif alabilir miyim?')
go

insert into Contacts(Name, Email,Subject,Message,ContactId)
values
    ('Cemal Kodyazar','info@cemalkodyazar.com','YNT-Proje Talebi','İstediğiniz web sitesi ile ilgili teklif, ektedir.',1),
    ('Cemal Kodyazar','info@cemalkodyazar.com','YNT-SEO Çalışması','Kurum olarak SEO çalışması yapmıyoruz, kusura bakmayın.',2)
go

-- Create Triggers

-- AppSettings tablosu için trigger
create trigger trg_UpdateModifiedDate_AppSettings
on AppSettings
after update
as
begin
    update AppSettings
    set ModifiedDate = getdate()
    from AppSettings a
    inner join inserted i on a.Id = i.Id
end
go

-- Socials tablosu için trigger
create trigger trg_UpdateModifiedDate_Socials
on Socials
after update
as
begin
    update Socials
    set ModifiedDate = getdate()
    from Socials s
    inner join inserted i on s.Id = i.Id
end
go

-- Skills tablosu için trigger
create trigger trg_UpdateModifiedDate_Skills
on Skills
after update
as
begin
    update Skills
    set ModifiedDate = getdate()
    from Skills sk
    inner join inserted i on sk.Id = i.Id
end
go

-- Services tablosu için trigger
create trigger trg_UpdateModifiedDate_Services
on Services
after update
as
begin
    update Services
    set ModifiedDate = getdate()
    from Services sv
    inner join inserted i on sv.Id = i.Id
end
go

-- Categories tablosu için trigger
create trigger trg_UpdateModifiedDate_Categories
on Categories
after update
as
begin
    update Categories
    set ModifiedDate = getdate()
    from Categories c
    inner join inserted i on c.Id = i.Id
end
go

-- Projects tablosu için trigger
create trigger trg_UpdateModifiedDate_Projects
on Projects
after update
as
begin
    update Projects
    set ModifiedDate = getdate()
    from Projects p
    inner join inserted i on p.Id = i.Id
end
go




