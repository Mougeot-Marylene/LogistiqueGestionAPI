SET client_encoding = 'UTF8';

CREATE SCHEMA IF NOT EXISTS public;
-- -----------------------------------------------------
-- Base de données : RevendTout
-- Script PostgreSQL
-- -----------------------------------------------------

-- Suppression des tables existantes pour éviter les conflits
DROP TABLE IF EXISTS produit_categories;
DROP TABLE IF EXISTS produit_paniers;
DROP TABLE IF EXISTS produit_tailles;
DROP TABLE IF EXISTS commande_produit;
DROP TABLE IF EXISTS images;
DROP TABLE IF EXISTS paniers;
DROP TABLE IF EXISTS commandes;
DROP TABLE IF EXISTS produits;
DROP TABLE IF EXISTS categories;
DROP TABLE IF EXISTS tailles;
DROP TABLE IF EXISTS statut_commandes;
DROP TABLE IF EXISTS utilisateurs;
DROP TABLE IF EXISTS adresses;

-- -----------------------------------------------------
-- 1. CREATION DES TABLES
-- -----------------------------------------------------

CREATE TABLE adresses (
    id SERIAL PRIMARY KEY,
    numero_rue VARCHAR(10) NOT NULL,
    nom_rue VARCHAR(200) NOT NULL,
    ville VARCHAR(100) NOT NULL,
    code_postal VARCHAR(20) NOT NULL,
    pays VARCHAR(100) NOT NULL,
    date_creation TIMESTAMP DEFAULT NOW() NOT NULL
);

CREATE TABLE categories (
    id SERIAL PRIMARY KEY,
    nom VARCHAR(100) NOT NULL,
    description TEXT
);

CREATE TABLE utilisateurs (
    id SERIAL PRIMARY KEY,
    adresse_id INT REFERENCES adresses(id) ON DELETE SET NULL,
    nom VARCHAR(100) NOT NULL,
    prenom VARCHAR(100) NOT NULL,
    email VARCHAR(150) UNIQUE NOT NULL,
    mdp VARCHAR(255) NOT NULL,
    date_creation TIMESTAMP DEFAULT NOW() NOT NULL,
    admin BOOLEAN DEFAULT FALSE NOT NULL,
    emailverification VARCHAR(255),
    emailverified BOOLEAN DEFAULT FALSE NOT NULL
);

CREATE TABLE statut_commandes (
    id SERIAL PRIMARY KEY,
    label VARCHAR(50) NOT NULL
);

CREATE TABLE commandes (
    id SERIAL PRIMARY KEY,
    utilisateur_id INT REFERENCES utilisateurs(id) ON DELETE CASCADE,
    date_creation TIMESTAMP DEFAULT NOW() NOT NULL,
    statut_commandes_id INT REFERENCES statut_commandes(id)
);

CREATE TABLE tailles (
    id SERIAL PRIMARY KEY,
    nom VARCHAR(100) NOT NULL
);

CREATE TABLE produits (
    id SERIAL PRIMARY KEY,
    nom VARCHAR(150) NOT NULL,
    description TEXT,
    prix DECIMAL(10, 2) NOT NULL,
    quantite INT DEFAULT 0 NOT NULL,
    date_creation TIMESTAMP DEFAULT NOW() NOT NULL
);

CREATE TABLE commande_produit (
    commande_id INT REFERENCES commandes(id) ON DELETE CASCADE,
    produit_id INT REFERENCES produits(id) ON DELETE CASCADE,
    quantite INT NOT NULL DEFAULT 1,
    estramasse BOOLEAN DEFAULT FALSE,
    estemballe BOOLEAN DEFAULT FALSE,
    PRIMARY KEY (commande_id, produit_id)
);

CREATE TABLE images (
    id SERIAL PRIMARY KEY,
    produit_id INT REFERENCES produits(id) ON DELETE CASCADE,
    url VARCHAR(100) NOT NULL,
    description VARCHAR(100),
    date_creation TIMESTAMP DEFAULT NOW() NOT NULL
);

