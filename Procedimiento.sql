

create PROC sp_ins_usuario
(
@tx_nombre varchar(50),
@tx_apellido_paterno varchar(50),
@tx_apellido_materno varchar(50),
@txt_email varchar(50),
@tx_login varchar(20),
@tx_password varchar(200),
@IdUsuario_crea int,
@Id int out
)
as
BEGIN
	insert into tb_usuario (
							tx_nombre,
							tx_apellido_paterno,
							tx_apellido_materno,
							tx_email,
							tx_login,
							tx_password,
							IdUsuario_crea,
							dt_fe_crea,
							IdEstado_reg
							)
	values(					
							@tx_nombre,
							@tx_apellido_paterno,
							@tx_apellido_materno,
							@txt_email,
							@tx_login,
							@tx_password,
							@IdUsuario_crea,
							getdate(),
							1)
	set @Id =@@IDENTITY
END
go
create procedure sp_upd_usuario(
@tx_nombre varchar(50),
@tx_apellido_paterno varchar(50),
@tx_apellido_materno varchar(50),
@txt_email varchar(50),
@tx_login varchar(20),
@tx_password varchar(200),
@IdUsuario_mod int,
@Id int 
)
as
begin

update tb_usuario
set tx_nombre =@tx_nombre ,
	tx_apellido_paterno= @tx_apellido_paterno,
	tx_apellido_materno=@tx_apellido_materno ,
	tx_email= @txt_email,
	tx_login=@tx_login ,
	tx_password= @tx_password,
	IdUsuario_mod = @IdUsuario_mod,
	dt_fe_mod=getdate() 
	where id = @Id
end
go 
create procedure sp_sel_usuario_x_id(
@Id int 
)
as
begin

SELECT 
	Id ,
	tx_nombre ,
	tx_apellido_paterno ,
	tx_apellido_materno ,
	tx_email ,
	tx_login ,
	tx_password 
FROM tb_usuario where id = @Id
end
go 
create procedure sp_del_usuario(
@Id int 
)
as
begin

update tb_usuario
	set IdEstado_reg =0 
	where id = @Id
end
go 
create PROCEDURE sp_sel_usuario
/*@serie varchar(20),
@numerodoc varchar(20),
@fechaproceso_ini varchar(8),
@fechaproceso_fin varchar(8),*/
@vi_Pagina Int,  
@vi_RegistrosporPagina Int,  
@vi_RecordCount INT OUTPUT  
  
AS  
  
BEGIN  
--SET NOCOUNT ON Evita que se devuelva el mensaje que muestra el recuento del número de filas afectadas por una instrucción  
SET NOCOUNT ON;  
  
SELECT ROW_NUMBER()Over(Order by Id Asc) As RowNum,  
	Id ,
	tx_nombre ,
	tx_apellido_paterno ,
	tx_apellido_materno ,
	tx_email ,
	tx_login ,
	tx_password /*,
	CONVERT(varchar(10),fechaproceso,103) as fechaproceso,
	CONVERT(varchar(10),fecharegistro,103) as fecharegistro	*/
 into #temporales  
FROM tb_usuario 
--where 
	/*(serie = @serie or '' = @serie ) and 
	(numerodoc = @numerodoc or '' = @numerodoc ) and 
	CONVERT(varchar(10),fechaproceso,112) between @fechaproceso_ini and @fechaproceso_fin*/
  
