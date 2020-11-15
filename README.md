**Quick Readme!

**First Note that this is a Net5.0 project

After creating new wep app app and installed the needed packages for this project:

```C#
    <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="5.0.0" NoWarn="NU1605"/>
    <PackageReference Include="Microsoft.AspNetCore.Authentication.OpenIdConnect" Version="5.0.0" NoWarn="NU1605"/>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.0">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="5.0.0"/>
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="5.0.0-rc2"/>
    <PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="5.0.0-alpha.1"/>
    <PackageReference Include="Swashbuckle.AspNetCore" Version="5.6.3"/>
    <PackageReference Include="GraphQL" Version="2.4.0"/>
    <PackageReference Include="graphiql" Version="1.2.0"/>
```

-The models and DBContexts were scaffolded from the dbs by "reverse-engineering", allowing to quickly create them.

Starting with the GraphQL Controller in the controller folder, we define the single GraphQL endpoint at /graphql:

```C#
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.Inputs = query.Variables;
                
            });
            if(result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            return Ok(result.Data);
        }
    }
```

-GraphQLQuery is a template which will be used for all queries :

```C#

 public class GraphQLQuery
  {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public Inputs Variables { get; set; }
    }
}

```

-The Schema into which queries are resolved is then defined :

```C#

    public class GraphQLSchema:Schema, ISchema
        {
            public GraphQLSchema(IDependencyResolver resolver):base(resolver)
            {
                Query = resolver.Resolve<FactInterventionQuery>();

            }
        }
```

-GraphQL query not the Entities themselves, but related type classes, which must be constructed with the various fields (attributes)
that are needed for the queries. For example, a building type is defined as such :

```C#

    public BuildingType(cindy_okino_warehouseContext _db, cindy_okino_dbContext db)
    {
      Name = "Building";

      Field(x => x.Id);
      Field(x => x.AddressId, nullable: true);
      Field(x => x.CustomerId, nullable: true);
      Field(x => x.TectContactPhone);
      Field(x => x.Address, type: typeof(AddressType));
      Field(x => x.Customer, type: typeof(CustomerType));
      Field<ListGraphType<FactInterventionType>>(
        "interventions",

        arguments: 
          new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            var interventions =_db.FactInterventions
                                .Where(ss => ss.BuildingId == context.Source.Id)
                                .ToListAsync();

            return interventions;
        });
```

-The various fields matches those of the entities, except for the last one, which is needed for the queries.
There is no need to modify the relation between existing entities, since Types are classes in themselves. We just add
fields that relate them as such. Making the type a function of dbCOntexts allow to query the two databases. This
is where the two databases connect. (or this is where I could've used some kind of "context selector" method to do it)

-Finally, the various queries are defined of an ObjectGraphType called...FactInterventionQuery! For example :

```C#

      Field<FactInterventionType>(
        "interventionQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var intervention = db
            .FactInterventions
            .FirstOrDefault(i => i.Id == id);

          return intervention;
        });
```

-This takes an id and spit us back a FactInterventionType. THis type will have fields like "building" into which we can query. Those fields in turn 
have fields that we can query,etc, allowing to make the desired queries.

-For this to work in dotnet, all types,queries and dbContexts must be added to the Dependency Injection (ConfigureServices in Startup.cs), including the namespaces needed to make the queries, 
like DependencyResolver and DocumentExecuter :

```C#

            services.AddScoped<BuildingType>();
            services.AddScoped<AddressType>();
            services.AddScoped<FactInterventionType>();
            services.AddScoped<EmployeeType>();
            services.AddScoped<BuildingsDetailType>();
            services.AddScoped<CustomerType>();

            services.AddScoped<FactInterventionQuery>();


            services.AddScoped<ISchema, GraphQLSchema>();
        
            services.AddDbContext<cindy_okino_dbContext>(options =>
                options.UseMySql(connectionMSQL));

           services.AddDbContext<cindy_okino_warehouseContext>(options => 
                options.UseNpgsql(connectionPSQL));
```

-The GraphiQL interface allow to easily make queries at localhost:5001/graphql. Here's the three required query :

```
INTERVENTION QUERY

query {
  interventionQuery(id:1) {
    startDateIntervention
    endDateIntervention
    building{
      address{
        address1
      }
    }

  }
}

BUILDING QUERY

query {
  buildingQuery(id:5) {

  customer{
    cpyContactName
    cpyContactPhone
    cpyContactEmail
    cpyDescription
    staName
    staPhone
    staMail
    }
    interventions{
      
    startDateIntervention
    endDateIntervention
    }


  }
}

EMPLOYEE QUERY


query {
  employeeQuery(id:5) {
    interventions{
      startDateIntervention
      endDateIntervention
      building{        
        buildingsDetails{
          infoKey
          value
        }
      }
    }


  }
}
```






