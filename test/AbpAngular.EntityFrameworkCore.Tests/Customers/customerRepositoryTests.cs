using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using AbpAngular.Customers;
using AbpAngular.EntityFrameworkCore;
using Xunit;

namespace AbpAngular.Customers
{
    public class customerRepositoryTests : AbpAngularEntityFrameworkCoreTestBase
    {
        private readonly IcustomerRepository _customerRepository;

        public customerRepositoryTests()
        {
            _customerRepository = GetRequiredService<IcustomerRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _customerRepository.GetListAsync(
                    licenseNo: "d4cfa64fe1fd41c3903c894c38c9769e4335c63d9c2e43ebb7e6dc618192ba4a9e0527f2",
                    address: "bde6cec324904c2792cb39f8b2",
                    city: "50a0d7baf27d419882777e3e9bc13d78701dc1d68f444",
                    zipCode: "55c89ba4beb442198cb5116ea4481",
                    country: "05d0a29ff73947bda30acc28dda9b214650a5eaf554f42178bcd952a1bc3c9ffe801fb37501044ddb3c4dae50d6a60d4da",
                    email: "951de579fafc4065b72c13@a5568d46355d490da30ffd.com",
                    website: "c43d6a8f8496425fafee610fec7ddbb",
                    telephone: "5ebc502aae9146f0b3aa6e70c0d0eb3e986ce2020fdf4595954da54f7f8cb0a69"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("445b88d4-9793-4011-b8e5-4876e2584ffa"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _customerRepository.GetCountAsync(
                    licenseNo: "1964b84e7e9a434f94c1f283ba6e5a4e47958bc85c684d24bd421702e9f56305666afd389e804096a92fdb14a2f9d3",
                    address: "8b3c14fa680b4067907441e529ce140177ea74dec4c04b2ba6c250f41975e1d0b9e332af80",
                    city: "cbfcfb85aa5b44ecaf9051758a94facb3229ebb92d7d4fb2aa253e860019d48e3d89653a50c34da7a8fce83a6f196bbd",
                    zipCode: "ddf6ed4ba3b246e998b06",
                    country: "2b9ed180c9f",
                    email: "1029f98acd8644adbdd4d@1bddd64cd0bb476b86a6d.com",
                    website: "cba09b3d1e",
                    telephone: "51df372dd6ad4e3e97e474760ed178ad23936f93ae3f4fc7a10142aaad6f674d7842430945e0"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}