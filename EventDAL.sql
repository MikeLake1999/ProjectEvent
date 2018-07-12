drop database if exists EventDB;


create database if not exists EventDB char set 'utf8';

use EventDB;



create table if not exists UserDB(
    user_name varchar(50) primary key not null,
    user_password varchar(50) not null,
    name_user varchar(100) not null,
    age int not null,
    type_account int,
    job varchar(50),
    address varchar(100),
    email varchar(50),
    phone_number int	
);

create table if not exists EventDB(
	event_id int auto_increment primary key,
    event_name varchar(100) not null,
    address varchar(100),
    description varchar(100),
    event_time varchar(10)
);



create table if not exists EventDetailsDB(
	username varchar(50) not null,
    event_id int not null,
    event_status varchar(50) not null,
    constraint pk_EventDetails primary key(username, event_id),
    constraint fk_EventDetails_Users foreign key(username) references UserDB(user_name),
    constraint fk_EventDetails_Events foreign key(event_id) references EventDB(event_id)
    
);
delimiter $$
create procedure sp_createEvent(IN event_Name varchar(100), IN Address varchar(100),IN Description varchar(100), In Event_Time varchar(10), OUT eventId int)
begin
	insert into EventDB(event_name, address, description, event_time) values (event_Name, Address, Description, Event_Time); 
    select max(event_id) into eventId from EventDB;
end $$
delimiter ;

insert into UserDB(user_name, user_password, name_user, age, type_account, job, address, email, phone_number) values
	('manager','123456','manager',18, 0, 'Manager', 'Ha Noi', 'manager@gmail.com', 01695651555),
    ('staff','123456','staff',18, 1, 'Dicrector', 'Ha Noi', 'staff@gmail.com', 0987455887),
    ('hoangtuan','123456789','Hoàng Tuấn',18,1,'Student','Ha noi','hoangtuan124@gmail.com',01669091174),
    ('kunkun18','kun123456','Kun Kun',25,1,'Teacher','Thai Nguyen','kunkun788@gmail.com',09869154885),
    ('lananhi29','anh147852','Lan Anh',19,1,'Student','Thanh Hoa','lananhlun@gmail.com',01669784822);
select * from UserDB;

insert into EventDB(event_name, address, description, event_time) values
	('BlueHole','Hai Duong','Nothing', '16h30' ),
    ('CKTG','Hanoi', 'Nothing', '6h30'),
    ('đêm nhạc “Chuyện chẳng kể được” của Lê Cát Trọng Lý','số 14 Phan Huy Ích, Hà Nội','Đêm diễn này của Lý còn rất đặc biệt với người
    yêu nhạc Việt Nam và quốc tế vì sự tham gia các nghệ sĩ cello Nguyễn Thanh Tú, oboe Nguyễn Hoàng Tùng và piano Cao
    Thanh Lan.','20 giờ, ngày 23 và 24/02/2018'),
    ('buổi chiếu phim “Vũ điệu Ba lê”','số 24 Tràng Tiền, Hà Nội','“Vũ điệu Ba lê” là bản giao hưởng hoàn chỉnh đưa người xem đi từ những xưởng may trang phục, qua những buổi công chiếu với các ngôi sao 
    nổi tiếng để tới trung tâm của rạp hát nổi tiếng Opera Paris.','18 giờ, ngày 25/02/2018');
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
    
