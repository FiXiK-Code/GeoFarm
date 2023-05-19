using MVP.Date.Models;
using System.Collections.Generic;
namespace MVP.Date.Interfaces
{
    public interface ITitle
    {
        public List<Title> GetTitles { get; }
    }
}
