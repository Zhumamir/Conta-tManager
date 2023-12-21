using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.DAL;
using ContactManager.DAL.Model;

namespace ContactManager.BLL
{
    public class Service
    {
        private IRepository repository;

        public Service(IRepository MyRepository)
        {
            repository = MyRepository;
        }
        //Метод AddContact создает новый объект Contact на основе предоставленных
        //данных и передает его в метод AddContact уровня доступа к данным (repository)
        public void AddContact(string name, string phone, string email)
        {
            var contact = new Contact { Name = name, Phone = phone, Email = email };
            repository.AddContact(contact);
        }

        //Метод GetAllContacts вызывает соответствующий метод уровня доступа к данным (repository) для получения списка всех контактов
        public List<Contact> GetAllContacts()
        {
            return repository.GetAllContacts();
        }

        //Метод DeleteContact вызывает соответствующий метод уровня доступа к данным (repository) для удаления контакта по его идентификатору
        public void DeleteContact(int id)
        {
            repository.DeleteContact(id);
        }

        //Метод EditContact получает существующий контакт по идентификатору из уровня доступа к данным (repository),
        //изменяет его свойства на новые значения и вызывает метод UpdateContact уровня доступа к данным
        public void EditContact(int id, string newName, string newPhone, string newEmail)
        {
            Contact existingContact = repository.GetContactById(id);

            if (existingContact != null)
            {
                existingContact.Name = newName;
                existingContact.Phone = newPhone;
                existingContact.Email = newEmail;

                repository.UpdateContact(existingContact);
            }
            else
            {
                Console.WriteLine("Контакт не найден.");
            }
        }

        //Метод SearchContact вызывает соответствующий метод уровня доступа к данным (repository) для выполнения поиска контактов по строке
        public List<Contact> SearchContact(string stroka)
        {
            return repository.SearchContact(stroka);
        }

        //Метод GetContactById вызывает соответствующий метод уровня доступа к данным (repository) для получения контакта по его идентификатору
        public Contact GetContactById(int id)
        {
            return repository.GetContactById(id);
        }
    }
}
