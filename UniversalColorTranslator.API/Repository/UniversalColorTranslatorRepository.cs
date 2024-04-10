using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

using UniversalColorTranslator.API.Model;
using UniversalColorTranslator.API.Interface;

namespace UniversalColorTranslator.API.Repository
{
    public class UniversalColorTranslatorRepository
    {
        private IUniversalColorTranslatorDbContext _context;
        private bool isMock = false;

        public UniversalColorTranslatorRepository() { }

        public UniversalColorTranslatorRepository(IUniversalColorTranslatorDbContext _mockDb)
        {
            this._context = _mockDb;
            this.isMock = true;
        }

        public List<Colors> GetColors()
        {
            using (IUniversalColorTranslatorDbContext context = this.isMock ? this._context : new UniversalColorTranslatorDbContext())
            {

                var colors = context.Colors.ToList();
                return colors;
            }
        }

        public Colors GetColor(string colorname)
        {
            using (IUniversalColorTranslatorDbContext context = this.isMock ? this._context : new UniversalColorTranslatorDbContext())
            {

                var color = context.Colors.Where(c => c.ColorName.ToLower() == colorname.ToLower()).FirstOrDefault();
                return color;
            }
        }

        public string GetColorHex(string colorname)
        {
            using (IUniversalColorTranslatorDbContext context = this.isMock ? this._context : new UniversalColorTranslatorDbContext())
            {

                var hexvalue = context.Colors.Where(c => c.ColorName.ToLower() == colorname.ToLower()).Select(c => c.HexValue).FirstOrDefault();
                return hexvalue;
            }
        }
    }
}
