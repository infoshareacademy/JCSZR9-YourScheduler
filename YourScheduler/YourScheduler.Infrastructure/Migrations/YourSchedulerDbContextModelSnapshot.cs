﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourScheduler.Infrastructure;

#nullable disable

namespace YourScheduler.Infrastructure.Migrations
{
    [DbContext(typeof(YourSchedulerDbContext))]
    partial class YourSchedulerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("YourScheduler.Infrastructure.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Displayname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "",
                            Displayname = "admin",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            Name = "admin",
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AOKovnwFekJWCyl0ZFRQ6EG0GMdV4O2Rq/nxx0GUw/2+PCHDjWYkDG5NZSrZxuE32g==",
                            PhoneNumber = "111 222 333",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "CQ32CK7E3JNAEL45NRT5Y6ATYFPKNLEO",
                            Surname = "admin",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "",
                            Displayname = "kjarzyna",
                            Email = "jarzyna@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            Name = "Krzysztof",
                            NormalizedEmail = "JARZYNA@GMAIL.COM",
                            NormalizedUserName = "JARZYNA@GMAIL.COM",
                            PasswordHash = "AIyZbEQ9YiK6/8lZAWM0cly21Tq8VsDsQE+ZfvWx1UkhTtt98TuKNyYe6O1YIJlZUg==",
                            PhoneNumber = "666 598 456",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ELYJG2US3WFS3USJUK4BGQPRO3KMM6DO",
                            Surname = "Jarzyna",
                            TwoFactorEnabled = false,
                            UserName = "jarzyna@gmail.com"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "",
                            Displayname = "Jane",
                            Email = "jane_johnson@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            Name = "Jane",
                            NormalizedEmail = "JANE_JOHNSON@GMAIL.COM",
                            NormalizedUserName = "JANE_JOHNSON@GMAIL.COM",
                            PasswordHash = "ABAerZJsh9tNiWoUuA7l0ag8/KAl3epUfSI3zip8iCCRQ0fCW8mbef/0MrRruvoaaA==",
                            PhoneNumber = "666 598 456",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "SCJSULCVZEC54SKQZYNTPY55OWTVFN6K",
                            Surname = "Johnson",
                            TwoFactorEnabled = false,
                            UserName = "jane_johnson@gmail.com"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "",
                            Displayname = "willmich",
                            Email = "michaelww@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            Name = "Michael",
                            NormalizedEmail = "MICHAELWW@GMAIL.COM",
                            NormalizedUserName = "MICHAELWW@GMAIL.COM",
                            PasswordHash = "ACdw7/3VTJ2dOjRuZ9ehbdQwjbIRPBGgbOwNhn36+v54e9o2ZcZ18bRx76my2TGyfA==",
                            PhoneNumber = "987 654 321",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "XOPWIDXRJ2MLZCC7WCUP7UTULBVFACEH",
                            Surname = "Williams",
                            TwoFactorEnabled = false,
                            UserName = "michaelww@gmail.com"
                        },
                        new
                        {
                            Id = 5,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "",
                            Displayname = "william",
                            Email = "joneswilliam@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            Name = "William",
                            NormalizedEmail = "JONESWILLIAM@GMAIL.COM",
                            NormalizedUserName = "JONESWILLIAM@GMAIL.COM",
                            PasswordHash = "AO0zXjP/C0TdDRO2Gt7JjkFu0mgwDuYAEpmsj2ZDgSiMCDC+/PmIoDJtvYZf3Jzcqw==",
                            PhoneNumber = "123 456 789",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "CXHR6NTRYKFSZDEVLF7SI5YM7SQYLXWG",
                            Surname = "Jones",
                            TwoFactorEnabled = false,
                            UserName = "joneswilliam@gmail.com"
                        },
                        new
                        {
                            Id = 6,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "",
                            Displayname = "brownie",
                            Email = "oliviab@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            Name = "Olivia",
                            NormalizedEmail = "OLIVIAB@GMAIL.COM",
                            NormalizedUserName = "OLIVIAB@GMAIL.COM",
                            PasswordHash = "AARX6N7OZVNL9Ww6mizN7gitOj3FGYnPCMJldeCHsr5IsRNpw+yddkWpVtHbBvcU2w==",
                            PhoneNumber = "666 598 456",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "BR2YJ5OBUV55DBWPO7M4SGXPCVKTH66R",
                            Surname = "Brown",
                            TwoFactorEnabled = false,
                            UserName = "oliviab@gmail.com"
                        });
                });

            modelBuilder.Entity("YourScheduler.Infrastructure.Entities.ApplicationUserEvent", b =>
                {
                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("ApplicationUsersEvents");

                    b.HasData(
                        new
                        {
                            ApplicationUserId = 1,
                            EventId = 1
                        },
                        new
                        {
                            ApplicationUserId = 2,
                            EventId = 2
                        },
                        new
                        {
                            ApplicationUserId = 2,
                            EventId = 3
                        },
                        new
                        {
                            ApplicationUserId = 2,
                            EventId = 4
                        },
                        new
                        {
                            ApplicationUserId = 3,
                            EventId = 4
                        },
                        new
                        {
                            ApplicationUserId = 4,
                            EventId = 5
                        },
                        new
                        {
                            ApplicationUserId = 5,
                            EventId = 5
                        },
                        new
                        {
                            ApplicationUserId = 6,
                            EventId = 6
                        });
                });

            modelBuilder.Entity("YourScheduler.Infrastructure.Entities.ApplicationUserTeam", b =>
                {
                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("ApplicationUsersTeams");

                    b.HasData(
                        new
                        {
                            ApplicationUserId = 1,
                            TeamId = 1
                        },
                        new
                        {
                            ApplicationUserId = 2,
                            TeamId = 2
                        },
                        new
                        {
                            ApplicationUserId = 2,
                            TeamId = 3
                        },
                        new
                        {
                            ApplicationUserId = 2,
                            TeamId = 4
                        },
                        new
                        {
                            ApplicationUserId = 3,
                            TeamId = 4
                        },
                        new
                        {
                            ApplicationUserId = 4,
                            TeamId = 4
                        },
                        new
                        {
                            ApplicationUserId = 5,
                            TeamId = 5
                        },
                        new
                        {
                            ApplicationUserId = 5,
                            TeamId = 6
                        },
                        new
                        {
                            ApplicationUserId = 6,
                            TeamId = 5
                        },
                        new
                        {
                            ApplicationUserId = 6,
                            TeamId = 6
                        });
                });

            modelBuilder.Entity("YourScheduler.Infrastructure.Entities.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("administratorId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            Date = new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Koncert z okazji urodzin TVP",
                            IsOpen = true,
                            Name = "Koncert Zenka Martyniuka",
                            administratorId = 1
                        },
                        new
                        {
                            EventId = 2,
                            Date = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Wyjątkowe spotkanie z autorami bestsellerowych książek",
                            IsOpen = true,
                            Name = "Spotkanie Literackie: Autorzy Bestsellerów",
                            administratorId = 1
                        },
                        new
                        {
                            EventId = 3,
                            Date = new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Spektakl muzyczny pełen magii i emocji",
                            IsOpen = true,
                            Name = "Występ Teatru Muzycznego: Magiczna Melodia",
                            administratorId = 2
                        },
                        new
                        {
                            EventId = 4,
                            Date = new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Najnowsze trendy i innowacje technologiczne na światowym poziomie",
                            IsOpen = true,
                            Name = "Konferencja Technologiczna: Przyszłość Innowacji",
                            administratorId = 3
                        },
                        new
                        {
                            EventId = 5,
                            Date = new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Przyjemny wieczór filmowy z wyjątkowymi produkcjami z całego świata",
                            IsOpen = false,
                            Name = "Sesja Filmowa: Kino bez Granic",
                            administratorId = 4
                        },
                        new
                        {
                            EventId = 6,
                            Date = new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Wyjątkowy pokaz kulinarny, podczas którego można odkryć smaki z różnych zakątków świata",
                            IsOpen = false,
                            Name = "Pokaz Kulinarny: Świat Smaków",
                            administratorId = 5
                        },
                        new
                        {
                            EventId = 7,
                            Date = new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Niezwykłe przedstawienie teatralne pełne emocji i wrażeń",
                            IsOpen = true,
                            Name = "Sztuka na Scenie: Wieczór Teatru",
                            administratorId = 6
                        });
                });

            modelBuilder.Entity("YourScheduler.Infrastructure.Entities.HomeView", b =>
                {
                    b.Property<int>("HomeViewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HomeViewId"));

                    b.Property<string>("GeneralInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HomeViewId");

                    b.ToTable("HomeViews");

                    b.HasData(
                        new
                        {
                            HomeViewId = 1,
                            GeneralInfo = "Sciezka do jpg",
                            ImgPath = "/Pictures/harmonogram_870x450_a.jpg"
                        });
                });

            modelBuilder.Entity("YourScheduler.Infrastructure.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            AdministratorId = 0,
                            Description = "Grupa szkółki pływackiej Argonaut",
                            Name = "Grupa początkująca basen Chełm"
                        },
                        new
                        {
                            TeamId = 2,
                            AdministratorId = 0,
                            Description = "Grupa zrzeszająca mieszkańców osiedla Lawendowe Wzgórze w Gdańsku",
                            Name = "Mieszkańcy osiedla Lawendowe Wzgórze"
                        },
                        new
                        {
                            TeamId = 3,
                            AdministratorId = 0,
                            Description = "Zapraszamy do naszego kreatywnego warsztatu artystycznego, gdzie możesz rozwijać swoje umiejętności w różnych dziedzinach sztuki.",
                            Name = "Kreatywny Warsztat Artystyczny"
                        },
                        new
                        {
                            TeamId = 4,
                            AdministratorId = 0,
                            Description = "Dołącz do naszego klubu fitness i wellness, gdzie możesz ćwiczyć, relaksować się i dbać o swoje zdrowie pod okiem profesjonalnych instruktorów.",
                            Name = "Klub Fitness i Wellness"
                        },
                        new
                        {
                            TeamId = 5,
                            AdministratorId = 0,
                            Description = "Zapraszamy do naszego klubu fotograficznego, gdzie pasjonaci fotografii mogą się spotkać, dzielić się wiedzą i rozwijać swoje umiejętności fotograficzne.",
                            Name = "Klub Fotograficzny Obiektyw"
                        },
                        new
                        {
                            TeamId = 6,
                            AdministratorId = 0,
                            Description = "Nasze studio tańca Ritmo oferuje różnorodne style taneczne dla osób w każdym wieku, bez względu na poziom zaawansowania.",
                            Name = "Studio Tańca Ritmo"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("YourScheduler.Infrastructure.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("YourScheduler.Infrastructure.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourScheduler.Infrastructure.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("YourScheduler.Infrastructure.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YourScheduler.Infrastructure.Entities.ApplicationUserEvent", b =>
                {
                    b.HasOne("YourScheduler.Infrastructure.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUsersEvents")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourScheduler.Infrastructure.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("YourScheduler.Infrastructure.Entities.ApplicationUserTeam", b =>
                {
                    b.HasOne("YourScheduler.Infrastructure.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUsersTeams")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourScheduler.Infrastructure.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("YourScheduler.Infrastructure.Entities.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUsersEvents");

                    b.Navigation("ApplicationUsersTeams");
                });
#pragma warning restore 612, 618
        }
    }
}
