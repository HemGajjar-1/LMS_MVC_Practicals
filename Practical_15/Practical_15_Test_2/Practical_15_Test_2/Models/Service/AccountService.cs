using Practical_15_Test_2.Models.Entities;
using Practical_15_Test_2.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_15_Test_2.Models.Service
{
    public class AccountService
    {
        private AccountRepository repo;

        public AccountService()
        {
            repo = new AccountRepository();
        }

        public bool ValidateUser(User user)
        {
            return repo.ValidateUser(user);
        }
    }
}