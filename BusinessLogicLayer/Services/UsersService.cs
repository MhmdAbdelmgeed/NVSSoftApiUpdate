using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UsersService
    {
        private readonly UsersRepository usersRepository;

        public UsersService(IConfiguration configuration)
        {
            this.usersRepository = new UsersRepository(configuration);
        }

        public List<User> GetUsers()
        {
            return usersRepository.GetUsers();
        }
    }
}
