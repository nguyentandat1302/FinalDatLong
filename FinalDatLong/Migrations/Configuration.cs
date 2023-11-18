namespace FinalDatLong.Migrations
{
    using FinalDatLong.Models;
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

            base.Seed(context);

            base.Seed(context);
        }
    }
}
