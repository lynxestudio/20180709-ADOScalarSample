# Oracle Recipe #2: How to execute a query that returns a Scalar result with OracleCommand

Microsoft ADO.NET command objects have an ExecuteScalar method, which enables you to execute a query that returns a single result.
Open a database connection.
Create and initialize a command object.
Call the ExecuteScalar method on the command object.
Convert the return value from ExecuteScalar into an appropriate data type.
Dispose the command object.
Close the database connection.
The following example, show how to execute a query that determines the average salary from the table employees on the HR schema provided by Oracle Database XE. The example assume that the query does not return a NULL result.

Fig 1. OracleCommand ExecuteScalar method code example.

OracleCommand ExecuteScalar method code example

Download example source code.
