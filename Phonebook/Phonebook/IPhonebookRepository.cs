using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    interface IPhonebookRepository
    {
        bool AddPhone(string name,


            IEnumerable<string> phoneNumbers);

        int ChangePhone(


            string oldPhoneNumber, string newPhoneNumber);

        Class1[] ListEntries(int startIndex, int count);
    }
}
