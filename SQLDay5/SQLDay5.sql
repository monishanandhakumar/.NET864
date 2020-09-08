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

create function fun_BirthYear(@eid int)returns int asbegin    return(select (DATEPART(YEAR,getdate())-Age) from tblEmployee where Empid=@eid)end--execuselect Ename,dbo.fun_BirthYear(Empid) as [Birth Year] from tblEmployee

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
CREATE FUNCTION fun_EmployeeRating(@rate int)returns tableasreturn (select * from tblEmployee ejointblPerformance pon e.Empid=p.Eidwhere p.Rating=@rate )select * from dbo.fun_EmployeeRating(5)------------------------------------------------------------------------------------------------------------------------------------------can we use insert,update and delete in function? No--Can we use DDL Commands in Function? No--can we call a function inside another function?--can we call stored procedure inside a function?/*stored Procedure					       function-------------------						  -----------	DDL,DML,TCL,DQL							    DQLnot mandiatory to return value             mandiatory to return valuecan call function						cant call stored procedure	perform transaction						can't perform transactionException handling						no Exception handling*/--calling function inside stored procedurealter proc  proc_callfunction(@id int)asbeginselect Ename,dbo.fun_BirthYear(@id) from tblEmployee where Empid=@idendproc_callfunction 1001--for all employeescreate proc  proc_callfunction1asbeginselect Ename,dbo.fun_BirthYear(Empid) from tblEmployee endproc_callfunction1--call procedure inside function--errorcreate function fun_callProc()returns tableasreturn (proc_callfunction1)--Alter function functionname-- drop function functionname									------------------------------------------------------------Triggers-------/*when  an action is performed which in turn leads to another actionEg: receving an OTP, Email trigger cant be manually executed by the userCREATE TRIGGER trigger_name   
ON { Table name or view name }   
[ WITH <Options> ]  
{ FOR | AFTER | INSTEAD OF }   
{ [INSERT], [UPDATE] , [DELETE] }*/select *  from Test--scenario: No Insertion in Test tablecreate trigger t_InsertTeston Testfor Insertasbeginprint 'INSERT OPERATION IS NOT ALLOWED!!!'rollback transactionEND--insert record in test tableInsert Test(id,name,Age) values(5,'D',34),(6,'S',23)--alter trigger trigger name--drop trigger trigger namedrop trigger t_InsertTestCREATE trigger t_InsertTeston Testfor Insert,Delete,Updateasbeginprint 'YOU CANT PERFORM INSERT,UPDATE AND DELETE OPERATION !!!'rollback transactionENDDELETE FROM Test ----------------------------create table tbl_PerformanceDesc(Eid int references tblEmployee(empid),Description nvarchar(30))select * from tbl_PerformanceDescselect * from tblPerformancecreate trigger t_insertdescon tblPerformancefor Insertas begindeclare @t_id int, @t_rating float(2)set @t_id=(select Eid from inserted)set @t_rating=(select Rating from inserted)insert tbl_PerformanceDesc values(@t_id,casewhen @t_rating=5 then 'Excellent'when @t_rating<=4.9 and @t_rating>=4 then 'Good' else 'poor'end)EndInsert tblPerformance values(1006,4.7)-----Delete Triggeralter trigger t_deletePerformanceon tblPerformancefor deleteasbegindeclare @t_id intset @t_id=(select Eid from deleted)begin trydelete from tbl_PerformanceDesc where Eid=@t_idprint 'Record Deleted'end trybegin catchprint 'Error Occurred'end catchEnddelete from tblPerformance where Eid='aaa'--Update triggercreate table tblLeaveStatus(Eid int references tblEmployee(Empid),Status varchar(30),ApprovedDate DateTime)Insert into tblLeaveStatus(Eid,Status)values(1002,'Pending'),(1004,'Pending')select * from tblLeaveStatusalter trigger t_Leaveon tblLeaveStatusfor updateasbegindeclare @tid int set @tid=(select Eid from inserted)update tblLeaveStatus set ApprovedDate=GETDATE() where Status='Approved' and Eid=@tidendupdate tblLeaveStatus set Status='Approved' where  Eid=1002--Exception Handlingdifference between Raiserror and throwbegin try 
declare @data int 
set @data='Hi'
End Try
begin catch
--print 'Error Occurred!!!'
select ERROR_MESSAGE()
End Catch
 begin try 
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