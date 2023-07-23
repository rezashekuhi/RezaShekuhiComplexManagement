using ComplexManagement.Services.Unit.Test.DataBaseConfig;
using ComplexManagement.Services.Unit.Test.DataBaseConfig.Units;
using ComplexManagement.Services.Unit.Test.Factory;
using ComplexManagement.Services.units.Contact;
using ComplexManagement.Services.units.Dto;
using ComplexManagement.Services.Units.Exeptions;
using ComplexManagment.Entities;
using ComplexManagment.Persistence.Ef;
using ComplexManagment.Persistence.Ef.Repositories.Blocks;
using ComplexManagment.Persistence.Ef.Repositories.Units;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace ComplexManagement.Services.Unit.Test.Units
{
    public class UnitServiceUnitTest : BusinessUnitTest
    {
        private readonly UnitService _Sut;
        public UnitServiceUnitTest()
        {
            var repository = new EFUnitRepository(SetupContext);
            var unitOfWork = new EfUnitOfWork(SetupContext);
            var blockRepository = new EFBlockRepository(SetupContext);
            _Sut = new UnitAppService(repository, blockRepository , unitOfWork);
        }

        [Theory]
        [InlineData(UnitType.khali)]
        [InlineData(UnitType.malek)]
        [InlineData(UnitType.mostager)]
        public void Add_add_unit_properly(UnitType type)
        {
            var complex = ComplexFactory.Create();
            DbContext.Save(complex);
            var block = BlockFactory.Create(complex);
            DbContext.Save(block);
            var dto = new AddUnitDto
            {
                Name = "dummy",
                Resident = type,
                BlookId = block.Id
            };
           
            _Sut.Add(dto);
            
            var expected = ReadContext.Set<ComplexManagment.Entities.Unit>().Single();
            expected.Name.Should().Be(dto.Name);
            expected.Resident.Should().Be(dto.Resident);
            expected.BlookId.Should().Be(dto.BlookId);

        }

        [Fact]
        public void Add_throw_exception_when_block_id_not_found()
        {
            var invalidBlockId = -1;
            var complex=ComplexFactory.Create();
            var block = BlockFactory.Create(complex);
            var dto = new AddUnitDto
            {
                Name = "dummy",
                Resident = UnitType.mostager,
                BlookId = invalidBlockId
            };

           var expected=()=> _Sut.Add(dto);

            expected.Should().ThrowExactly<BlockNotFoundException>();
        }

        [Fact]
        public void Add_throw_exception_when_unit_name_is_duplicate()
        {
            var complex = ComplexFactory.Create();
            var block=BlockFactory.Create(complex);
            var unit=UnitFactory.Create(block);
            DbContext.Save(unit);
            var dto = new AddUnitDto
            {
                Name="dummy",
                Resident=UnitType.mostager,
                BlookId=block.Id
            };

           var expected=()=> _Sut.Add(dto);

            expected.Should().ThrowExactly<UnitNameDuplicateException>();
        }

        [Fact]
        public void Add_throw_exception_when_()
        {
            var complex = ComplexFactory.Create();
            var block = BlockFactory.Create(complex);
            block.UnitCount = 1;
            var unit = UnitFactory.Create(block);
            DbContext.Save(unit);
            var dto = new AddUnitDto
            {
                Name = "dummyy",
                Resident = UnitType.mostager,
                BlookId = block.Id
            };
           
            var expected = () => _Sut.Add(dto);

            expected.Should().ThrowExactly<UnitCountException>();
        }

    }
}
