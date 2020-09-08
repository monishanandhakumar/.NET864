/*Implementing Functions
o Creating Functions
o Implement Scalar Functions
o Create Table Valued Functions*/

/*CREATE FUNCTION [schema_name.]function_name (parameter_list)
RETURNS data_type AS
BEGIN
    statements
    RETURN value
END*/

/*function cant return- text ,ntext,image,cursor,timestamp
Two types of function
1. system defined function 2 . User defined function
								 a. Scalar function b.Table Valued Function
*/

--SCALAR FUNCTION (SINGLE VALUE)
CREATE FUNCTION fun_EmpNameCity(@name nvarchar(20),@city nvarchar(20))
returns nvarchar(100)
as
begin
return (select @name+' '+@city)
END

--execute
select Empid,dbo.fun_EmpNameCity(Ename,City) as 'Name City' ,age from tblEmployee

--Tax Calculation

CREATE FUNCTION fun_TaxCalculation(@id int)
returns int
as 
begin
 declare @Annualsalary int
declare @Taxamount int

set @Annualsalary = (select salary*12 from tblEmployee where Empid=@id)
if(@Annualsalary>400000)
   begin
   set @Taxamount=@Annualsalary*0.1
   
   end
else
   begin
   set @Taxamount=0
   end
   return @Taxamount
end 

--exec
select Empid,Ename,dbo.fun_TaxCalculation(Empid) 'TAX AMOUNT' from tblEmployee

--create a function to find the experience of employees
--Find year of birth for employees

create function fun_BirthYear(@eid int)

--Table Valued Function
/*CREATE FUNCTION [schema_name.]function_name (parameter_list)
RETURNS Table
as
    statements
    RETURN 
*/

CREATE FUNCTION fun_T_EmpPersonalDetails()
returns Table
as 
return(select Empid,Ename,Age,Gender from tblEmployee)

--exec
select Ename,Gender from dbo.fun_T_EmpPersonalDetails()

--display the employees of particular department

create function fun_Employeedept(@did int)
returns table
as
return(select * from tblEmployee where did=@did)

select * from fun_Employeedept(101)

--display the employee details based on their rating
CREATE FUNCTION fun_EmployeeRating(@rate int)
ON { Table name or view name }   
[ WITH <Options> ]  
{ FOR | AFTER | INSTEAD OF }   
{ [INSERT], [UPDATE] , [DELETE] }
declare @data int 
set @data='Hi'
End Try
begin catch
--print 'Error Occurred!!!'
select ERROR_MESSAGE()
End Catch

declare @data int 
set @data='Hi'
End Try
begin catch
--print 'Error Occurred!!!'
throw
End Catch

begin try 
declare @data int 
set @data='Hi'
End Try
begin catch
--print 'Error Occurred!!!'


raiserror ('Conversion Failed',16,1)
End Catch

--------------------------------------------------------
--Integrity Constraint
drop table Book
/*Book                           Reader   						customer
bid,bname,cost,			bid,cid,issuedate			cid,cname,age,phno    
   
 */
 create table Book(bid int primary key,bname varchar(30))

 create table Customer(Cid int primary key,cname nvarchar(20),Age int)

 select * from Book
 select * from Customer

 create table Reader(bid int references book(bid) on delete cascade
 on update cascade,cid int  references customer(cid) on delete cascade
 on update cascade,Issuedate date)

 insert into Reader(bid,cid,Issuedate) values(1,100,'2020-09-01')

 insert into Reader(bid,cid,Issuedate) values(1,101,'2020-09-02')
 ,(2,106,'2020-09-06')


 select * from Book
 select * from Customer
 select * from Reader

 update Book set bid=1000 where bid=1
 delete from Book where bid=2

 --Avoids data redundancy
--Ensures that the data in a database is accurate, consistent, and reliable
--Is broadly classified into the following categories:
--Entity integrity: Ensures that each row can be uniquely identified by an attribute called the primary key
--Domain integrity: Ensures that only a valid range of values is allowed to be stored in a column
--Referential integrity: Ensures that the values of the foreign key match the value of the corresponding primary key
--User-defined integrity: Refers to a set of rules specified by a user, which do not belong to the entity, domain, and referential integrity categories


--Various type of integrities can be used to remove the redundancy from the data stored in a table. 
--Additional Inputs
--Domain integrity is implemented using the CHECK constraint. 
--Entity integrity is implemented using the PRIMARY KEY constraint.
--Referential integrity is implemented using the FOREIGN KEY and PRIMARY KEY constraints.
--User-defined integrity is implemented in the form of business rules using CHECK constraints or triggers. 


CREATE TABLE tblEmployeeLeave
(
EmployeeID int CONSTRAINT fkEmployeeID 
FOREIGN KEY REFERENCES tblEmployee(Empid), 
LeaveStartDate datetime CONSTRAINT cpkLeaveStartDate 
PRIMARY KEY(EmployeeID, LeaveStartDate),
LeaveEndDate datetime NOT NULL,
LeaveReason varchar(100),
LeaveType char(2) CONSTRAINT chkLeave 
CHECK(LeaveType IN('CL','SL','PL'))
CONSTRAINT chkDefLeave DEFAULT 'PL'
)

--disabling constraint
--Enabling and Disabling work only to check and foreign key constraint 
sp_help tblDepartment
sP_help tblEmployee

select * from tblEmployee
--disabling Check constraint
alter table tblEmployee nocheck constraint CK__tblEmployee__Age__5BE2A6F2
update tblEmployee set age=14 where Empid=1011

--disabling both constraint
alter table tblEmployee nocheck constraint all

update tblEmployee set Did=10000 where Empid=1011

-- all constraint enable 
alter table tblEmployee check constraint all

update tblEmployee set age=14 where Empid=1011

update tblEmployee set Did=10001 where Empid=1011

--select Into 
--select column name into 'new table' from 'old table'
select * into EMPCity from  tblEmployee
where City like '[CG]%'

sp_help EMPCity

--Insert into
--correlated queires (Exists)

--DCL(data control Language)
--grant ,Revoke