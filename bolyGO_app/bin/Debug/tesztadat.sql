-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Okt 24. 19:20
-- Kiszolgáló verziója: 10.4.27-MariaDB
-- PHP verzió: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `bolygo_db`
--

--
-- A tábla adatainak kiíratása `bolygo`
--

INSERT INTO `bolygo` (`id`, `nev`) VALUES
(1, 'Bogoly'),
(2, 'Szaturnusz'),
(3, 'MakkaBolygo'),
(4, 'Dubina-2542'),
(5, 'GLIESE 667CC'),
(6, 'KEPLER-22B'),
(7, 'KEPLER-69C'),
(8, 'KEPLER-62F'),
(9, 'KEPLER-186F'),
(10, 'KEPLER-442B');

--
-- A tábla adatainak kiíratása `csomag`
--

INSERT INTO `csomag` (`id`, `nev`, `leiras`, `bolygoid`, `kezdes`, `vege`, `ar`) VALUES
(1, 'Macskák mindenhol', 'Sok macska van nagyon', 3, '2023-10-24', '2025-10-31', 400),
(2, 'Nézze meg a Szaturnuszt', 'Lesz szaturnusz és ott dolgok lesznek', 6, '2023-10-24', '2023-10-31', 450);

--
-- A tábla adatainak kiíratása `jarmu`
--

INSERT INTO `jarmu` (`id`, `nev`, `osztaly`, `fekvohely`) VALUES
(1, 'Space-Piro', 11, 1),
(2, 'Sun-Sail', 3, 0),
(3, 'Big-Fly', 1, 1);

--
-- A tábla adatainak kiíratása `ugyfel`
--

INSERT INTO `ugyfel` (`id`, `nev`, `lakcim`, `szul`, `nem`, `tel`, `email`) VALUES
(1, 'Kovács László', '2600. Vác, Zöldfa u. 4.', '1995-10-01', 'férfi', '+36302558445', 'kovacslaci@gmail.com'),
(2, 'Virág Anna', '2629. Szob, Árpád u. 10.', '1988-01-01', 'nő', '+36204558795', 'v.anna88@gmail.com'),
(3, 'Hárosi Jácint', '1181. Budapest XVIII., Havanna u. 73. IV/14', '1991-09-30', 'férfi', '+36204879855', 'harosi91@gmail.com');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
