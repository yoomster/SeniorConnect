-- Insert User data and link to AddressID
INSERT INTO [dbo].[User] 
(FirstName, LastName, Email, Password, DateOfBirth, Gender, Origin, DateOfRegistration, AddressID)
VALUES
    ('Jan', 'Jansen', 'jan.jansen@example.com', 'Password123!', '1950-04-12', 'M', 'Dutch', '2020-05-10', 1),
    ('Maria', 'de Vries', 'maria.vries@example.com', 'Password123!', '1942-09-15', 'F', 'Dutch', '2019-08-25', 2),
    ('Pieter', 'Kramer', 'pieter.kramer@example.com', 'Password123!', '1958-11-22', 'M', 'Dutch', '2021-01-17', 3),
    ('Anke', 'Bakker', 'anke.bakker@example.com', 'Password123!', '1945-02-19', 'F', 'Dutch', '2023-03-12', 4),
    ('Henk', 'Peters', 'henk.peters@example.com', 'Password123!', '1949-06-01', 'M', 'Dutch', '2022-12-30', 5),
    ('Emma', 'Kuipers', 'emma.kuipers@example.com', 'Password123!', '1935-12-15', 'F', 'Dutch', '2023-04-22', 6),
    ('Joop', 'Smit', 'joop.smit@example.com', 'Password123!', '1940-03-03', 'M', 'Dutch', '2020-11-08', 7),
    ('Sophie', 'Visser', 'sophie.visser@example.com', 'Password123!', '1947-07-21', 'F', 'Dutch', '2021-07-13', 8),
    ('Tom', 'de Boer', 'tom.boer@example.com', 'Password123!', '1938-01-01', 'M', 'Dutch', '2023-10-02', 9),
    ('Eva', 'Jong', 'eva.jong@example.com', 'Password123!', '1955-08-10', 'F', 'Dutch', '2022-02-18', 10),
    ('Karel', 'Vos', 'karel.vos@example.com', 'Password123!', '1946-05-20', 'M', 'Dutch', '2021-09-25', 11),
    ('Inge', 'Mulder', 'inge.mulder@example.com', 'Password123!', '1944-09-14', 'F', 'Dutch', '2020-06-29', 12),
    ('Bart', 'Vermeer', 'bart.vermeer@example.com', 'Password123!', '1950-12-31', 'M', 'Dutch', '2023-11-11', 13),
    ('Els', 'Schouten', 'els.schouten@example.com', 'Password123!', '1937-02-02', 'F', 'Dutch', '2020-02-10', 14),
    ('Frank', 'Groen', 'frank.groen@example.com', 'Password123!', '1948-03-15', 'M', 'Dutch', '2021-03-03', 15),
    ('Lieke', 'Willems', 'lieke.willems@example.com', 'Password123!', '1939-09-07', 'F', 'Dutch', '2022-04-16', 16),
    ('Wim', 'van Dijk', 'wim.dijk@example.com', 'Password123!', '1943-11-05', 'M', 'Dutch', '2023-07-24', 17),
    ('Clara', 'Smits', 'clara.smits@example.com', 'Password123!', '1942-04-09', 'F', 'Dutch', '2021-10-18', 18),
    ('Rik', 'Hofman', 'rik.hofman@example.com', 'Password123!', '1936-07-22', 'M', 'Dutch', '2022-01-10', 19),
    ('Noor', 'Heemskerk', 'noor.heemskerk@example.com', 'Password123!', '1941-06-13', 'F', 'Dutch', '2020-08-15', 20);
