
using _0301_persAddress.Views;
using _0301_persAddress.Services;

namespace _0301_persAddress

{
    class Program
    {
        static void Main()
        {
            AddressBookManager addressBook = new AddressBookManager();
            Menu menu = new Menu(addressBook);
            menu.DisplayMenu();
        }
    }
}
