CREATE DATABASE `Web2Hotel` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
CREATE TABLE `Contacto` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) NOT NULL,
  `Apellido` varchar(45) NOT NULL,
  `Descripcion` varchar(500) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Telefono` varchar(45) NOT NULL,
  `Estado` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `Habitacion` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Numero` int(11) NOT NULL,
  `Capacidad` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Numero_UNIQUE` (`Numero`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `Usuario` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(45) NOT NULL,
  `Password` varchar(45) NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `Apelllido` varchar(45) NOT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  `Role` varchar(45) NOT NULL,
  `Estado` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Username_UNIQUE` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `Reserva` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CreationId` int(11) NOT NULL,
  `CreationDate` datetime NOT NULL,
  `HabitacionId` int(11) NOT NULL,
  `Estado` varchar(45) NOT NULL,
  `UsuarioId` int(11) NOT NULL,
  `FechaInicio` datetime NOT NULL,
  `FechaFin` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `User_idx` (`UsuarioId`),
  KEY `Creator_idx` (`CreationId`),
  KEY `Habitacion_idx` (`HabitacionId`),
  CONSTRAINT `Creator` FOREIGN KEY (`CreationId`) REFERENCES `usuario` (`id`),
  CONSTRAINT `Habitacion` FOREIGN KEY (`HabitacionId`) REFERENCES `habitacion` (`id`),
  CONSTRAINT `User` FOREIGN KEY (`UsuarioId`) REFERENCES `usuario` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
