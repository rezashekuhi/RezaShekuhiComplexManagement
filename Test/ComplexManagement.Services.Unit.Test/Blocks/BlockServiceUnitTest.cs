using ComplexManagement.Services.Blooks.Contract;
using ComplexManagement.Services.Blooks.Dto;
using ComplexManagement.Services.Blooks.Exeptions;
using ComplexManagement.Services.Complexes.Exeptions;
using ComplexManagement.Services.Unit.Test.DataBaseConfig;
using ComplexManagement.Services.Unit.Test.DataBaseConfig.Units;
using ComplexManagement.Services.Unit.Test.Factory;
using ComplexManagment.Entities;
using ComplexManagment.Persistence.Ef;
using ComplexManagment.Persistence.Ef.Repositories.Blocks;
using ComplexManagment.Persistence.Ef.Repositories.Complexs;
using ComplexManagment.Persistence.Ef.Repositories.Units;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace ComplexManagement.Services.Unit.Test.Blocks
{
    public class BlockServiceUnitTest : BusinessUnitTest
    {
        private readonly BlookService _Sut;
        public BlockServiceUnitTest()
        {
            var repository = new EFBlockRepository(SetupContext);
            var complexRepository = new EFComplexRepository(SetupContext);
            var unitRepository = new EFUnitRepository(SetupContext);
            var unitOfWork = new EfUnitOfWork(SetupContext);
            _Sut = new BlookAppService(complexRepository, repository,unitRepository,unitOfWork);
        }

        [Fact]
        public void Add_add_block_properly()
        {
            var complex=ComplexFactory.Create();
            DbContext.Save(complex);
            var dto = new AddBlockDto
            {
                Name = "b1",
                UnitCount = 10,
                ComplexId=complex.Id
            };

            _Sut.Add(dto);

            var expected = ReadContext.Set<Blook>().Single();
            expected.ComplexId.Should().Be(dto.ComplexId);
            expected.Name.Should().Be(dto.Name);
            expected.UnitCount.Should().Be(dto.UnitCount);

        }

        [Fact]
        public void Add_add_throw_exception_when_complex_id_not_found()
        {
            var invalidBlockId = -1;
            var dto = new AddBlockDto
            {
                Name = "dummy",
                UnitCount = 10,
                ComplexId= invalidBlockId
            };

            var expected = () => _Sut.Add(dto);

            expected.Should().ThrowExactly<ComplexNotFoundException>();
        }

        [Fact]
        public void Add_check_block_unit_count_exception()
        {
            var complex = ComplexFactory.Create();
            var block1 = BlockFactory.Create(complex);
            block1.UnitCount = 50;
            DbContext.Save(block1);
            var dto = new AddBlockDto
            {
                Name = "dummy2",
                UnitCount = 10,
                ComplexId = complex.Id
            };

            var expected=()=> _Sut.Add(dto);

            expected.Should().ThrowExactly<TheNumberOfBlockUnitsIsMoreThanTheLimitException>();

        }

        [Fact]
        public void Add_block_is_duplicate_Name()
        {
            var complex=ComplexFactory.Create();
            var block = BlockFactory.Create(complex);
            DbContext.Save(block);
            var dto = new AddBlockDto
            {
                Name = "dummy",
                UnitCount = 2,
                ComplexId = complex.Id
            };

            var expected=()=> _Sut.Add(dto);

            expected.Should().ThrowExactly<NameDuplicateException>();
        }

        [Fact]
        public void Get_get_all_block_properly()
        {
            var complex = ComplexFactory.Create();
            var block = BlockFactory.Create(complex);
            DbContext.Save(block);

            var result = _Sut.GetAll();

            result.Single().Id.Should().Be(block.Id);
            result.Single().Name.Should().Be(block.Name);
            result.Single().UnitCount.Should().Be(block.UnitCount);
        }
    }
}
