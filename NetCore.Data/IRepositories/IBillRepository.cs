using NetCore.Data.Entites;
using NetCore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.IRepositories
{
    public interface IBillRepository:IRepository<Bill,int>
    {
    }
}
