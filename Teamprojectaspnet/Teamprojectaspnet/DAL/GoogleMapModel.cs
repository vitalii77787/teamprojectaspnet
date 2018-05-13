namespace Teamprojectaspnet.DAL
{
    using System.Data.Entity;
    using Teamprojectaspnet.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class GoogleMapModel : DbContext
    {
        // Your context has been configured to use a 'GoogleMapModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Teamprojectaspnet.DAL.GoogleMapModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GoogleMapModel' 
        // connection string in the application configuration file.
        public GoogleMapModel()
            : base("name=GoogleMapModel")
        {
          //  Database.SetInitializer(new DataBaseInitializer<GoogleMapModel>());
         // Database.SetInitializer<GoogleMapModel>(new DataBaseInitializer<GoogleMapModel>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<LoginStatus> LoginStatuses { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<MarkerType> MarkerTypes { get; set; }
        public virtual DbSet<Marker> Markers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

       // public System.Data.Entity.DbSet<Teamprojectaspnet.Models.MarkerModel> MarkerModels { get; set; }
    }
}