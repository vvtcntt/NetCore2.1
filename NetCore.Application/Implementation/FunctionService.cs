using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NetCore.Application.Interfaces;
using NetCore.Application.ViewModels.System;
using NetCore.Data.Entites;
using NetCore.Data.Enums;
using NetCore.Data.IRepositories;
using NetCore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Application.Implementation
{
    public class FunctionService : IFunctionService
    {
        private IFunctionRepository _functionRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IPermissionRepository _permissionRepository;
        private IRoleService _roleService;

        public FunctionService(IMapper mapper,
            IFunctionRepository functionRepository,
            IUnitOfWork unitOfWork, IPermissionRepository permissionRepository, IRoleService roleService)
        {
            _functionRepository = functionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _permissionRepository = permissionRepository;
            _roleService = roleService;
        }


        public bool CheckExistedId(string id)
        {
            return _functionRepository.FindById(id) != null;
        }

        public void Add(FunctionViewModel functionVm)
        {
            var function = _mapper.Map<Function>(functionVm);
            _functionRepository.Add(function);
        }

        public void Delete(string id)
        {
            _functionRepository.Remove(id);
        }

        public FunctionViewModel GetById(string id)
        {
            var function = _functionRepository.FindSingle(x => x.Id == id);
            return Mapper.Map<Function, FunctionViewModel>(function);
        }

        public Task<List<FunctionViewModel>> GetAll(string filter)
        {
            var query = _functionRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter));
            return query.OrderBy(x => x.ParentId).ProjectTo<FunctionViewModel>().ToListAsync();
        }

        public IEnumerable<FunctionViewModel> GetAllWithParentId(string parentId)
        {
            return _functionRepository.FindAll(x => x.ParentId == parentId).ProjectTo<FunctionViewModel>();
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(FunctionViewModel functionViewModel)
        {
            var function = Mapper.Map<FunctionViewModel, Function>(functionViewModel);
            _functionRepository.Update(function);
        }

        public void ReOrder(string sourceId, string targetId)
        {

            var source = _functionRepository.FindById(sourceId);
            var target = _functionRepository.FindById(targetId);
            int tempOrder = source.SortOrder;

            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _functionRepository.Update(source);
            _functionRepository.Update(target);

        }

        public void UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items)
        {
            //Update parent id for source
            var category = _functionRepository.FindById(sourceId);
            category.ParentId = targetId;
            _functionRepository.Update(category);

            //Get all sibling
            var sibling = _functionRepository.FindAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _functionRepository.Update(child);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<FunctionViewModel> GetAllFunc()
        {
             return _functionRepository.FindAll().OrderBy(x => x.ParentId).ProjectTo<FunctionViewModel>().ToList();
        }

        public Task<List<FunctionViewModel>> GetAllByRole(string roleId)
        {
             var permison = _permissionRepository.FindAll(x => x.RoleId.ToString() == roleId && x.CanRead==true).Select(x=>x.FunctionId).ToList();
            var query = _functionRepository.FindAll(x => permison.Contains(x.Id));
           
            return query.OrderBy(x => x.ParentId).ProjectTo<FunctionViewModel>().ToListAsync();
        }
    }
}
