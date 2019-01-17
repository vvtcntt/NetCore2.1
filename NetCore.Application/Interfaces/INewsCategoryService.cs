using NetCore.Application.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.Interfaces
{
    public interface INewsCategoryService
    {
        NewsCategoryViewModel Add(NewsCategoryViewModel newsVm);
        void Update(NewsCategoryViewModel productCategoryVm);
        void Delete(int id);
        List<NewsCategoryViewModel> GetAll();
        List<NewsCategoryViewModel> GetAll(string keyword);
        NewsCategoryViewModel GetById(int id);
    }
}
