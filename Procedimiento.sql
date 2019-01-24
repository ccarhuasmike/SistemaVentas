
alter PROC sp_ins_tb_usuario
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

alter procedure sp_upd_tb_usuario(
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