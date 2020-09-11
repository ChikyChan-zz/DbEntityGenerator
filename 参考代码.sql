use master
go
    -- 查看 DBMS 中所有对象
select
    *
from
    sysobjects;

-- 查看 DBMS 中所有数据库
select
    *
from
    sysdatabases;

------------------------------------------------------
use yourDataBase
go
    -- 查看"yourDataBase"数据库中所有的表
select
    *
from
    yourDataBase.information_schema.tables;

-- 查看"yourDataBase"数据库中所有的字段
select
    *
from
    yourDataBase.information_schema.columns;

-- 查看"yourDataBase"数据库中,"yourTable"表的相关字段的属性
select
    column_name,
    data_type --数据类型
from
    yourDataBase.information_schema.columns
where
    table_name = 'yourTable';

select
    column_name,
    is_nullable --是否为空
from
    yourDataBase.information_schema.columns
where
    table_name = 'yourTable';

-- 查看表的列
select
    *
from
    AdventureWorks2017.sys.columns
where
    object_id = object_id('HumanResources.EmployeePayHistory');

-- 查看注释
select
    *
from
    sys.extended_properties
where
    name = 'MS_Description'
    and p.class = 1
    -- and major_id = object_id('HumanResources.EmployeePayHistory') --查看表下所有对象的注释
    -- and minor_id = [column_id] -- column_id为查看某列的注释，0为查看表注释;