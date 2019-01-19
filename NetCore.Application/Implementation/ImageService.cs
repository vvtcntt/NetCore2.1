using AutoMapper.QueryableExtensions;
using NetCore.Application.Interfaces;
using NetCore.Application.ViewModels.Image;
using NetCore.Data.Enums;
using NetCore.Data.IRepositories;
using NetCore.Infrastructure.Interfaces;
using NetCore.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore.Application.Implementation
{
    public class ImageService : IImageService
    {
        private IImageRepository _imageRepository;
        private IUnitOfWork _unitOfWork;
        public ImageService(IImageRepository imageRepository,IUnitOfWork unitOfWork)
        {
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }
        public ImageViewModel Add(ImageViewModel imageVm)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ImageViewModel> GetAll(string keyword)
        {
            throw new NotImplementedException();
        }

        public ImageViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageViewModel> GetSlide(int top)
        {
            return _imageRepository.FindAll(x => x.Active==Active.Active && x.Type==CommonConstants.ImageSlide).ProjectTo<ImageViewModel>().OrderByDescending(x=>x.SortOrder).Take(top).ToList();
        }

        public void Update(ImageViewModel imageVm)
        {
            throw new NotImplementedException();
        }
    }
}
