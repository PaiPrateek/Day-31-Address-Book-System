--Welcome to Address Book System Problem

--Creating the Address Book Service data base
CREATE DATABASE Address_Book_Service

use Address_Book_Service

--Create AddressBook Table
CREATE TABLE AddressBook
(
FirstName Varchar(20),
LastName Varchar(15),
Address Varchar(50),
City Varchar(20),
State Varchar(20),
ZIP int,
PhoneNumber Varchar(15),
Email Varchar(20)
)

--To View the AddressBook Table
SELECT * FROM AddressBook

--Insert COntacts into AddressBook
INSERT INTO AddressBook Values 
('Prateek','Pai','Bangalore','Bangalore', 'Karnataka','560027','99445007207','prateekpai@gmail.com'),
('Prateeksha','Pai','Sirsi','Sirsi', 'Karnataka','581336','8945231256','prateeksha@gmail.com'),
('Vasanth','Pai','Sirsi','Sirsi', 'Karnataka','581336','9482615957','vasanthpai@gmail.com'),
('Geetha','Pai','Sirsi','Sirsi', 'Karnataka','581336','6284519537','geethapai@gmail.com');

--Edit the existing data in the table
UPDATE AddressBook
set Address = 'Dharwad', City = 'Dharwad' where FirstName = 'Prateeksha' ;

--Delete person using persons name
DELETE AddressBook WHERE FirstName = 'Geetha'

--Retrieve the persons city / State by using persons name
Select City, State from AddressBook where FirstName = 'Prateek'

--Size of Addressbook by City / State
select COUNT(City) FROM AddressBook
select COUNT(State) FROM AddressBook

INSERT INTO AddressBook Values
('Geetha','Pai','Sirsi','Sirsi', 'Karnataka','581336','6284519537','geethapai@gmail.com'),
('Ramanath','Pai','Kumata','Kumta', 'Karnataka','581441','6824531296','ramanath@gmail.com'),
('Akshay','Kamath','Sagar','Sagar', 'Karnataka','581477','9173842682','akshay@gmail.com');

--Sort Persons Name Alphabetically for a given city
SELECT * FROM AddressBook WHERE City = 'Sirsi' ORDER by FirstName ASC

--Identify the address book by Name and Type
ALTER TABLE AddressBook ADD AddressBookName varchar (20),AddressBookType varchar (20);

--Update AddressBook Contact
update AddressBook SET AddressBookName = 'Self', AddressBookType = 'Family' where FirstName = 'Prateek'
update AddressBook SET AddressBookName = 'Prateeksha', AddressBookType = 'Friend' where FirstName = 'Prateeksha'
update AddressBook SET AddressBookName = 'Vasanth', AddressBookType = 'Family' where FirstName = 'Vasanth'
update AddressBook SET AddressBookName = 'Geetha', AddressBookType = 'Family' where FirstName = 'Geetha'
update AddressBook SET AddressBookName = 'Ramu', AddressBookType = 'Friend' where FirstName = 'Ramanath'
update AddressBook SET AddressBookName = 'Akshay', AddressBookType = 'Profession' where FirstName = 'Akshay'