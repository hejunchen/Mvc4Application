Mvc4Application
===============

My own practice on ASP.NET MVC

This is a practice project that I created to help myself move on from ASP.NET Web Form to MVC world.
It will require a SQL Server database "AdventureWorks2008R2" to provide the data.
Modify the connection string in web.config file to probably configure the database that will be used.

To download the sample database file, go to: (AdventureWorks2012_Database.zip)
http://msftdbprodsamples.codeplex.com/releases/view/93587

Once the database is attached to your local instance, make sure you copy and run the following scripts to create two views.

-------------------------------------------------------------------------------------------

create view [dbo].[v_Employees] as
(
         select vEmp.*, tEmp.BirthDate, tEmp.Gender
         from HumanResources.vEmployee vEmp
         left join HumanResources.Employee tEmp on vEmp.BusinessEntityID = tEmp.BusinessEntityID
)

-------------------------------------------------------------------------------------------

create view [dbo].[v_SalesPersons] as
(
         select vSales.*, tEmp.BirthDate, tEmp.Gender
         from Sales.vSalesPerson vSales
         left join HumanResources.Employee tEmp on vSales.BusinessEntityID = tEmp.BusinessEntityID
)

-------------------------------------------------------------------------------------------






