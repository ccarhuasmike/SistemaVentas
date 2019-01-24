/*CREATE DATABASE BDFERRETERIA
GO
USE BDFERRETERIA
GO*/

create table tb_usuario(
	Id int identity (1,1) primary key not null,
	tx_nombre varchar(50) not null,
	tx_apellido_paterno varchar(50) not null,
	tx_apellido_materno varchar(50) not null,
	tx_email varchar(50) not null,
	tx_login varchar(20) not null,
	tx_password varchar(200) not null,	
	IdUsuario_crea int not null,
	dt_fe_crea datetime not null,
	IdUsuario_mod int  null,
	dt_fe_mod datetime  null,
	IdEstado_reg int not null
)
create table tb_proveedor(
	Id int identity (1,1) primary key not null,
	Codigo char(13) not null,
	tx_nombre varchar(50) not null,
	tx_apellido_paterno varchar(50) not null,
	tx_apellido_materno varchar(50) not null,
	tx_ruc varchar(11) not null,
	tx_email varchar(50) not null,
	tx_direccion varchar(100) not null,
	tx_telefono varchar(11) not null,
	tx_celular  varchar(11) not null,
	IdUsuario_crea int not null,
	dt_fe_crea datetime not null,
	IdUsuario_mod int  null,
	dt_fe_mod datetime  null,
	IdEstado_reg int not null
)

CREATE SEQUENCE [SQ_tb_proveedor] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE  10 
GO

ALTER TABLE tb_proveedor ADD  CONSTRAINT [CNX_tb_proveedor_DEFAULT_CODIGO]  DEFAULT ('PRV'+right((('000000'+CONVERT([varchar](11)
,NEXT VALUE FOR [SQ_tb_proveedor] ))+'.')+
right(CONVERT([char](4),datepart(year,getdate())),(2)),(9))) FOR [Codigo]
GO

create table tb_cliente(
	Id int identity (1,1) primary key not null,
	Codigo char(13) not null,
	tx_nombre varchar(50) not null,
	tx_apellido_paterno varchar(50) not null,
	tx_apellido_materno varchar(50) not null,
	tx_dni varchar(11) not null,
	tx_ruc varchar(11) not null,
	tx_email varchar(50) not null,
	tx_direccion varchar(100) not null,
	tx_telefono varchar(11) not null,
	tx_celular  varchar(11) not null,
	IdUsuario_crea int not null,
	dt_fe_crea datetime not null,
	IdUsuario_mod int  null,
	dt_fe_mod datetime  null,
	IdEstado_reg int not null
)

CREATE SEQUENCE [SQ_tb_cliente] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE  10 
GO

ALTER TABLE tb_cliente ADD  CONSTRAINT [CNX_tb_cliente_DEFAULT_CODIGO]  DEFAULT ('CLI'+right((('000000'+CONVERT([varchar](11)
,NEXT VALUE FOR [SQ_tb_cliente] ))+'.')+
right(CONVERT([char](4),datepart(year,getdate())),(2)),(9))) FOR [Codigo]
GO



CREATE TABLE tb_parameter_cab(
	Id int IDENTITY(1,1) NOT NULL,
	skey_cab varchar(45) NOT NULL primary key,
	tx_descripcion varchar(100) NULL DEFAULT (NULL),
	IdEstado_reg int NULL DEFAULT (NULL),
	dt_fe_crea datetime NULL DEFAULT (NULL),
	tx_comentario varchar(255) NULL DEFAULT (NULL)
)

CREATE TABLE tb_parameter_det(
	Id int IDENTITY(1,1) NOT NULL primary key,
	skey_det varchar(45) NOT NULL,
	In_valor int NULL DEFAULT (NULL),
	tx_valor varchar(45) NOT NULL,
	tx_descripcion varchar(1000) NULL DEFAULT (NULL),
	tx_comentario varchar(500) NULL DEFAULT (NULL),
	In_orden int not null,
	IdEstado_reg int NULL DEFAULT (NULL),
	dt_fe_crea datetime NULL DEFAULT (NULL),
	skey_cab varchar(45) NULL,
	FOREIGN KEY (skey_cab) REFERENCES tb_parameter_cab(skey_cab)
)

create table tb_producto(
	Id int IDENTITY(1,1) NOT NULL primary key,
	Codigo char(13) not null,
	tx_nombre varchar(50) not null ,
	tx_descripcion varchar(1000) NULL DEFAULT (NULL),
	In_cant_producto int not null,
	In_unidad int not null,
	db_precio_costo decimal(9,1) not null,
	db_precio_sin_igv decimal(9,1) not null,
	db_precio_bruto_igv decimal(9,1) not null,
	In_igv decimal(9,1) not null,		
	tx_imagen_producto varchar(500) null,
	IdUsuario_crea int not null,
	dt_fe_crea datetime not null,
	IdUsuario_mod int  null,
	dt_fe_mod datetime  null,
	IdEstado_reg int not null	
)

CREATE SEQUENCE [SQ_tb_producto] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE  10 
GO

ALTER TABLE tb_producto ADD  CONSTRAINT [CNX_tb_producto_DEFAULT_CODIGO]  DEFAULT ('PROD'+right((('000000'+CONVERT([varchar](11)
,NEXT VALUE FOR [SQ_tb_producto] ))+'.')+
right(CONVERT([char](4),datepart(year,getdate())),(2)),(9))) FOR [Codigo]
GO

create table tb_kardex(
	Id int identity (1,1) primary key not null,	
	IdTipoMovimiento int not null,
	IdProducto int not null,
	In_cant_entrada int null,
	In_cant_salida int null,
	In_unidad int not null,	
	db_precio_costo decimal(9,1) not null,
	db_precio_por_unidad decimal(9,1) not null,
	db_precio_total decimal(9,1) not null,
	IdUsuario_crea int not null,
	dt_fe_crea datetime not null,
	IdUsuario_mod int  null,
	dt_fe_mod datetime  null,
	FOREIGN KEY (IdProducto) REFERENCES tb_producto(Id)
)

create table tb_documento(
	Id int identity (1,1) primary key not null,
	Codigo char(13) not null,
	IdTipoDocumento int not null,
	IdCliente int not null,	
	serie char(8) not null,
	correlativo char(14) not null,	
	dt_fec_emi_factura datetime not null,
	dt_fec_venc_factura datetime not null,
	tx_nota varchar(500) null	,
	IdTipoMoneda int null,
	db_precio_neto decimal(9,1) not null,
	db_precio_bruto decimal(9,1) not null,
	db_descuento decimal(9,1) null,
	db_total_igv decimal(9,1) null,
	db_monto_total decimal(9,1) null,
	db_tipo_cambio decimal(9,1) null,
	IdCond_pago int null,	
	IdEstado_documento int not null,
	IdUsuario_crea int not null,
	dt_fe_crea datetime not null,
	IdUsuario_mod int  null,	
	dt_fe_mod datetime  null,	
	IdEstado_reg int not null,
	FOREIGN KEY (IdCliente) REFERENCES tb_cliente(Id)
)
create table tb_documento_detalle (
	Id int identity (1,1) primary key not null,
	IdDocumento int not null,
	IdProducto int not null,
	In_cantidad int not null,
	db_precio_unitario decimal(9,1) not null,
	db_precio_x_cantidad decimal(9,1) not null,
	db_total decimal(9,1) not null,
	IdUsuario_crea int not null,
	dt_fe_crea datetime not null,
	IdUsuario_mod int  null,
	dt_fe_mod datetime  null,
	FOREIGN KEY (IdDocumento) REFERENCES tb_documento(Id)
)