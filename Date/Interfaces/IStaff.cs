
using MVP.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVP.Date.Interfaces
{
    public interface IStaff
    {
        IEnumerable<Staff> AllStaffs { get; }
        IEnumerable<Staff> DivisoinStaff(int divisionId);
        Staff GetStaff(int staffId);

        void AddToDb(Staff staff);
        bool RedactStaff(
            int id,
            string name,
            int divId,
            string post,
            string supCod,
            string login,
            string paswd,
            string mail,
            string role,
            bool admin);

    }
}
