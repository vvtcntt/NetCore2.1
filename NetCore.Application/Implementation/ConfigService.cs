using AutoMapper;
using NetCore.Application.Interfaces;
using NetCore.Application.ViewModels.System;
using NetCore.Data.Entites;
using NetCore.Data.IRepositories;
using NetCore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.Implementation
{
    public class ConfigService : IConfigService
    {
        private IConfigRepository _configRepository;
        private IUnitOfWork _unitOfWork;

        public ConfigService(IConfigRepository configRepository, IUnitOfWork unitOfWork)
        {
            _configRepository = configRepository;
            _unitOfWork = unitOfWork;
        }

        public ConfigViewModel GetById(string id)
        {
            var config = _configRepository.FindSingle(x => x.Id == id);
            return Mapper.Map<Config, ConfigViewModel>(config);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void update(ConfigViewModel configVm)
        {
            var config = Mapper.Map<ConfigViewModel, Config>(configVm);
            _configRepository.Update(config);
        }
    }
}
