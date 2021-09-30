-- Table db_version
CREATE TABLE DbVersion (
  Id int NOT NULL,
  Version varchar(32) NOT NULL,
  Description nvarchar(1024) NOT NULL,
  DateApplied datetime NOT NULL,
  PRIMARY KEY (Id)
);