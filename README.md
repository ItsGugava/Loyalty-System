# Loyalty System Web Service

This is an ASP.NET Core web service project for a loyalty system where retail staff can register customers, manage their data, accumulate and spend loyalty points, and view their activity logs. The system supports features such as accumulating points, spending points, and reversing point transactions with detailed logs for each action.

## Features

- **Customer Management by Retail Staff**:
  - Retail staff can register new customers.
  - Modify or delete customer data (e.g., update contact information).
  - Retrieve customer information.
  
- **Points Accumulation**: 
  - Service can accumulate points for customers at a 1 GEL to 1 point ratio.
  
- **Points Spending**: 
  - Service can spend points for customers at a 100 points = 1 GEL ratio.
  
- **Reverse Transactions**:
  - Service can reverse point accumulation and spending using a unique check ID.
  
- **Transaction Logs**:
  - View detailed logs of accumulated points and spent points.

## Technologies Used

- **ASP.NET Core**: Framework for building the web service.
- **Entity Framework Core**: ORM for database interaction.
- **SQL Server**: Database to store customer and transaction information.
- **API Key Authentication**: Secure API access with API key in the header of each request.

## API Key Authentication

Every request to the API should include an `x-api-key` parameter in the request header. 

"x-api-key": "Jsdjas923kjwdw9923iw9W8Sid8CkaiA9E123kess8eo"

![image](https://github.com/user-attachments/assets/dfe379cc-0cc2-4a13-8f2f-75eff4d8925b)