set @vi_RecordCount  = (select  COUNT(*)  
      FROM #temporales  )
        
SELECT * FROM #temporales       
WHERE RowNum BETWEEN (@vi_Pagina - 1) * @vi_RegistrosporPagina + 1 AND @vi_Pagina * @vi_RegistrosporPagina  
  
DROP TABLE #temporales   
END

GO
create PROCEDURE sp_sel_producto
/*@serie varchar(20),
@numerodoc varchar(20),
@fechaproceso_ini varchar(8),
@fechaproceso_fin varchar(8),*/
@vi_Pagina Int,  
@vi_RegistrosporPagina Int,  
@vi_RecordCount INT OUTPUT  
  
AS  
  
BEGIN  
--SET NOCOUNT ON Evita que se devuelva el mensaje que muestra el recuento del número de filas afectadas por una instrucción  
SET NOCOUNT ON;  
  
SELECT ROW_NUMBER()Over(Order by Id Asc) As RowNum,  
	Id ,
	Codigo,
	tx_nombre ,
	tx_descripcion ,
	In_cant_producto ,
	In_unidad ,
	db_precio_costo ,
	db_precio_sin_igv,
	db_precio_bruto_igv ,
	In_igv,
	tx_imagen_producto,
	IdEstado_reg
	 /*,
	CONVERT(varchar(10),fechaproceso,103) as fechaproceso,
	CONVERT(varchar(10),fecharegistro,103) as fecharegistro	*/
 into #temporales  
FROM tb_producto 
--where 
	/*(serie = @serie or '' = @serie ) and 
	(numerodoc = @numerodoc or '' = @numerodoc ) and 
	CONVERT(varchar(10),fechaproceso,112) between @fechaproceso_ini and @fechaproceso_fin*/
  
set @vi_RecordCount  = (select  COUNT(*)  
      FROM #temporales  )
        
SELECT * FROM #temporales       
WHERE RowNum BETWEEN (@vi_Pagina - 1) * @vi_RegistrosporPagina + 1 AND @vi_Pagina * @vi_RegistrosporPagina  
  
DROP TABLE #temporales   
END

GO
create PROC sp_ins_producto
(
@tx_nombre varchar(50),
@tx_descripcion varchar(1000),
@In_cant_producto int,
@In_unidad int,
@db_precio_costo decimal(9,1),
@db_precio_sin_igv decimal(9,1),
@db_precio_bruto_igv decimal(9,1),
@In_igv decimal(9,1),
@tx_imagen_producto varchar(500),
@IdUsuario_crea int,
@Id int out
)
as
BEGIN
	insert into tb_producto (
							tx_nombre,
							tx_descripcion,
							In_cant_producto,
							In_unidad,
							db_precio_costo,
							db_precio_sin_igv,							
							db_precio_bruto_igv,
							In_igv,
							tx_imagen_producto,
							IdUsuario_crea,
							dt_fe_crea,
							IdEstado_reg
							)
	values(					
							@tx_nombre,
							@tx_descripcion,
							@In_cant_producto,
							@In_unidad,
							@db_precio_costo,
							@db_precio_sin_igv,
							@db_precio_bruto_igv,
							@In_igv,
							@tx_imagen_producto,
							@IdUsuario_crea,
							getdate(),
							1)
	set @Id =@@IDENTITY
END


go
create procedure sp_upd_producto(
@tx_nombre varchar(50),
@tx_descripcion varchar(1000),
@In_cant_producto int,
@In_unidad int,
@db_precio_costo decimal(9,1),
@db_precio_sin_igv decimal(9,1),
@db_precio_bruto_igv decimal(9,1),
@In_igv decimal(9,1),
@tx_imagen_producto varchar(500),
@IdUsuario_mod int,
@Id int 
)
as
begin

update tb_producto
set		tx_nombre= @tx_nombre,
		tx_descripcion= @tx_descripcion,
		In_cant_producto= @In_cant_producto,
		In_unidad= @In_unidad,
		db_precio_costo= @db_precio_costo,
		db_precio_sin_igv= @db_precio_sin_igv,							
		db_precio_bruto_igv= @db_precio_bruto_igv,
		In_igv = @In_igv,
		tx_imagen_producto=@tx_imagen_producto,
		IdUsuario_mod = @IdUsuario_mod,
		dt_fe_mod=getdate() 
	where id = @Id
end

go
create procedure sp_sel_producto_x_id(
@Id int 
)
as
begin

SELECT 
	Id ,
	Codigo,
	tx_nombre ,
	tx_descripcion ,
	In_cant_producto ,
	In_unidad ,
	db_precio_costo ,
	db_precio_sin_igv,
	db_precio_bruto_igv ,
	In_igv,
	tx_imagen_producto,
	IdEstado_reg
FROM tb_producto where id = @Id
end

go 
create procedure sp_del_producto(
@Id int 
)
as
begin

update tb_producto
	set IdEstado_reg =0 
	where id = @Id
end
go
create PROCEDURE sp_sel_proveedor
/*@serie varchar(20),
@numerodoc varchar(20),
@fechaproceso_ini varchar(8),
@fechaproceso_fin varchar(8),*/
@vi_Pagina Int,  
@vi_RegistrosporPagina Int,  
@vi_RecordCount INT OUTPUT  
  
AS  
  
BEGIN  
--SET NOCOUNT ON Evita que se devuelva el mensaje que muestra el recuento del número de filas afectadas por una instrucción  
SET NOCOUNT ON;  
  
SELECT ROW_NUMBER()Over(Order by Id Asc) As RowNum,  
	Id ,
	Codigo,
	tx_nombre ,
	tx_apellido_paterno ,
	tx_apellido_materno ,
	tx_ruc ,
	tx_email ,
	tx_direccion,
	tx_telefono ,
	tx_celular,
	IdEstado_reg
	 /*,
	CONVERT(varchar(10),fechaproceso,103) as fechaproceso,
	CONVERT(varchar(10),fecharegistro,103) as fecharegistro	*/
 into #temporales  
FROM tb_proveedor 
--where 
	/*(serie = @serie or '' = @serie ) and 
	(numerodoc = @numerodoc or '' = @numerodoc ) and 
	CONVERT(varchar(10),fechaproceso,112) between @fechaproceso_ini and @fechaproceso_fin*/
  
set @vi_RecordCount  = (select  COUNT(*)  
      FROM #temporales  )
        
SELECT * FROM #temporales       
WHERE RowNum BETWEEN (@vi_Pagina - 1) * @vi_RegistrosporPagina + 1 AND @vi_Pagina * @vi_RegistrosporPagina  
  
DROP TABLE #temporales   
END

GO
create PROC sp_ins_proveedor
(
@tx_nombre varchar(50),
@tx_apellido_paterno varchar(50),
@tx_apellido_materno varchar(50),
@tx_ruc varchar(11),
@tx_email varchar(50),
@tx_direccion varchar(100),
@tx_telefono varchar(11),
@tx_celular varchar(11),
@IdUsuario_crea int,
@Id int out
)
as
BEGIN
	insert into tb_proveedor (
							tx_nombre,
							tx_apellido_paterno,
							tx_apellido_materno,
							tx_ruc,
							tx_email,
							tx_direccion,							
							tx_telefono,
							tx_celular,							
							IdUsuario_crea,
							dt_fe_crea,
							IdEstado_reg
							)
	values(					
							@tx_nombre,
							@tx_apellido_paterno,
							@tx_apellido_materno,
							@tx_ruc,
							@tx_email,
							@tx_direccion,
							@tx_telefono,
							@tx_celular,
							@tx_imagen_producto,
							@IdUsuario_crea,
							getdate(),
							1)
	set @Id =@@IDENTITY
END


go
create procedure sp_upd_proveedor(
@tx_nombre varchar(50),
@tx_descripcion varchar(1000),
@In_cant_producto int,
@In_unidad int,
@db_precio_costo decimal(9,1),
@db_precio_sin_igv decimal(9,1),
@db_precio_bruto_igv decimal(9,1),
@In_igv decimal(9,1),
@tx_imagen_producto varchar(500),
@IdUsuario_mod int,
@Id int 
)
as
begin

update tb_producto
set		tx_nombre= @tx_nombre,
		tx_descripcion= @tx_descripcion,
		In_cant_producto= @In_cant_producto,
		In_unidad= @In_unidad,
		db_precio_costo= @db_precio_costo,
		db_precio_sin_igv= @db_precio_sin_igv,							
		db_precio_bruto_igv= @db_precio_bruto_igv,
		In_igv = @In_igv,
		tx_imagen_producto=@tx_imagen_producto,
		IdUsuario_mod = @IdUsuario_mod,
		dt_fe_mod=getdate() 
	where id = @Id
end

go
create procedure sp_sel_proveedor_x_id(
@Id int 
)
as
begin

SELECT 
	Id ,
	Codigo,
	tx_nombre ,
	tx_descripcion ,
	In_cant_producto ,
	In_unidad ,
	db_precio_costo ,
	db_precio_sin_igv,
	db_precio_bruto_igv ,
	In_igv,
	tx_imagen_producto,
	IdEstado_reg
FROM tb_producto where id = @Id
end

go 
create procedure sp_del_proveedor(
@Id int 
)
as
begin

update tb_producto
	set IdEstado_reg =0 
	where id = @Id
end