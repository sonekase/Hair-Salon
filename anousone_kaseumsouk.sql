-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 24, 2018 at 06:20 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `anousone_kaseumsouk`
--
CREATE DATABASE IF NOT EXISTS `anousone_kaseumsouk` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `anousone_kaseumsouk`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `name`, `stylist_id`) VALUES
(16, 'Kanye West', 11),
(17, 'Jennifer Lopez', 10),
(18, 'Alex Rodriguez', 10),
(19, 'Beyonce Knowles', 10),
(20, 'Nancy Kaseumsouk', 4),
(21, 'Sandy Sisa-at', 4),
(22, 'Kathy Sisa-at', 4),
(23, 'Sonny Kaseumsouk', 7),
(24, 'Daniel Kaseumsouk', 7),
(25, 'Shaquille O\'Neal', 11),
(26, 'Lebron James', 11),
(27, 'Jean Jia', 9),
(28, 'Lan Dam', 9),
(29, 'Eddie Harris', 9),
(30, 'Bruce Lee', 9);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `name`) VALUES
(2, 'Women\'s Haircut'),
(3, 'Men\'s Haircut'),
(4, 'Children\'s Haircut'),
(5, 'Color'),
(6, 'Perm'),
(7, 'Straightening'),
(8, 'Hair Extension');

-- --------------------------------------------------------

--
-- Table structure for table `specialties_stylist`
--

CREATE TABLE `specialties_stylist` (
  `id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties_stylist`
--

INSERT INTO `specialties_stylist` (`id`, `specialty_id`, `stylist_id`) VALUES
(3, 2, 4),
(4, 4, 9),
(5, 5, 4),
(6, 3, 4),
(7, 6, 4),
(8, 7, 4),
(9, 8, 4),
(10, 3, 11),
(11, 2, 9),
(12, 3, 9),
(13, 2, 7),
(14, 3, 7),
(15, 6, 7),
(16, 5, 7);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `detail` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `name`, `detail`) VALUES
(4, 'Gene Juarez', 'Full Hair Salon'),
(7, 'Ashton Kim.', 'Asian Hair'),
(9, 'Casey Kimura', 'Menshair'),
(10, 'Michael Jackson', 'Full Service'),
(11, 'Kobe Bryant', 'Menshair'),
(14, 'Drake Graham', 'Toronto');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties_stylist`
--
ALTER TABLE `specialties_stylist`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `specialties_stylist`
--
ALTER TABLE `specialties_stylist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
