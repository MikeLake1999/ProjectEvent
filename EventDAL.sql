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

select * from EventDetailsDB;	

update EventDetailsDB set event_status = 'Tham Gia' where user_id = 2 and event_id = 2;


delimiter $$
create procedure sp_createEvent(IN eventName varchar(100), IN eventAddress varchar(100),IN eventDescription varchar(500), In eventTime varchar(50), OUT eventId int)

begin
	insert into EventDB(event_name, address, description, event_time) values (eventName, eventAddress, eventDescription, eventTime); 
    select max(event_id) into eventId from EventDB;
end $$
delimiter ;



insert into UserDB(user_name, user_password, name_user, age, type_account, job, address, email, phone_number) values
	('manager','123456','Manager1',18, 0, 'Manager', 'Ha Noi', 'manager@gmail.com','01695651555'),
    ('staff','123456','Hồ Đức Hiếu',18, 1, 'Producer', 'Ha Noi', 'staff@gmail.com','0987455887'),
    ('hoangtuan','123456','Hoàng Tuấn',18,1,'Hoc Sinh','Ha noi','hoangtuan124@gmail.com','01669091174'),
    ('nguyenvandung','123456','Nguyễn Văn Dũng',18,1,'Hoc sinh','Ha noi','vandung123@gmail.com','09169092344'),
    ('ducnasa','123456','Đào Văn Đức',22,1,'Giao Vien','Ha noi','ducnasa@gmail.com','09123456789'),
    ('nguyenxuansinh','123456','Nguyễn Xuân Sinh',28,1,'Giao Vien','Ha noi','xuannguyensinh@gmail.com','09987654321'),
    ('vutranlam','123456','Vũ Trần Lâm',28,1,'Giao vien','Ha noi','vutranlam@gmail.com','0969696969'),
    ('phamhang','123456','Phạm Hằng',25,1,'SRO cu','Ha noi','phamhang@gmail.com','0968745631'),
    ('phanthanhtung','123456','Phan Thanh Tùng',25,1,'hoc sinh','Ha noi','tung123456@gmail.com','0965487423'),
    ('Linh Trang','123456','Linh Trang',24,1,'Giao Vu','Ha noi','linhtrang124@gmail.com','0965487423'),
    ('lananh','123456','Lan Anh',19,1,'Hoc Sinh','Thanh Hoa','lananhlun@gmail.com','01669784822');
select * from UserDB;

insert into EventDB(event_name, address, description, event_time) values
	('BlueHole','Hai Duong','Nothing', '16h30' );
select * from EventDB;


drop user if exists 'EventUser'@'localhost';
create user if not exists 'EventUser'@'localhost' identified by '123456789';
    grant all on UserDB to 'EventUser'@'localhost';
    grant all on EventDB to 'EventUser'@'localhost';
    grant all on EventDetailsDB to 'EventUser'@'localhost';
grant all on EventDB.* to 'EventUser'@'localhost';
    
select event_id, event_name,
ifnull(address, '') as address
from EventDB where event_id=1;

select LAST_INSERT_ID();
select event_id from EventDB order by event_id desc limit 1;
    
