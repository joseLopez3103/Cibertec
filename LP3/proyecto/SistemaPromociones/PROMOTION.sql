USE master
go
drop database PROMOTION
go
create database PROMOTION
go
use PROMOTION 
go
CREATE TABLE tb_promotion
(
cod int PRIMARY KEY IDENTITY,
name varchar(20) ,
state varchar(20),
date_init datetime,
date_end datetime,
description varchar(255)
)