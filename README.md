Scripts to insert manually
===========================
--insert into Role values ('Super Admin','2023-12-16 00:00:00','00000000-0000-0000-0000-000000000000',null,null,1)
--insert into Role values ('Admin','2023-12-16 00:00:00','00000000-0000-0000-0000-000000000000',null,null,1)
--insert into Role values ('Staff','2023-12-16 00:00:00','00000000-0000-0000-0000-000000000000',null,null,1)

--insert into AuthenticationSetting values ('UserAccount','View')
--insert into AuthenticationSetting values ('UserAccount','Add/Edit')
--insert into AuthenticationSetting values ('UserAccount','Delete')

--insert into RoleAuthentication values (1,1)
--insert into RoleAuthentication values (1,2)
--insert into RoleAuthentication values (1,3)

--update [User] set RoleId = 1 where Id ='userId'

Login Request / Response
----------------------------------------
```json
{
  "email": "sannlynnhtun.ace@gmail.com",
  "password": "123@ace"
}
```
```json
{
  "userId": "21954647-54b7-4f9c-be8d-638b1da32036",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyMTk1NDY0Ny01NGI3LTRmOWMtYmU4ZC02MzhiMWRhMzIwMzYiLCJyb2xlIjoiMSIsIm5iZiI6MTcwMzM2Nzk3NywiZXhwIjoxNzAzNDU0Mzc3LCJpYXQiOjE3MDMzNjc5NzcsImlzcyI6InNhbm5fbHlubl9odHVuIn0.kC9pPClAlFTLwAxuKrZA9zP31UfnlcNYkYZaR7Ua_h0",
  "name": "Sann Lynn Htun",
  "email": "sannlynnhtun.ace@gmail.com",
  "statusCode": 200,
  "message": "Success"
}
```
----------------------------------------
Register Request / Response
----------------------------------------
```json
{
  "email": "sannlynnhtun.ace@gmail.com",
  "password": "123@ace",
  "name": "Sann Lynn Htun"
}
```
```json
{
  "userId": "21954647-54b7-4f9c-be8d-638b1da32036",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyMTk1NDY0Ny01NGI3LTRmOWMtYmU4ZC02MzhiMWRhMzIwMzYiLCJyb2xlIjoiMCIsIm5iZiI6MTcwMzM2Nzg0NSwiZXhwIjoxNzAzNDU0MjQ0LCJpYXQiOjE3MDMzNjc4NDUsImlzcyI6InNhbm5fbHlubl9odHVuIn0.LSmWmXBxZQmxPIyayQGdWLF3bbkbLlwDMelIyfUxj_Q",
  "statusCode": 200,
  "message": "Success"
}
```
----------------------------------------