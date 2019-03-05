<h1 align="center">NorthwindData</h1>

 ![Learning](https://media.wired.com/photos/5932988b9be5e55af6c261cb/master/pass/learning-styles.jpg)
<div align="center">
  NorthwindData is a small project used by me for learning purposes. In this project I am presenting my knowledge for project architecture.
</div>
<br />

<h3 align="center">This project uses:</h3>
<div align="center">
  <h3>
    <a href="https://reactjs.org/">
      React
    </a>
    <span> | </span>
    <a href="https://redux.js.org/">
      Redux
    </a>
    <span> | </span>
    <a href="https://dotnet.microsoft.com/download">
      .Net Core
    </a>
    <span> | </span>
    <a href="https://github.com/aspnet/EntityFrameworkCore">
      EntityFrameworkCore
    </a>
    <span> | </span>
    <a href="https://www.microsoft.com/en-us/sql-server/sql-server-2017">
      SQLServer
    </a>
  </h3>
</div>

##
### Project Architecture

[Front end App] </br> > | api points  |[ApiControllers] </br> < >| Abstraction  |[BusinessLayer] </br> < >| Abstraction | [Access] </br> <
--------|---|--|--|--|---|---

- The front end application gets and sets data through the api points.
- The ApiControllers communicate with the BusinessLayer through abstraction. Dependency injection is used to fulfill the abstraction at run time.
- The BusinessLayer communicate with the Access layer(persistence layer) through abstraction. Dependency injection is used to fulfill the abstraction at run time.

### Project layers
* __Front end App:__ It is a web app made with React and Redux.
* __ApiControllers:__ .Net core project which exposes api points.
* __BusinessLayer:__ .Net core project which hold all the business requirements.
* __Access:__ This is the persistence layer. Here is where all the communication with the database is made.
  * This layer uses Entity framework core to communicate with SQL server. 
  * This layer uses CQRS pattern and more precisely Command and Query pattern. Commands would make change to the database and queries would retrieve data.

### Features
* __Version 1.0__ 
  * Show employees for certain territories.
  * Change employee description.
* __Version 1.1__
  * Show the 10 most expensive products
  
##### Resources:
<a href="https://github.com/Microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql">
      Link to database used in the project
    </a>

