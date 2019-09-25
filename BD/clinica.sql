create database clinicaP

go
use clinicaP
go

create table users(
UserID int identity (1,1) primary key,
LoginName nvarchar (100) unique not null,
password nvarchar (100) not null,
FirstName nvarchar (100) not null,
LastName nvarchar (100) not null,
Position nvarchar (100) not null,
Email nvarchar (100) not null
)

insert into users values ('admin', 'abc123','admin','admin','Administrator','admin@gmail.com')
insert into users values ('Chris','unodostres','Christopher','Salgado','developer','cristopher.salgado1997@gmail.com')
insert into users values ('DonBosco', 'salesiano','Juanito','Bosco','cura','donbosco@gmail.com')

select * from users

drop table users