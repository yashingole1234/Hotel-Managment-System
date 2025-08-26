create table employee
(
eid int identity(1,1) primary key,
ename varchar(250) not null,
mobile bigint not null,
gender varchar(50) not null,
emailid varchar(120) not null,
username varchar(150) not null,
pass varchar(150) not null
);
select * from employee