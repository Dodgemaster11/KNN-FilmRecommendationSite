using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.Models
{
    public class FilmContext : DbContext 
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public FilmContext(DbContextOptions<FilmContext> options)
            : base(options)
        {
           //Database.EnsureDeleted();
           Database.EnsureCreated();
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
                modelBuilder
               .Entity<Film>()
               .HasMany(c => c.Users)
               .WithMany(s => s.Films)
               .UsingEntity<Marks>(
                   j => j
                    .HasOne(pt => pt.Users)
                    .WithMany(t => t.Marks)
                    .HasForeignKey(pt => pt.UsersId),
                j => j
                    .HasOne(pt => pt.Film)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(pt => pt.FilmId),
                 j =>
                 {
                     j.Property(pt => pt.Mark).HasDefaultValue(3);
                     j.HasKey(t => new { t.FilmId, t.UsersId });
                     j.ToTable("Marks");
                 });
        

        modelBuilder.Entity<Film>().HasData(
                new Film[]
                {
                   new Film {
                        Id = 1,
                        film_name = "1+1 ( Intouchables / The Intouchables)",
                        prod_year = "2011",
                        shortDesc = "Sometimes you have to reach into someone else's world to find out what's missing in your own",
                        longDesc= "Филипп очень богатый человек, но в результате несчастного случая его парализовало, и он прикован к инвалидному креслу. Он потерял всякий интерес к жизни, и нуждается в постоянном присмотре. Для этих целей нанимаются сиделки, однако ни одна из них долго не работает.И вот однажды, очередной сиделкой Филиппа становится чернокожий молодой парень по имени Дрисса, вышедший совсем недавно из тюрьмы. Сложно представить такого человека в роли сиделки, однако парень умудряется найти общий язык с Филиппом. Он не жалеет его, и относится к нему не как к инвалиду, а как к здоровому человеку. Они весело проводят время вместе, и благодаря этому Филипп начинает смотреть на жизнь по-новому, и даже влюбляется.",
                        poster = "/img/onePlusOne.jpg",
                        trailer = "https://www.youtube.com/embed/tTwFeGArcrs",
                        film_time = "112 мин.",
                        price = 400,

                    },
                    new Film {
                        Id = 2,
                        film_name = "Тихоокеанский рубеж",
                        prod_year = "2013",
                        shortDesc = "Чтобы сражаться с монстрами, мы создали монстров",
                        longDesc= "В 2013 году, через червоточину на дне океана инопланетные пришельцы исполинских размеров, получивших в народе название «кайдзю», вторгаются на Землю с целью ее порабощения. Путем колоссальных усилий человечеству удается отбить первую атаку и перенаправить всю экономику планеты на оборонительные проекты. Люди создают огромных роботов, «егерей», управляемых одновременно двумя пилотами, чтобы вовремя отражать нападения монстров. Находясь на грани поражения, в самый критический момент судьба всего мира оказывается в руках пилотов устаревшего «Бродяги», опытного Райли Беккета и молодого стажера Мако Мори.",
                        poster = "/img/TihookeanskyiRybezh.jpg", 
                        trailer = "https://www.youtube.com/embed/Ed0FIOInP-4",
                        film_time = "131 мин.",
                        price = 250,

                    },
                    new Film {
                        Id = 3,
                        film_name = "Брюс Всемогущий",
                         prod_year = "2003",
                        shortDesc = "The guy next door just became the man upstairs",
                        longDesc= "В центре сюжета находится парень по имени Брюс Нолан, работающий репортером. У него есть хорошая работа, любимая девушка, однако он постоянно чем-то не доволен. Однажды из-за своих пессимистических настроений и скверного характера Брюса увольняют с телеканала, на котором он трудился. Не имея возможности лично вылить на кого-то все накипевшее, герой адресует свою речь ни кому нибудь, а Богу. И как не странно, но тот его услышал, и даже явился в облике самого обычного человека.Всевышний решает проучить зарвавшегося человечишку, и отдает Брюсу на целую неделю свои божественные силы. Поначалу тот очень радуется этому, и воплощает в жизнь все свои причуды. Но как вскоре выясняется, что кроме него, еще есть сотни миллионов людей, которые каждый день обращаются за помощью к богу, и что управлять миром далеко не так просто, как кажется.",
                        poster = "/img/BruceVsemogyshiy.jpg",
                        trailer = "https://www.youtube.com/embed/phJa5I6TX9Y",
                        film_time = "97 мин.",
                        price = 150,

                    },
                    new Film {
                        Id = 4,
                        film_name = "Джон Уик 2",
                         prod_year = "2011",
                        shortDesc = "Never stab the devil in the back",
                        longDesc= "Фильм является продолжением увлекательной истории о профессиональном наёмном убийце по имени Джон Уик. На этот раз киллеру в отставке, который так хотел насладиться заслуженным покоем, отойдя от дел и навсегда оставив темное прошлое, снова необходимо вынужденно вернуться в кровавую игру.Однажды на пороге его дома оказывается старый знакомый дон Сантино Д’Антонио, который в прошлом оказал Джону немалую помощь и теперь требует чтобы киллер вернул ему долг, выполнив одно непростое дельце. Сантино желает, чтобы Джон убил его сестру Джианну, которая после смерти отца получала в наследство место в крупнейшей мафиозной сети. Мириться с такой несправедливостью влиятельный дон не намерен, и после довольно жесткого убеждения он склоняет нашего героя к сотрудничеству.Делать нечего, и теперь Джону необходимо отложить все свои мирные дела и отправиться в Рим, чтобы вступить в смертельную схватку с такими же профессиональными киллерами, защищающими интересы своих хозяев. Вот только нашего героя мало волнует количество хладнокровных убийц, вставших у него на пути, ведь это далеко не его проблемы.",
                        poster = "/img/John_Wick_2.jpg",
                        trailer = "https://www.youtube.com/embed/0DkJa_aGTP8",
                        film_time = "122 мин.",
                        price = 250,

                    }
                });
         
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "123";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            Users adminUser = new Users { Id = 1, user_email = adminEmail, user_password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<Users>().HasData(new Users[] { adminUser });
            base.OnModelCreating(modelBuilder);


        }


    }
}
