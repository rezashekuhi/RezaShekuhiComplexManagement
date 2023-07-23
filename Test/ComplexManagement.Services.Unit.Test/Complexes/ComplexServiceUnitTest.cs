using ComplexManagement.Services.Complexes;
using ComplexManagement.Services.Complexes.Contracts;
using ComplexManagement.Services.Complexes.Dto;
using ComplexManagement.Services.Complexes.Exeptions;
using ComplexManagement.Services.Unit.Test.DataBaseConfig;
using ComplexManagement.Services.Unit.Test.DataBaseConfig.Units;
using ComplexManagement.Services.Unit.Test.Factory;
using ComplexManagment.Entities;
using ComplexManagment.Persistence.Ef;
using ComplexManagment.Persistence.Ef.Repositories.Blocks;
using ComplexManagment.Persistence.Ef.Repositories.Complexs;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace ComplexManagement.Services.Unit.Test.Complexes
{
    public class ComplexServiceUnitTest : BusinessUnitTest
    {
        private readonly ComplexService _Sut;
        public ComplexServiceUnitTest()
        {
            var repository = new EFComplexRepository(SetupContext);
            var blockRepository = new EFBlockRepository(SetupContext);
            var unitOfWork=new EfUnitOfWork(SetupContext);
            _Sut = new ComplexAppService(repository,blockRepository,unitOfWork);
        }

        [Fact]
        public void Add_add_complex_properly()
        {
            var dto = new AddComplexDto
            {
                Name="dummy",
                UnitCount=10,
            };

            _Sut.Add(dto);

            var expected=ReadContext.Set<Complex>().Single();
            expected.Name.Should().Be(dto.Name);
            expected.UnitCount.Should().Be(dto.UnitCount);
        }

        [Fact]
        public void Get_get_all_search_by_name()
        {
            var complex=new Complex()
            {
                Name = "dummy",
                UnitCount = 10,
            };
            DbContext.Save(complex);
            var complexId=complex.Id;
            var complexName=complex.Name;

            var result = _Sut.GetAllSearchByName(complexId,complexName);

            result.Single().Id.Should().Be(complex.Id);
            result.Single().Name.Should().Be(complex.Name);
        }

        [Fact]
        public void Delete_delete_complex_properly()
        {
            var complex = ComplexFactory.Create();
            DbContext.Save(complex);

            _Sut.Delete(complex.Id);

            ReadContext.Set<Complex>().Any().Should().BeFalse();
        
        }

        [Fact]
        public void Delete_throw_exception_when_complex_has_a_unit()
        {
            var complex=ComplexFactory.Create();
            var block = BlockFactory.Create(complex);
            var unit=UnitFactory.Create(block);
            DbContext.Save(unit);

            var expected=()=> _Sut.Delete(complex.Id);

            expected.Should().ThrowExactly<ThisComplexHasUnitsException>();
        }

        [Fact]
        public void Edite_edite_unit_count_complex_properly()
        {
            var complex= ComplexFactory.Create();
            DbContext.Save(complex);
            var unitCount = 60;

            _Sut.EditUnitcount(complex.Id, unitCount);

            var expected = ReadContext.Set<Complex>().Single();
            expected.Name.Should().Be(complex.Name);
            expected.UnitCount.Should().Be(unitCount);
        }

        [Fact]
        public void Edite_edite_unit_count_complex()
        {
            var complex = ComplexFactory.Create();
            DbContext.Save(complex);
            var unitCount = 40;
            var block=BlockFactory.Create(complex);
            block.UnitCount = 0;

            _Sut.EditUnitcount(complex.Id, unitCount);

            var expected = ReadContext.Set<Complex>().Single();
            expected.Name.Should().Be(complex.Name);
            expected.UnitCount.Should().Be(unitCount);
            
        }

        [Fact]
        public void Edit_throw_exception_when_Complex_Not_Found()
        {
            var invaliComplexId = 20;
            var unitCount = 20;

            var expected = () => _Sut.EditUnitcount(invaliComplexId,unitCount);

            expected.Should().ThrowExactly<ComplexNotFoundException>();
        }

        [Fact]
        public void Edit_throw_exception_when_complex_has_unit()
        {
            var complex = ComplexFactory.Create();
            var block = BlockFactory.Create(complex);
            var unit = UnitFactory.Create(block);
            DbContext.Save(unit);

            var expected = () => _Sut.Delete(complex.Id);

            expected.Should().ThrowExactly<ThisComplexHasUnitsException>();
        }

        [Fact]
        public void Get_get_complex_by_id()
        {
            var complex=ComplexFactory.Create();
            DbContext.Save(complex);

            var result=_Sut.FindById(complex.Id);

            result.Id.Should().Be(complex.Id);
            result.Name.Should().Be(complex.Name);
        }

        [Fact]
        public void Get_get_complex_by_id_with_blocks()
        {
            var complex= ComplexFactory.Create();
            var block= BlockFactory.Create(complex);
            DbContext.Save(block);

            var result=_Sut.GetComplexByIdWithBlocksDto(complex.Id);

            result.Id.Should().Be(complex.Id);
            result.Name.Should().Be(complex.Name);
            var resultBlock = result.Blocks.Single();
            resultBlock.BlockId.Should().Be(block.Id);
            resultBlock.BlockName.Should().Be(block.Name);

        }
    }
}
