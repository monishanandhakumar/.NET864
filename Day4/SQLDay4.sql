--TCL  (Transaction Control Language)
--4 modes Local transaction 
--1.Autocommit Transaction 2.Explicit transaction
--3.Implicit Transaction 4.Batch-Scoped Transaction

--Explicit transaction
--commit , Rollback,Save (Check point/BookMark)
select * from Book
Insert Book(Bid,Bname)values(1,'C#'),(2,'Java')

begin Transaction
save Transaction s1
Insert Book(Bid,Bname)values(5,'OOPS')
save Transaction s2
delete from Book where Bname='Java'
update Book set Bname='SQL' where Bid=1
select * from Book
rollback Transaction s2

select * from Book


begin Transaction
save Transaction s3
create table tblStudent(sid varchar(20) primary key,Sname nvarchar(20))
save Transaction s4
Insert tblStudent(sid,Sname)values('S001','Subam')
save transaction s5
update Book set Bname='SQL' where Bid=1
select * from tblStudent
select * from Book
rollback Transaction s4
rollback transaction s3

select * from tblStudent
select * from Book

--Commit
begin transaction t1
insert into Book values(6,'DBMS')
select * from Book
commit tran t1
rollback tran 

--Pl/Sql (pl --Procedural Language)
/*
T-SQL Programming
o Variable Declarations
o Programming Constructs
o Conditional statements
o If-else
o Case
o While
o Break
o Continue
     WHEN Value_1 THEN Statement_1
     WHEN Value_2 THEN Statement_2
     .
     .
     WHEN Value_N THEN Statement_N
     [ELSE Statement_Else]   
END AS [ALIAS_NAME]
*/
--case statement in select queries along with where,order by ,group by.
--It can be used in Insert statement
select * from tblEmployee
--In tblEmployee For Gender M,F

alter table tblEmployee alter  column Gender nvarchar(20)
update tblEmployee
set Gender=CASE Gender
WHEN 'F' THEN 'FEMALE'
WHEN 'M' THEN 'MALE'
ELSE 'Not Entered'
End

--create table tblPerformance
create table tblPerformance(Eid int references tblEmployee(Empid),Rating float(2))
insert into tblPerformance(Eid,Rating) values(1001,5.0),(1002,4.3),(1003,4.5)
,(1004,3.2),(1005,5.0)

select * from tblPerformance
--Case and when with multiple condition
select Eid,Rating,
CASE
WHEN Rating=5 then 'Excellent'
When Rating<=4.9 and Rating>=4 then 'Very Good'
When Rating<=3.9 and Rating>=3 then 'Good'
Else 'Poor'
End as 'Rating Description'
 from tblPerformance

 --in Order by ,female salary in desc order
 --Male salary in  ascending order
 select Ename,Gender,Salary
 from tblEmployee
 order by case Gender
 when 'FEMALE' then Salary End Desc,
 case When Gender='MALE' then Salary 
 End

 --While
 /*declare @count int
 set @count=1
 while @count <=5
  Begin
  Print @count
  set  @count= @count+1
  End*/
 
 --While break and Continue

 DECLARE @count INT = 0
As 
Begin 
<SQL Statement> 
End 
Go
*/
/*Implementing Stored Procedures
o What is Stored Procedure
o Creating Stored Procedures
o Executing Stored Procedures
o Creating Parameterized Stored Procedures
o Handle errors in a stored procedure */
--1
create procedure proc_GetName
as
begin
select 'Hello'
end

exec proc_GetName
--or
proc_GetName

--2
alter procedure proc_GetNameuser(@name varchar(20))
as
begin
--select 'Hello'+' '+@name
select CONCAT('H',@name)
end

proc_GetNameuser 'Monisha'

--3
--SP with Parameters
alter proc proc_AddDept(@Deptname nvarchar(20),@Loc varchar(20) )
as
begin
insert tblDepartment(Dname,Location) values (@Deptname,@Loc)
end

proc_AddDept @Loc='Pune',@Deptname='AAA'

--Sp with out parameter
create proc proc_CallDept
as
begin
select * from tblDepartment
end

proc_CallDept

--create a stored procedure to insert emp details

