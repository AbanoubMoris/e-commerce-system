# e-commerce-system

#### Project Structure [Repository pattern]
- API Project
  - Receive and respond to HTTP requests
- Infrastructure Project
  - Communicating with database
  - Sending Queries and receiving data from database
- Core Project
  - Contains our business entities and doesn't contain anything else


#### [If you want to add new migrations] First cd to the API folder 
```
dotnet ef migrations add initialCreate -o Data/Migrations -p ..\Infrastructure
dotnet ef database update
```
