drop database IF EXISTS TransportCompany;
DROP TYPE IF EXISTS CategoryType;
drop rule IF EXISTS CategoryRule;
drop default IF EXISTS CategoryDefault;
DROP TYPE IF EXISTS ControlTypeType;
drop rule IF EXISTS ControlTypeRule;
drop default IF EXISTS ControlTypeDefault;
drop view IF EXISTS Buses;
drop view IF EXISTS Waybills;
drop view IF EXISTS Trolleybuses;

create database TransportCompany;
go 
use TransportCompany;
go


create type CategoryType from nvarchar(3);
go
create rule CategoryRule as @category in ('D', 'DE', 'D1', 'D1E', 'Tb');
go
create default CategoryDefault as 'D';
go

create type ControlTypeType from nvarchar(10);
go
create rule ControlTypeRule as @category in ('НСУ', 'РКСУ', 'РКСУ+', 'ТИСУ', 'ТрСУ');
go
create default ControlTypeDefault as 'РКСУ';
go

create table Tariff(
id int primary key identity(1,1),
name nvarchar(90) not null,
price money not null,
validityPeriod int null,
description nvarchar(990) not null,
tripCount int null)

create table TariffZone(
id int primary key identity(1,1),
name nvarchar(90) not null,
description nvarchar(990) not null,
coefficient float not null)

create table Passenger(
phoneNumber nvarchar(15) primary key,
pass nvarchar(190) not null,
firstName nvarchar(90) not null,
secondName nvarchar(90) not null,
patronym nvarchar(90) not null,
birthDate date not null)

create table Ticket(
id int primary key identity(1,1),
phonePassenger nvarchar(15) not null,
idTariff int not null,
idTariffZone int not null,
expiration datetime null,
tripRemains int null,
purchaseTime datetime not null,
constraint FK_TicketPassenger foreign key (phonePassenger) references Passenger(phoneNumber) on delete cascade on update cascade,
constraint FK_TicketTariff foreign key (idTariff) references Tariff(id) on delete cascade on update cascade,
constraint FK_TicketTariffZone foreign key (idTariffZone) references TariffZone(id) on delete cascade on update cascade)

create table Employee(
id int primary key identity(1,1),
passport int not null,
snils int not null,
oms int not null,
firstName nvarchar(90) not null,
secondName nvarchar(90) not null,
patronym nvarchar(90) null,
birthDate date not null,
registrationPlace nvarchar(90) null,
photo nvarchar(190) not null,
experience int not null)

create table Controller(
id int primary key,
constraint FK_ControllerEmployee foreign key (id) references Employee(id) on delete cascade on update cascade)

create table Driver(
id int primary key,
licenseNumber int not null,
licenceDate date not null,
constraint FK_DriverEmployee foreign key (id) references Employee(id) on delete cascade on update cascade)

create table Category(
name CategoryType primary key,
transcript nvarchar(90))

create table DriverCategory(
idCategory CategoryType not null,
idDriver int not null,
constraint FK_DriverCategoryCategory foreign key (idCategory) references Category(name) on delete cascade on update cascade,
constraint FK_DriverCategoryDriver foreign key (idDriver) references Driver(id) on delete cascade on update cascade)

create table Depot(
number int primary key,
address nvarchar(90) not null)

create table Stock(
number nvarchar(90) primary key,
depotNumber int null,
manufacturer nvarchar(90) not null,
manufactureYear int not null,
insurance nvarchar(90) not null,
photo nvarchar(190) not null,
constraint FK_StockDepot foreign key (depotNumber) references Depot(number) on delete cascade on update cascade)

create table Bus(
number nvarchar(90) primary key,
engineVolume float not null,
constraint FK_BusStock foreign key (number) references Stock(number))

create table Trolleybus(
number nvarchar(90) primary key,
controlType nvarchar(90) not null,
constraint FK_TroleybusStock foreign key (number) references Stock(number))

create table [Route](
id int primary key identity(1,1),
number nvarchar(90) not null,
beginRoute nvarchar(90) not null,
endRoute nvarchar(90) not null)

create table Schedule(
id int primary key identity(1,1),
beginTime datetime not null,
endTime datetime not null)

