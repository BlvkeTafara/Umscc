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
    public interface IUnitOfWork:IDisposable
    {

        IEmailqueueRepository emailqueueRepository { get; }
        IRoleUserRepository roleUserRepository { get; }
        IModuleRepository moduleRepository { get; }
        ISubmoduleRepository submoduleRepository { get; }
        IPermissionRepository permissionRepository { get; }
        IRolePermissionRepository rolePermissionRepository { get; }
        IRoleRepository roleRepository { get; }
        IUserRepository userRepository { get; }
        ICurrencyRepository currencyRepository { get; }
        IApprovalStageRepository approvalStageRepository { get; }
        IAreaRepository areaRepository { get; }
        IBankRepository bankRepository { get; }
        IBankAccountRepository bankAccountRepository { get; }
        IAbstractionSettingRepository abstractionSettingRepository { get; }
        IBoreholeRepository boreholeRepository { get; }
        IDocumentRepository documentRepository { get; }
        IExchangeRateRepository exchangeRateRepository { get; }
        IOwnershipTypeRepository ownershipTypeRepository { get; }
        IOwnershipTypeDocumentRepository ownershipTypeDocumentRepository { get; }
        IPermitRepository permitRepository { get; }
        IPermitTypeRepository permitTypeRepository { get; }
        IPermitTypeDocumentRepository permitTypeDocumentRepository { get; }
        IPermitTypeDocumentExemptionRepository permitTypeDocumentExemptionRepository { get; }
        IPropertyInformationRepository propertyInformationRepository { get; }
        IPropertyOwnerRepository propertyOwnerRepository { get; }
        IPropertyTypeRepository propertyTypeRepository { get; }
        IPurposeRepository purposeRepository { get; }
        IRainmonitorRepository rainmonitorRepository { get; }
        IRainreadingRepository rainreadingRepository { get; }
        IRiverbankRepository riverbankRepository { get; }
        IRiverbankreportRepository riverbankreportRepository { get; }
        IRiverbankreportImageRepository riverbankreportImageRepository { get; }
        IPermitCategoryRepository permitCategoryRepository { get; }
        ISuburbRepository suburbRepository { get; }
        IUomRepository uomRepository { get; }
        Task<int> Save();
    }
}
