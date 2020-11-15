using System.Linq;
using System;
using GraphQL_API.Entities;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.GraphQL
{
  public class FactInterventionQuery : ObjectGraphType
  {
    public FactInterventionQuery(cindy_okino_warehouseContext db, cindy_okino_dbContext _db)
    {
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

        Field<EmployeeType>(
        "employeeQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var employee = _db
            .Employees
            .FirstOrDefault(i => i.Id == id);

          return employee;
        });

        Field<BuildingType>(
        "buildingQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var building = _db
            .Buildings
            .Include(x => x.Address)
            .Include(x => x.Customer)
            .FirstOrDefault(i => i.Id == id);

          return building;
        });


    }
  }
}