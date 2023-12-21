using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.BLL;
using ContactManager.DAL;

namespace ContaсtManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = "contacts.db";
            IRepository repository = new Repository(Path);
            Service service = new Service(repository);
            Console.WriteLine("МЕНЕДЖЕР КОНТАКТОВ");
            Console.WriteLine();
            Console.WriteLine("Выберите пункт:  ");
            while (true)
            {
                Console.WriteLine("1. Добавить контакт");
                Console.WriteLine("2. Просмотреть все контакты");
                Console.WriteLine("3. Удалить контакт");
                Console.WriteLine("4. Редактировать контакт");
                Console.WriteLine("5. Поиск контакта по строке: ");
                Console.WriteLine("6. Поиск контакта по ID: ");
                Console.WriteLine("0. Выход из программы");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Введите имя: ");
                            string name = Console.ReadLine();
                            Console.Write("Введите телефон: ");
                            string phone = Console.ReadLine();
                            Console.Write("Введите электронную почту: ");
                            string email = Console.ReadLine();
                            service.AddContact(name, phone, email);
                            break;

                        case 2:
                            var contacts = service.GetAllContacts();
                            foreach (var contact in contacts)
                            {
                                Console.WriteLine($"ID: {contact.Id}, Имя: {contact.Name}, Телефон: {contact.Phone}, Email: {contact.Email}");
                            }
                            break;

                        case 3:
                            Console.Write("Введите ID контакта для удаления: ");
                            int deleteId = Convert.ToInt32(Console.ReadLine());
                            service.DeleteContact(deleteId);
                            break;

                        case 4:
                            Console.Write("Введите ID контакта для редактирования: ");
                            int editId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите новое имя: ");
                            string newName = Console.ReadLine();
                            Console.Write("Введите новый телефон: ");
                            string newPhone = Console.ReadLine();
                            Console.Write("Введите новую электронную почту: ");
                            string newEmail = Console.ReadLine();
                            service.EditContact(editId, newName, newPhone, newEmail);
                            break;

                        case 5:
                            Console.Write("Введите строку для поиска: ");
                            string searchTerm = Console.ReadLine();
                            var searchResults = service.SearchContact(searchTerm);
                            foreach (var contact in searchResults)
                            {
                                Console.WriteLine($"ID: {contact.Id}, Имя: {contact.Name}, Телефон: {contact.Phone}, Email: {contact.Email}");
                            }
                            break;

                        case 6:
                            Console.Write("Введите ID контакта для просмотра деталей: ");
                            int detailsId = Convert.ToInt32(Console.ReadLine());
                            var contactDetails = service.GetContactById(detailsId);
                            if (contactDetails != null)
                            {
                                Console.WriteLine($"ID: {contactDetails.Id}, Имя: {contactDetails.Name}, Телефон: {contactDetails.Phone}, Email: {contactDetails.Email}");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Контакт не найден.");
                            }
                            break;

                        case 0:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Неизвестный пункт. Попробуйте снова.");
                            Console.WriteLine();
                            break;
                    }
                } catch (Exception ex) { 
                    Console.WriteLine("Неизвестный символ. Введите пожалуйста число");
                    Console.WriteLine();
                }
            }
        }
    }
}
