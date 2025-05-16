
using System.Collections.Generic;
using System.IO;


namespace _0301_persAddress.Services
{
    public static class DataStorage
    {
        private const string DataFile = "addresses.csv";
        
        public static List<Address> LoadAdress()
        {
            var list = new List<Address>();
            if (!File.Exists(DataFile)) return list;

            foreach (var line in File.ReadAllLines(DataFile))
            {
                var parts = line.Split(',');
                if (parts.Length == 6)
                {
                    list.Add(new Address(
                        parts[0],
                        parts[1],
                        parts[2],
                        parts[3],
                        parts[4],
                        parts[5]
                    ));
                }
            }
            return list;
        }

        public static void SaveAddress(List<Address> addresses)
        {
            using (var w = new StreamWriter(DataFile, false))
            {
                foreach (var a in addresses)
                {
                    w.WriteLine(
                        $"{a.FirstName}," +
                        $"{a.LastName}," +
                        $"{a.Street}," +
                        $"{a.City}," +
                        $"{a.PostalCode}," +
                        $"{a.PhoneNumber}"
                    );
                }
            }
        }
    }
}
