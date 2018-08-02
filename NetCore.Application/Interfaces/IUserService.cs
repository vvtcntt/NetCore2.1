﻿using NetCore.Application.ViewModels.System;
using NetCore.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(AppUserViewModel userVm);

        Task DeleteAsync(string id);

        Task<List<AppUserViewModel>> GetAllAsync();

        PagedResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppUserViewModel> GetById(string id);

        Task UpdateAsync(AppUserViewModel userVm);
    }
}
