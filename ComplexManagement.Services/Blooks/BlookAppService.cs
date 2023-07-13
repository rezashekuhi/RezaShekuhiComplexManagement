using ComplexManagement.Services.Blooks.Dto;
using ComplexManagement.Services.Complexes;
using ComplexManagement.Services.units;
using ComplexManagement.Services.units.Dto;
using ComplexManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement.Services.Blooks.Contract
{
    public class BlookAppService : BlookService
    {
        private readonly ComplexRepository _complexRepository;
        private readonly BlockRepository _blockRepository;
        private readonly UnitRepository _unitRepository;
        private readonly UnitOfWork _unitOfWork;

        public BlookAppService(
            ComplexRepository complexRepository,
            BlockRepository blockRepository,
            UnitRepository unitRepository,
            UnitOfWork unitOfWork)
        {
            _complexRepository = complexRepository;
            _blockRepository = blockRepository;
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddBlockDto dto)
        {
            var isExistsComplex = _complexRepository.IsExistsById(dto.ComplexId);
            if (!isExistsComplex)
            {
                throw new Exception("complex not found");
            }

            var isDuplicateBlockName = _blockRepository
                .IsDuplicateNameByComplexId(dto.Name, dto.ComplexId);
            if (isDuplicateBlockName)
            {
                throw new Exception("name duplicate");
            }

            var totalBlockUnitCount = _blockRepository
                .GetTotalUnitCountByComplexId(dto.ComplexId);
            var complexUnitCount = _complexRepository
                .GetUnitCountById(dto.ComplexId);
            if (totalBlockUnitCount + dto.UnitCount > complexUnitCount)
            {
                throw new Exception("totalBlockUnitCount");
            }

            var block = new Blook()
            {
                ComplexId = dto.ComplexId,
                Name = dto.Name,
                UnitCount = dto.UnitCount
            };

            _blockRepository.Add(block);
            _unitOfWork.Complit();
        }

        public void AddBlockAndUnitRegistration(AddBlockAndUnitRegistrationDto dto)
        {
            var isExistsComplex = _complexRepository.IsExistsById(dto.ComplexId);
            if (!isExistsComplex)
            {
                throw new Exception("complex not found");
            }

            var isDuplicateBlockName = _blockRepository
                .IsDuplicateNameByComplexId(dto.Name, dto.ComplexId);
            if (isDuplicateBlockName)
            {
                throw new Exception("name duplicate");
            }

            var totalBlockUnitCount = _blockRepository
                .GetTotalUnitCountByComplexId(dto.ComplexId);
            var complexUnitCount = _complexRepository
                .GetUnitCountById(dto.ComplexId);
            if (totalBlockUnitCount + dto.UnitCount > complexUnitCount)
            {
                throw new Exception("totalBlockUnitCount");
            }

            var Blook = new Blook()
            {
                ComplexId = dto.ComplexId,
                Name = dto.Name,
                UnitCount = dto.UnitCount

            };
            var units = dto.Units.Select(_ => new Unit
            {
                Blook = Blook,
                Name = _.UnitName,
                Resident = _.Resident

            }).ToHashSet();
                
            
            _blockRepository.AddBlockAndUnitRegistration(Blook,units);
            _unitOfWork.Complit();
            
        }

        public void EditeBlookById(int id, UpdateBlockDto dto)
        {
            var block = _blockRepository.FindById(id);

            if (block == null)
            {
                throw new Exception("block not found");
            }

            var isDuplicateBlockName = _blockRepository
                .IsDuplicateNameByComplexId(block.Id, dto.Name, block.ComplexId);
            if (isDuplicateBlockName)
            {
                throw new Exception("name duplicate");
            }

            var isExistUnit = _unitRepository.IsExistsByBlockId(block.Id);

            if (isExistUnit)
            {
                var totalBlockUnitCount = _blockRepository
                    .GetTotalUnitCountByComplexIdWithOutThisBlockId(
                        block.Id,
                        block.ComplexId);
                var complexUnitCount = _complexRepository
                    .GetUnitCountById(block.ComplexId);
                if (totalBlockUnitCount + dto.UnitCount > complexUnitCount)
                {
                    throw new Exception("totalBlockUnitCount");
                }
                block.UnitCount = dto.UnitCount;
            }

            block.Name = dto.Name;

            _blockRepository.Update(block);
            _unitOfWork.Complit();
        }

        public List<GetAllBlookDto> GetAll()
        {
            return _blockRepository.GetAllBlook();
        }
    }
}
