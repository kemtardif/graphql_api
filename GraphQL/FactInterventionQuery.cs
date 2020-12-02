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
            .ToListAsync();

          return employee;
        });

        Field<ListGraphType<EmployeeType>>(
        "allemployeesQuery",

        //arguments:// new QueryArguments(
        //  new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          //var id = context.GetArgument<long>("id");
          var employees = _db
            .Employees
            .ToListAsync();

          return employees;
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
            //.Include(x => x.Customer)
            .FirstOrDefault(i => i.Id == id);

          return building;
        });

        Field<ListGraphType<ElevatorType>>(
        "elevatorQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var elevators = _db
            .Elevators
            .Where(_=>_.ColumnId == id)
                            .ToListAsync();

          return elevators;
        });

        Field<ListGraphType<ColumnType>>(
        "columnQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var columns = _db
            .Columns
            .Where(_=>_.BatteryId == id)
                            .ToListAsync();

          return columns;
        });

        Field<ListGraphType<BatteryType>>(
        "batteryQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var batteries = _db
            .Batteries
            .Where(_=>_.BuildingId == id)
                            .ToListAsync();

          return batteries;
        });

        Field<CustomerType>(
        "customerQuery",

        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id"}),

        resolve: context =>
        {
          var id = context.GetArgument<long>("id");
          var customers = _db
            .Customers
            .FirstOrDefault(i => i.Id == id);

          return customers;
        });

    }
  }
}