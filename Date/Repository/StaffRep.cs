using MVP.Date.Interfaces;
using MVP.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVP.Date.Repository
{
    public class StaffRep : IStaff
    {
        private readonly AppDB _appDB;

        public StaffRep(AppDB appDB)
        {
            _appDB = appDB;
        }

        public IEnumerable<Staff> AllStaffs => _appDB.DBStaff;

        public void AddToDb(Staff staff)
        {
            _appDB.DBStaff.Add(staff);
            _appDB.SaveChanges();
        }

        public IEnumerable<Staff> DivisoinStaff(int divisionId) => _appDB.DBStaff.Where(p => p.divisionId == divisionId);// incl

        public Staff GetStaff(int staffId) => _appDB.DBStaff.FirstOrDefault(p => p.id == staffId);

        public bool RedactStaff(int id, string name, int divId, string post, string supCod, string login, string paswd, string mail, string role, bool admin)
        {
            Staff staff = _appDB.DBStaff.FirstOrDefault(p => p.id == id);

            staff.admin = admin;
            staff.name = name;
            staff.divisionId = divId;
            staff.post = post;
            staff.supervisorCod = supCod.ToString();
            staff.login = login;
            staff.passvord = paswd;
            staff.mail = mail;
            staff.roleCod = _appDB.DBRole.FirstOrDefault(p => p.name == role).code;
            _appDB.SaveChanges();

            return true;
        }

        public List<StaffOut> StaffTable(string SessionRole, string sessionCod)
        {
            List<StaffOut> StaffTable = new List<StaffOut>();

            var staff = _appDB.DBStaff.FirstOrDefault(p => p.code == sessionCod);
            var obj = new StaffOut
            {
                id = staff.id,
                code = staff.code,
                name = staff.name,
                divisionId = staff.divisionId,
                post = staff.post,
                roleCod = staff.roleCod,
                supervisorCod = staff.supervisorCod,
                login = staff.login,
                mail = staff.mail
            };
            StaffTable.Add(obj);

            var role = _appDB.DBRole.FirstOrDefault(p => p.name == SessionRole).recipient.Split(',');

            foreach (var rol in role)
            {
                var staffCod = _appDB.DBRole.FirstOrDefault(p => p.name == rol.Trim()).code;
                foreach (var staffs in _appDB.DBStaff.Where(p => p.roleCod == staffCod))
                {
                    var outStaff = new StaffOut
                    {
                        id = staffs.id,
                        code = staffs.code,
                        name = staffs.name,
                        divisionId = staffs.divisionId,
                        post = staffs.post,
                        roleCod = staffs.roleCod,
                        supervisorCod = staffs.supervisorCod,
                        login = staffs.login,
                        mail = staffs.mail
                    };
                    StaffTable.Add(outStaff);
                }
            }

            return StaffTable;
        }
    }
}
