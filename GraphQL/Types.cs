using GraphQL_API.Entities;
using GraphQL.Types;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

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

  ///////BUILDING TYPE///////////////////

  public class BuildingType : ObjectGraphType<Building>
  {
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
    public CustomerType()
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

}

