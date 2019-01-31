Link for ER Diagram:
https://www.lucidchart.com/invitations/accept/570f4773-2886-4f55-b17c-48768d7dfef5

S3697158

Advantage of social media login:
- New users do not need to create a 'local account' for the website and can use their preferred social media login (google/facebook/twitter)
- Organisations don't need to store the data/password of the new user, meaning they are not liable if the accounts registered through external social media login gets compromised
- Ease of use for new users


bootstrap.css -- 7520-7523 lines omitted this: cancelled...
.mb-3,
.my-3 {
  margin-bottom: 1rem !important;
}


Microsoft.VisualStudio.Web.CodeGeneration.Tools has been deprecated in favor of dotnet-aspnet-codegenerator
https://github.com/aspnet/Tooling/issues/1075

Scaffolding 
dotnet aspnet-codegenerator controller -name StaffController -m Staff -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet aspnet-codegenerator controller -name StudentController -m Student -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet aspnet-codegenerator controller -name RoomController -m Room -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet aspnet-codegenerator controller -name SlotController -m Slot -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries


Add -f to overwrite

dotnet aspnet-codegenerator razorpage -m Slot -dc SlotDbContext -udl -outDir Pages/Slots --referenceScriptLibraries


Migration commands:
dotnet ef migrations add Initial
dotnet ef database update


Creating new clean project with authentication:
dotnet new mvc -o test project -uld --auth Individual




SQL Scripts:

create table Room
(
	RoomID nvarchar(10) not null,
	constraint PK_Room primary key (RoomID)
);

create table Staff
(
	UserID nvarchar(6) not null,
	Name nvarchar(max) not null,
	Email nvarchar(max) not null,
    	constraint PK_User primary key (UserID)
);

create table Student
(
	UserID nvarchar(8) not null,
	Name nvarchar(max) not null,
	Email nvarchar(max) not null,
    	constraint PK_User primary key (UserID)
);

create table Slot
(
    	RoomID nvarchar(10) not null,
	StartTime datetime2 not null,
 	StaffID nvarchar(6) not null,
    	BookedInStudentID nvarchar(8) null,
 	constraint PK_Slot primary key (RoomID, StartTime),
	constraint FK_Slot_Room foreign key (RoomID) references Room (RoomID),
	constraint FK_Slot_Staff foreign key (StaffID) references Staff (UserID),
	constraint FK_Slot_Student foreign key (BookedInStudentID) references Student (UserID)
);



insert into Room (RoomID) values ('A');
insert into Room (RoomID) values ('B');
insert into Room (RoomID) values ('C');
insert into Room (RoomID) values ('D');

insert into [Staff] (UserID, Name, Email) values ('e12345', 'Matt', 'e12345@rmit.edu.au');
insert into [Staff] (UserID, Name, Email) values ('e56789', 'Joe', 'e56789@rmit.edu.au');

insert into [Student] (UserID, Name, Email) values ('s1234567', 'Kevin', 's1234567@student.rmit.edu.au');
insert into [Student] (UserID, Name, Email) values ('s4567890', 'Olivier', 's4567890@student.rmit.edu.au');