create table Waybill(
id int primary key identity(1,1),
stockNumber nvarchar(90) not null,
idRoute int not null,
idDriver int not null,
idController int not null,
idSchedule int not null,
constraint FK_FlightStock foreign key (stockNumber) references Stock(number),
constraint FK_FlightRoute foreign key (idRoute) references Route(id),
constraint FK_FlightDriver foreign key (idDriver) references Driver(id),
constraint FK_FlightController foreign key (idController) references Controller(id),
constraint FK_FlightSchedule foreign key (idSchedule) references Schedule(id))

create table Trip(
id int primary key identity(1,1),
idWaybill int not null,
idTicket int not null,
tripTime datetime not null,
mark int null,
constraint FK_TripFlight foreign key (idWaybill) references Waybill(id) on delete cascade on update cascade,
constraint FK_TripTicket foreign key (idTicket) references Ticket(id) on delete cascade on update cascade)

exec sp_bindrule 'CategoryRule','CategoryType'
exec sp_bindefault 'CategoryDefault','CategoryType'
exec sp_bindrule 'ControlTypeRule','ControlTypeType'
exec sp_bindefault 'ControlTypeDefault','ControlTypeType'

go
create view Waybills as
select Stock.number as [Регистрационный номер],
		Route.number as [Номер маршрута],
		Employee.firstName as [Имя водителя],
		Employee.secondName as [Фамилия водителя],
		Schedule.beginTime as [Время начала рейса],
		Schedule.endTime as [Время конца рейса]
from (Waybill join Stock on Waybill.stockNumber = Stock.number join
		[Route] on Waybill.idRoute = [Route].id join 
		(Driver join Employee on Driver.id = Employee.id) on idDriver = Driver.id join 
		(Controller join Employee as ControllerMainTable on Controller.id = ControllerMainTable.id) on idController = Controller.id join
		Schedule on Schedule.id = idSchedule)
go

create view Buses as
select Bus.number as [Регистрационный номер],
		Bus.engineVolume as [Объем двигателя],
		Stock.manufacturer as [Производитель],
		Stock.manufactureYear as [Год выпуска],
		Stock.Photo as [Фото]
from Bus join Stock on Bus.number = Stock.number
go

create view Trolleybuses as
select Trolleybus.number as [Регистрационный номер],
		Trolleybus.controlType as [Тип системы управления],
		Stock.manufacturer as [Производитель],
		Stock.manufactureYear as [Год выпуска],
		Stock.Photo as [Фото]
from Trolleybus join Stock on Trolleybus.number = Stock.number
go

create view TripsView
as
select Trip.id as[Номер поездки], Passenger.phoneNumber as[Пассажир], Employee.FirstName as[Имя водителя], Employee.secondName as[Фамилия водителя], Employee.photo as [Фото видителя], Route.Number as [Номер машрута], Stock.number as[Регистрационный номер п/с], Trip.tripTime as [Время поезки], Trip.mark as [Оценка пользователя]
from Trip join Waybill on Trip.idWaybill = Waybill.id join Driver on Waybill.idDriver = Driver.id join Employee on Driver.id = Employee.id join Stock on Waybill.stockNumber = Stock.number join Route on Waybill.idRoute = Route.id join Ticket on Trip.idTicket = Ticket.id join Passenger on Ticket.phonePassenger = Passenger.phoneNumber

create procedure AddBus(@regNum nvarchar(90), @depot int, @manufacturer nvarchar(90), @year int, @insurance nvarchar(90), @photo nvarchar(190), @volume float)
as
insert into Stock values (@regNum, @depot, @manufacturer, @year, @insurance, @photo)
insert into Bus values (@regNum, @volume)
go

create procedure AddTrolleybus(@regNum nvarchar(90), @depot int, @manufacturer nvarchar(90), @year int, @insurance nvarchar(90), @photo nvarchar(190), @control ControlTypeType)
as
insert into Stock values (@regNum, @depot, @manufacturer, @year, @insurance, @photo)
insert into Bus values (@regNum, @control)
go

create procedure DeleteBus(@regNum nvarchar(90))
as
delete from Bus where (number = @regNum)
delete from Stock where (number = @regNum)
go

