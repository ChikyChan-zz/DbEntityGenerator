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