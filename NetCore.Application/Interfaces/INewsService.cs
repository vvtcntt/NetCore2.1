using NetCore.Application.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.Interfaces
{
   public interface INewsService
    {
        NewsViewModel Add(NewsViewModel newsVm);
        void Update(NewsViewModel productCategoryVm);
        void Delete(int id);
        List<NewsViewModel> GetAll();
        List<NewsViewModel> GetAll(string keyword);
        NewsViewModel GetById(int id);

    }
}
