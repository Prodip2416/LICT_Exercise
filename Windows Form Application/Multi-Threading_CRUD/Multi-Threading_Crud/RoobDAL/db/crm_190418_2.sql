-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.31-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win32
-- HeidiSQL Version:             9.2.0.4947
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping structure for table crm.additional_info
CREATE TABLE IF NOT EXISTS `additional_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nID` int(11) NOT NULL,
  `image` varbinary(50) NOT NULL,
  `joinDate` datetime NOT NULL,
  `dob` datetime NOT NULL,
  `active` varchar(10) CHARACTER SET latin1 NOT NULL,
  `accessRole` varchar(10) CHARACTER SET latin1 NOT NULL,
  `others` varchar(50) CHARACTER SET latin1 NOT NULL,
  `c_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin2 COLLATE=latin2_bin;

-- Dumping data for table crm.additional_info: ~0 rows (approximately)
/*!40000 ALTER TABLE `additional_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `additional_info` ENABLE KEYS */;


-- Dumping structure for table crm.contact_info
CREATE TABLE IF NOT EXISTS `contact_info` (
  `id` int(11) NOT NULL,
  `name` varchar(15) NOT NULL,
  `email` varchar(25) NOT NULL,
  `mobileNo` varchar(15) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table crm.contact_info: ~0 rows (approximately)
/*!40000 ALTER TABLE `contact_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `contact_info` ENABLE KEYS */;


-- Dumping structure for table crm.personal_info
CREATE TABLE IF NOT EXISTS `personal_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bloodGroup` varchar(15) NOT NULL,
  `balance` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table crm.personal_info: ~0 rows (approximately)
/*!40000 ALTER TABLE `personal_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `personal_info` ENABLE KEYS */;


-- Dumping structure for table crm.person_info
CREATE TABLE IF NOT EXISTS `person_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `contactNo` varchar(20) NOT NULL,
  `email` varchar(30) NOT NULL,
  `gender` int(11) NOT NULL,
  `balance` float NOT NULL,
  `address` varchar(100) NOT NULL,
  `userType` varchar(10) NOT NULL,
  `note` varchar(100) NOT NULL,
  `cn_id` int(11) NOT NULL,
  `entryDate` date DEFAULT NULL,
  `active` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`,`cn_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table crm.person_info: ~3 rows (approximately)
/*!40000 ALTER TABLE `person_info` DISABLE KEYS */;
INSERT INTO `person_info` (`id`, `name`, `contactNo`, `email`, `gender`, `balance`, `address`, `userType`, `note`, `cn_id`, `entryDate`, `active`) VALUES
	(1, 'pro', '1234567', 'asdbe', 0, 132134, 'dewdfscfsfv', '', 'sefdxfsd', 1, '2018-04-18', 0),
	(2, 'qwe', 'qwe', 'adwed', 0, 233, 'qwed', '', 'we', 2, '2018-04-11', 0),
	(3, 'wwwww', '21313', 'wwwww', 0, 232323, 'sdfs', 'Member', 'wef', 3, '2018-04-18', 0);
/*!40000 ALTER TABLE `person_info` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
