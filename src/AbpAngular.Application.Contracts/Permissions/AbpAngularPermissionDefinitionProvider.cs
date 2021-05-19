using AbpAngular.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace AbpAngular.Permissions
{
    public class AbpAngularPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpAngularPermissions.GroupName);

            myGroup.AddPermission(AbpAngularPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(AbpAngularPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpAngularPermissions.MyPermission1, L("Permission:MyPermission1"));

            var companyPermission = myGroup.AddPermission(AbpAngularPermissions.companies.Default, L("Permission:companies"));
            companyPermission.AddChild(AbpAngularPermissions.companies.Create, L("Permission:Create"));
            companyPermission.AddChild(AbpAngularPermissions.companies.Edit, L("Permission:Edit"));
            companyPermission.AddChild(AbpAngularPermissions.companies.Delete, L("Permission:Delete"));

            var customerPermission = myGroup.AddPermission(AbpAngularPermissions.customers.Default, L("Permission:customers"));
            customerPermission.AddChild(AbpAngularPermissions.customers.Create, L("Permission:Create"));
            customerPermission.AddChild(AbpAngularPermissions.customers.Edit, L("Permission:Edit"));
            customerPermission.AddChild(AbpAngularPermissions.customers.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpAngularResource>(name);
        }
    }
}