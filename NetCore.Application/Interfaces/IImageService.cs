using NetCore.Application.ViewModels.Image;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.Interfaces
{
   public interface IImageService
    {
        ImageViewModel Add(ImageViewModel imageVm);
        void Update(ImageViewModel imageVm);
        void Delete(int id);
        List<ImageViewModel> GetAll();
        List<ImageViewModel> GetAll(string keyword);
        ImageViewModel GetById(int id);
        List<ImageViewModel> GetSlide(int top);
     }
}
