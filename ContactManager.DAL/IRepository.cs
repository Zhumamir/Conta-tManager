using ContactManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DAL
{
    public interface IRepository
    {
        void AddContact(Contact contact);
        List<Contact> GetAllContacts();
        void DeleteContact(int id);
        void UpdateContact(Contact contact);
        List<Contact> SearchContact(string stroka);
        Contact GetContactById(int id);
    }
}
