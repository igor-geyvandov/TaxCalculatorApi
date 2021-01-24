# TaxServices

TaxService is web API built with a .Net Core. It offers a common RESTful interface to customers that need to perform tax calculations. 

**TaxService leverages the following software design patterns and best practices:**

 - Single-responsibility principle
 - dependency injection for achieving Inversion of Control between classes and their dependencies
 - global error/exception handling with custom middlewares
 - global model validation with custom ActionFilters
 - use of DTOs to return results and accept inputs
 - appropriately scoped DI services lifetimes
 - environment variables and use of Options pattern for AppSettings access
 - use of asynchronous code 
 - logging
 - clean controllers and action methods
 - use of AutoMapper for object mapping 
 - unit tests for TaxService interface endpoints
 - health check monitoring endpoint with custom middleware (/health)
 - Swagger specification for describing TaxService REST APIs (/swagger)
 - CORS support
 - optimized data access and I/O
 - clean and well-documented code

**TaxService can also be improved in the following ways:**

 - move sensitive API keys from source code into Azure Key Vault
 - abstract HttpClient functionality from implementations of ITaxCalculatorService interface
 - move service interfaces and implementation into a separate project within the solution
 - add endpoint data output caching with Azure Cache for Redis

**Class diagram of entities used for GetTaxRateForLocation:**

![alt text](https://github.com/igor-geyvandov/TaxCalculatorApi/blob/master/Images/ClassDiagram-TaxRateEntities.jpg?raw=true)


**Class diagram of entities used for GetSalesTaxForOrder:**

![alt text](https://github.com/igor-geyvandov/TaxCalculatorApi/blob/master/Images/ClassDiagram-OrderTaxEntities.jpg?raw=true)


