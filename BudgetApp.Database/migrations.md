#1 
`dotnet ef migrations add NAME --project BudgetApp.Database --startup-project BudgetApp`
#2 
`mkdir BudgetApp.Database/Database/2022-10-04`
#3
`dotnet ef migrations script --project BudgetApp.Database --startup-project BudgetApp > BudgetApp.Database/Database/2022-10-04/db.sql`