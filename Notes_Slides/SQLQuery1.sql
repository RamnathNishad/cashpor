--Table-Valued
create or alter function fn_getemps_by_did(@did int) returns table
as
return (
	select * 
	from tbl_employee 
	where deptid = @did
)

--to execute

declare @did int=201
select * from dbo.fn_getemps_by_did(@did)


--Ranking statement

select * from tbl_employee

SELECT ROW_NUMBER() OVER (ORDER BY salary desc) AS [Row Number by Salary], ename, salary
FROM tbl_employee

--This will do ranking based on salary order 

SELECT ROW_NUMBER() OVER (PARTITION BY deptid ORDER BY salary) AS [Partition by deptid], ename, salary, deptid 
FROM tbl_employee


SELECT DENSE_RANK() OVER (ORDER BY salary) AS [Rank by salary], ename, salary 
FROM tbl_employee


SELECT 
    deptid,  
    SUM(salary) AS total_salary
FROM 
    tbl_employee
GROUP BY 
    CUBE (deptid)

select * from tbl_employee


WITH SalaryCTE (did,noOfSal)
AS 
(
 SELECT deptid, COUNT(salary)
FROM tbl_employee 
GROUP BY deptid 
) 
SELECT did,noOfSal 
FROM SalaryCTE

WITH SalaryCTE(deptid, noofsalary) 
AS 
(
 SELECT deptid, COUNT(salary) 
FROM tbl_employee 
GROUP BY deptid 
) 
SELECT * 
FROM SalaryCTE 
WHERE noofsalary>1


WITH SalaryCTE(deptid, noofsalary) 
AS 
(
 SELECT deptid, COUNT(salary) 
FROM tbl_employee 
GROUP BY deptid 
) 
SELECT AVG(noofsalary)
FROM SalaryCTE 
WHERE noofsalary>1


SELECT * 
FROM tbl_employee 
PIVOT(SUM(salary) FOR deptid IN ([201],[202],[203])) AS a

------------------Performance Tuning ---------------------

SQl Profiler tool : It is used for analysing different events occurring 
on database at runtime. Trace information is created which can be saved 
in file(.trc) or table and can be used by Database Tuning Advisor Tool to
use this trace information of workload and provide recommendations like
indexes to be created or dropped, views indexes


Query writing to improve peformance:-
