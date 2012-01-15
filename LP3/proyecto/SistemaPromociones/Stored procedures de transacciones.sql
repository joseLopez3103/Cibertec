/* Stored procedures de transacciones */
use ventas
go
create procedure pr_listarvendedores
as
select cod_ven,nom_ven + ' ' + ape_ven as nombrecompleto from tb_vendedor
order by nombrecompleto
go

create procedure pr_listarproductos
AS
select * from Tb_Producto
order by Des_pro
go

create procedure pr_datosproducto
@vc_codigo varchar(8)
as
select * from Tb_Producto
where Cod_pro=@vc_codigo
go


create procedure pr_listarclientes
as
select * from Tb_Cliente
order by Raz_soc_cli
go

create procedure pr_generaNumero
as
declare @vc_factura varchar(5)
select @vc_factura='FA'+ right('00'+rtrim(CONVERT(INT,RIGHT(ISNULL(MAX(Num_fac),0),3))+1),3)  from Tb_Factura
select @vc_factura as CódigoGenerado
go

create procedure pr_graba_CabeceraFactura
@num VarChar(5),
@fecfac varchar(10),
@vc_cli varchar(8),
@feccan varchar(10),
@vc_ven varchar(6)
as
insert into Tb_Factura(Num_fac,Fec_fac,Cod_cli,Fec_can,Est_fac,Cod_ven,Por_Igv)
values(@num,CONVERT(datetime,@fecfac),@vc_cli,CONVERT(datetime,@feccan),'P',@vc_ven,0.19)
go


create procedure pr_graba_DetalleDetalle
@num VarChar(5),
@vc_pro VarChar(8),
@int_can int,
@dc_pre Decimal(30,3)
as
insert into tb_detalle_factura(num_fac,cod_pro,can_ven,pre_ven)
values (@num,@vc_pro,@int_can,@dc_pre)
go

create procedure pr_lee_ultima_factura
as
select isnull(MAX(num_fac),'')as maximo 
from Tb_Factura
go
