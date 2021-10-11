-- Table db_version
CREATE TABLE db_version (
  Id int NOT NULL,
  Version varchar(32) NOT NULL,
  Description nvarchar(1024) NOT NULL,
  DateApplied datetime NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE pet (
	Id int NOT NULL AUTO_INCREMENT,
	Name varchar(255) NOT NULL,
	DateOfBirth datetime NOT NULL,
	DateCreated datetime NOT NULL,
	DateUpdated datetime NOT NULL,
	Primary Key (Id)
);

CREATE TABLE owner (
	Id int NOT NULL AUTO_INCREMENT,
	Firstname varchar(255) NOT NULL,
	LastName varchar(255) NOT NULL,
	DateCreated datetime NOT NULL,
	DateUpdated datetime NOT NULL,
	Primary Key (Id)
);

CREATE TABLE pet_owner (
	PetId INT NOT NULL,
	OwnerId INT NOT NULL,
	Primary Key (PetId, OwnerId),
	CONSTRAINT FK_pet_owner_pet
		FOREIGN KEY (PetId)
		REFERENCES Pet (Id) ON DELETE CASCADE,
	CONSTRAINT FK_pet_owner_owner
		FOREIGN KEY (OwnerId)
		REFERENCES Owner (Id) ON DELETE CASCADE
);