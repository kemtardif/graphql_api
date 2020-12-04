using GraphQL_API.Entities;
using GraphQL.Types;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GraphQL_API.GraphQL
{
  public class FactInterventionType : ObjectGraphType<FactIntervention>
  {

    ///////INTERVENTION Type//////////////
    public FactInterventionType(cindy_okino_dbContext db)
    {
      Name = "Intervention";

      Field(x => x.Id);
      Field(x => x.BuildingId, nullable: true);
      Field(x => x.StartDateIntervention, nullable: true);
      Field(x => x.EndDateIntervention, nullable: true);
      Field<BuildingType>(
        "building",

        arguments: 
          new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            var building = db.Buildings
                            .Include(_ => _.Address)
                            //.Include(_ => _.Customer)
                            .FirstOrDefault(i => i.Id == context.Source.BuildingId);

            return building;
        });


    }    
  }
    //////////////EMPLOYEE TYPE//////////////////////

  public class EmployeeType : ObjectGraphType<Employee>
  {
    public EmployeeType(cindy_okino_warehouseContext _db)
    {
      Name = "Employee";

      Field(x => x.Id);
      Field(x => x.FirstName);
      Field(x => x.LastName);
      Field<ListGraphType<FactInterventionType>>(
        "interventions",

        arguments: 
        new QueryArguments(
          new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            var interventions =_db.FactInterventions
                                .Where(ss => ss.EmployeeId == context.Source.Id)
                                .ToListAsync();

            return interventions;
        });
      

    } 
  }

  ///////BUILDING TYPE///////////////////

  public class BuildingType : ObjectGraphType<Building>
  {
    public BuildingType(cindy_okino_warehouseContext _db, cindy_okino_dbContext db)
    {
      Name = "Building";

      Field(x => x.Id);
      Field(x => x.TectContactPhone);
      Field(x => x.TectContactEmail);
      Field(x => x.TectContactName);
      Field(x => x.AdmContactPhone);
      Field(x => x.AdmContactMail);
      Field(x => x.AdmContactName);
      Field(x => x.AddressId, nullable: true);
      Field(x => x.CustomerId, nullable: true);

      //Field(x => x.Address, type: typeof(AddressType));
      Field<AddressType>(
        "address",

        arguments: 
          new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            var address = db.Addresses
                            .FirstOrDefault(i => i.Id == context.Source.AddressId);

            return address;
        });
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
        Field<ListGraphType<BatteryType>>(
        "batteries",

        // arguments: 
        //   new QueryArguments(
        //     new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            var batteries = db.Batteries
                                .Where(ss => ss.BuildingId == context.Source.Id)
                                .ToListAsync();

            return batteries;
        });

      Field<ListGraphType<BuildingsDetailType>>(
      "buildingsDetails",

      arguments: 

        new QueryArguments(
          new QueryArgument<IntGraphType> { Name = "id" }),

      resolve: context => 
      {
          var buildingDetails = db.BuildingsDetails
                              .Where(ss => ss.BuildingId == context.Source.Id)
                              .ToListAsync();

          return buildingDetails;
      });

    }    
  }

  /////////////////ADDRESS TYPE/////////////////////

  
  public class AddressType : ObjectGraphType<Address>
  {
    public AddressType()
    {
      Name = "Address";

      Field(x => x.Id);
      Field(x => x.Address1);
      Field(x => x.Buildings, type: typeof(ListGraphType<BuildingType>));
      

    } 
  }



  //////////////CUSTOMER TYPE////////////////////

   public class CustomerType : ObjectGraphType<Customer>
  {
    public CustomerType(cindy_okino_dbContext _db)
    {
      Name = "Customer";

      Field(x => x.Id);
      Field(x => x.CpyContactName);
      Field(x => x.CpyContactPhone);
      Field(x => x.CpyContactEmail);
      Field(x => x.CpyDescription);
      Field(x => x.StaName);
      Field(x => x.StaPhone);
      Field(x => x.StaMail);

      Field<ListGraphType<BuildingType>>(
        "buildings",

        arguments: 
          new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
             var buildings =_db.Buildings
                                // .Include(_ => _.Batteries)
                                 .Where(ss => ss.CustomerId == context.Source.Id)
                                 .ToListAsync();


            return buildings;
        });
        Field<ListGraphType<BatteryType>>(
        "batteries",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var batteries = _db.Batteries
                            .Where(_=>_.Building.CustomerId == context.Source.Id)
                            .ToListAsync();

            return batteries;
      });
      Field<ListGraphType<ColumnType>>(
        "columns",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var columns = _db.Columns
                            .Where(_=>_.Battery.Building.CustomerId == context.Source.Id)
                            .ToListAsync();

            return columns;
      });
      Field<ListGraphType<ElevatorType>>(
        "elevators",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var elevators = _db.Elevators
                            .Where(_=>_.Column.Battery.Building.CustomerId == context.Source.Id)
                            .ToListAsync();

            return elevators;
      });
    } 
  }


