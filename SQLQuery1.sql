create database myHotel

create table rooms(
    roomid int Identity(1,1) primary key,
    roomNo varchar(250) not null unique,
    roomType varchar(250) not null,
    bed varchar(250) not null,
    price bigint not null,
    booked varchar(50) default 'NO'
);


create table customer(
    cid int Identity(1,1) primary key,
    cname varchar(250) not null,
    mobile bigint not null,
    nationality varchar(250) not null,
    gender varchar(50) not null,
    dob varchar(50) not null,
    idproof varchar(250) not null,
    addres varchar(350) not null,
    checkin varchar(250) not null,
	checkout varchar(250) ,
    chekout varchar(250) not null default 'NO',
    roomid int not null,
    foreign key (roomid) references rooms(roomid)
);


