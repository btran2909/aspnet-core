using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using AbpAngular.Companies;

namespace AbpAngular.Companies
{
    public class companiesDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IcompanyRepository _companyRepository;

        public companiesDataSeedContributor(IcompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _companyRepository.InsertAsync(new company
            (
                id: Guid.Parse("1640783d-0657-4ca9-bc0d-e1910e0fea58"),
                companyName: "061fcab2938444f58d539d9961067f6b96374f530cfa4aab9abedf0",
                description: "328a1e5982e9486c8a6424b067371c7e6695be15cfd343149c2a445cdec0512a2ac2ef43496a4b4ca"
            ));

            await _companyRepository.InsertAsync(new company
            (
                id: Guid.Parse("335aa134-0500-4866-ae36-ca11b8df0ddc"),
                companyName: "306b56f8cff",
                description: "22667945ebfc4becb156cc7922fe981248412394a37e459b914b2cd1b44d8f09c1"
            ));
        }
    }
}