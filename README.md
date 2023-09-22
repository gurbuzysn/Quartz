### Application Core
```
	Install-Package Ardalis.Specification
```

### Infrastructure
```
	Install-Package Microsoft.EntityFrameworkCore
	Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
	Install-Package Microsoft.EntityFrameworkCore.Tools
	Install-Package Microsoft.EntityFrameworkCore.Design
	Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore
	Install-Package Ardalis.Specification.EntityFrameworkCore
```


### Migrations

```
	Add-Migration InitialCreate -Context QuartzContext -OutputDir Data/Migrations
	Update-Database -Context QuartzContext
```

```
	Add-Migration InitialIdentity -Context AppIdentityDbContext -OutputDir Identity/Migrations
	Update-Database -Context AppIdentityDbContext
```