CREATE TABLE paniers (
    id SERIAL PRIMARY KEY,
    utilisateur_id INT REFERENCES utilisateurs(id) ON DELETE CASCADE,
    date_creation TIMESTAMP DEFAULT NOW() NOT NULL
);

CREATE TABLE produit_categories (
    produit_id INT REFERENCES produits(id) ON DELETE CASCADE,
    categorie_id INT REFERENCES categories(id) ON DELETE CASCADE,
    PRIMARY KEY (produit_id, categorie_id)
);

CREATE TABLE produit_paniers (
    panier_id INT REFERENCES paniers(id) ON DELETE CASCADE,
    produit_id INT REFERENCES produits(id) ON DELETE CASCADE,
    quantite INT NOT NULL DEFAULT 1,
    PRIMARY KEY (panier_id, produit_id)
);

CREATE TABLE produit_tailles (
    produit_id INT REFERENCES produits(id) ON DELETE CASCADE,
    taille_id INT REFERENCES tailles(id) ON DELETE CASCADE,
    PRIMARY KEY (produit_id, taille_id)
);

-- -----------------------------------------------------
-- 2. INSERTION DES DONNEES
-- -----------------------------------------------------

-- Table : adresses
INSERT INTO adresses (id, numero_rue, nom_rue, ville, code_postal, pays) VALUES
(1, '12', 'Rue de la République', 'Paris', '75001', 'France'),
(2, '45', 'Avenue Jean Jaurès', 'Lyon', '69007', 'France'),
(3, '8', 'Rue des Fleurs', 'Marseille', '13001', 'France');

-- Table : categories (uniquement les 3 catégories utilisées par les produits, texte exact non modifié)
INSERT INTO categories (id, nom, description) VALUES
(5, 'Hommes', 'La catégorie Homme propose des vêtements variés alliant confort et style, adaptés à toutes les occasions. T-shirts, chemises, pantalons, vestes et plus, pour répondre aux be'),
(7, 'Pulls', 'La catégorie Pulls regroupe une variété de pulls confortables et stylés, adaptés à toutes les saisons. Idéals pour apporter chaleur et élégance à vos tenues, avec des modèles p'),
(9, 'Tee-shirt', 'La catégorie Tee-shirt rassemble une sélection de tee-shirts confortables et tendance, adaptés à tous les styles et occasions. Disponibles pour hommes, femmes et enfants, il'),
(11, 'Accessoires', 'La catégorie Accessoires regroupe une sélection d’articles complémentaires pour parfaire votre tenue. Écharpes, ceintures, chapeaux, sacs et bien plus, pour hommes, femmes et enfants.');

