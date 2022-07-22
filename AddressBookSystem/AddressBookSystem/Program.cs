using System;
using System.Data.SqlClient;

namespace AddressBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create AddreessBook_System Database
            CreateAddressBookServiceDB();

            //Create AddressBook Table
            CreateAddressBookTable();

            //Insert New Contacts in  AddressBook Table
            InsertContactInAddressBookTable();

            //Update existing Contacts in  AddressBook Table
            UpdateExistingContactInAddressBookTable();

            //Delete existing Contacts in  AddressBook Table by using persons name
            DeleteContactInAddressBookTable();

            //Retrieve the persons city / State by using persons name
            RetrievePersonBelongsToCityByPersonsName();

            //Size of Addressbook by City 
            SizeOfAddressBookByCity();

            //Size of Addressbook by State
            SizeOfAddressBookByState();

            //Sort Persons Name Alphabetically for a given city
            RetrieveEntriesSortedAlphabeticallyByPersonsName();

            //Identify the address book by Name and Type
            IdentifyAddressBookByNameandType(); //UC9

            //Identify the address book by Name and Type
            UpdateAddressBookByNameandType(); //UC9-extended
        }
        //Create New Database
        public static void CreateAddressBookServiceDB()
        {
            string SQL = "CREATE DATABASE AddreessBook_System ";

            string connectingstring = @"Server=localhost;Integrated security=SSPI;database=master";

            SqlConnection connection = new SqlConnection(connectingstring);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Database Created Successfully....");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception :" + e.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        //Create AddressBook Table
        public static void CreateAddressBookTable()
        {
            var SQL = @$"CREATE TABLE AddressBook ( FirstName Varchar(20), LastName Varchar(15), Address Varchar(50), City Varchar(20), State Varchar(20), ZIP int, PhoneNumber Varchar(15), Email Varchar(20) )";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("AddressBook Table Created Successfully");
            Console.ReadKey();
        }

        //Insert New Contacts in  AddressBook Table
        public static void InsertContactInAddressBookTable() 
        {
            var SQL = @$"INSERT INTO AddressBook Values  ('Prateek','Pai','Bangalore','Bangalore', 'Karnataka','560027','99445007207','prateekpai@gmail.com'),
                                                         ('Prateeksha','Pai','Sirsi','Sirsi', 'Karnataka','581336','8945231256','prateeksha@gmail.com'),
                                                         ('Vasanth','Pai','Sirsi','Sirsi', 'Karnataka','581336','9482615957','vasanthpai@gmail.com'),
                                                         ('Geetha','Pai','Sirsi','Sirsi', 'Karnataka','581336','6284519537','geethapai@gmail.com');";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("New contact is Successfully inserted");
            Console.ReadKey();
        }


        //Update existing Contacts in  AddressBook Table
        public static void UpdateExistingContactInAddressBookTable() 
        {
            var SQL = @$"UPDATE AddressBook set Address = 'Dharwad', City = 'Dharwad' where FirstName = 'Prateeksha'";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("Contact is Updated Successfully ");
            Console.ReadKey();
        }

        //Delete existing Contacts in  AddressBook Table by using persons name
        public static void DeleteContactInAddressBookTable() 
        {
            var SQL = @$"DELETE AddressBook WHERE FirstName = 'Geetha'";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("Contact is deleted Successfully ");
            Console.ReadKey();
        }

        //Retrieve the persons city / State by using persons name
        public static void RetrievePersonBelongsToCityByPersonsName() 
        {
            var SQL = @$"Select City, State from AddressBook where FirstName = 'Prateek'";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Person Belongs to {0} - City {1} - State", reader["City"], reader["State"]);
                }
                reader.Close();
            };
            Console.ReadKey();
        }
        //Size of Addressbook by City 
        public static void SizeOfAddressBookByCity() 
        {
            var SQL = @$"select COUNT(City) FROM AddressBook";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine("Size of the AddressBook is " + reader);
            Console.ReadKey();
        }

        //Size of Addressbook by State
        public static void SizeOfAddressBookByState() 
        {
            var SQL = @$"select COUNT(State) FROM AddressBook";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine("Size of the AddressBook is " + reader);
            Console.ReadKey();
        }
        //Sort Persons Name Alphabetically for a given city
        public static void RetrieveEntriesSortedAlphabeticallyByPersonsName() 
        {
            var SQL = @$"SELECT * FROM AddressBook WHERE City = 'Sirsi' ORDER by FirstName ASC";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Person Belongs to {0} - City {1} - State", reader["City"], reader["State"]);
                }
                reader.Close();
            };
            Console.ReadKey();
        }

        //Identify the address book by Name and Type
        public static void IdentifyAddressBookByNameandType() 
        {
            var SQL = @$"ALTER TABLE AddressBook ADD AddressBookName varchar (20),AddressBookType varchar (20)";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("AddressBook Table is Updated Successfully ");
            Console.ReadKey();
        }

        //Identify the address book by Name and Type
        public static void UpdateAddressBookByNameandType()
        {
            var SQL = @$"update AddressBook SET AddressBookName = 'Self', AddressBookType = 'Family' where FirstName = 'Prateek'
                        update AddressBook SET AddressBookName = 'Prateeksha', AddressBookType = 'Friend' where FirstName = 'Prateeksha'
                        update AddressBook SET AddressBookName = 'Vasanth', AddressBookType = 'Family' where FirstName = 'Vasanth'
                        update AddressBook SET AddressBookName = 'Geetha', AddressBookType = 'Family' where FirstName = 'Geetha'
                        update AddressBook SET AddressBookName = 'Ramu', AddressBookType = 'Friend' where FirstName = 'Ramanath'
                        update AddressBook SET AddressBookName = 'Akshay', AddressBookType = 'Profession' where FirstName = 'Akshay'";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=AddreessBook_System;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("AddressBook Table is Updated Successfully ");
            Console.ReadKey();
        }
    }
}
