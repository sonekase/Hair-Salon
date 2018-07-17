# Hair Salon
##### Hair Salon database.

#### By Anousone Kaseumsouk 07.13.2018

## Description

A database that stores hair salon information.

## Setup

Install Hair Salon by downloading the folder.

#### In MySQL
* CREATE DATABASE anousone_kaseumsouk;
* USE anousone_kaseumsouk;
* CREATE TABLE stylist (stylist_id PRIMARY KEY, stylist_name VARCHAR(255), detail VARCHAR(255), client_name VARCHAR(255));
* CREATE TABLE client (client_id PRIMARY KEY, client_name VARCHAR(255), stylist_id Int);


## Technologies Used

Application: CSharp, netcoreapp1.1, Razor, MAMP, MySQL

## Support and Contact

For any questions or support details, please email:
anousonekaseumsouk@icloud.com

## Spec

* Connect to both a development database and a test database.
* Let employee add stylist content to database.
* Let employee view stylist details and clients.
* Let employee add new stylist.
* Let employee add new clients to a specific client.


### Legal

Copyright (c) 2018 **Anousone Kaseumsouk**

This software is licensed under the MIT license.