-- Table : utilisateurs
INSERT INTO utilisateurs (id, adresse_id, nom, prenom, email, mdp, date_creation, admin, emailverification, emailverified) VALUES
(25, 2, 'coucou', 'Marylène', 'ze@gmail.com', 'AQAAAAIAAYagAAAAEL0WIKMT8nZcoKALAuuTrfoalFDy3vf6mz...', '2026-01-29 19:30:28.226', FALSE, NULL, FALSE),
(11, NULL, 'Mougeot', 'Marylène', 'marylene.m39@gmail.com', 'AQAAAAIAAYagAAAAEN64YQPhukh0NTQo5cvn1ZEdwKtds1j0b...', '2026-01-12 14:04:47.735', FALSE, NULL, FALSE),
(19, 1, 'Durant', 'Qqdqq', 'dZZh@gmail.com', 'AQAAAAIAAYagAAAENesStNSmdy5DO6EzYsy6xpk7x/vCwwKX...', '2026-01-13 12:52:59.304', FALSE, NULL, FALSE),
(18, 1, 'Durant', 'Henry', 'drurantH@gmail.com', 'AQAAAAIAAYagAAAE0a1mtgxurFWzwlsXAjQeohCCRYb2023C...', '2026-01-12 20:18:36.765', FALSE, NULL, FALSE),
(20, 3, 'hollla', 'QFSSQ', 'dSSh@gmail.com', 'AQAAAAIAAYagAAELagCKeSZ7ISDEHK1zeCEky0odMKe5w613...', '2026-01-13 13:16:22.444', FALSE, NULL, FALSE),
(21, 1, 'hollladee', 'fsd', 'dhsds@gmail.com', 'AQAAAAIAAYagAAAEB4SKnFbT2Ohpims3KosQE7ZfIDnyGnxX...', '2026-01-13 14:06:17.366', FALSE, NULL, FALSE),
(22, 1, 'ssq', 'Marylène', 'dkkrurantH@gmail.com', 'AQAAAAIAAYagAAAEcEWWAAbNPATpog9cOYWOPn2PNXiibUo9...', '2026-01-13 15:12:05.468', FALSE, NULL, FALSE),
(1, 1, 'Dupont', 'Marie', 'marie.dupont@test.fr', 'AQAAAAIAAYagAAAAEN64YQPhukh0NTQo5cvn1ZEdwKtds1j0b...', '2026-01-05 08:51:58.257', TRUE, NULL, TRUE),
(2, 2, 'Martin', 'Paul', 'paul.martin@test.fr', 'AQAAAAIAAYagAAAAEN64YQPhukh0NTQo5cvn1ZEdwKtds1j0b...', '2026-01-05 08:51:58.257', FALSE, NULL, TRUE),
(23, 3, 'Mougeot', 'Manon', 'manon.mougeot@gmail.com', 'AQAAAAIAAYagAAAAEIC1wfEm/WnWluGcvmP/ypepYgsihLV/...', '2026-01-17 14:49:49.866', FALSE, NULL, FALSE);

-- Table : statut_commandes
INSERT INTO statut_commandes (id, label) VALUES
(1, 'Attente'),
(2, 'Preparation'),
(3, 'Finalisee'),
(4, 'Envoie');

-- Table : commandes
INSERT INTO commandes (id, utilisateur_id, date_creation, statut_comma) VALUES
(1, 1, '2026-01-05 08:51:58.257', 3),
(2, 2, '2026-01-05 08:51:58.257', 2),
(3, 18, '2026-01-12 20:20:01.304', 1),
(4, 19, '2026-01-13 12:54:10.512', 4),
(46, 20, '2026-01-15 16:10:22.114', 3),
(48, 21, '2026-01-16 09:05:41.002', 2),
(51, 22, '2026-01-17 11:32:19.458', 1);

-- Table : tailles
INSERT INTO tailles (id, nom) VALUES
(1, '4 ans'), (2, '5 ans'), (4, '6 ans'), (5, '7 ans'), (6, '8 ans'),
(7, '9 ans'), (8, '10 ans'), (9, '11 ans'), (10, '12 ans'), (11, '13 ans'),
(12, '14 ans'), (13, '15 ans'), (14, 'XS'), (15, 'S'), (16, 'M'),
(17, 'L'), (18, 'XL'), (19, 'XLL'), (20, 'XLLL');

-- Table : produits (uniquement les 3 produits utilisés dans le test)
INSERT INTO produits (id, nom, description, prix, quantite) VALUES
(1, 'Tee-shirt blanc', 'Tee-shirt blanc 100% coton', 22, 100),
(3, 'basket blanche', 'basket blanche nike', 85, 2),
(4, ' Pull avec motifs nœuds fille', 'Ce pull pour fille a tout pour plaire aux jeunes passionnées de mode. Confectionné dans une maille douce enrichie en viscose, il offre un confort incomparable tout en adoptant une coupe oversize ultra tendance. Ses jolis motifs nœuds ajoutent une touche girly et délicate, idéale pour égayer le dressing de saison. Doté d’un col rond et de finitions en bord-côte, ce pull à motifs se marie parfaitement avec un jean ou un pantalon uni pour un look à la fois moderne et plein de charme.', 35, 6);