create proc proc_MgrEmp
as 
begin
select e.Ename 'EmployeeName',m.Ename 'ManagerName'
from tblEmployee e
 Inner join tblEmployee m
 on e.Mgrid=m.Empid
 End

 proc_MgrEmp

 --display the manager name,no of employees whoes manager name is not null and having more than 2 employee

 create proc proc_MgrEmployees(@noofEmp int)
 as
 begin
 select M.Ename as 'ManagerName', count(E.Empid)  'Count_Emp'
create proc proc_TaxCalculator(@id int)
as
begin
declare @Annualsalary int
declare @Taxamount int

set @Annualsalary = (select salary*12 from tblEmployee where Empid=@id)
if(@Annualsalary>400000)
   begin
   set @Taxamount=@Annualsalary*0.1
   print @Taxamount
   end
else
   begin
   print cast(@id as nvarchar(20))+' ' +'Not eligible to pay tax'
   end

end

proc_TaxCalculator @id=1010

----------------------------------
alter proc proc_calculateTax(@empid int)
GO  
SELECT * FROM sys.dm_exec_cached_plans cp CROSS APPLY sys.dm_exec_query_plan(cp.plan_handle);  
GO 
//https://blog.sqlauthority.com/2009/08/21/sql-server-get-query-plan-along-with-query-text-and-execution-count/
USE master;  
GO  
SELECT * FROM sys.dm_exec_query_stats qs CROSS APPLY sys.dm_exec_query_plan(qs.plan_handle);  
GO  


SELECT cp.objtype AS ObjectType,
OBJECT_NAME(st.objectid,st.dbid) AS ObjectName,
cp.usecounts AS ExecutionCount,
st.TEXT AS QueryText,
qp.query_plan AS QueryPlan
FROM sys.dm_exec_cached_plans AS cp
CROSS APPLY sys.dm_exec_query_plan(cp.plan_handle) AS qp
CROSS APPLY sys.dm_exec_sql_text(cp.plan_handle) AS st
--WHERE OBJECT_NAME(st.objectid,st.dbid) = 'YourObjectName'
--where st.text like 'select%' or st.text like 'create%'

select * from tblDepartment

--calling procedure

proc_CallDept

-----Exception Handling
/* BEGIN TRY
--T-SQL statements
--or T-SQL statement blocks
END TRY
BEGIN CATCH
--T-SQL statements
--or T-SQL statement blocks
END CATCH */

--Error Function
--Error_Number(),Error_Line(),Error_Severity(),ErrorState(),ErrorProcedure(),Error_Message()

begin try
declare @data int,@msg varchar(300)
set @data=10/0
end try
begin catch
--set @msg=(select Error_Message())
--print @msg
select Error_Number() as ErrorNumber,Error_Line() as LineNumber,
Error_Severity() as Severity,Error_Message() as Message
End catch

--
alter proc proc_AddDept(@Deptname nvarchar(20),@Loc varchar(20) )
as
begin
  begin try
		insert tblDepartment(Dname,Location) values (@Deptname,@Loc)
 End try
 begin catch
		/*select Error_Number() as ErrorNumber,Error_Line() as LineNumber,
		Error_Severity() as Severity,Error_Message() as Message*/
		print 'Department Name Exist!!!'
 end catch
end

proc_AddDept 'HR','Chennai'





--Tranaction in stored Procedure

alter proc proc_AddDept(@Deptname nvarchar(20),@Loc varchar(20) )
as
begin
  begin try
     begin Transaction
	     delete from tblDepartment where Location=@Loc
		insert tblDepartment(Dname,Location) values (@Deptname,@Loc)

		  If @@TRANCOUNT >0
		     commit
 End try
 begin catch
		/*select Error_Number() as ErrorNumber,Error_Line() as LineNumber,
		Error_Severity() as Severity,Error_Message() as Message*/
		If @@TRANCOUNT>0
		  Rollback
		  select Error_Number() as ErrorNumber,Error_Message() as Message
		print 'Department Name Exist!!!'
 end catch
end

proc_AddDept 'HR','Chennai'

proc_CallDept

--can we call  a stored procedure inside another procedure?
--yes

create proc proc_callProcedure
as
begin

exec proc_CallDept
exec proc_MgrEmp

end

proc_callProcedure