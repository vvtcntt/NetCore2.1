﻿using NetCore.Application.ViewModels.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Application.Interfaces
{
   public interface IFunctionService:IDisposable
    {
        void Add(FunctionViewModel function);
        List<FunctionViewModel> GetAllFunc();
        Task<List<FunctionViewModel>> GetAll(string filter);

        IEnumerable<FunctionViewModel> GetAllWithParentId(string parentId);

        FunctionViewModel GetById(string id);

        void Update(FunctionViewModel function);

        void Delete(string id);

        void Save();

        bool CheckExistedId(string id);

        void UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items);

        void ReOrder(string sourceId, string targetId);
    }
}
