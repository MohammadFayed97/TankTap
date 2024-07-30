namespace TankTap.Stations.Infrastructure.Persistence;

public class TankTabDbContextSchema
{
    public const string DefaultSchema = "TankTap";
    public const string DefaultConnectionStringName = "TankTapContext";

    public class CitySchema
    {
        public const string TableName = "Cities";
    }
    public class PointOfSaleTypeSchema
    {
        public const string TableName = "PointOfSaleTypes";
    }
    public class ProductSchema
    {
        public const string TableName = "Products";
    }
    public class RegionSchema
    {
        public const string TableName = "Regions";
    }
    public class StationSchema
    {
        public const string TableName = "Stations";
        public const string TankTableName = "Tanks";
        public const string PumpTableName = "Pumps";
        public const string StationProductsTableName = "StationProducts";
        public const string Latitude = "Latitude";
        public const string Longitude = "Longitude";
        public const string CityIdForgienKey = "CityId";
        public const string CityForgienKeyConstrain = "Stations_Cities_CityId";
        public const string District = "District";
        public const string POSTableName = "StationPointOfSales";
        public const string POSTypeForginKey = "PointOfSaleTypeId";
        public const string POSTypeBackendField = "_pointOfSales";

    }
}
