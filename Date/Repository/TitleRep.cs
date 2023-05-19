using MVP.Date.Interfaces;
using MVP.Date.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVP.Date.Repository
{
    public class TitleRep : ITitle
    {
        private readonly AppDB _appDB;

        public TitleRep(AppDB appDB)
        {
            _appDB = appDB;
        }

        public List<Title> GetTitles => _appDB.DBTitle.ToList();
    }
}