-- Table : commande_produit (uniquement les lignes référençant les produits 1, 2, 3)
INSERT INTO commande_produit (commande_id, produit_id, quantite, estramasse, estemballe) VALUES
(1, 1, 2, FALSE, FALSE),
(1, 3, 1, FALSE, FALSE),
(1, 4, 1, FALSE, FALSE),
(2, 4, 1, FALSE, FALSE),
(4, 1, 2, FALSE, FALSE),
(4, 3, 2, FALSE, FALSE),
(46, 3, 1, FALSE, FALSE),
(48, 3, 1, FALSE, FALSE),
(51, 1, 1, FALSE, FALSE);

-- Table : images (uniquement les images des produits 1, 2, 3)
INSERT INTO images (id, produit_id, url, description, date_creation) VALUES
(11, 1, '/images/Produits/hw3hfc3c.webp', 'image_1', '2026-01-08 14:21:47.000'),
(12, 1, '/images/Produits/2bedgkkm.webp', 'image_2', '2026-01-08 14:21:47.000'),
(13, 1, '/images/Produits/0exqxzth.webp', 'image_3', '2026-01-08 14:21:47.000'),
(14, 3, '/images/Produits/lvgmouvj.webp', 'image_1', '2026-01-08 15:02:19.000'),
(15, 3, '/images/Produits/e2nfuw1z.webp', 'image_2', '2026-01-08 15:02:19.000'),
(16, 3, '/images/Produits/f5baohi2.webp', 'image_3', '2026-01-08 15:02:19.000'),
(17, 4, '/images/Produits/frd5rcph.webp', 'image_1', '2026-01-08 14:45:12.000'),
(18, 4, '/images/Produits/p1na4gsh.webp', 'image_2', '2026-01-08 14:45:12.000'),
(19, 4, '/images/Produits/klsjnwzj.webp', 'image_3', '2026-01-08 14:45:12.000');

-- Table : paniers
INSERT INTO paniers (id, utilisateur_id, date_creation) VALUES
(1, 1, '2026-02-01 10:15:00.000'),
(2, 2, '2026-02-02 11:20:00.000'),
(3, 23, '2026-02-03 09:05:00.000'),
(4, 11, '2026-02-04 17:40:00.000');

-- Table : produit_categories (mapping exact : chemise->Hommes, tee shirt->Pulls, basket blanche->Hommes)
INSERT INTO produit_categories (produit_id, categorie_id) VALUES
(1, 9),
(3, 5),
(3, 11),
(4, 7);

-- Table : produit_paniers (uniquement les lignes référençant les produits 1, 2, 3)
INSERT INTO produit_paniers (panier_id, produit_id, quantite) VALUES
(1, 1, 1),
(1, 3, 1),
(2, 4, 3);

-- Table : produit_tailles (uniquement les lignes référençant les produits 1, 2)
INSERT INTO produit_tailles (produit_id, taille_id) VALUES
(1, 14), (1, 15), (1, 16), (1, 17),
(3, 15), (3, 16), (3, 17), (3, 18);

-- -----------------------------------------------------
-- 3. MISE A JOUR DES SEQUENCES DE CLES PRIMAIRES
-- -----------------------------------------------------
SELECT setval(pg_get_serial_sequence('adresses', 'id'), COALESCE(MAX(id), 1)) FROM adresses;
SELECT setval(pg_get_serial_sequence('categories', 'id'), COALESCE(MAX(id), 1)) FROM categories;
SELECT setval(pg_get_serial_sequence('utilisateurs', 'id'), COALESCE(MAX(id), 1)) FROM utilisateurs;
SELECT setval(pg_get_serial_sequence('statut_commandes', 'id'), COALESCE(MAX(id), 1)) FROM statut_commandes;
SELECT setval(pg_get_serial_sequence('commandes', 'id'), COALESCE(MAX(id), 1)) FROM commandes;
SELECT setval(pg_get_serial_sequence('tailles', 'id'), COALESCE(MAX(id), 1)) FROM tailles;
SELECT setval(pg_get_serial_sequence('produits', 'id'), COALESCE(MAX(id), 1)) FROM produits;
SELECT setval(pg_get_serial_sequence('images', 'id'), COALESCE(MAX(id), 1)) FROM images;
SELECT setval(pg_get_serial_sequence('paniers', 'id'), COALESCE(MAX(id), 1)) FROM paniers;