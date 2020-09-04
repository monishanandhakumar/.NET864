/*Groupby
SELECT column1, column2 
FROM table_name 
WHERE [ conditions ] 
GROUP BY column1, column2 
ORDER BY column1, column2 

*/
--Group by works with aggregate function
--No of employees under each manager

select Mgrid,count(Empid) 'No of Employees'
from tblEmployee
group by Mgrid
order by Mgrid desc

---display the name of each department and the Maximum salary in the department
/*            did
department ---------->   Employee*/

select d.Dname,MAX(e.Salary)  as Maxsalary from
tblEmployee e,tblDepartment d
where e.Did=d.Did
group by d.Dname

--no of male and female in dept 100
select count(Empid) [No. of Employees], Gender 
from tblemployee where Did=101 group by Gender

select * from tblEmployee

--Having
/*SELECT column1, column2 
FROM table_name 
WHERE [ conditions ] 
GROUP BY column1, column2 
having condition
ORDER BY column1, column2*/

--Display the manager who has > =2 employees
select Mgrid ,count(Empid)
from tblEmployee
group by Mgrid
having count(Empid)>=2 

--display the department id, Min salary whoes minimum salary>=40000
select Did,Min(Salary) as 'MinSalary'
from tblEmployee
group by Did
having Min(Salary)>=40000 