create procedure DeleteTrolleybus(@regNum nvarchar(90))
as
delete from Trolleybus where (number = @regNum)
delete from Stock where (number = @regNum)
go

create procedure AddPassenger(@phoneNumber nvarchar(15), @pass nvarchar(190), @firstname nvarchar(90), @secondname nvarchar(90), @patronym nvarchar(90), @birth date)
as
insert into Passenger values (@phoneNumber, @pass, @firstname, @secondname, @patronym, @birth)
go

create procedure AddTicket(@passenger nvarchar(15), @tariff int, @tariffZone int, @expiration datetime, @tripRemains int, @purchaseTime datetime)
as
insert into Ticket values (@passenger, @tariff, @tariffZone, @expiration, @tripRemains, @purchaseTime)
go

create procedure Evaluation(@waybill int, @ticket int, @mark int)
as
update Trip set mark = @mark where idWaybill = @waybill and idTicket = @ticket
go

create procedure GetPassenger(@phoneNumber nvarchar(15))
as
select* from Passenger where phoneNumber = @phoneNumber
go

create proc GetTripsView(@idPassenger nvarchar(15))
as
select * from TripsView where Пассажир = @idPassenger
go

create procedure GetTicket(@passenger nvarchar(15))
as
select top(1) * from Ticket where idPassenger = @passenger order by id desc
go

create procedure GetAllZones
as
select * from TariffZone
go

create proc GetBus(@num nvarchar(90))
as
select * from Buses where [Регистрационный номер] = @num
go
create proc GetBuses
as
select * from Buses 
go
create proc GetTrolleybus(@num nvarchar(90))
as
select * from Trolleybuses where [Регистрационный номер] = @num
go
create proc GetTrolleybuses
as
select * from Trolleybuses 

create procedure GetZone(@id int)
as
select * from TariffZone where id = @id

go
create procedure GetTariff(@id int)
as
select * from Tariff where id = @id

go

create procedure AddWaybill(@stockNum nvarchar(90), @idRoute int, @idDriver int, @idContoller int, @idSchedule int)
as
declare @catDriver CategoryType
set @catDriver = (select Category.name from Category join DriverCategory on Category.name = idCategory)
if (exists (select * from DriverCategory where idDriver = @idDriver and idCategory in ('D', 'D1', 'D1E', 'DE')) and exists (select * from Buses where [Регистрационный номер] = @stockNum)) or (exists (select * from DriverCategory where idDriver = @idDriver and idCategory in ('Tb')) and exists (select * from Trolleybuses where [Регистрационный номер] = @stockNum)) begin 
insert into Waybill(stockNumber, idRoute, idDriver, idController, idSchedule) values (@stockNum, @idRoute, @idDriver, @idContoller, @idSchedule)
end
else print ('Водитель не может работать на этом транспортном средстве')
go

create proc ShowPurchases(@phone nvarchar(15))
as
select Ticket.purchaseTime as PurchaseTime, Tariff.name as TariffName , Tariff.price as TariffPrice, TariffZone.name as TariffZone, Tariff.Price*TariffZone.coefficient as summ
from Ticket join Tariff on Ticket.idTariff = Tariff.id join TariffZone on Ticket.idTariffZone = TariffZone.id 
where phonePassenger = @phone

create trigger TicketTrigger on Ticket after insert
as
if (null = (select expiration from inserted) and 
	null = (select tripRemains from inserted)) or 
	(null != (select expiration from inserted) and 
	null != (select tripRemains from inserted))
	begin
	rollback tran
	end
go

create trigger BusTrigger on Bus instead of delete
as
delete from Bus where number = (select number from deleted)
delete from Stock where number = (select number from deleted)
go

create trigger TrolleybusTrigger on Trolleybus instead of delete
as
delete from Trolleybus where number = (select number from deleted)
delete from Stock where number = (select number from deleted)

