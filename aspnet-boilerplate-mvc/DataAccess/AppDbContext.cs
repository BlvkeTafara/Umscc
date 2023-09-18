using aspnet_boilerplate_mvc.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace aspnet_boilerplate_mvc.DataAccess
{
    public class AppDbContext: IdentityDbContext    
    {
        private readonly string _username;
        public AppDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            if (httpContextAccessor.HttpContext != null)
            {
                var claimsPrincipal = httpContextAccessor.HttpContext.User;
                _username = "Unauthenticated User";
                if (claimsPrincipal != null && claimsPrincipal.Identity.IsAuthenticated)
                {
                    _username = claimsPrincipal.Identity.Name;
                }
            }
            else
            {
                _username = "Unauthenticated User";
            }
        }

        public DbSet<Module> Modules { get; set; }  
        public DbSet<Submodule> Submodules { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<Emailqueue> emailqueues { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<Document> documents { get; set; }

        public DbSet<PermitTypeDocument> permitTypeDocuments { get; set; }

        public DbSet<PermitTypeDocumentExemption> permitTypeDocumentExemptions { get; set; }

        public DbSet<Uom> uoms { get; set; }

        public DbSet<Purpose> purposes { get; set; }

        public DbSet<AbstractionSetting> abstractionsetting { get; set; }

        public DbSet<PermitAction> permitactions { get; set; }
        public DbSet<Suburb> suburbs { get; set; }

        public DbSet<PropertyType> propertytypes { get; set; }

        public DbSet<OwnershipType> ownershiptypes { get; set; }

        public DbSet<OwnershipTypeDocument> ownershipTypeDocuments { get; set; }
        public DbSet<PropertyOwner> propertyowners { get; set; }

        public DbSet<PropertyInformation> propertyinformation { get; set; }
        public DbSet<Sourcetype> sourcetypes { get; set; }

        public DbSet<Watersource> watersources { get; set; }

        public DbSet<Watersourcereading> watersourcereadings { get; set; }

        public DbSet<Rainmonitor> rainmonitors { get; set; }

        public DbSet<Rainreading> rainreadings { get; set; }

        public DbSet<Wetland> wetlands { get; set; }

        public DbSet<Wetlandreport> wetlandreports { get; set; }

        public DbSet<WetlandreportImage> wetlandreportImages { get; set; }
        public DbSet<Riverbank> riverbanks { get; set; }

        public DbSet<Riverbankreport> riverbankreports { get; set; }

        public DbSet<RiverbankreportImage> riverbankreportImages { get; set; }

        public DbSet<Permit> permits { get; set; }
        public DbSet<Borehole> boreholes { get; set; }
        public DbSet<PermitCategory> permitCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roles = new List<Role>
            {
                new Role
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Id = "687ec51e-073a-4bb7-b586-e6c10eb7963a",
                    ConcurrencyStamp = "687ec51e-073a-4bb7-b586-e6c10eb7963a"
                },
                new Role
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN",
                    Id = "46a827df-6b02-4344-8197-bb7e23731f5c",
                    ConcurrencyStamp = "46a827df-6b02-4344-8197-bb7e23731f5c"
                }
            };

            builder.Entity<Role>().HasData(roles);

            var SuperAdminUser = new User
            {
                UserName = "superadmin@anixsys.co.zw",
                Name = "Super",
                Surname = "Admin",
                Gender = "M",
                Enabled = true,
                Email = "superadmin@anixsys.co.zw",
                NormalizedEmail = "superadmin@anixsys.co.zw".ToUpper(),
                NormalizedUserName = "superadmin@anixsys.co.zw".ToUpper(),
                Id = "18250bc5-dc10-4a75-89ba-74a0631225fa"
            };
            SuperAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(SuperAdminUser, "Superadmin@123");
            builder.Entity<User>().HasData(SuperAdminUser);

            var superadminroles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId="687ec51e-073a-4bb7-b586-e6c10eb7963a",
                    UserId="18250bc5-dc10-4a75-89ba-74a0631225fa"
                },
                new IdentityUserRole<string>
                {
                    RoleId="46a827df-6b02-4344-8197-bb7e23731f5c",
                    UserId="18250bc5-dc10-4a75-89ba-74a0631225fa"
                }
            };
            builder.Entity<AuditEntry>().Property(a => a.Changes).HasConversion(value => JsonConvert.SerializeObject(value),
                                                                            serializedValue => JsonConvert.DeserializeObject<Dictionary<string, object>>(serializedValue));
        }
       


    }
}
