namespace AbpAngular.Customers
{
    public static class customerConsts
    {
        private const string DefaultSorting = "{0}LicenseNo asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "customer." : string.Empty);
        }

    }
}