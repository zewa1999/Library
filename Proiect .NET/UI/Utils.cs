//using Library.DomainLayer;
//using Library.ServiceLayer.IServices;
//using Proiect_.NET.Injection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Proiect_.NET.UI
//{
//    public static class Utils
//    {
//        static Utils()
//        {
//            Injector.Initialize();
//        }

//        public static void ManageLibrary(int selectedAction, int selectedItem)
//        {
//            switch (selectedItem)
//            {
//                // Books
//                case 1:
//                    ManageBooks(selectedAction);
//                    break;

//                // Domains
//                case 2:
//                    ManageDomains(selectedAction);
//                    break;

//                // Authors
//                case 3:
//                    ManageAuthors(selectedAction);
//                    break;

//                // Thresholds
//                case 7:
//                    ManageThresholds(selectedAction);
//                    break;

//                default:
//                    break;
//            }

//            Console.ReadKey();
//        }

//        private static void ManageBooks(int selectedAction)
//        {
//            IBookService service = Injector.Create<IBookService>();
//            switch (selectedAction)
//            {
//                // Get all books.
//                case 1:
//                    foreach (Book book in service.GetAll(null, book => book.OrderBy(x => x.Id), null))
//                    {
//                        Console.WriteLine(book.Title);
//                    }

//                    break;

//                // Add a new book.
//                case 2:
//                    service.Insert(book);
//                    break;

//                // Update book.
//                case 3:
//                    break;

//                // Delete book.
//                case 4:
//                    break;

//                default:
//                    break;
//            }
//        }

//        private static void ManageDomains(int selectedAction)
//        {
//            IDomainServices service = new DomainServicesImplementation();
//            int id = 0;
//            switch (selectedAction)
//            {
//                // Get all domains.
//                case 1:
//                    foreach (Domain domain in service.GetAllDomains())
//                    {
//                        Console.WriteLine(domain.Name);
//                    }

//                    break;

//                // Add a new domain.
//                case 2:
//                    Domain newDomain = new Domain();
//                    newDomain.Name = Console.ReadLine();
//                    id = Convert.ToInt32(Console.ReadLine());
//                    newDomain.ParrentDomain = service.GetDomainById(id);
//                    service.AddDomain(newDomain);
//                    break;

//                // Update domain.
//                case 3:
//                    break;

//                // Delete domain.
//                case 4:
//                    Console.Write("ID: ");
//                    id = Convert.ToInt32(Console.ReadLine());
//                    Domain foundDomain = service.GetDomainById(id);
//                    service.DeleteDomain(foundDomain);
//                    break;

//                default:
//                    break;
//            }
//        }

//        private static void ManageAuthors(int selectedAction)
//        {
//            IAuthorServices service = new AuthorServicesImplementation();
//            switch (selectedAction)
//            {
//                // Get all authors.
//                case 1:
//                    foreach (Author author in service.GetAllAuthors())
//                    {
//                        Console.WriteLine(author.FullName);
//                    }

//                    break;

//                // Add a new author.
//                case 2:
//                    break;

//                // Update author.
//                case 3:
//                    break;

//                // Delete author.
//                case 4:
//                    break;

//                default:
//                    break;
//            }
//        }

//        private static void ManageThresholds(int selectedAction)
//        {
//            IDomainServices service = new DomainServicesImplementation();
//            int id = 0;
//            switch (selectedAction)
//            {
//                // Get all thresholds.
//                case 1:
//                    break;

//                // Add a new threshold.
//                case 2:
//                    AddThresholds();
//                    break;

//                // Update threshold.
//                case 3:
//                    break;

//                // Delete threshold.
//                case 4:
//                    break;

//                default:
//                    break;
//            }
//        }

//        private static void AddDomain()
//        {
//            IDomainServices service = new DomainServicesImplementation();

//            Domain domain = new Domain();
//            domain.Name = "Quantum algorithms";
//            domain.ParrentDomain = service.GetDomainById(6);

//            service.AddDomain(domain);
//        }

//        private static void AddAuthor()
//        {
//            IAuthorServices service = new AuthorServicesImplementation();

//            Author author = new Author();
//            author.FullName = "Martin Fawler";

//            service.AddAuthor(author);
//        }

//        private static void AddThresholds()
//        {
//            List<Threshold> thresholds = new List<Threshold>();

//            Threshold threshold = new Threshold()
//            {
//                ThresholdName = "DOMENII",
//                Value = 3,
//                Description = "O carte nu poate face parte din mai mult de <DOMENII> domenii.",
//            };
//            thresholds.Add(threshold);

//            threshold = new Threshold()
//            {
//                ThresholdName = "NMC",
//                Value = 30,
//                Description = "Un cititor poate imprumuta un numar maxim de carti NMC intr-o perioada PER.",
//            };
//            thresholds.Add(threshold);

//            threshold = new Threshold()
//            {
//                ThresholdName = "PER",
//                Value = 1,
//                Description = "Un cititor poate imprumuta un numar maxim de carti NMC intr-o perioada PER.",
//            };
//            thresholds.Add(threshold);

//            threshold = new Threshold()
//            {
//                ThresholdName = "C",
//                Value = 30,
//                Description = "La un imprumut cititorii pot prelua cel mult C carti.",
//            };
//            thresholds.Add(threshold);

//            threshold = new Threshold()
//            {
//                ThresholdName = "D",
//                Value = 5,
//                Description = "Cititorii nu pot imprumuta mai mult de D carti dintr-un acelasi domeniu in ultimele L luni.",
//            };
//            thresholds.Add(threshold);

//            threshold = new Threshold()
//            {
//                ThresholdName = "L",
//                Value = 6,
//                Description = "Cititorii nu pot imprumuta mai mult de D carti dintr-un acelasi domeniu in ultimele L luni.",
//            };
//            thresholds.Add(threshold);

//            threshold = new Threshold()
//            {
//                ThresholdName = "LIM",
//                Value = 5,
//                Description = "Suma prelungirilor acordate in ultimele 3 luni nu poate depasi o valoare limita LIM.",
//            };
//            thresholds.Add(threshold);

//            threshold = new Threshold()
//            {
//                ThresholdName = "DELTA",
//                Value = 5,
//                Description = "Cititorii nu pot imprumuta aceeasi carte de mai multe ori intr-un interval DELTA specificat.",
//            };
//            thresholds.Add(threshold);

//            threshold = new Threshold()
//            {
//                ThresholdName = "NCZ",
//                Value = 3,
//                Description = "Cititorii Pot imprumuta cel mult NCZ carti intr-o zi.",
//            };
//            thresholds.Add(threshold);

//            threshold = new Threshold()
//            {
//                ThresholdName = "PERSIMP",
//                Value = 50,
//                Description = "Personalul bibliotecii nu poate acorda mai mult de PERSIMP carti intr-o zi.",
//            };
//            thresholds.Add(threshold);

//            IThresholdServices service = new ThresholdServicesImplementation();

//            foreach (Threshold t in thresholds)
//            {
//                service.AddThreshold(t);
//            }
//        }
//    }
//}