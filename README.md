# TechnicalAssessmentSurvey
Technical Assessment Survey API, project kanban (https://github.com/juanflorezc/TechnicalAssessmentSurvey/projects/1)

# Functional requirements Maded:
•	Each table have a CRUD implementation.
•	Has a Trigger over reorder_table, when insert, update or delete, this trigger reorder all items
•	Method to change a question’s order /api/Surveys/ReorderQuestionOrder/{questionid}/{order}
•	Methods widh insert, delete or update have exception control.
•	Has Logging controls over exceptions.

# Technical requirements Maded:
•	C#.
•	Dotnet Core version 3.1
•	Each endpoint whit comment.
•	MS SQL Server.
•	Dependency injection, abstraction (interfaces), and code encapsulation
•	Stored procedure for reorder questions (/api/Surveys/ReorderQuestionOrder/{questionid}/{order}).
• SQL View (/api/Responses/ResponsesAll).
•	Entity Framework Core (with Scaffold-DbContext).
•	Unit testing.

# Instruccions to execution
1. Dowload the file https://github.com/juanflorezc/TechnicalAssessmentSurvey/blob/main/TASurvey_structure.sql
2. Create a new database over a MS SQL Server 
3. Execute the file dowloaded on the first point over the database created on second point
4. Dowload or clone the code 
5. Modify over the file appsettings.json the connection string:
  "TASurveyDatabase": "Server=xxxxx;Database=xxxxx;User ID=xxxxx;Password=xxxx;MultipleActiveResultSets=False;Connection Timeout=30;"
  modify all xxxx with real information of the database created on second point and conection 
6. Run the project

# To test
  you can use the next postman collection
  https://www.getpostman.com/collections/f583bdc7a5500e852f51
  there is all the definition request.
 
 # Architectur
 
The solution consists of 3 projects and a NUNIT project for unit tests.

Of the 3 projects that compose it, the main one is the TASurvey.api, which is in charge of exposing the REST services in 3 controllers, this project is in charge of injecting the dependency of the service layer and the connection chain for the context.

The TASurvey.services project takes care of the business logic and contains both the interfaces and the classes that support all the logic and events on the database.

The TASurvey.model project is in charge of support the database entities.

# Implemented design patterns and architecture patterns.
I used dependency injection like a desing pattern and a layer desing architecture principaly

# Missing points and enhancement opportunities.
I did all the CRUD events but, on my experience, it's a good idea use delete logic, is just a field that control the state of the register (is_deleted for example)

