# WPF_WCF_Project
# Overview
## User Story #1
Ability to insert new customer records
 ### Acceptance Critria
 When an user enters first name, last name, and a phone number of a new customer in the specified fields, and clicks an insert button.
 Then the new customer record gets created in the database 
 ## User Story #2
Ability to update the phone number of existing customer records
 ### Acceptance Critria
 When an user enters first name and last name, of an existing user including the new phone number, and clicks an Update Phone button. 
 Then the phone number of a customer record with the name specified, gets updated in the database.
 ## User Story #3
Ability to list all of the customer records
 ### Acceptance Critria
 When an user clicks the Read button all of the records currently stored in the database are listed.
 
 # Set up Instructions
 ## Database set Up
 1. Install SQL Server 2019 Express. You can download the isntallation file here https://www.microsoft.com/en-us/sql-server/sql-server-downloads
 2. After creating your own SQL Server, connect to it using SSMS.
 3. Create the new Database called `WCF`.
 4. Create new table inside WCF database called `TCustomers`, with following columns, `FirstName varchar(50)`, `LastName varchar(50)`, `Phone varchar(50)`
 5. Check if your ServerName and/or Database Name are the same as specified in `Service.svc.cs`, if not, update them accordingly.
