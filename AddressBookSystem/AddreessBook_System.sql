select * from AddressBook
select * from AddressBookCategory

INSERT INTO AddressBook Values
('Geetha','Pai','Sirsi','Sirsi', 'Karnataka','581336','6284519537','geethapai@gmail.com'),
('Ramanath','Pai','Kumata','Kumta', 'Karnataka','581441','6824531296','ramanath@gmail.com'),
('Akshay','Kamath','Sagar','Sagar', 'Karnataka','581477','9173842682','akshay@gmail.com');

SELECT AddressBookType,  COUNT(AddressBookType) from AddressBook group by AddressBookType

Alter table AddressBook add AddressBookID int foreign key references AddressBookCategory

delete from AddressBook where FirstName = 'Ramanath'

AlTER table AddressBook drop column AddressBookID