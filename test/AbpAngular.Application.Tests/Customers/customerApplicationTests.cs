using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AbpAngular.Customers
{
    public class customersAppServiceTests : AbpAngularApplicationTestBase
    {
        private readonly IcustomersAppService _customersAppService;
        private readonly IRepository<customer, Guid> _customerRepository;

        public customersAppServiceTests()
        {
            _customersAppService = GetRequiredService<IcustomersAppService>();
            _customerRepository = GetRequiredService<IRepository<customer, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _customersAppService.GetListAsync(new GetcustomersInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("445b88d4-9793-4011-b8e5-4876e2584ffa")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("3488c753-819b-4a61-89c1-c452b5ec4798")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _customersAppService.GetAsync(Guid.Parse("445b88d4-9793-4011-b8e5-4876e2584ffa"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("445b88d4-9793-4011-b8e5-4876e2584ffa"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new customerCreateDto
            {
                LicenseNo = "88e62c15687541e2bca6f985410046e166b648104c7c4d0793a8f9d0a8",
                LicenseExpired = new DateTime(2015, 10, 13),
                Address = "e8a608ed373a489ca7b3f7c5be6b7dd3f25e2f3da9cd4ab7819e0a439074cfc4a9f397516a",
                City = "731dd1a127aa445e92dd",
                ZipCode = "53c27dcc33db4ca1996e61929e5125172199bc0c963449678553ee96b74f2ae987396dccdfc6410b995c4480",
                Country = "b40878c5877249f1879f5ab6ad2bf823f1216d55c204410aabbca63af",
                Email = "9742010e6bb243@10e284a433984b.com",
                Website = "a0a7312ca04842d9aa18910f36acd8d906311561f62b4f108f09b0dea596d8b3cb",
                Telephone = "3a96045e60be4361aa6b4ea044f"
            };

            // Act
            var serviceResult = await _customersAppService.CreateAsync(input);

            // Assert
            var result = await _customerRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.LicenseNo.ShouldBe("88e62c15687541e2bca6f985410046e166b648104c7c4d0793a8f9d0a8");
            result.LicenseExpired.ShouldBe(new DateTime(2015, 10, 13));
            result.Address.ShouldBe("e8a608ed373a489ca7b3f7c5be6b7dd3f25e2f3da9cd4ab7819e0a439074cfc4a9f397516a");
            result.City.ShouldBe("731dd1a127aa445e92dd");
            result.ZipCode.ShouldBe("53c27dcc33db4ca1996e61929e5125172199bc0c963449678553ee96b74f2ae987396dccdfc6410b995c4480");
            result.Country.ShouldBe("b40878c5877249f1879f5ab6ad2bf823f1216d55c204410aabbca63af");
            result.Email.ShouldBe("9742010e6bb243@10e284a433984b.com");
            result.Website.ShouldBe("a0a7312ca04842d9aa18910f36acd8d906311561f62b4f108f09b0dea596d8b3cb");
            result.Telephone.ShouldBe("3a96045e60be4361aa6b4ea044f");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new customerUpdateDto()
            {
                LicenseNo = "14f32ca8898f4b459e4cb68e24256a414f848fa9333e4b53911072e23af81bff52b9fe2133834f6b",
                LicenseExpired = new DateTime(2012, 3, 11),
                Address = "6ca6e2",
                City = "9f1a19025f8b4e9da0b3ed63b62423aea6893d",
                ZipCode = "6edf73e339f4",
                Country = "0de67e8102",
                Email = "678118e9006b422ca27cf3f44c97372f9be1a97cce79@e3ed87415020455cbe1a068642f6210440e8a0b6c3ad.com",
                Website = "28c685f63d1c43a4",
                Telephone = "134d75619c094ccdae5e932ac9ed7fcaa2ec03b"
            };

            // Act
            var serviceResult = await _customersAppService.UpdateAsync(Guid.Parse("445b88d4-9793-4011-b8e5-4876e2584ffa"), input);

            // Assert
            var result = await _customerRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.LicenseNo.ShouldBe("14f32ca8898f4b459e4cb68e24256a414f848fa9333e4b53911072e23af81bff52b9fe2133834f6b");
            result.LicenseExpired.ShouldBe(new DateTime(2012, 3, 11));
            result.Address.ShouldBe("6ca6e2");
            result.City.ShouldBe("9f1a19025f8b4e9da0b3ed63b62423aea6893d");
            result.ZipCode.ShouldBe("6edf73e339f4");
            result.Country.ShouldBe("0de67e8102");
            result.Email.ShouldBe("678118e9006b422ca27cf3f44c97372f9be1a97cce79@e3ed87415020455cbe1a068642f6210440e8a0b6c3ad.com");
            result.Website.ShouldBe("28c685f63d1c43a4");
            result.Telephone.ShouldBe("134d75619c094ccdae5e932ac9ed7fcaa2ec03b");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _customersAppService.DeleteAsync(Guid.Parse("445b88d4-9793-4011-b8e5-4876e2584ffa"));

            // Assert
            var result = await _customerRepository.FindAsync(c => c.Id == Guid.Parse("445b88d4-9793-4011-b8e5-4876e2584ffa"));

            result.ShouldBeNull();
        }
    }
}