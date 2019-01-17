using NetCore.Application.ViewModels.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.Interfaces
{
   public interface IConfigService
    {
        ConfigViewModel GetById(string id);
        void update(ConfigViewModel configVm);
        void Save();

    }
}
