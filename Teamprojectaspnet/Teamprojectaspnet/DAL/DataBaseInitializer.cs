using System.Data.Entity;
using Teamprojectaspnet.Models;
using Teamprojectaspnet.Services;

namespace Teamprojectaspnet.DAL
{
    public class DataBaseInitializer: DropCreateDatabaseIfModelChanges<GoogleMapModel>
    {
        protected override void Seed(GoogleMapModel context)
        {
            City cityRivne = new City() { Name = "Rivne" };
            context.Cities.Add(cityRivne);
            context.Cities.Add(new City() { Name = "Kyiv" });
            context.Cities.Add(new City() { Name = "Lutsk" });
            context.Cities.Add(new City() { Name = "Lviv" });
            context.SaveChanges();

            LoginStatus loginStatusAdmin = new LoginStatus() { Name = "admin" };
            LoginStatus loginStatusUser = new LoginStatus() { Name = "user" };
            context.LoginStatuses.Add(loginStatusAdmin);
            context.LoginStatuses.Add(loginStatusUser);
            context.SaveChanges();

            var password1 = "admin";
            var password2 ="user";
            var securepassword1 = SecurePasswordHasher.Hash(password1);
            var securepassword2 = SecurePasswordHasher.Hash(password2);
            Address adminAddress = new Address() { City = cityRivne, Street = "Київська", Number = "20" };
            Login adminLogin = new Login() { Name = "admin", LoginStatus = loginStatusAdmin, Password = securepassword1, Address = adminAddress };
            context.Logins.Add(adminLogin);
            context.Logins.Add(new Login() { Name = "user", LoginStatus = loginStatusUser, Password = securepassword2, Address = adminAddress });
            context.SaveChanges();

            MarkerType supermarketType = new MarkerType() { Name = "supermarket" };
            MarkerType schoolType = new MarkerType() { Name = "school" };
            MarkerType otherType = new MarkerType() { Name = "other" };
            context.MarkerTypes.Add(new MarkerType() { Name = "user" });
            context.MarkerTypes.Add(supermarketType);
            context.MarkerTypes.Add(new MarkerType() { Name = "bank" });
            context.MarkerTypes.Add(schoolType);
            context.MarkerTypes.Add(new MarkerType() { Name = "library" });
            context.MarkerTypes.Add(new MarkerType() { Name = "cinema" });
            context.MarkerTypes.Add(otherType);
            context.SaveChanges();
            string terminalImage ="";
            string supermarketImage = "";
            string schoolImage = "";
            string otherImage = "";
            string cinemaImage = "";
            string libraryImage = "";
            Address silpoAddress = new Address() { City = cityRivne, Street = "Київська", Number = "69" };
            Address fozziAddress = new Address() { City = cityRivne, Street = "Курчатова", Number = "9" };
            Address velmartAddress = new Address() { City = cityRivne, Street = "Макарова", Number = "22" };
            Address cumAddress = new Address() { City = cityRivne, Street = "Соборна", Number = "17" };
            context.Addresses.Add(silpoAddress);
            context.Addresses.Add(fozziAddress);
            context.Addresses.Add(velmartAddress);
            context.Addresses.Add(cumAddress);
            context.SaveChanges();


            Marker silpoMarker = new Marker()
            {
                Type = supermarketType,
                Lat = 50.616842,
                Lng = 26.281758,
                Name = "Silpo",
                Address = silpoAddress,
                Picture = supermarketImage,
                Description = "supermarket",
                Login = adminLogin
            };
            context.Markers.Add(silpoMarker);
            Marker fozziMarker = new Marker()
            {
                Type = supermarketType,
                Lat = 50.603368,
                Lng = 26.284247,
                Name = "Fozzi",
                Address = fozziAddress,
                Picture = supermarketImage
                                            ,
                Description = "supermarket",
                Login = adminLogin
            };
            context.Markers.Add(fozziMarker);
            Marker velmartMarker = new Marker()
            {
                Type = supermarketType,
                Lat = 50.626279,
                Lng = 26.199893,
                Name = "Velmart",
                Address = velmartAddress,
                Picture = supermarketImage,
                Description = "supermarket",
                Login = adminLogin
            };
            context.Markers.Add(velmartMarker);
            Marker cumMarker = new Marker
            {
                Type = supermarketType,
                Lat = 50.618634,
                Lng = 26.252800,
                Name = "CUM",
                Address = cumAddress,
                Picture = supermarketImage,

                Description = "supermarket",
                Login = adminLogin
            };
            context.Markers.Add(cumMarker);

            Marker otherMarker = new Marker
            {
                Type = otherType,
                Lat = 50.618634,
                Lng = 26.252800,
                Name = "CUM",
                Address = cumAddress,
                Picture = otherImage,

                Description = "supermarket",
                Login = adminLogin
            };
            context.Markers.Add(otherMarker);

            context.Contacts.Add(new Contact() { Name = "0362 20 52 04", Marker = silpoMarker });
            context.Contacts.Add(new Contact() { Name = "0362 20 52 04", Marker = fozziMarker });
            context.Contacts.Add(new Contact() { Name = "0362 20 52 04", Marker = velmartMarker });
            context.Contacts.Add(new Contact() { Name = "0362 20 52 04", Marker = cumMarker });
            context.Contacts.Add(new Contact() { Name = "0362 20 52 04", Marker = otherMarker });
            context.SaveChanges();

            Address cinemaEra = new Address() { City = cityRivne, Street = "Гагаріна", Number = "51" };
            Address cinemaUkraine = new Address() { City = cityRivne, Street = "майдан Незалежності", Number = "2" };
            Address school12Address = new Address() { City = cityRivne, Street = "Академіка Грушевського", Number = "81А" };
            Address school19Address = new Address() { City = cityRivne, Street = "Макарова", Number = "48" };
            Address school8Address = new Address() { City = cityRivne, Street = "Князя Острозького", Number = "20" };
            Address school27Address = new Address() { City = cityRivne, Street = "Дубенська", Number = "133" };
            Address school23Address = new Address() { City = cityRivne, Street = "Вербова", Number = "42" };
            Address school26Address = new Address() { City = cityRivne, Street = "Павлюченка", Number = "24" };
            Address school6Address = new Address() { City = cityRivne, Street = "Олени Пчілки", Number = "9" };
            Address terminal1 = new Address() { City = cityRivne, Street = "Соборна", Number = "15" };
            Address terminal2 = new Address() { City = cityRivne, Street = "Соборна", Number = "17" };
            Address terminal3 = new Address() { City = cityRivne, Street = "Соборна", Number = "12а" };
            Address terminal4 = new Address() { City = cityRivne, Street = "Проспект Миру", Number = "2" };
            Address terminal5 = new Address() { City = cityRivne, Street = "Словацького", Number = "4/6" };
            Address terminal6 = new Address() { City = cityRivne, Street = "Шевченка", Number = "18" };
            Address terminal7 = new Address() { City = cityRivne, Street = "Проспект Миру", Number = "8" };
            Address terminal8 = new Address() { City = cityRivne, Street = "Відінська", Number = "48" };
            Address terminal9 = new Address() { City = cityRivne, Street = "Вячеслава Чорновола", Number = "53" };
            Address terminal10 = new Address() { City = cityRivne, Street = "Алекси Новака", Number = "75" };
            Address terminal11 = new Address() { City = cityRivne, Street = "Шкільна", Number = "33" };
            Address library1 = new Address() { City = cityRivne, Street = "Соборна", Number = "416" };
            Address library2 = new Address() { City = cityRivne, Street = "Залізнична", Number = "6" };
            Address library3 = new Address() { City = cityRivne, Street = "Короленка", Number = "6" };
            Address library4 = new Address() { City = cityRivne, Street = "Проспект Миру", Number = "18" };
            Address library5 = new Address() { City = cityRivne, Street = "Петра Могили", Number = "22Б" };
            context.Addresses.Add(cinemaEra);
            context.Addresses.Add(cinemaUkraine);
            context.Addresses.Add(school6Address);
            context.Addresses.Add(school26Address);
            context.Addresses.Add(school23Address);
            context.Addresses.Add(school27Address);
            context.Addresses.Add(school8Address);
            context.Addresses.Add(school19Address);
            context.Addresses.Add(school12Address);
            context.Addresses.Add(terminal1);
            context.Addresses.Add(terminal2);
            context.Addresses.Add(terminal3);
            context.Addresses.Add(terminal4);
            context.Addresses.Add(terminal5);
            context.Addresses.Add(terminal6);
            context.Addresses.Add(terminal7);
            context.Addresses.Add(terminal8);
            context.Addresses.Add(terminal9);
            context.Addresses.Add(terminal10);
            context.Addresses.Add(terminal11);
            context.Addresses.Add(library1);
            context.Addresses.Add(library2);
            context.Addresses.Add(library3);
            context.Addresses.Add(library4);
            context.Addresses.Add(library5);
            context.SaveChanges();
            //Address school12Address = new Address() { Name = "school 12", City = cityRivne, Street = "Академіка Грушевського", Number = "81А" };
            Marker librarymarker1 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "library").Result,
                Lat = 50.635571,
                Lng = 26.2130483,
                Name = "Library",
                Address = library1,
                Picture = libraryImage,
                Description = "Міська бібліотека №3",
                Login = adminLogin
            };
            Marker librarymarker2 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "library").Result,
                Lat = 50.6001784,
                Lng = 26.2351745,
                Name = "Library",
                Address = library2,
                Picture = libraryImage,
                Description = "Міська бібліотека №2",
                Login = adminLogin
            };
            Marker librarymarker3 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "library").Result,
                Lat = 50.617936,
                Lng = 26.246253,
                Name = "Library",
                Address = library3,
                Picture = libraryImage,
                Description = "Рівненська обласна універсальна наукова бібліотека",
                Login = adminLogin
            };
            Marker librarymarker4 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "library").Result,
                Lat = 50.6259239,
                Lng = 26.246049,
                Name = "Library",
                Address = library4,
                Picture = libraryImage,
                Description = "Рівненська обласна бібліотека для дітей",
                Login = adminLogin
            };
            Marker librarymarker5 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "library").Result,
                Lat = 50.6194729,
                Lng = 26.2274645,
                Name = "Library",
                Address = library5,
                Picture = libraryImage,
                Description = "Центральна Районна Бібліотека",
                Login = adminLogin
            };
            Marker terminalmarker1 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6186878,
                Lng = 26.2542766,
                Name = "ATM",
                Address = terminal1,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker2 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6186417,
                Lng = 26.2526823,
                Name = "ATM",
                Address = terminal2,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker3 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6185876,
                Lng = 26.2620209,
                Name = "ATM",
                Address = terminal3,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker4 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6232695,
                Lng = 26.2532465,
                Name = "ATM",
                Address = terminal4,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker5 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6220565,
                Lng = 26.2494317,
                Name = "ATM",
                Address = terminal5,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker6 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6224676,
                Lng = 26.2434406,
                Name = "ATM",
                Address = terminal6,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker7 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6240029,
                Lng = 26.250818,
                Name = "ATM",
                Address = terminal7,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker8 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6057137,
                Lng = 26.2723808,
                Name = "ATM",
                Address = terminal8,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker9 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6073427,
                Lng = 26.2588497,
                Name = "ATM",
                Address = terminal9,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker10 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6095943,
                Lng = 26.2614005,
                Name = "ATM",
                Address = terminal10,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker11 = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6194412,
                Lng = 26.2438825,
                Name = "ATM",
                Address = terminal11,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker school12Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.617336,
                Lng = 26.275402,
                Name = "School 12",
                Address = school12Address,
                Picture = schoolImage,
                Description = "school",
                Login = adminLogin
            };

            Marker school19Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.6413633,
                Lng = 26.1992904,
                Name = "School 19",
                Address = school19Address,
                Picture = schoolImage,
                Description = "Rivne Educational Complex №19",
                Login = adminLogin
            };
            Marker school8Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.6379384,
                Lng = 26.2014107,
                Name = "School 8",
                Address = school8Address,
                Picture = schoolImage,
                Description = "Школа №8",
                Login = adminLogin
            };
            Marker school27Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.6113521,
                Lng = 26.2149297,
                Name = "School 27",
                Address = school27Address,
                Picture = schoolImage,
                Description = "Школа №27",
                Login = adminLogin
            };
            Marker school23Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.632157,
                Lng = 26.2051265,
                Name = "School 23",
                Address = school23Address,
                Picture = schoolImage,
                Description = "Школа №23",
                Login = adminLogin
            };
            Marker school26Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.6226748,
                Lng = 26.2096796,
                Name = "School 26",
                Address = school26Address,
                Picture = schoolImage,
                Description = "Школа №26",
                Login = adminLogin
            };
            Marker school6Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.6129689,
                Lng = 26.2263948,
                Name = "School 6",
                Address = school6Address,
                Picture = schoolImage,
                Description = "Школа №6",
                Login = adminLogin
            };

            Marker cinemaUkr = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "cinema").Result,
                Lat = 50.6202974,
                Lng = 26.2514783,
                Name = "Україна Кінопалац",
                Address = cinemaUkraine,
                Picture = cinemaImage,
                Description = "Украина Кинопалац",
                Login = adminLogin
            };

            Marker Eracinema = new Marker()
            {
                Type = context.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "cinema").Result,
                Lat = 50.6320133,
                Lng = 26.2736146,
                Name = "Ера",
                Address = cinemaEra,
                Picture = cinemaImage,
                Description = "Мультиплекс Кіноцентр Ера",
                Login = adminLogin
            };
            context.Markers.Add(librarymarker1);
            context.Markers.Add(librarymarker2);
            context.Markers.Add(librarymarker3);
            context.Markers.Add(librarymarker4);
            context.Markers.Add(librarymarker5);
            context.Markers.Add(terminalmarker1);
            context.Markers.Add(terminalmarker2);
            context.Markers.Add(terminalmarker3);
            context.Markers.Add(terminalmarker4);
            context.Markers.Add(terminalmarker5);
            context.Markers.Add(terminalmarker6);
            context.Markers.Add(terminalmarker7);
            context.Markers.Add(terminalmarker8);
            context.Markers.Add(terminalmarker9);
            context.Markers.Add(terminalmarker10);
            context.Markers.Add(terminalmarker11);
            context.Markers.Add(Eracinema);
            context.Markers.Add(cinemaUkr);
            context.Markers.Add(school6Marker);
            context.Markers.Add(school26Marker);
            context.Markers.Add(school23Marker);
            context.Markers.Add(school27Marker);
            context.Markers.Add(school8Marker);
            context.Markers.Add(school12Marker);
            context.Markers.Add(school19Marker);
            context.SaveChanges();
            context.Contacts.Add(new Contact() { Name = "0800 505 333", Marker = Eracinema });
            context.Contacts.Add(new Contact() { Name = "068 800 5588", Marker = cinemaUkr });
            context.Contacts.Add(new Contact() { Name = "097 716 7813", Marker = school6Marker });
            context.Contacts.Add(new Contact() { Name = "03622 52083", Marker = school23Marker });
            context.Contacts.Add(new Contact() { Name = "0362 628 377", Marker = school27Marker });
            context.Contacts.Add(new Contact() { Name = "03622 85592", Marker = school12Marker });
            context.Contacts.Add(new Contact() { Name = "0362 25 63 05", Marker = school19Marker });
            context.Contacts.Add(new Contact() { Name = "0362 641 257", Marker = school8Marker });
            context.Contacts.Add(new Contact() { Name = "03622 53238", Marker = school26Marker });
            context.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker1 });
            context.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker2 });
            context.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker3 });
            context.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker4 });
            context.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker5 });
            context.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker6 });
            context.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker7 });
            context.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker8 });
            context.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker9 });
            context.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker10 });
            context.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker11 });
            context.Contacts.Add(new Contact() { Name = "0362252042", Marker = librarymarker1 });
            context.Contacts.Add(new Contact() { Name = "0362681805", Marker = librarymarker2 });
            context.Contacts.Add(new Contact() { Name = "0362263585", Marker = librarymarker3 });
            context.SaveChanges();
            base.Seed(context);
        }
     }
}