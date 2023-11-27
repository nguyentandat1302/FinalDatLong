namespace FinalDatLong.Migrations
{
    using FinalDatLong.Models;
    using SachOnline;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalDatLong.Models.Model1>
    {
        public Configuration()
        {
   
        AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinalDatLong.Models.Model1 context)
        {
            var lstUsers = new List<Admin>();
            lstUsers.Add(new Admin {IDAdmin =1,UserName = "admin", Password = "123", Role = "admin", Email = "datnguyen13021302@gmail.com", Avatar = Utility.ConvertImageToBase64(Path.GetFullPath("../Image/q.jpg")), FullName="Tét" });
            lstUsers.Add(new Admin {IDAdmin =2, UserName = "doctor1", Password = "123", Role = "doctor", FullName ="fsfs",Email="gdgdgd" });
            lstUsers.ForEach(s => context.Admin.AddOrUpdate(s));

            var lstDoctors = new List<Doctor>();
            lstDoctors.Add(new Doctor { IDDoctor = 10, UserName = "dcotor10", Password = "bfdf@3", FullName = "Mr.Jen", Email = "tui243@gmail.com", Phone = "54678856745", Specialization = "Đa Khoa", Avatar = Utility.ConvertImageToBase64(Path.GetFullPath("../Image/q.jpg")), Introduction = "Bacsythientai" });
            lstDoctors.ForEach(s => context.Doctor.AddOrUpdate(s));
             
            base.Seed(context);

            
        }
    }
}