/////////////////BUILDINGS DETAIL TYPE///////////////////
  public class BuildingsDetailType : ObjectGraphType<BuildingsDetail>
  {
    public BuildingsDetailType()
    {
      Name = "BuildingsDetail";

      Field(x => x.Id);
      Field(x => x.InfoKey);
      Field(x => x.Value);
      Field(x => x.BuildingId, nullable: true);

    } 
  }


  ///BATTERY TYPE ////////////////////

    public class BatteryType : ObjectGraphType<Battery>
    {
      public BatteryType(cindy_okino_dbContext _db)
      {
        Name = "Battery";

        Field(x => x.Id);
        Field(x => x.TypeBuilding);
        Field(x => x.Status);
        Field(x => x.DateCommissioning, nullable: true);
        Field(x => x.DateLastInspection, nullable: true);
        Field(x => x.CertOpe);
        Field(x => x.BuildingId, nullable: true);
        Field<CustomerType>(
          "customer",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var building = _db.Buildings
                              .FirstOrDefault(i => i.Id == context.Source.BuildingId);
              var customer = _db.Customers.FirstOrDefault(i => i.Id == building.CustomerId);

              return customer;
        });
      Field<BuildingType>(
          "building",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var building = _db.Buildings
                              .FirstOrDefault(i => i.Id == context.Source.BuildingId);

              return building;
        });
      Field<ListGraphType<ColumnType>>(
        "columns",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var columns = _db.Columns
                            .Where(_=>_.BatteryId == context.Source.Id)
                            .ToListAsync();

            return columns;
      });
      } 
    }



    /////COLUMN TYPE /////////////////////

    public class ColumnType : ObjectGraphType<Column>
    {
      public ColumnType(cindy_okino_dbContext _db)
      {
        Name = "Column";

        Field(x => x.Id);
        Field(x => x.TypeBuilding);
        Field(x => x.AmountFloorsServed, nullable: true);
        Field(x => x.Status);
        Field(x => x.Information);
        Field(x => x.Notes);
        Field(x => x.BatteryId, nullable: true);
        Field<CustomerType>(
          "customer",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var battery = _db.Batteries
                              .FirstOrDefault(i => i.Id == context.Source.BatteryId);
              var customer = _db.Customers
                              .FirstOrDefault(i => i.Id == battery.Building.CustomerId);

              return customer;
        });
        Field<BatteryType>(
          "battery",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var battery = _db.Batteries
                              .FirstOrDefault(i => i.Id == context.Source.BatteryId);

              return battery;
        });
      Field<ListGraphType<ElevatorType>>(
        "elevators",

        arguments: 
            new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "id" }),

        resolve: context => 
        {
            
            var elevators = _db.Elevators
                            .Where(_=>_.ColumnId == context.Source.Id)
                            .ToListAsync();

            return elevators;
      });

      } 
    }

     ///// ELEVATOR TYPE ////////////////////



    public class ElevatorType : ObjectGraphType<Elevator>
    {
      public ElevatorType(cindy_okino_dbContext _db)
      {
        Name = "Elevator";

        Field(x => x.Id);
        Field(x => x.SerialNumber);
        Field(x => x.Model);
        Field(x => x.DateLastInspection, nullable: true);
        Field(x => x.DateCommissioning, nullable: true);
        Field(x => x.TypeBuilding);
        Field(x => x.Status);
        Field(x => x.CertOpe);
        Field(x => x.ColumnId, nullable: true);
        Field<CustomerType>(
          "customer",

          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var column = _db.Columns
                              .FirstOrDefault(i => i.Id == context.Source.ColumnId);
              var customer = _db.Customers
                              .FirstOrDefault(i => i.Id == column.Battery.Building.CustomerId);

              return customer;
        });
        Field<ColumnType>(
          "column",
          arguments: 
            new QueryArguments(
              new QueryArgument<IntGraphType> { Name = "id" }),

          resolve: context => 
          {
              var column = _db.Columns
                              .FirstOrDefault(i => i.Id == context.Source.ColumnId);

              return column;
        });

      } 
    }



}

