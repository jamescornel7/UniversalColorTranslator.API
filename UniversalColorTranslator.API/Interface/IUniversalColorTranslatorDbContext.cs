using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniversalColorTranslator.API.Model;

namespace UniversalColorTranslator.API.Interface
{
    public interface IUniversalColorTranslatorDbContext :IDisposable
    {
        DbSet<Colors> Colors { get; set; }
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void Dispose();
    }
}
