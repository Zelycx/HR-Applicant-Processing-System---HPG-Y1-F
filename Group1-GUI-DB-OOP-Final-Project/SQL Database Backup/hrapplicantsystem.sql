-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 01, 2026 at 02:03 PM
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
-- Database: `hrapplicantsystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `applicantaccounts`
--

CREATE TABLE `applicantaccounts` (
  `ApplicantAccountID` int(11) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `IsActive` tinyint(1) DEFAULT 1,
  `CreatedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `applicantdocuments`
--

CREATE TABLE `applicantdocuments` (
  `ApplicantDocumentID` int(11) NOT NULL,
  `ApplicationID` int(11) NOT NULL,
  `RequirementTypeID` int(11) NOT NULL,
  `FileName` varchar(255) DEFAULT NULL,
  `FilePath` varchar(500) DEFAULT NULL,
  `UploadedAt` datetime DEFAULT current_timestamp(),
  `Remarks` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `applicants`
--

CREATE TABLE `applicants` (
  `ApplicantID` int(11) NOT NULL,
  `ApplicantAccountID` int(11) NOT NULL,
  `FirstName` varchar(100) NOT NULL,
  `MiddleName` varchar(100) DEFAULT NULL,
  `LastName` varchar(100) NOT NULL,
  `Gender` varchar(20) DEFAULT NULL,
  `BirthDate` date DEFAULT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `Address` text DEFAULT NULL,
  `EducationLevel` varchar(100) DEFAULT NULL,
  `School` varchar(200) DEFAULT NULL,
  `Course` varchar(200) DEFAULT NULL,
  `Skills` text DEFAULT NULL,
  `WorkExperience` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `applications`
--

CREATE TABLE `applications` (
  `ApplicationID` int(11) NOT NULL,
  `ApplicantID` int(11) NOT NULL,
  `JobVacancyID` int(11) NOT NULL,
  `ApplicationDate` datetime DEFAULT current_timestamp(),
  `CurrentStatus` enum('Draft','Submitted','Under Review','Shortlisted','For Interview','For Assessment','For Final Review','Accepted','Rejected','Withdrawn') DEFAULT 'Draft',
  `IsLocked` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `applicationstatushistory`
--

CREATE TABLE `applicationstatushistory` (
  `StatusHistoryID` int(11) NOT NULL,
  `ApplicationID` int(11) NOT NULL,
  `OldStatus` varchar(50) DEFAULT NULL,
  `NewStatus` varchar(50) DEFAULT NULL,
  `ChangedByUserID` int(11) DEFAULT NULL,
  `Remarks` text DEFAULT NULL,
  `ChangedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `audittrail`
--

CREATE TABLE `audittrail` (
  `AuditTrailID` int(11) NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  `ActionType` varchar(100) DEFAULT NULL,
  `ModuleName` varchar(100) DEFAULT NULL,
  `RecordID` int(11) DEFAULT NULL,
  `Description` text DEFAULT NULL,
  `ActionDateTime` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `departments`
--

CREATE TABLE `departments` (
  `DepartmentID` int(11) NOT NULL,
  `DepartmentName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `departments`
--

INSERT INTO `departments` (`DepartmentID`, `DepartmentName`) VALUES
(2, 'Finance'),
(1, 'Human Resources'),
(3, 'Information Technology'),
(5, 'Marketing'),
(4, 'Operations');

-- --------------------------------------------------------

--
-- Table structure for table `employmenttypes`
--

CREATE TABLE `employmenttypes` (
  `EmploymentTypeID` int(11) NOT NULL,
  `EmploymentTypeName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employmenttypes`
--

INSERT INTO `employmenttypes` (`EmploymentTypeID`, `EmploymentTypeName`) VALUES
(3, 'Contract'),
(1, 'Full-Time'),
(4, 'Internship'),
(2, 'Part-Time');

-- --------------------------------------------------------

--
-- Table structure for table `hiringdecisions`
--

CREATE TABLE `hiringdecisions` (
  `HiringDecisionID` int(11) NOT NULL,
  `ApplicationID` int(11) NOT NULL,
  `DecidedByUserID` int(11) NOT NULL,
  `FinalDecision` enum('Accepted','Rejected','On Hold') NOT NULL,
  `FinalRemarks` text DEFAULT NULL,
  `DecisionDate` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `interviewevaluations`
--

CREATE TABLE `interviewevaluations` (
  `InterviewEvaluationID` int(11) NOT NULL,
  `InterviewScheduleID` int(11) NOT NULL,
  `EvaluatorUserID` int(11) NOT NULL,
  `Score` decimal(5,2) DEFAULT NULL,
  `Result` enum('Pass','Fail') DEFAULT NULL,
  `Remarks` text DEFAULT NULL,
  `Recommendation` text DEFAULT NULL,
  `EvaluationDate` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `interviewschedules`
--

CREATE TABLE `interviewschedules` (
  `InterviewScheduleID` int(11) NOT NULL,
  `ApplicationID` int(11) NOT NULL,
  `ScheduledByUserID` int(11) NOT NULL,
  `InterviewDate` date NOT NULL,
  `InterviewTime` time NOT NULL,
  `InterviewerName` varchar(150) DEFAULT NULL,
  `InterviewMode` varchar(100) DEFAULT NULL,
  `InterviewLocation` varchar(255) DEFAULT NULL,
  `Status` enum('Scheduled','Completed','Cancelled') DEFAULT 'Scheduled'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `jobrequirements`
--

CREATE TABLE `jobrequirements` (
  `JobRequirementID` int(11) NOT NULL,
  `JobVacancyID` int(11) NOT NULL,
  `RequirementTypeID` int(11) NOT NULL,
  `IsRequired` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `jobvacancies`
--

CREATE TABLE `jobvacancies` (
  `JobVacancyID` int(11) NOT NULL,
  `DepartmentID` int(11) NOT NULL,
  `EmploymentTypeID` int(11) NOT NULL,
  `JobTitle` varchar(150) NOT NULL,
  `JobDescription` text DEFAULT NULL,
  `Qualifications` text DEFAULT NULL,
  `SlotsAvailable` int(11) DEFAULT 1,
  `PostedDate` date DEFAULT NULL,
  `ClosingDate` date DEFAULT NULL,
  `Status` enum('Open','Closed') DEFAULT 'Open',
  `CreatedByUserID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `requirementtypes`
--

CREATE TABLE `requirementtypes` (
  `RequirementTypeID` int(11) NOT NULL,
  `RequirementName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `requirementtypes`
--

INSERT INTO `requirementtypes` (`RequirementTypeID`, `RequirementName`) VALUES
(4, 'Certificate of Employment'),
(5, 'Portfolio'),
(1, 'Resume'),
(3, 'Transcript of Records'),
(2, 'Valid ID');

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `RoleID` int(11) NOT NULL,
  `RoleName` varchar(50) NOT NULL,
  `Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`RoleID`, `RoleName`, `Description`) VALUES
(1, 'Admin', NULL),
(2, 'HR Manager', NULL),
(3, 'HR Staff', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `screeningresults`
--

CREATE TABLE `screeningresults` (
  `ScreeningResultID` int(11) NOT NULL,
  `ApplicationID` int(11) NOT NULL,
  `ScreenedByUserID` int(11) NOT NULL,
  `ScreeningStatus` enum('Qualified','Not Qualified') NOT NULL,
  `Remarks` text DEFAULT NULL,
  `ScreeningDate` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `RoleID` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `IsActive` tinyint(1) DEFAULT 1,
  `CreatedAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `applicantaccounts`
--
ALTER TABLE `applicantaccounts`
  ADD PRIMARY KEY (`ApplicantAccountID`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Indexes for table `applicantdocuments`
--
ALTER TABLE `applicantdocuments`
  ADD PRIMARY KEY (`ApplicantDocumentID`),
  ADD KEY `ApplicationID` (`ApplicationID`),
  ADD KEY `RequirementTypeID` (`RequirementTypeID`);

--
-- Indexes for table `applicants`
--
ALTER TABLE `applicants`
  ADD PRIMARY KEY (`ApplicantID`),
  ADD KEY `ApplicantAccountID` (`ApplicantAccountID`);

--
-- Indexes for table `applications`
--
ALTER TABLE `applications`
  ADD PRIMARY KEY (`ApplicationID`),
  ADD UNIQUE KEY `ApplicantID` (`ApplicantID`,`JobVacancyID`),
  ADD KEY `JobVacancyID` (`JobVacancyID`);

--
-- Indexes for table `applicationstatushistory`
--
ALTER TABLE `applicationstatushistory`
  ADD PRIMARY KEY (`StatusHistoryID`),
  ADD KEY `ApplicationID` (`ApplicationID`),
  ADD KEY `ChangedByUserID` (`ChangedByUserID`);

--
-- Indexes for table `audittrail`
--
ALTER TABLE `audittrail`
  ADD PRIMARY KEY (`AuditTrailID`),
  ADD KEY `UserID` (`UserID`);

--
-- Indexes for table `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`DepartmentID`),
  ADD UNIQUE KEY `DepartmentName` (`DepartmentName`);

--
-- Indexes for table `employmenttypes`
--
ALTER TABLE `employmenttypes`
  ADD PRIMARY KEY (`EmploymentTypeID`),
  ADD UNIQUE KEY `EmploymentTypeName` (`EmploymentTypeName`);

--
-- Indexes for table `hiringdecisions`
--
ALTER TABLE `hiringdecisions`
  ADD PRIMARY KEY (`HiringDecisionID`),
  ADD KEY `ApplicationID` (`ApplicationID`),
  ADD KEY `DecidedByUserID` (`DecidedByUserID`);

--
-- Indexes for table `interviewevaluations`
--
ALTER TABLE `interviewevaluations`
  ADD PRIMARY KEY (`InterviewEvaluationID`),
  ADD KEY `InterviewScheduleID` (`InterviewScheduleID`),
  ADD KEY `EvaluatorUserID` (`EvaluatorUserID`);

--
-- Indexes for table `interviewschedules`
--
ALTER TABLE `interviewschedules`
  ADD PRIMARY KEY (`InterviewScheduleID`),
  ADD KEY `ApplicationID` (`ApplicationID`),
  ADD KEY `ScheduledByUserID` (`ScheduledByUserID`);

--
-- Indexes for table `jobrequirements`
--
ALTER TABLE `jobrequirements`
  ADD PRIMARY KEY (`JobRequirementID`),
  ADD UNIQUE KEY `JobVacancyID` (`JobVacancyID`,`RequirementTypeID`),
  ADD KEY `RequirementTypeID` (`RequirementTypeID`);

--
-- Indexes for table `jobvacancies`
--
ALTER TABLE `jobvacancies`
  ADD PRIMARY KEY (`JobVacancyID`),
  ADD KEY `DepartmentID` (`DepartmentID`),
  ADD KEY `EmploymentTypeID` (`EmploymentTypeID`),
  ADD KEY `CreatedByUserID` (`CreatedByUserID`);

--
-- Indexes for table `requirementtypes`
--
ALTER TABLE `requirementtypes`
  ADD PRIMARY KEY (`RequirementTypeID`),
  ADD UNIQUE KEY `RequirementName` (`RequirementName`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`RoleID`),
  ADD UNIQUE KEY `RoleName` (`RoleName`);

--
-- Indexes for table `screeningresults`
--
ALTER TABLE `screeningresults`
  ADD PRIMARY KEY (`ScreeningResultID`),
  ADD KEY `ApplicationID` (`ApplicationID`),
  ADD KEY `ScreenedByUserID` (`ScreenedByUserID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `Username` (`Username`),
  ADD UNIQUE KEY `Email` (`Email`),
  ADD KEY `RoleID` (`RoleID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `applicantaccounts`
--
ALTER TABLE `applicantaccounts`
  MODIFY `ApplicantAccountID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `applicantdocuments`
--
ALTER TABLE `applicantdocuments`
  MODIFY `ApplicantDocumentID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `applicants`
--
ALTER TABLE `applicants`
  MODIFY `ApplicantID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `applications`
--
ALTER TABLE `applications`
  MODIFY `ApplicationID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `applicationstatushistory`
--
ALTER TABLE `applicationstatushistory`
  MODIFY `StatusHistoryID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `audittrail`
--
ALTER TABLE `audittrail`
  MODIFY `AuditTrailID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `departments`
--
ALTER TABLE `departments`
  MODIFY `DepartmentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `employmenttypes`
--
ALTER TABLE `employmenttypes`
  MODIFY `EmploymentTypeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `hiringdecisions`
--
ALTER TABLE `hiringdecisions`
  MODIFY `HiringDecisionID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `interviewevaluations`
--
ALTER TABLE `interviewevaluations`
  MODIFY `InterviewEvaluationID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `interviewschedules`
--
ALTER TABLE `interviewschedules`
  MODIFY `InterviewScheduleID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `jobrequirements`
--
ALTER TABLE `jobrequirements`
  MODIFY `JobRequirementID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `jobvacancies`
--
ALTER TABLE `jobvacancies`
  MODIFY `JobVacancyID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `requirementtypes`
--
ALTER TABLE `requirementtypes`
  MODIFY `RequirementTypeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `RoleID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `screeningresults`
--
ALTER TABLE `screeningresults`
  MODIFY `ScreeningResultID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `applicantdocuments`
--
ALTER TABLE `applicantdocuments`
  ADD CONSTRAINT `applicantdocuments_ibfk_1` FOREIGN KEY (`ApplicationID`) REFERENCES `applications` (`ApplicationID`),
  ADD CONSTRAINT `applicantdocuments_ibfk_2` FOREIGN KEY (`RequirementTypeID`) REFERENCES `requirementtypes` (`RequirementTypeID`);

--
-- Constraints for table `applicants`
--
ALTER TABLE `applicants`
  ADD CONSTRAINT `applicants_ibfk_1` FOREIGN KEY (`ApplicantAccountID`) REFERENCES `applicantaccounts` (`ApplicantAccountID`);

--
-- Constraints for table `applications`
--
ALTER TABLE `applications`
  ADD CONSTRAINT `applications_ibfk_1` FOREIGN KEY (`ApplicantID`) REFERENCES `applicants` (`ApplicantID`),
  ADD CONSTRAINT `applications_ibfk_2` FOREIGN KEY (`JobVacancyID`) REFERENCES `jobvacancies` (`JobVacancyID`);

--
-- Constraints for table `applicationstatushistory`
--
ALTER TABLE `applicationstatushistory`
  ADD CONSTRAINT `applicationstatushistory_ibfk_1` FOREIGN KEY (`ApplicationID`) REFERENCES `applications` (`ApplicationID`),
  ADD CONSTRAINT `applicationstatushistory_ibfk_2` FOREIGN KEY (`ChangedByUserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `audittrail`
--
ALTER TABLE `audittrail`
  ADD CONSTRAINT `audittrail_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `hiringdecisions`
--
ALTER TABLE `hiringdecisions`
  ADD CONSTRAINT `hiringdecisions_ibfk_1` FOREIGN KEY (`ApplicationID`) REFERENCES `applications` (`ApplicationID`),
  ADD CONSTRAINT `hiringdecisions_ibfk_2` FOREIGN KEY (`DecidedByUserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `interviewevaluations`
--
ALTER TABLE `interviewevaluations`
  ADD CONSTRAINT `interviewevaluations_ibfk_1` FOREIGN KEY (`InterviewScheduleID`) REFERENCES `interviewschedules` (`InterviewScheduleID`),
  ADD CONSTRAINT `interviewevaluations_ibfk_2` FOREIGN KEY (`EvaluatorUserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `interviewschedules`
--
ALTER TABLE `interviewschedules`
  ADD CONSTRAINT `interviewschedules_ibfk_1` FOREIGN KEY (`ApplicationID`) REFERENCES `applications` (`ApplicationID`),
  ADD CONSTRAINT `interviewschedules_ibfk_2` FOREIGN KEY (`ScheduledByUserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `jobrequirements`
--
ALTER TABLE `jobrequirements`
  ADD CONSTRAINT `jobrequirements_ibfk_1` FOREIGN KEY (`JobVacancyID`) REFERENCES `jobvacancies` (`JobVacancyID`),
  ADD CONSTRAINT `jobrequirements_ibfk_2` FOREIGN KEY (`RequirementTypeID`) REFERENCES `requirementtypes` (`RequirementTypeID`);

--
-- Constraints for table `jobvacancies`
--
ALTER TABLE `jobvacancies`
  ADD CONSTRAINT `jobvacancies_ibfk_1` FOREIGN KEY (`DepartmentID`) REFERENCES `departments` (`DepartmentID`),
  ADD CONSTRAINT `jobvacancies_ibfk_2` FOREIGN KEY (`EmploymentTypeID`) REFERENCES `employmenttypes` (`EmploymentTypeID`),
  ADD CONSTRAINT `jobvacancies_ibfk_3` FOREIGN KEY (`CreatedByUserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `screeningresults`
--
ALTER TABLE `screeningresults`
  ADD CONSTRAINT `screeningresults_ibfk_1` FOREIGN KEY (`ApplicationID`) REFERENCES `applications` (`ApplicationID`),
  ADD CONSTRAINT `screeningresults_ibfk_2` FOREIGN KEY (`ScreenedByUserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`RoleID`) REFERENCES `roles` (`RoleID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
