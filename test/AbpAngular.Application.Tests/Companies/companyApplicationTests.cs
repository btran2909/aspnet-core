using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AbpAngular.Companies
{
    public class companiesAppServiceTests : AbpAngularApplicationTestBase
    {
        private readonly IcompaniesAppService _companiesAppService;
        private readonly IRepository<company, Guid> _companyRepository;

        public companiesAppServiceTests()
        {
            _companiesAppService = GetRequiredService<IcompaniesAppService>();
            _companyRepository = GetRequiredService<IRepository<company, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companiesAppService.GetListAsync(new GetcompaniesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("1640783d-0657-4ca9-bc0d-e1910e0fea58")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("335aa134-0500-4866-ae36-ca11b8df0ddc")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companiesAppService.GetAsync(Guid.Parse("1640783d-0657-4ca9-bc0d-e1910e0fea58"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("1640783d-0657-4ca9-bc0d-e1910e0fea58"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new companyCreateDto
            {
                CompanyName = "55383ce847d84b10b361987a1555c6785d323dabc213440ab6e785eae56e0fce80149e14f24",
                Description = "ea1b2b4575ec4a50abc56704fc"
            };

            // Act
            var serviceResult = await _companiesAppService.CreateAsync(input);

            // Assert
            var result = await _companyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyName.ShouldBe("55383ce847d84b10b361987a1555c6785d323dabc213440ab6e785eae56e0fce80149e14f24");
            result.Description.ShouldBe("ea1b2b4575ec4a50abc56704fc");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new companyUpdateDto()
            {
                CompanyName = "61cd86edd2564ba",
                Description = "6daa82c61fa4451eb1386b4e4fbe3d8bd0f79cb31b304a739acec5b359eebfb55a9e448f"
            };

            // Act
            var serviceResult = await _companiesAppService.UpdateAsync(Guid.Parse("1640783d-0657-4ca9-bc0d-e1910e0fea58"), input);

            // Assert
            var result = await _companyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyName.ShouldBe("61cd86edd2564ba");
            result.Description.ShouldBe("6daa82c61fa4451eb1386b4e4fbe3d8bd0f79cb31b304a739acec5b359eebfb55a9e448f");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companiesAppService.DeleteAsync(Guid.Parse("1640783d-0657-4ca9-bc0d-e1910e0fea58"));

            // Assert
            var result = await _companyRepository.FindAsync(c => c.Id == Guid.Parse("1640783d-0657-4ca9-bc0d-e1910e0fea58"));

            result.ShouldBeNull();
        }
    }
}