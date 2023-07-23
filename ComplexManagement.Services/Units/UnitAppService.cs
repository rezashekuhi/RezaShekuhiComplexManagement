using ComplexManagement.Services.Blooks;
using ComplexManagement.Services.units.Dto;
using ComplexManagement.Services.Units.Exeptions;
using ComplexManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement.Services.units.Contact
{
    public class UnitAppService : UnitService
    {

        private readonly UnitRepository _unitRepository;
        private readonly BlockRepository _blockRepository;
        private readonly UnitOfWork _unitOfWork;

        public UnitAppService(UnitRepository unitRepository,
            BlockRepository blockRepository,
            UnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _blockRepository = blockRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddUnitDto dto)
        {
            var isExistBlockId = _blockRepository.CheckBlookId(dto.BlookId);
            if (!isExistBlockId)
            {
                throw new BlockNotFoundException();
            }

            var duplicateUnitName = _unitRepository.CheckDuplicateUnitNameAndId(dto.Name, dto.BlookId);
            if (duplicateUnitName)
            {
                throw new UnitNameDuplicateException();
            }

            var blockUnitCount = _unitRepository.GetBlockUnitCount(dto.BlookId);
            var totalUnitInBlock = _unitRepository.TotalUnitInBlock(dto.BlookId);

            if (totalUnitInBlock == blockUnitCount)
            {
                throw new UnitCountException();
            }

            var unit = new Unit()
            {
                Name = dto.Name,
                BlookId = dto.BlookId,
                Resident = dto.Resident
            };

            _unitRepository.AddUnit(unit);
            _unitOfWork.Complit();
        }
    }
}
