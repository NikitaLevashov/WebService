using System.Linq;
using WebService.DAL.Models;

namespace WebService.DAL.EFCore
{
    public class SeedData
    {
        public static void SeedDatabase(UserContext db)
        {
            if (!db.Users.Any() && !db.Details.Any())
            {
                UserDAL user1 = new UserDAL { Name = "Misha", Surname = "Mironov" };
                UserDAL user2 = new UserDAL { Name = "Pavel", Surname = "Kironov" };
                UserDAL user3 = new UserDAL { Name = "Egor", Surname = "Lopenov" };
                UserDAL user4 = new UserDAL { Name = "Nikita", Surname = "Volodko" };
                UserDAL user5 = new UserDAL { Name = "Danya", Surname = "Filonov" };
                UserDAL user6 = new UserDAL { Name = "Stas", Surname = "Xilonov" };
                UserDAL user7 = new UserDAL { Name = "Aleksandr", Surname = "Lovonov" };
                UserDAL user8 = new UserDAL { Name = "Mitya", Surname = "Akonov" };
                UserDAL user9 = new UserDAL { Name = "Ilya", Surname = "Bonov" };
                UserDAL user10 = new UserDAL { Name = "Yura", Surname = "Ronin" };

                db.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8, user9, user10);

                DetailsDAL detail1 = new DetailsDAL { Age = 21, Adress = "Minsk", User = user1 };
                DetailsDAL detail2 = new DetailsDAL { Age = 24, Adress = "Gomel", User = user2 };
                DetailsDAL detail3 = new DetailsDAL { Age = 31, Adress = "Gomel", User = user3 };
                DetailsDAL detail4 = new DetailsDAL { Age = 34, Adress = "Grodno", User = user4 };
                DetailsDAL detail5 = new DetailsDAL { Age = 41, Adress = "Grodno", User = user5 };
                DetailsDAL detail6 = new DetailsDAL { Age = 34, Adress = "Vitebsk", User = user6 };
                DetailsDAL detail7 = new DetailsDAL { Age = 76, Adress = "Moscow", User = user7 };
                DetailsDAL detail8 = new DetailsDAL { Age = 12, Adress = "Kiev", User = user8 };
                DetailsDAL detail9 = new DetailsDAL { Age = 35, Adress = "Brest", User = user9 };
                DetailsDAL detail10 = new DetailsDAL { Age = 26, Adress = "Vilnus", User = user10 };

                db.Details.AddRange(detail1, detail2, detail3, detail4, detail5, detail6, detail7, detail8, detail9, detail10);

                db.SaveChanges();
            }
        }
    }
    
}
