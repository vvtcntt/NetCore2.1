﻿using NetCore.Infrastructure.Interfaces;
using NETCORE.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public EFUnitOfWork (AppDbContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
