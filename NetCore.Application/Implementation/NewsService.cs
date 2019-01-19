using AutoMapper;
using AutoMapper.QueryableExtensions;
using NetCore.Application.Interfaces;
using NetCore.Application.ViewModels.News;
using NetCore.Data.Entites;
using NetCore.Data.Entities;
using NetCore.Data.Enums;
using NetCore.Data.IRepositories;
using NetCore.Infrastructure.Interfaces;
using NetCore.Utilities.Constants;
using NetCore.Utilities.Dtos;
using NetCore.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore.Application.Implementation
{
    public class NewsService : INewsService
    {
        private INewsRepository _newsRepository;
        private IUnitOfWork _unitOfWork;
        private ITagRepository _tagRepository;
        public NewsService(INewsRepository newsRepository, IUnitOfWork unitOfWork,ITagRepository tagRepository)
        {
            _newsRepository = newsRepository;
            _unitOfWork = unitOfWork;
            _tagRepository = tagRepository;
        }
        public NewsViewModel Add(NewsViewModel newsVm)
        {
            List<NewsTag> NewsTags = new List<NewsTag>();
            if (!string.IsNullOrEmpty(newsVm.Tag))
            {
                string[] tags = newsVm.Tag.Split(',');
                foreach (var item in tags)
                {
                    var tagId = TextHelper.ToUnsignString(item);
                    if (!_tagRepository.FindAll(x => x.Id == tagId && x.Type==CommonConstants.NewsTag).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = item,
                            Type = CommonConstants.NewsTag
                        };
                        _tagRepository.Add(tag);
                        NewsTag newsTag = new NewsTag
                        {
                            NewsId = newsVm.Id,
                            TagId = tagId
                        };
                        NewsTags.Add(newsTag);
                    }
                }
            }
            var News = Mapper.Map<NewsViewModel, News>(newsVm);
            foreach (var newsTag in NewsTags)
            {
                News.NewsTags.Add(newsTag);
            }
            _newsRepository.Add(News);
            return newsVm;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<NewsViewModel> GetAll()
        {
            return _newsRepository.FindAll(x => x.Active==Active.Active).ProjectTo<NewsViewModel>().ToList();
        }

        public List<NewsViewModel> GetAll(string keyword)
        {
            throw new NotImplementedException();
        }

        public NewsViewModel GetById(int id)
        {
            return Mapper.Map<News, NewsViewModel>(_newsRepository.FindById(id));
        }

        public List<NewsViewModel> GetLastest(int top)
        {
          return  _newsRepository.FindAll(x => x.Active == Active.Active && x.ViewHomes == true).ProjectTo<NewsViewModel>().ToList();
        }

        public void Update(NewsViewModel productCategoryVm)
        {
            throw new NotImplementedException();
        }
        public PagedResult<NewsViewModel> GetAllPaging(int? categogyId, string keyword, int page, int pageSize)
        {
            var query = _newsRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword));
            }
            if (categogyId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categogyId.Value);
            }
            int totalRow = query.Count();
            query = query.OrderByDescending(p => p.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);
            var data = query.ProjectTo<NewsViewModel>().ToList();
            var paginationSet = new PagedResult<NewsViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }
    }
}
