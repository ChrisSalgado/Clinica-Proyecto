create database clinicaP

go
use clinicaP
go

ON
( NAME =clinicaP_dat,
  FILENAME='C:\Clinica\clinicaP.mdf',
  SIZE=8,
  MAXSIZE=30,
  FILEGROWTH=2 )
  LOG ON
( NAME =clinicaP_log,
  FILENAME='C:\Clinica\clinicaP.ldf',
  SIZE=4,
  MAXSIZE=15,
  FILEGROWTH=2 )
  GO
USE clinicaP
GO


create table users(
UserID int identity (1,1) primary key,
LoginName nvarchar (100) unique not null,
password nvarchar (100) not null,
FirstName nvarchar (100) not null,
LastName nvarchar (100) not null,
Position nvarchar (100) not null,
Email nvarchar (100) not null
)

CREATE table  Contraseñas
	(IdContraseñain int identity (1,1),
	passwork nvarchar(20)
	)

	
GO

  CREATE TABLE Medicamentos
	(IdMedicamento int identity (1,1) PRIMARY KEY,
	 NombreMedicamento varchar(25),
	 CodCategoria varchar(25),
	 IdCantidad Char(10),
	 Descripción varchar(max),
	 Ubicación varchar(max),
	 Fecha_Ingreso date default getdate() ,
	 Codtipo varchar(25),
	 Fecha_vencimiento date 
	)
		
	GO

	CREATE TABLE Cantidades
	(IdCantidad Char(10)PRIMARY KEY,
	 Cantidad int,
	 Descripcionesdecantidad varchar(max)
	)
	
	CREATE TABLE Tipos_de_productos
	(Codtipo varchar (25) PRIMARY KEY,
	CodCategoria varchar (25),
	Nombre char (50)
	)

	CREATE TABLE Categorias
	(CodCategoria varchar (25)PRIMARY KEY,
	categoria varchar (25))

	alter table Tipos_de_productos
	add constraint fktipodeproducto
	FOREIGN KEY (CodCategoria) references Categorias (CodCategoria)
	ON UPDATE CASCADE
	ON DELETE CASCADE
	
	alter table Medicamentos
	add constraint fk_catmedicamentos
	foreign key (CodCategoria) references Categorias (CodCategoria)
	ON UPDATE CASCADE
	ON DELETE CASCADE

	alter table Medicamentos
	add constraint fk_tipomedica
	foreign key (Codtipo) references Tipos_de_productos (Codtipo)
	on update cascade
	on delete cascade

	alter table Medicamentos
	add constraint fk_catidad
	foreign key (idCantidad) 
	references Cantidades(idCantidad)
	ON UPDATE CASCADE
	ON DELETE CASCADE  

----------------------------restricciones-------------------

	
alter table Usuario
add constraint check_correo
 check(correo like '[a-z][1-9]+@+[a-z]+.com')

 

 ALTER TABLE Medicamentos 
 add constraint fV_me
 CHECK (Fecha_vencimiento>getdate())


ALTER TABLE Cantidades
add constraint Cant
CHECK (Cantidad>=1)


alter table Contraseñas
add constraint fk_ContraUsuari
FOREIGN KEY (passwork)
 references Usuarios(IdContraseña)


go

insert into Categorias values
('1', 'General'),
('2', 'Odontologia'),
('3', 'Ginecologia');

insert into Cantidades values
('1C','1','Cajas'),
('2C','2','Cajas'),
('3C','3','Cajas');

insert into Tipos_de_productos values
('1','1', 'Analgesicos');

insert into Medicamentos values
('Acetaminofen', '1','3C','Acetaminofen para acetominofenizar','En la farmacia','','1','2020/2/2' )

select * from Medicamentos

use clinicaP
select * from Categorias

select * from Tipos_de_productos



insert into users values ('admin', 'abc123','admin','admin','Administrator','admin@gmail.com')
insert into users values ('Chris','unodostres','Christopher','Salgado','developer','cristopher.salgado1997@gmail.com')
insert into users values ('DonBosco', 'salesiano','Juanito','Bosco','cura','donbosco@gmail.com')

select * from users where LoginName = 'admin' and password = 'abc123'

declare @user nvarchar(100)='admin'
declare @pass nvarchar(100)='abc123'
select * from users where LoginName=@user and password = @pass


drop table users