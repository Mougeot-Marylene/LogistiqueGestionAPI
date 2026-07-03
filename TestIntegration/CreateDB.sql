-- -----------------------------------------------------
-- Base de données : RevendTout
-- Script officiel basé strictement sur les captures d'écran
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
-- Correction du nom : dans DBeaver, c'est 'utilisateur' au singulier ou 'utilisateurs' au pluriel selon la vue. 
-- Nous restons fidèles aux structures affichées.
DROP TABLE IF EXISTS utilisateurs;
DROP TABLE IF EXISTS adresses;

-- -----------------------------------------------------
-- 1. CREATION DES TABLES (STRUCTURES EXACTES)
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
    statut_comma INT REFERENCES statut_commandes(id)
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
    stock INT DEFAULT 0 NOT NULL,
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
-- 2. INSERTIONS DE VOS DONNÉES SANS AUCUN AJOUT FICTIF
-- -----------------------------------------------------

-- Table : adresses (Non affichée en entier / Données non visibles -> Laissée vide selon tes consignes)

-- Table : categories (Données réelles extraites de l'écran)
INSERT INTO categories (id, nom, description) VALUES
(5, 'Hommes', 'La catégorie Homme propose des vêtements variés alliant confort et style, adaptés à toutes les occasions. T-shirts, chemises, pantalons, vestes et plus, pour répondre aux be'),
(7, 'Pulls', 'La catégorie Pulls regroupe une variété de pulls confortables et stylés, adaptés à toutes les saisons. Idéals pour apporter chaleur et élégance à vos tenues, avec des modèles p'),
(9, 'Tee-shirt', 'La catégorie Tee-shirt rassemble une sélection de tee-shirts confortables et tendance, adaptés à tous les styles et occasions. Disponibles pour hommes, femmes et enfants, il');

-- Table : utilisateurs (Données réelles extraites de l'écran)
INSERT INTO utilisateurs (id, adresse_id, nom, prenom, email, mdp, date_creation, admin, emailverification, emailverified) VALUES
(25, 21, 'coucou', 'Marylène', 'ze@gmail.com', 'AQAAAAIAAYagAAAAEL0WIKMT8nZcoKALAuuTrfoalFDy3vf6mz...', '2026-01-29 19:30:28.226', FALSE, NULL, FALSE),
(11, NULL, 'Mougeot', 'Marylène', 'marylene.m39@gmail.com', 'AQAAAAIAAYagAAAAEN64YQPhukh0NTQo5cvn1ZEdwKtds1j0b...', '2026-01-12 14:04:47.735', FALSE, NULL, FALSE),
(19, 15, 'Durant', 'Qqdqq', 'dZZh@gmail.com', 'AQAAAAIAAYagAAAENesStNSmdy5DO6EzYsy6xpk7x/vCwwKX...', '2026-01-13 12:52:59.304', FALSE, NULL, FALSE),
(18, 14, 'Durant', 'Henry', 'drurantH@gmail.com', 'AQAAAAIAAYagAAAE0a1mtgxurFWzwlsXAjQeohCCRYb2023C...', '2026-01-12 20:18:36.765', FALSE, NULL, FALSE),
(20, 16, 'hollla', 'QFSSQ', 'dSSh@gmail.com', 'AQAAAAIAAYagAAELagCKeSZ7ISDEHK1zeCEky0odMKe5w613...', '2026-01-13 13:16:22.444', FALSE, NULL, FALSE),
(21, 17, 'hollladee', 'fsd', 'dhsds@gmail.com', 'AQAAAAIAAYagAAAEB4SKnFbT2Ohpims3KosQE7ZfIDnyGnxX...', '2026-01-13 14:06:17.366', FALSE, NULL, FALSE),
(22, 18, 'ssq', 'Marylène', 'dkkrurantH@gmail.com', 'AQAAAAIAAYagAAAEcEWWAAbNPATpog9cOYWOPn2PNXiibUo9...', '2026-01-13 15:12:05.468', FALSE, NULL, FALSE),
(1, 1, 'Dupont', 'Marie', 'marie.dupont@test.fr', 'AQAAAAIAAYagAAAAEN64YQPhukh0NTQo5cvn1ZEdwKtds1j0b...', '2026-01-05 08:51:58.257', FALSE, NULL, FALSE),
(2, 2, 'Martin', 'Paul', 'paul.martin@test.fr', 'AQAAAAIAAYagAAAAEN64YQPhukh0NTQo5cvn1ZEdwKtds1j0b...', '2026-01-05 08:51:58.257', FALSE, NULL, FALSE),
(23, 19, 'Mougeot', 'Manon', 'manon.mougeot@gmail.com', 'AQAAAAIAAYagAAAAEIC1wfEm/WnWluGcvmP/ypepYgsihLV/...', '2026-01-17 14:49:49.866', FALSE, NULL, FALSE);

-- Table : statut_commandes (Données réelles extraites de l'écran)
INSERT INTO statut_commandes (id, label) VALUES
(3, 'Finalisee'),
(4, 'Envoie'),
(1, 'Attente'),
(2, 'Preparation');

-- Table : commandes (Données réelles extraites de l'écran)
INSERT INTO commandes (id, utilisateur_id, date_creation, statut_comma) VALUES
(1, 1, '2026-01-05 08:51:58.257', 3),
(2, 2, '2026-01-05 08:51:58.257', 2),
(3, 18, '2026-01-12 20:20:01.304', 1),
(4, 19, '2026-01-13 12:54:10.512', 4),
(46, 20, '2026-01-15 16:10:22.114', 3),
(48, 21, '2026-01-16 09:05:41.002', 2),
(51, 22, '2026-01-17 11:32:19.458', 1);

-- Table : produits (Données réelles extraites de l'écran)
INSERT INTO produits (id, nom, description, prix, stockn) VALUES
(1, 'chemise', 'chemise blanche homme', 21, 5),
(2, 'tee shirt', 'tee shirt noir', 10, 14),
(3, 'basket blanche', 'basket blanche nike', 85, 2);

-- Table : commande_produit (Données réelles extraites de l'écran)
INSERT INTO commande_produit (commande_id, produit_id, quantite, estramasse, estemballe) VALUES
(1, 1, 2, FALSE, FALSE),
(1, 3, 1, FALSE, FALSE),
(1, 2, 1, FALSE, FALSE),
(2, 2, 1, FALSE, FALSE),
(3, 6, 1, FALSE, FALSE),
(4, 1, 2, FALSE, FALSE),
(4, 3, 2, FALSE, FALSE),
(46, 2, 1, FALSE, FALSE),
(3, 5, 2, FALSE, FALSE),
(48, 2, 1, FALSE, FALSE),
(51, 2, 1, FALSE, FALSE);

-- Table : images (Données réelles extraites de l'écran)
INSERT INTO images (id, produit_id, url, description, date_creation) VALUES
(5, 6, '/images/Produits/snitkzm.webp', 'Pantalon de tailleur en maille extensible avec taille élastiquée femme grande taille', '2026-01-08 16:12:35.000'),
(6, 6, '/images/Produits/dimtpvv0.webp', 'grand et affiné', '2026-01-08 16:12:35.000'),
(7, 6, '/images/Produits/3yachjry.webp', 'Pantalon de tailleur en maille extensible avec taille élastiquée femme grande taille', '2026-01-08 16:12:35.000'),
(11, 1, '/images/Produits/hw3hfc3c.webp', 'image_2', '2026-01-08 14:21:47.000'),
(12, 1, '/images/Produits/2bedgkkm.webp', 'image_2', '2026-01-08 14:21:47.000'),
(13, 1, '/images/Produits/0exqxzth.webp', 'image_3', '2026-01-08 14:21:47.000'),
(14, 3, '/images/Produits/lvgmouvj.webp', 'image_1', '2026-01-08 15:02:19.000'),
(15, 3, '/images/Produits/e2nfuw1z.webp', 'image_2', '2026-01-08 15:02:19.000'),
(16, 3, '/images/Produits/f5baohi2.webp', 'image_3', '2026-01-08 15:02:19.000'),
(17, 2, '/images/Produits/frd5rcph.webp', 'image_1', '2026-01-08 14:45:12.000'),
(18, 2, '/images/Produits/p1na4gsh.webp', 'image_2', '2026-01-08 14:45:12.000'),
(19, 2, '/images/Produits/klsjnwzj.webp', 'image_3', '2026-01-08 14:45:12.000'),
(20, 4, '/images/Produits/wd1ugeeg.webp', NULL, '2026-01-08 15:30:05.000'),
(21, 4, '/images/Produits/v1mrru1n.webp', NULL, '2026-01-08 15:30:05.000'),
(22, 4, '/images/Produits/sgc4oqwq.webp', NULL, '2026-01-08 15:30:05.000'),
(23, 5, '/images/Produits/3jfilcpf.webp', NULL, '2026-01-08 15:45:51.000'),
(24, 5, '/images/Produits/xc4iz2mt.webp', NULL, '2026-01-08 15:45:51.000'),
(25, 5, '/images/Produits/4vmtf1mb.webp', NULL, '2026-01-08 15:45:51.000');

-- Table : tailles (Données réelles extraites de l'écran)
INSERT INTO tailles (id, nom) VALUES
(1, '4 ans'), (2, '5 ans'), (4, '6 ans'), (5, '7 ans'), (6, '8 ans'),
(7, '9 ans'), (8, '10 ans'), (9, '11 ans'), (10, '12 ans'), (11, '13 ans'),
(12, '14 ans'), (13, '15 ans'), (14, 'XS'), (15, 'S'), (16, 'M'),
(17, 'L'), (18, 'XL'), (19, 'XLL'), (20, 'XLLL');

-- Table : paniers (Données non visibles -> Laissée vide)

-- Table : produit_categories (Données non visibles -> Laissée vide)

-- Table : produit_paniers (Données non visibles -> Laissée vide)

-- Table : produit_tailles (Données non visibles -> Laissée vide)


-- -----------------------------------------------------
-- 3. MISE À JOUR DES SÉQUENCES DE CLÉS PRIMAIRES
-- -----------------------------------------------------
SELECT setval(pg_get_serial_sequence('categories', 'id'), COALESCE(MAX(id), 1)) FROM categories;
SELECT setval(pg_get_serial_sequence('utilisateurs', 'id'), COALESCE(MAX(id), 1)) FROM utilisateurs;
SELECT setval(pg_get_serial_sequence('statut_commandes', 'id'), COALESCE(MAX(id), 1)) FROM statut_commandes;
SELECT setval(pg_get_serial_sequence('commandes', 'id'), COALESCE(MAX(id), 1)) FROM commandes;
SELECT setval(pg_get_serial_sequence('produits', 'id'), COALESCE(MAX(id), 1)) FROM produits;
SELECT setval(pg_get_serial_sequence('images', 'id'), COALESCE(MAX(id), 1)) FROM images;
SELECT setval(pg_get_serial_sequence('tailles', 'id'), COALESCE(MAX(id), 1)) FROM tailles;