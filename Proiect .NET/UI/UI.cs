namespace Proiect_.NET.UI
{
    using Library.DomainLayer;
    using Library.DomainLayer.Person;
    using Library.ServiceLayer.Services;
    using Proiect_.NET.Injection;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UI
    {
        public static void Main(String[] args)
        {
            Injector.Initialize();

            //var propertiesFlag = EndToEndProperties();
            var flag8 = EndToEndBook();
            //var flag7 = EndToEndAuthor();
            //var flag6 = EndToEndDomain();
            //var flag5 = EndToEndLibrarian();
            //var flag4 = EndToEndBorrower();
            //var flag3 = EndToEndEdition();
            //var flag2 = EndToEndProperties();
            //var flag1 = EndToEndAccount();
            Console.WriteLine(flag8);
        }

        private static bool EndToEndBook()
        {
            var service = Injector.Create<BookService>();

            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
            };

            var domain = new Domain()
            {
                Name = "Stiinta",
                ParentDomain = null,
                ChildrenDomains = new List<Domain>()
            };

            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com"
            };

            var edition = new Edition()
            {
                Publisher = "Cartea studentilor saraci",
                Year = "1999",
                EditionNumber = int.MaxValue,
                NumberOfPages = 25
            };

            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account
            };

            var book = new Book()
            {
                Title = "Head first design patters",
                LecturesOnlyBook = false,
                IsBorrowed = false,
                Type = "Hard  cover",
                Authors = new List<Author>() { author },
                Domains = new List<Domain>() { domain },
                Editions = new List<Edition>() { edition },
            };

            //if (service.Insert(book) == false)
            //{
            //    Console.WriteLine("A crapat la insert!");
            //    return false;
            //}

            //if (service.GetByID(1) == null)
            //{
            //    Console.WriteLine("A crapat la GetByID!");
            //    return false;
            //}

            if (service.GetAll(null, book => book.OrderBy(x => x.Id), "") == null)
            {
                Console.WriteLine("A crapat la Get!");
                return false;
            }

            var entity = service.GetByID(1);
            var domains = entity.Domains.ToList();
            var childrenDomains = domains[0].ChildrenDomains;
            if (entity != null)
            {
                Console.WriteLine("A mers GetByID!");
                entity.Title = "Idiot things in programming";
                if (service.Update(entity) == false)
                {
                    Console.WriteLine("A crapat Update!");
                    return false;
                }
            }

            if (service.DeleteById(1) == false)
            {
                Console.WriteLine("A crapat Delete!");
                return false;
            }

            return true;
        }

        private static bool EndToEndDomain()
        {
            var service = Injector.Create<DomainService>();

            var domain = new Domain()
            {
                Name = "Literatura",
                ParentDomain = null,
                ChildrenDomains = new List<Domain>(),
            };

            if (service.Insert(domain) == false)
            {
                Console.WriteLine("A crapat la insert!");
                return false;
            }

            if (service.GetByID(1) == null)
            {
                Console.WriteLine("A crapat la GetByID!");
                return false;
            }

            if (service.GetAll(null, book => book.OrderBy(x => x.Id), "") == null)
            {
                Console.WriteLine("A crapat la Get!");
                return false;
            }

            var entity = service.GetByID(1);

            if (entity.ChildrenDomains == null)
            {
                entity.ChildrenDomains = new List<Domain>();
                entity.ChildrenDomains.Add(
                    new Domain()
                    {
                        Name = "Proza",
                        ParentDomain = domain,
                        ChildrenDomains = new List<Domain>()
                    });
            }
            else if (entity.ChildrenDomains.Count == 0)
            {
                entity.ChildrenDomains.Add(
                    new Domain()
                    {
                        Name = "Proza",
                        ParentDomain = domain,
                        ChildrenDomains = new List<Domain>()
                    });
            }
            else
            {
                entity.ChildrenDomains.Add(
                    new Domain()
                    {
                        Name = "Proza",
                        ParentDomain = domain,
                        ChildrenDomains = new List<Domain>()
                    });
            }

            if (entity != null)
            {
                Console.WriteLine("A mers GetByID!");
                entity.Name = "Stiinta";
                if (service.Update(entity) == false)
                {
                    Console.WriteLine("A crapat Update!");
                    return false;
                }
            }

            if (service.DeleteById(1) == false)
            {
                Console.WriteLine("A crapat Delete!");
                return false;
            }

            return true;
        }

        private static bool EndToEndLibrarian()
        {
            var service = Injector.Create<LibrarianService>();

            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com"
            };

            var borrower = new Librarian()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                IsReader = true,
                Account = account
            };

            if (service.Insert(borrower) == false)
            {
                Console.WriteLine("A crapat la insert!");
                return false;
            }

            if (service.GetByID(1) == null)
            {
                Console.WriteLine("A crapat la GetByID!");
                return false;
            }

            if (service.GetAll(null, book => book.OrderBy(x => x.Id), "") == null)
            {
                Console.WriteLine("A crapat la Get!");
                return false;
            }

            var entity = service.GetByID(2);
            if (entity != null)
            {
                Console.WriteLine("A mers GetByID!");
                entity.Address = "strada Gneral Mihai";
                if (service.Update(entity) == false)
                {
                    Console.WriteLine("A crapat Update!");
                    return false;
                }
            }

            if (service.DeleteById(2) == false)
            {
                Console.WriteLine("A crapat Delete!");
                return false;
            }

            return true;
        }

        private static bool EndToEndBorrower()
        {
            var service = Injector.Create<BorrowerService>();

            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com"
            };

            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account
            };

            if (service.Insert(borrower) == false)
            {
                Console.WriteLine("A crapat la insert!");
                return false;
            }

            if (service.GetByID(1) == null)
            {
                Console.WriteLine("A crapat la GetByID!");
                return false;
            }

            if (service.GetAll(null, book => book.OrderBy(x => x.Id), "") == null)
            {
                Console.WriteLine("A crapat la Get!");
                return false;
            }

            var entity = service.GetByID(1);
            if (entity != null)
            {
                Console.WriteLine("A mers GetByID!");
                entity.Address = "strada Gneral Mihai";
                if (service.Update(entity) == false)
                {
                    Console.WriteLine("A crapat Update!");
                    return false;
                }
            }

            if (service.DeleteById(1) == false)
            {
                Console.WriteLine("A crapat Delete!");
                return false;
            }

            return true;
        }

        private static bool EndToEndAuthor()
        {
            var service = Injector.Create<AuthorService>();
            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel"
            };

            if (service.Insert(author) == false)
            {
                Console.WriteLine("A crapat la insert!");
                return false;
            }

            if (service.GetByID(1) == null)
            {
                Console.WriteLine("A crapat la GetByID!");
                return false;
            }

            if (service.GetAll(null, book => book.OrderBy(x => x.Id), "") == null)
            {
                Console.WriteLine("A crapat la Get!");
                return false;
            }

            var entity = service.GetByID(1);
            if (entity != null)
            {
                Console.WriteLine("A mers GetByID!");
                entity.LastName = "Garcea";
                if (service.Update(entity) == false)
                {
                    Console.WriteLine("A crapat Update!");
                    return false;
                }
            }

            if (service.DeleteById(1) == false)
            {
                Console.WriteLine("A crapat Delete!");
                return false;
            }

            return true;
        }

        private static bool EndToEndEdition()
        {
            var service = Injector.Create<EditionService>();
            var edition = new Edition()
            {
                Publisher = "Cartea studentilor saraci",
                Year = "1999",
                EditionNumber = int.MaxValue,
                NumberOfPages = 5
            };

            if (service.Insert(edition) == false)
            {
                Console.WriteLine("A crapat la insert!");
                return false;
            }

            if (service.GetByID(1) == null)
            {
                Console.WriteLine("A crapat la GetByID!");
                return false;
            }

            if (service.GetAll(null, book => book.OrderBy(x => x.Id), "") == null)
            {
                Console.WriteLine("A crapat la Get!");
                return false;
            }

            var entity = service.GetByID(1);
            if (entity != null)
            {
                Console.WriteLine("A mers GetByID!");
                entity.Year = "2072";
                if (service.Update(entity) == false)
                {
                    Console.WriteLine("A crapat Update!");
                    return false;
                }
            }

            if (service.DeleteById(1) == false)
            {
                Console.WriteLine("A crapat Delete!");
                return false;
            }

            return true;
        }

        private static bool EndToEndProperties()
        {
            var service = Injector.Create<PropertiesService>();

            var properties = new Properties()
            {
                Domenii = 2,
                NumarMaximCarti = 3,
                L = 2,
                NrMaximCartiImprumutate = 3,
                NrMaximCartiImprumutateAcelasiDomeniu = 2,
                LimitaMaximaImprumut = 2,
                Delta = 3,
                NumarCartiImprumutateZilnic = 4,
                Persimp = 3,
                Perioada = 3
            };

            if (service.Insert(properties) == false)
            {
                Console.WriteLine("A crapat la insert!");
                return false;
            }

            if (service.GetByID(1) == null)
            {
                Console.WriteLine("A crapat la GetByID!");
                return false;
            }

            if (service.GetAll(null, book => book.OrderBy(x => x.Id), "") == null)
            {
                Console.WriteLine("A crapat la Get!");
                return false;
            }

            var entity = service.GetByID(2);
            if (entity != null)
            {
                Console.WriteLine("A mers GetByID!");
                entity.NumarMaximCarti = 2;
                entity.Perioada = 8;
                if (service.Update(entity) == false)
                {
                    Console.WriteLine("A crapat Update!");
                    return false;
                }
            }

            //if (service.DeleteById(1) == false)
            //{
            //    Console.WriteLine("A crapat Delete!");
            //    return false;
            //}

            return true;
        }

        private static bool EndToEndAccount()
        {
            var service = Injector.Create<AccountService>();

            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "validemail@gmail.com"
            };

            if (service.Insert(account) == false)
            {
                Console.WriteLine("A crapat la insert!");
                return false;
            }

            if (service.GetByID(2) == null)
            {
                Console.WriteLine("A crapat la GetByID!");
                return false;
            }

            if (service.GetAll(null, book => book.OrderBy(x => x.Id), "") == null)
            {
                Console.WriteLine("A crapat la Get!");
                return false;
            }

            var entity = service.GetByID(2);
            if (entity != null)
            {
                Console.WriteLine("A mers GetByID!");
                entity.Email = "validmain123@mail.com";
                if (service.Update(entity) == false)
                {
                    Console.WriteLine("A crapat Update!");
                    return false;
                }
            }

            if (service.DeleteById(2) == false)
            {
                Console.WriteLine("A crapat Delete!");
                return false;
            }

            return true;
        }

        //{
        //    private static readonly List<string> Menu1 = new List<string>()
        //    {
        //        "    1. List all...",
        //        "    2. Add new...",
        //        "    3. Update...",
        //        "    4. Delete...",
        //        "    0. Exit App...",
        //    };

        //    private static readonly List<string> Menu2 = new List<string>()
        //    {
        //        "    1. ...books",
        //        "    2. ...domains",
        //        "    3. ...authors",
        //        "    4. ...editions",
        //        "    5. ...users",
        //        "    6. ...borrowed books",
        //        "    7. ...thresholds",
        //        "    0. Back",
        //    };

        //    private static void Main(string[] args)
        //    {
        //        int selectedAction = 0, selectedItem = 0, exit = 0;

        //        while (exit != 1)
        //        {
        //            do
        //            {
        //                Console.Clear();
        //                Console.WriteLine("\n Hello user!\n");
        //                PrintMenu(Menu1);
        //                selectedAction = Convert.ToInt32(Console.ReadLine());
        //            }
        //            while (selectedAction < 0 || selectedAction > Menu1.Count);

        //            if (selectedAction == 0)
        //            {
        //                exit = 1;
        //            }
        //            else
        //            {
        //                do
        //                {
        //                    Console.Clear();
        //                    PrintMenu(Menu2);
        //                    selectedItem = Convert.ToInt32(Console.ReadLine());
        //                }
        //                while (selectedItem < 0 || selectedItem > Menu2.Count);

        //                if (selectedItem != 0)
        //                {
        //                    Utils.ManageLibrary(selectedAction, selectedItem);

        //                    Console.WriteLine("\n Done! Press any key to continue...");
        //                }
        //            }
        //        }
        //    }

        //    private static void PrintMenu(List<string> menu)
        //    {
        //        Console.WriteLine("\n Choose an option:");

        //        foreach (string menuItem in menu)
        //        {
        //            Console.WriteLine(menuItem);
        //        }

        //        Console.Write("\n Option: ");
        //    }
    }
}