drop database if exists EventDB;

create database if not exists EventDB char set 'utf8';

use EventDB;



create table if not exists UserDB(
	user_id int auto_increment primary key,
    user_name varchar(50) not null,
    user_password varchar(50) not null,
    name_user varchar(50) not null,
    age int not null,
    type_account int,
    job varchar(50),
    address varchar(100),
    email varchar(50),
    phone_number varchar(30)	
);

create table if not exists EventDB(
	event_id int auto_increment primary key,
    event_name varchar(100) not null,
    address varchar(100),
    description varchar(500),
    event_time varchar(50)
);



create table if not exists EventDetailsDB(
	user_id int not null,
    event_id int not null,
    event_status varchar(50) not null,
    constraint pk_EventDetails primary key(user_id, event_id),
    constraint fk_EventDetails_Users foreign key(user_id) references UserDB(user_id),
    constraint fk_EventDetails_Events foreign key(event_id) references EventDB(event_id)
    
);
delimiter $$
create procedure sp_createEvent(IN event_Name varchar(100), IN Address varchar(100),IN Description varchar(500), In Event_Time varchar(50), OUT eventId int)
begin
	insert into EventDB(event_name, address, description, event_time) values (event_Name, Address, Description, Event_Time); 
    select max(event_id) into eventId from EventDB;
end $$
delimiter ;

insert into UserDB(user_name, user_password, name_user, age, type_account, job, address, email, phone_number) values
	('manager','123456','manager',18, 0, 'Manager', 'Ha Noi', 'manager@gmail.com','01695651555'),
    ('staff','123456','staff',18, 1, 'Dicrector', 'Ha Noi', 'staff@gmail.com','0987455887'),
    ('hoangtuan','123456789','Hoàng Tuấn',18,1,'Student','Ha noi','hoangtuan124@gmail.com','01669091174'),
    ('lananhi29','anh147852','Lan Anh',19,1,'Student','Thanh Hoa','lananhlun@gmail.com','01669784822');
select * from UserDB;

insert into EventDB(event_name, address, description, event_time) values
	('BlueHole','Hai Duong','Nothing', '16h30' ),
    ('CKTG','Hanoi', 'Nothing', '6h30');
select * from EventDB;


drop user if exists 'EventUser'@'localhost';
create user if not exists 'EventUser'@'localhost' identified by '123456789';
    grant all on UserDB to 'EventUser'@'localhost';
    grant all on EventDB to 'EventUser'@'localhost';
    grant all on EventDetailsDB to 'EventUser'@'localhost';
    
select event_id, event_name,
ifnull(address, '') as address
from EventDB where event_id=1;

select LAST_INSERT_ID();
select event_id from EventDB order by event_id desc limit 1;
    
