# ArriveWarehouseManagementApi

Will need to resolve the nuget packages. The following packages were added:
- Microsoft.EntityFrameworkCore.InMemory
- Newtonsoft.Json
- Swashbuckle.AspNetCore
- Swashbuckle.AspNetCore.Swagger

Once nuget resolves these packages, build / run the application. Assuming the project builds and runs, you should see a browser open up with the swagger interface exposing the endpoints to the Api.

If you receive a certificate error upon running the application in chrome, you can go to chrome://flags/ and enable the **Allow invalid certificates for resources loaded from localhost** flag. Then re-run the app and it should load properly. 
