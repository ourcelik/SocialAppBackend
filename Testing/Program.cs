using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace Testing
{
    class Program
    {
         static void Main(string[] args)
        {
            CreateTest1();
        }
        public static void CreateTest1()
        {
            UserManager _userManager;
            _userManager = new UserManager(new EfUserDal());
            _userManager.Add(new User()
            {
                Username= "ourcelik",
                _Password= "deneme",
                Mail = "deneme",
                TelNo = "000000",
                ProfileId =1
            });
        }
    }
}
