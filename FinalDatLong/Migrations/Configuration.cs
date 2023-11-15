namespace FinalDatLong.Migrations
{
    using FinalDatLong.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalDatLong.Models.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinalDatLong.Models.Model1 context)
        {
            var lstChuDe = new List<Doctor>();
            lstChuDe.Add(new Doctor { FullName = "Mr.Long", Email = "Long123@gmail.com", Specialization = "Đa khoa" });
            lstChuDe.Add(new Doctor { FullName = "Mr.Dat", Email = "Dat123@gmail.com", Specialization = "Đa khoa" });
            lstChuDe.Add(new Doctor { FullName = "Mr.Phong", Email = "phong123@gmail.com", Specialization = "Nha khoa" });
            lstChuDe.Add(new Doctor { FullName = "Mr.Nam", Email = "nam1236@gmail.com", Specialization = "Da liễu" });
            lstChuDe.Add(new Doctor { FullName = "Mr.tho", Email = "tho123@gmail.com", Specialization = "Da liễu" });
            lstChuDe.Add(new Doctor { FullName = "Mr.hoang", Email = "hoang1623@gmail.com", Specialization = "Nhãn khoa" });
            lstChuDe.Add(new Doctor { FullName = "Mr.do", Email = "do1238@gmail.com", Specialization = "Phụ khoa" });
            lstChuDe.Add(new Doctor { FullName = "Mr.dung", Email = "dung4123@gmail.com", Specialization = "Phụ khoa" });
            lstChuDe.Add(new Doctor
            {
                FullName = "Mr.tan",
                Email = "tan1283@gmail.com",
                Specialization = "Thần kinh cột sống"
            });
            lstChuDe.ForEach(c => context.Doctor.AddOrUpdate(c));



            base.Seed(context);
        }
    }
}
