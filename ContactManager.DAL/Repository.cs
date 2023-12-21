using ContactManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using LiteDB;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DAL
{
    public class Repository : IRepository
    {
        private readonly LiteDatabase db;
        private readonly LiteCollection<Contact> contacts;

        public Repository(string Path)
        {
            db = new LiteDatabase(Path);
            contacts = db.GetCollection<Contact>("contacts");
        }

        //Метод AddContact добавляет новый контакт в коллекцию базы данных
        public void AddContact(Contact contact)
        {
            contacts.Insert(contact);
        }

        //Метод GetAllContacts возвращает список всех контактов из коллекции базы данных
        public List<Contact> GetAllContacts()
        {
            return contacts.FindAll().ToList();
        }

        //Метод DeleteContact удаляет контакт из коллекции базы данных по его идентификатору
        public void DeleteContact(int id)
        {
            contacts.Delete(id);
        }

        //Метод UpdateContact обновляет информацию о контакте в коллекции базы данных
        public void UpdateContact(Contact contact)
        {
            contacts.Update(contact);
        }

        //Метод SearchContact выполняет поиск контактов в коллекции базы данных по заданной строке.
        //Поиск осуществляется в свойствах Name, Phone и Email контакта, игнорируя регистр
        public List<Contact> SearchContact(string stroka)
        {
            return contacts.Find(c =>
                    c.Name.IndexOf(stroka, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    c.Phone.IndexOf(stroka, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    c.Email.IndexOf(stroka, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        //Метод GetContactById возвращает контакт из коллекции базы данных по его идентификатору
        public Contact GetContactById(int id)
        {
            return contacts.FindById(id);
        }
    }
}
