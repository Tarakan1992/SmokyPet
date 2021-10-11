INSERT INTO `pet`
(`Id`, `Name`, `DateOfBirth`, `DateCreated`, `DateUpdated`)
VALUES
( 1, 'Смоки', '2019-11-03 00:00:00', '2021-10-01 15:14:31' , '2021-10-01 15:14:31'),
( 2,  'Соня', '2017-09-20 00:00:00', '2021-10-01 15:14:31' , '2021-10-01 15:14:31');


INSERT INTO `owner`
(`Id`, `Firstname`, `LastName`, `DateCreated`, `DateUpdated`)
VALUES
(1,    'Денис', 'Новогродский', '2021-10-01 15:14:31', '2021-10-01 15:14:31'),
(2, 'Кристина', 'Новогродская', '2021-10-01 15:14:31', '2021-10-01 15:14:31');

INSERT INTO `pet_owner`
(`PetId`, `OwnerId`)
VALUES
( 1, 1),
( 2, 2);



