-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 27, 2025 at 09:24 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `attendance_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `attendance`
--

CREATE TABLE `attendance` (
  `id` bigint(20) NOT NULL COMMENT 'Unique attendance record ID',
  `session_id` int(11) NOT NULL COMMENT 'Links to the session ID from sessions table',
  `student_name` varchar(120) NOT NULL COMMENT 'Student''s full name',
  `student_id` varchar(50) NOT NULL COMMENT 'student university id',
  `uesr_agent` varchar(200) NOT NULL COMMENT 'device or browser used to register',
  `ip_address` varbinary(16) NOT NULL COMMENT 'ip address of student',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `attendance`
--

INSERT INTO `attendance` (`id`, `session_id`, `student_name`, `student_id`, `uesr_agent`, `ip_address`, `created_at`) VALUES
(1, 3, 'omararef', '230102010002', '', '', '2025-11-12 14:47:24'),
(5, 7, 'عمر عارف محمد علي', '230102010002', '', '', '2025-11-26 18:45:43'),
(7, 7, 'محمد احمد محمود المحمدي', '230102010003', '', '', '2025-11-26 18:46:17'),
(8, 7, 'محمد احمد حامد المحمدي', '230102010004', '', '', '2025-11-26 18:46:30'),
(9, 7, 'محمد احمد حامد الرجال', '230102010005', '', '', '2025-11-26 18:47:47');

-- --------------------------------------------------------

--
-- Table structure for table `sessions`
--

CREATE TABLE `sessions` (
  `id` int(11) NOT NULL COMMENT 'Unique session ID',
  `title` varchar(150) NOT NULL COMMENT 'Session title',
  `token` char(12) NOT NULL COMMENT 'Random token for QR',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `course_name` varchar(100) NOT NULL COMMENT 'the name of the course',
  `level` varchar(50) NOT NULL,
  `group_name` varchar(50) NOT NULL,
  `start_time` datetime NOT NULL COMMENT 'Session start time',
  `end_time` datetime NOT NULL COMMENT 'Session end time'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `sessions`
--

INSERT INTO `sessions` (`id`, `title`, `token`, `created_at`, `course_name`, `level`, `group_name`, `start_time`, `end_time`) VALUES
(3, 'lecture 2', '6eba0c12e17b', '2025-11-12 13:52:54', 'computer networks', '4', 'b', '2025-11-12 16:52:00', '2025-11-12 17:49:00'),
(5, 'lecture test', '6ae292e6948b', '2025-11-23 19:47:38', 'programming', 'CreateSessionForm', 'a and b', '2025-11-23 10:50:00', '2025-11-23 11:05:00'),
(6, 'lecture 5', '64f982eeab77', '2025-11-26 18:13:29', 'web devlopment', 'CreateSessionForm', 'a', '2025-11-26 21:13:00', '2025-11-26 21:20:00'),
(7, 'lecture final', '933684712c42', '2025-11-26 18:40:41', 'web', '4', 'all', '2025-11-26 21:40:00', '2025-11-26 21:50:00');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) UNSIGNED NOT NULL,
  `username` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `attendance`
--
ALTER TABLE `attendance`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `uq_attendance_session_student` (`session_id`,`student_id`);

--
-- Indexes for table `sessions`
--
ALTER TABLE `sessions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `token` (`token`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `attendance`
--
ALTER TABLE `attendance`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'Unique attendance record ID', AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `sessions`
--
ALTER TABLE `sessions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Unique session ID', AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `attendance`
--
ALTER TABLE `attendance`
  ADD CONSTRAINT `fk_attendance_session` FOREIGN KEY (`session_id`) REFERENCES `sessions` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
