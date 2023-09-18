using aspnet_boilerplate_mvc.DataAccess;
using aspnet_boilerplate_mvc.Repositories.AbstractionSettings;
using aspnet_boilerplate_mvc.Repositories.ApprovalStages;
using aspnet_boilerplate_mvc.Repositories.Areas;
using aspnet_boilerplate_mvc.Repositories.BankAccounts;
using aspnet_boilerplate_mvc.Repositories.Banks;
using aspnet_boilerplate_mvc.Repositories.Boreholes;
using aspnet_boilerplate_mvc.Repositories.Currencies;
using aspnet_boilerplate_mvc.Repositories.Documents;
using aspnet_boilerplate_mvc.Repositories.EmailQueues;
using aspnet_boilerplate_mvc.Repositories.ExchangeRates;
using aspnet_boilerplate_mvc.Repositories.Modules;
using aspnet_boilerplate_mvc.Repositories.OwnershipTypeDocuments;
using aspnet_boilerplate_mvc.Repositories.OwnershipTypes;
using aspnet_boilerplate_mvc.Repositories.Permissions;
using aspnet_boilerplate_mvc.Repositories.PermitCategories;
using aspnet_boilerplate_mvc.Repositories.Permits;
using aspnet_boilerplate_mvc.Repositories.PermitTypeDocumentExemptions;
using aspnet_boilerplate_mvc.Repositories.PermitTypeDocuments;
using aspnet_boilerplate_mvc.Repositories.PermitTypes;
using aspnet_boilerplate_mvc.Repositories.PropertyInformations;
using aspnet_boilerplate_mvc.Repositories.PropertyOwners;
using aspnet_boilerplate_mvc.Repositories.PropertyTypes;
using aspnet_boilerplate_mvc.Repositories.Purposes;
using aspnet_boilerplate_mvc.Repositories.Rainmonitors;
using aspnet_boilerplate_mvc.Repositories.Rainreadings;
using aspnet_boilerplate_mvc.Repositories.RiverbankreportImages;
using aspnet_boilerplate_mvc.Repositories.Riverbankreports;
using aspnet_boilerplate_mvc.Repositories.Riverbanks;
using aspnet_boilerplate_mvc.Repositories.RolePermissions;
using aspnet_boilerplate_mvc.Repositories.Roles;
using aspnet_boilerplate_mvc.Repositories.RoleUsers;
using aspnet_boilerplate_mvc.Repositories.Submodules;
using aspnet_boilerplate_mvc.Repositories.Suburbs;
using aspnet_boilerplate_mvc.Repositories.Uoms;
using aspnet_boilerplate_mvc.Repositories.Users;

namespace aspnet_boilerplate_mvc.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;  
            emailqueueRepository = new EmailqueueRepository(_context);
            roleUserRepository = new RoleUserRepository(_context);
            moduleRepository = new ModuleRepository(_context);  
            submoduleRepository = new SubmoduleRepository(_context);
            permissionRepository = new PermissionRepository(_context);
            rolePermissionRepository = new RolePermissionRepository(_context);
            roleRepository = new RoleRepository(_context);
            userRepository = new UserRepository(_context);
            currencyRepository = new CurrencyRepository(_context);
            approvalStageRepository = new ApprovalStageRepository(_context);
            areaRepository = new AreaRepository(_context);
            bankRepository = new BankRepository(_context);
            bankAccountRepository = new BankAccountRepository(_context);
            abstractionSettingRepository = new AbstractionSettingRepository(_context);
            boreholeRepository = new BoreholeRepository(_context);
            documentRepository = new DocumentRepository(_context);
            exchangeRateRepository = new ExchangeRateRepository(_context);
            ownershipTypeRepository = new OwnershipTypeRepository(_context);
            ownershipTypeDocumentRepository = new OwnershipTypeDocumentRepository(_context);    
            permitRepository = new PermitRepository(_context);
            permitTypeRepository = new PermitTypeRepository(_context);
            permitTypeDocumentRepository = new PermitTypeDocumentRepository(_context);
            permitTypeDocumentExemptionRepository = new PermitTypeDocumentExemptionRepository(_context);
            propertyInformationRepository = new PropertyInformationRepository(_context);
            propertyOwnerRepository = new PropertyOwnerRepository(_context);
            propertyTypeRepository = new PropertyTypeRepository(_context);
            purposeRepository = new PurposeRepository(_context);
            rainmonitorRepository = new RainmonitorRepository(_context);
            rainreadingRepository = new RainreadingRepository(_context);
            riverbankRepository = new RiverbankRepository(_context);
            riverbankreportRepository = new RiverbankreportRepository(_context);
            riverbankreportImageRepository = new RiverbankreportImageRepository(_context);
            suburbRepository = new SuburbRepository(_context);
            uomRepository = new UomRepository(_context);
            permitCategoryRepository = new PermitCategoryRepository(_context);
        }

        public IEmailqueueRepository emailqueueRepository { get; private set; }

        public IRoleUserRepository roleUserRepository { get; private set; }

        public IModuleRepository moduleRepository { get; private set; }

        public ISubmoduleRepository submoduleRepository { get; private set; }

        public IPermissionRepository permissionRepository { get; private set; }

        public IRolePermissionRepository rolePermissionRepository { get; private set; }

        public IRoleRepository roleRepository { get; private set; }

		public IUserRepository userRepository { get; private set; }
        public ICurrencyRepository currencyRepository { get; private set; }
        public IApprovalStageRepository approvalStageRepository { get; private set; }
        public IAreaRepository areaRepository { get; private set; }
        public IBankRepository bankRepository { get; private set; }
        public IBankAccountRepository bankAccountRepository { get; private set; }
        public IAbstractionSettingRepository abstractionSettingRepository { get; private set; }
        public IBoreholeRepository boreholeRepository { get; private set; }
        public IDocumentRepository documentRepository { get; private set; }
        public IExchangeRateRepository exchangeRateRepository { get; private set; }
        public IOwnershipTypeRepository ownershipTypeRepository { get; private set; }
        public IOwnershipTypeDocumentRepository ownershipTypeDocumentRepository { get; private set; }
        public IPermitRepository permitRepository { get; private set; }
        public IPermitTypeRepository permitTypeRepository { get; private set; }
        public IPermitTypeDocumentRepository permitTypeDocumentRepository { get; private set; }
        public IPermitTypeDocumentExemptionRepository permitTypeDocumentExemptionRepository { get; private set; }
        public IPropertyInformationRepository propertyInformationRepository { get; private set; }
        public IPropertyOwnerRepository propertyOwnerRepository { get; private set; }
        public IPropertyTypeRepository propertyTypeRepository { get; private set; }
        public IPurposeRepository purposeRepository { get; private set; }
        public IRainmonitorRepository rainmonitorRepository { get; private set; }
        public IRainreadingRepository rainreadingRepository { get; private set; }
        public IRiverbankRepository riverbankRepository { get; private set; }
        public IRiverbankreportRepository riverbankreportRepository { get; private set; }
        public IRiverbankreportImageRepository riverbankreportImageRepository { get; private set; }
        public ISuburbRepository suburbRepository { get; private set; }
        public IUomRepository uomRepository { get; private set; }
        public IPermitCategoryRepository permitCategoryRepository { get; private set; }
		public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
