namespace AbpAngular.Companies
{
    public static class companyConsts
    {
        private const string DefaultSorting = "{0}CompanyName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "company." : string.Empty);
        }

    }
}