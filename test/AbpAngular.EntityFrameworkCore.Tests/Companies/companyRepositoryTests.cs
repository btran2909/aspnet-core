using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using AbpAngular.Companies;
using AbpAngular.EntityFrameworkCore;
using Xunit;

namespace AbpAngular.Companies
{
    public class companyRepositoryTests : AbpAngularEntityFrameworkCoreTestBase
    {
        private readonly IcompanyRepository _companyRepository;

        public companyRepositoryTests()
        {
            _companyRepository = GetRequiredService<IcompanyRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyRepository.GetListAsync(
                    companyName: "061fcab2938444f58d539d9961067f6b96374f530cfa4aab9abedf0",
                    description: "328a1e5982e9486c8a6424b067371c7e6695be15cfd343149c2a445cdec0512a2ac2ef43496a4b4ca"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("1640783d-0657-4ca9-bc0d-e1910e0fea58"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyRepository.GetCountAsync(
                    companyName: "306b56f8cff",
                    description: "22667945ebfc4becb156cc7922fe981248412394a37e459b914b2cd1b44d8f09c1"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}