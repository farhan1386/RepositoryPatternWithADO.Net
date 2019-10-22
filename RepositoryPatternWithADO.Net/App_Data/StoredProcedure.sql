
/* TO GET ALL EMPLYEES AND GET EMPLOYEE BY ID*/
create procedure spGetEmployee
as
begin 
select * from Employee
end

/* TO CREATE NEW EMPLOYEE*/
create procedure spAddNew
(
@Name nvarchar(50),
@Position nvarchar(50),
@Office nvarchar(50),
@Age int,
@Salary int
)
as
begin
	insert into Employee(Name,Position,Office,Age,Salary)
	values(@Name,@Position,@Office,@Age,@Salary)
end

/* TO UPDATE EMPLOYEE*/
create procedure spUpdateEmployee
(
@Id int,
@Name nvarchar(50),
@Position nvarchar(50),
@Office nvarchar(50),
@Age int,
@Salary int
)
as
begin
	update Employee 
	set Name=@Name,Position=@Position,Office=@Office,Age=@Age,Salary=@Salary
	where Id=@Id
end

/* TO DELETE EMPLOYEE*/
create procedure spDeleteEmployee
(
@Id int
)
as
begin
	delete from Employee where Id=@Id
end