create trigger insertCollisionTriggerDriver on Waybill after insert
as
declare @datebegin datetime, @datend datetime
declare @trigdatebegin datetime, @trigdatend datetime
declare @driverid int 
declare @isError int
set @isError = 0
set @driverid = (select idDriver from inserted)
set @datebegin = (select Schedule.beginTime from Schedule join inserted on Schedule.id = inserted.idSchedule)
set @datend = (select Schedule.endTime from Schedule join inserted on Schedule.id = inserted.idSchedule)
declare C1 cursor
for
select Schedule.beginTime, Schedule.endTime from Schedule join Waybill on Schedule.id = Waybill.idSchedule where Waybill.idDriver = @driverid
open C1
FETCH next FROM C1
INTO @trigdatebegin, @trigdatend
if (@datebegin > @trigdatebegin and @datebegin < @trigdatend) or (@datend > @trigdatebegin and @datend < @trigdatend) begin rollback tran print'Водитель уже в рейсе' set @isError = 1 end
WHILE @@FETCH_STATUS = 0 and @isError=0
BEGIN
FETCH NEXT FROM C1
INTO @trigdatebegin, @trigdatend
if (@datebegin > @trigdatebegin and @datebegin < @trigdatend) or (@datend > @trigdatebegin and @datend < @trigdatend) begin rollback tran print'Водитель уже в рейсе' set @isError = 1 end
END
CLOSE C1
DEALLOCATE C1


create trigger insertCollisionTriggerController on Waybill after insert
as
declare @datebegin datetime, @datend datetime
declare @trigdatebegin datetime, @trigdatend datetime
declare @controllerid int 
declare @isError int
set @isError = 0
set @controllerid = (select idController from inserted)
set @datebegin = (select Schedule.beginTime from Schedule join inserted on Schedule.id = inserted.idSchedule)
set @datend = (select Schedule.endTime from Schedule join inserted on Schedule.id = inserted.idSchedule)
declare C1 cursor
for
select Schedule.beginTime, Schedule.endTime from Schedule join Waybill on Schedule.id = Waybill.idSchedule where Waybill.idController = @controllerid
open C1
FETCH next FROM C1
INTO @trigdatebegin, @trigdatend
if (@datebegin > @trigdatebegin and @datebegin < @trigdatend) or (@datend > @trigdatebegin and @datend < @trigdatend) begin rollback tran print'Водитель уже в рейсе' set @isError = 1 end
WHILE @@FETCH_STATUS = 0 and @isError=0
BEGIN
FETCH NEXT FROM C1
INTO @trigdatebegin, @trigdatend
if (@datebegin > @trigdatebegin and @datebegin < @trigdatend) or (@datend > @trigdatebegin and @datend < @trigdatend) begin rollback tran print'Водитель уже в рейсе' set @isError = 1 end
END
CLOSE C1
DEALLOCATE C1

create proc AddTrip(@idWaybill int, @idTicket int, @tripTime datetime)
as
insert into Trip(idWaybill, idTicket, tripTime) values (@idWaybill, @idTicket, @tripTime)

go

create trigger insertTripTrigger on Trip instead of insert
as
declare @idWaybill int, @idTicket int, @tripTime datetime
declare c1 cursor
for
select idWaybill, idTicket, tripTime from inserted
open c1
FETCH NEXT FROM C1
INTO @idWaybill, @idTicket, @tripTime
WHILE @@FETCH_STATUS = 0
BEGIN
FETCH NEXT FROM C1
INTO @idWaybill, @idTicket, @tripTime

if (select tripRemains from Ticket where id = @idTicket) is not null
begin
	if 0 < (select tripRemains from Ticket where id = @idTicket)
	begin
		insert into Trip(idWaybill, idTicket, tripTime) values (@idWaybill, @idTicket, @tripTime)
		declare @tripRemains int
		set @tripRemains = (select tripRemains from Ticket where id = @idTicket)
		update Ticket set tripRemains = @tripRemains - 1 where id = @idTicket
	end
	else
		begin
		print ('У пользователя закончились поездки')
		end
	end
else
begin
	if GETDATE() < (select expiration from Ticket where id = @idTicket)
	begin
		insert into Trip(idWaybill, idTicket, tripTime) values (@idWaybill, @idTicket, @tripTime)
	end
	else
		begin
		print ('У пользователя закончилось время действия билета')
		end
	end
end
CLOSE C1
DEALLOCATE C1
go