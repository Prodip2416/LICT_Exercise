

use master 
go
create database dbArticle
go
use dbArticle
go

create table Category
(
id int identity primary key,
Name varchar(200) not null unique,
Description varchar(500),
categoryId int,
foreign key(categoryId) references category(id)
)

create table Gender
(
id int identity primary key,
Name  varchar(200) not null unique,
Description varchar(500)
)

create table Country
(
id int identity primary key,
Name  varchar(200) not null unique
)

create table City
(
id int identity primary key,
Name  varchar(200) not null,
CountryId int not null,
foreign key(CountryId) references country(id)
)

create table SubscriptionType
(
id int identity primary key,
Name  varchar(200) not null unique,
Description varchar(500)
)

create table Subscription
(
id int identity primary key,
Name  varchar(200) not null unique,
Description varchar(500),
DurationDay int not null,
Price float not null
)

create table Users
(
id int identity primary key,
Name  varchar(200) not null,
Email  varchar(200) not null unique,
Password varchar(200) not null,
Contact  varchar(200) not null unique,
Image varchar(200) not null default 'noimage.png',
GenderId int not null,
dateOfBirth date not null,
joinDate date not null,
IP varchar(50) not null,
Address varchar(500),
CityId int not null,
foreign key(GenderId) references gender(id),
foreign key(CityId) references city(id)
)

create table UsersVerified
(
UserId int not null,
DateTime datetime,
IP varchar(50),
foreign key(UserId) references users(id),
primary key(UserId)
)

create table UsersAuthor
(
UserId int not null,
DateTime datetime,
IP varchar(50),
foreign key(UserId) references users(id),
primary key(UserId)
)

create table UsersAdmin
(
UserId int not null,
DateTime datetime,
IP varchar(50),
foreign key(UserId) references users(id),
primary key(UserId)
)


create table article
(
id int identity primary key,
title varchar(500)  not null unique,
Tags varchar(200) not null,
Description varchar(2000) not null,
AuthorId int not null,
categoryId int not null,
dateTime datetime not null default getdate(),
Details varchar(200) not null,
IP varchar(50) not null,
SubscriptionTypeId int not null,
foreign key(AuthorId) references usersAuthor(userId),
foreign key(categoryid) references Category(id),
foreign key(SubscriptionTypeId) references SubscriptionType(id)
)

create table ArticleComments
(
Id int identity primary key,
ArticleId int not null,
Comments varchar(2000) not null,
DateTime datetime default getdate(),
UserId int not null,
IP varchar(50),
foreign key(ArticleId) references Article(id),
foreign key(UserId) references Users(id)
)

create table ArticlePublished
(
ArticleId int,
UserId int not null,
DateTime datetime default getdate(),
IP varchar(50),
foreign key(ArticleId) references Article(id),
foreign key(UserId) references Users(id),
primary key(ArticleId)
)


create table ArticleFile
(
id int identity primary key,
ArticleId int not null,
[file] varchar(200),
foreign key(ArticleId) references Article(id)
)

create table ArticleVideos
(
id int identity primary key,
ArticleId int not null,
VideoLink varchar(200),
foreign key(ArticleId) references Article(id)
)

create table ArticleLinks
(
id int identity primary key,
ArticleId int not null,
Link varchar(200),
foreign key(ArticleId) references Article(id)
)

create table ArticleLikes
(
id int identity primary key,
ArticleId int not null,
DateTime datetime default getdate(),
UserId int not null, 
IP varchar(50),
foreign key(ArticleId) references Article(id),
foreign key(UserId) references Users(id)
)


create table ArticleImages
(
id int identity primary key,
ArticleId int not null,
Image varchar(200) not null,
title varchar(200),
foreign key(ArticleId) references Article(id)
)


create table LiveMessage
(
id int identity primary key,
SenderUserId int not null,
ReceiverUserId int not null,
DateTime datetime default getdate(),
IP varchar(50) not null,
Message varchar(2000) not null,
SeenTime datetime,
foreign key(SenderUserId) references Users(id),
foreign key(ReceiverUserId) references Users(id)
)



create table UsersSubscription
(
id int identity primary key,
UserId int not null, 
SubscriptionId int not null,
Date date not null,
ExpireDate date not null,
Remarks varchar(500),
foreign key(SubscriptionId) references Subscription(id),
foreign key(UserId) references Users(id)
)	

create table AddManager
(
id int identity primary key,
Name varchar(50) not null unique,
Title varchar(200) not null,
Description varchar(500),
rawHtml varchar(2000),
height int,
width int,
link varchar(2000),
viewCount int,
clickCount int
)

