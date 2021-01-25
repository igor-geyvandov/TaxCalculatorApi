# TaxServices

TaxService is web API built with ASP.NET Core framework. It offers a common RESTful interface to customers that need to perform tax calculations. 

**TaxService leverages the following software design patterns and best practices:**

 - Single-responsibility principle
 - Dependency Injection for achieving Inversion of Control between classes and their dependencies
 - Global error/exception handling with custom middlewares
 - Global model validation with custom ActionFilters
 - Use of DTOs to return results and accept inputs
 - Appropriately scoped DI services lifetimes
 - Environment variables and use of Options pattern for AppSettings access
 - Use of asynchronous code for optimized data access and I/O
 - Logging
 - Light controllers and action methods
 - Use of AutoMapper for object mapping 
 - Unit tests for TaxService interface endpoints
 - Health check monitoring endpoint with custom middleware (/health)
 - Swagger specification for describing TaxService REST APIs (/swagger)
 - CORS support enabled
 - Clean and well-documented code
 

**TaxService can also be improved in the following ways:**

 - Move sensitive API keys from source code into Azure Key Vault
 - Abstract HttpClient functionality from implementations of ITaxCalculatorService interface
 - Move service interfaces and implementation into a separate project within the solution
 - Add endpoint data output caching with Azure Cache for Redis
 

**Class diagram of entities used by ITaxCalculatorService.GetTaxRateForLocation():**

![alt text](https://github.com/igor-geyvandov/TaxCalculatorApi/blob/master/Images/ClassDiagram-TaxRateEntities.jpg?raw=true)


**Class diagram of entities used for ITaxCalculatorService.GetSalesTaxForOrder():**

![alt text](https://github.com/igor-geyvandov/TaxCalculatorApi/blob/master/Images/ClassDiagram-OrderTaxEntities.jpg?raw=true)


**TaxService API Swagger specification (/swagger):**

![alt text](https://github.com/igor-geyvandov/TaxCalculatorApi/blob/master/Images/SwaggerSpec.jpg?raw=true)


**TaxService API sequence diagrams:**

![alt text](https://github.com/igor-geyvandov/TaxCalculatorApi/blob/master/Images/SequenceDiagram-TaxServices.jpg?raw=true)
