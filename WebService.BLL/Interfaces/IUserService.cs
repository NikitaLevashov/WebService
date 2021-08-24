using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.BLL.ModelsBLL;

namespace WebService.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserBLL> GetAll();
        UserBLL Get(int id);
        void Create(UserBLL item);
        void Update(UserBLL item);
        void Delete(UserBLL id);
    }
}
