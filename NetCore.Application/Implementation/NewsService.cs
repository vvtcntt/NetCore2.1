using NetCore.Application.Interfaces;
using NetCore.Application.ViewModels.News;
using NetCore.Data.IRepositories;
using NetCore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.Implementation
{
    public class NewsService : INewsService
    {
        private INewsRepository _newsRepository;
        private IUnitOfWork _unitOfWork;
        public NewsService(INewsRepository newsRepository, IUnitOfWork unitOfWork)
        {
            _newsRepository = newsRepository;
            _unitOfWork = unitOfWork;
        }
        public NewsViewModel Add(NewsViewModel newsVm)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<NewsViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<NewsViewModel> GetAll(string keyword)
        {
            throw new NotImplementedException();
        }

        public NewsViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(NewsViewModel productCategoryVm)
        {
            throw new NotImplementedException();
        }
    }
}
