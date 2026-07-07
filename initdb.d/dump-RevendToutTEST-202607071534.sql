--
-- PostgreSQL database dump
--

\restrict I9v25ZQ9a9KvmHFED6Ohdlf07wbBOubbk5TlhrEFSasN51Mf4EOcWOcmvhHhTvk

-- Dumped from database version 18.4 (Debian 18.4-1.pgdg13+1)
-- Dumped by pg_dump version 18.4

-- Started on 2026-07-07 15:34:52

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 5 (class 2615 OID 30997)
-- Name: public; Type: SCHEMA; Schema: -; Owner: postgres
--

-- *not* creating schema, since initdb creates it


ALTER SCHEMA public OWNER TO postgres;

--
-- TOC entry 3582 (class 0 OID 0)
-- Dependencies: 5
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON SCHEMA public IS '';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 220 (class 1259 OID 30999)
-- Name: adresses; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.adresses (
    id integer NOT NULL,
    numero_rue character varying(10) NOT NULL,
    nom_rue character varying(200) NOT NULL,
    ville character varying(100) NOT NULL,
    code_postal character varying(20) NOT NULL,
    pays character varying(100) NOT NULL,
    date_creation timestamp without time zone DEFAULT now() NOT NULL
);


ALTER TABLE public.adresses OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 30998)
-- Name: adresses_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.adresses_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.adresses_id_seq OWNER TO postgres;

--
-- TOC entry 3584 (class 0 OID 0)
-- Dependencies: 219
-- Name: adresses_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.adresses_id_seq OWNED BY public.adresses.id;


--
-- TOC entry 222 (class 1259 OID 31014)
-- Name: categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.categories (
    id integer NOT NULL,
    nom character varying(100) NOT NULL,
    description text
);


ALTER TABLE public.categories OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 31013)
-- Name: categories_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.categories_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.categories_id_seq OWNER TO postgres;

--
-- TOC entry 3585 (class 0 OID 0)
-- Dependencies: 221
-- Name: categories_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.categories_id_seq OWNED BY public.categories.id;


--
-- TOC entry 233 (class 1259 OID 31105)
-- Name: commande_produit; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.commande_produit (
    commande_id integer NOT NULL,
    produit_id integer NOT NULL,
    quantite integer DEFAULT 1 NOT NULL,
    estramasse boolean DEFAULT false,
    estemballe boolean DEFAULT false
);


ALTER TABLE public.commande_produit OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 31061)
-- Name: commandes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.commandes (
    id integer NOT NULL,
    utilisateur_id integer,
    date_creation timestamp without time zone DEFAULT now() NOT NULL,
    statut_comma integer
);


ALTER TABLE public.commandes OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 31060)
-- Name: commandes_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.commandes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.commandes_id_seq OWNER TO postgres;

--
-- TOC entry 3586 (class 0 OID 0)
-- Dependencies: 227
-- Name: commandes_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.commandes_id_seq OWNED BY public.commandes.id;


--
-- TOC entry 235 (class 1259 OID 31127)
-- Name: images; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.images (
    id integer NOT NULL,
    produit_id integer,
    url character varying(100) NOT NULL,
    description character varying(100),
    date_creation timestamp without time zone DEFAULT now() NOT NULL
);


ALTER TABLE public.images OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 31126)
-- Name: images_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.images_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.images_id_seq OWNER TO postgres;

--
-- TOC entry 3587 (class 0 OID 0)
-- Dependencies: 234
-- Name: images_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.images_id_seq OWNED BY public.images.id;


--
-- TOC entry 237 (class 1259 OID 31143)
-- Name: paniers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.paniers (
    id integer NOT NULL,
    utilisateur_id integer,
    date_creation timestamp without time zone DEFAULT now() NOT NULL
);


ALTER TABLE public.paniers OWNER TO postgres;

--
-- TOC entry 236 (class 1259 OID 31142)
-- Name: paniers_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.paniers_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.paniers_id_seq OWNER TO postgres;

--
-- TOC entry 3588 (class 0 OID 0)
-- Dependencies: 236
-- Name: paniers_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.paniers_id_seq OWNED BY public.paniers.id;


--
-- TOC entry 238 (class 1259 OID 31157)
-- Name: produit_categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.produit_categories (
    produit_id integer NOT NULL,
    categorie_id integer NOT NULL
);


ALTER TABLE public.produit_categories OWNER TO postgres;

--
-- TOC entry 239 (class 1259 OID 31174)
-- Name: produit_paniers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.produit_paniers (
    panier_id integer NOT NULL,
    produit_id integer NOT NULL,
    quantite integer DEFAULT 1 NOT NULL
);


ALTER TABLE public.produit_paniers OWNER TO postgres;

--
-- TOC entry 240 (class 1259 OID 31193)
-- Name: produit_tailles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.produit_tailles (
    produit_id integer NOT NULL,
    taille_id integer NOT NULL
);


ALTER TABLE public.produit_tailles OWNER TO postgres;

--
-- TOC entry 232 (class 1259 OID 31090)
-- Name: produits; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.produits (
    id integer NOT NULL,
    nom character varying(150) NOT NULL,
    description text,
    prix numeric(10,2) NOT NULL,
    quantite integer DEFAULT 0 NOT NULL,
    date_creation timestamp without time zone DEFAULT now() NOT NULL
);


ALTER TABLE public.produits OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 31089)
-- Name: produits_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.produits_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.produits_id_seq OWNER TO postgres;

--
-- TOC entry 3589 (class 0 OID 0)
-- Dependencies: 231
-- Name: produits_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.produits_id_seq OWNED BY public.produits.id;


--
-- TOC entry 226 (class 1259 OID 31052)
-- Name: statut_commandes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.statut_commandes (
    id integer NOT NULL,
    label character varying(50) NOT NULL
);


ALTER TABLE public.statut_commandes OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 31051)
-- Name: statut_commandes_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.statut_commandes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.statut_commandes_id_seq OWNER TO postgres;

--
-- TOC entry 3590 (class 0 OID 0)
-- Dependencies: 225
-- Name: statut_commandes_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.statut_commandes_id_seq OWNED BY public.statut_commandes.id;


--
-- TOC entry 230 (class 1259 OID 31081)
-- Name: tailles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tailles (
    id integer NOT NULL,
    nom character varying(100) NOT NULL
);


ALTER TABLE public.tailles OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 31080)
-- Name: tailles_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tailles_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.tailles_id_seq OWNER TO postgres;

--
-- TOC entry 3591 (class 0 OID 0)
-- Dependencies: 229
-- Name: tailles_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tailles_id_seq OWNED BY public.tailles.id;


--
-- TOC entry 224 (class 1259 OID 31025)
-- Name: utilisateurs; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.utilisateurs (
    id integer NOT NULL,
    adresse_id integer,
    nom character varying(100) NOT NULL,
    prenom character varying(100) NOT NULL,
    email character varying(150) NOT NULL,
    mdp character varying(255) NOT NULL,
    date_creation timestamp without time zone DEFAULT now() NOT NULL,
    admin boolean DEFAULT false NOT NULL,
    emailverification character varying(255),
    emailverified boolean DEFAULT false NOT NULL
);


ALTER TABLE public.utilisateurs OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 31024)
-- Name: utilisateurs_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.utilisateurs_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.utilisateurs_id_seq OWNER TO postgres;

--
-- TOC entry 3592 (class 0 OID 0)
-- Dependencies: 223
-- Name: utilisateurs_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.utilisateurs_id_seq OWNED BY public.utilisateurs.id;


--
-- TOC entry 3345 (class 2604 OID 31002)
-- Name: adresses id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.adresses ALTER COLUMN id SET DEFAULT nextval('public.adresses_id_seq'::regclass);


--
-- TOC entry 3347 (class 2604 OID 31017)
-- Name: categories id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories ALTER COLUMN id SET DEFAULT nextval('public.categories_id_seq'::regclass);


--
-- TOC entry 3353 (class 2604 OID 31064)
-- Name: commandes id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commandes ALTER COLUMN id SET DEFAULT nextval('public.commandes_id_seq'::regclass);


--
-- TOC entry 3362 (class 2604 OID 31130)
-- Name: images id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.images ALTER COLUMN id SET DEFAULT nextval('public.images_id_seq'::regclass);


--
-- TOC entry 3364 (class 2604 OID 31146)
-- Name: paniers id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.paniers ALTER COLUMN id SET DEFAULT nextval('public.paniers_id_seq'::regclass);


--
-- TOC entry 3356 (class 2604 OID 31093)
-- Name: produits id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produits ALTER COLUMN id SET DEFAULT nextval('public.produits_id_seq'::regclass);


--
-- TOC entry 3352 (class 2604 OID 31055)
-- Name: statut_commandes id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statut_commandes ALTER COLUMN id SET DEFAULT nextval('public.statut_commandes_id_seq'::regclass);


--
-- TOC entry 3355 (class 2604 OID 31084)
-- Name: tailles id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tailles ALTER COLUMN id SET DEFAULT nextval('public.tailles_id_seq'::regclass);


--
-- TOC entry 3348 (class 2604 OID 31028)
-- Name: utilisateurs id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.utilisateurs ALTER COLUMN id SET DEFAULT nextval('public.utilisateurs_id_seq'::regclass);


--
-- TOC entry 3556 (class 0 OID 30999)
-- Dependencies: 220
-- Data for Name: adresses; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.adresses (id, numero_rue, nom_rue, ville, code_postal, pays, date_creation) FROM stdin;
1	12	Rue de la République	Paris	75001	France	2026-07-06 12:21:17.740599
2	45	Avenue Jean Jaurès	Lyon	69007	France	2026-07-06 12:21:17.740599
3	8	Rue des Fleurs	Marseille	13001	France	2026-07-06 12:21:17.740599
\.


--
-- TOC entry 3558 (class 0 OID 31014)
-- Dependencies: 222
-- Data for Name: categories; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.categories (id, nom, description) FROM stdin;
5	Hommes	La catégorie Homme propose des vêtements variés alliant confort et style, adaptés à toutes les occasions. T-shirts, chemises, pantalons, vestes et plus, pour répondre aux be
7	Pulls	La catégorie Pulls regroupe une variété de pulls confortables et stylés, adaptés à toutes les saisons. Idéals pour apporter chaleur et élégance à vos tenues, avec des modèles p
9	Tee-shirt	La catégorie Tee-shirt rassemble une sélection de tee-shirts confortables et tendance, adaptés à tous les styles et occasions. Disponibles pour hommes, femmes et enfants, il
\.


--
-- TOC entry 3569 (class 0 OID 31105)
-- Dependencies: 233
-- Data for Name: commande_produit; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.commande_produit (commande_id, produit_id, quantite, estramasse, estemballe) FROM stdin;
1	1	2	f	f
1	3	1	f	f
1	2	1	f	f
2	2	1	f	f
4	1	2	f	f
4	3	2	f	f
46	2	1	f	f
48	2	1	f	f
51	2	1	f	f
\.


--
-- TOC entry 3564 (class 0 OID 31061)
-- Dependencies: 228
-- Data for Name: commandes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.commandes (id, utilisateur_id, date_creation, statut_comma) FROM stdin;
1	1	2026-01-05 08:51:58.257	3
2	2	2026-01-05 08:51:58.257	2
3	18	2026-01-12 20:20:01.304	1
4	19	2026-01-13 12:54:10.512	4
46	20	2026-01-15 16:10:22.114	3
48	21	2026-01-16 09:05:41.002	2
51	22	2026-01-17 11:32:19.458	1
\.


--
-- TOC entry 3571 (class 0 OID 31127)
-- Dependencies: 235
-- Data for Name: images; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.images (id, produit_id, url, description, date_creation) FROM stdin;
11	1	/images/Produits/hw3hfc3c.webp	image_1	2026-01-08 14:21:47
12	1	/images/Produits/2bedgkkm.webp	image_2	2026-01-08 14:21:47
13	1	/images/Produits/0exqxzth.webp	image_3	2026-01-08 14:21:47
14	3	/images/Produits/lvgmouvj.webp	image_1	2026-01-08 15:02:19
15	3	/images/Produits/e2nfuw1z.webp	image_2	2026-01-08 15:02:19
16	3	/images/Produits/f5baohi2.webp	image_3	2026-01-08 15:02:19
17	2	/images/Produits/frd5rcph.webp	image_1	2026-01-08 14:45:12
18	2	/images/Produits/p1na4gsh.webp	image_2	2026-01-08 14:45:12
19	2	/images/Produits/klsjnwzj.webp	image_3	2026-01-08 14:45:12
\.


--
-- TOC entry 3573 (class 0 OID 31143)
-- Dependencies: 237
-- Data for Name: paniers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.paniers (id, utilisateur_id, date_creation) FROM stdin;
1	1	2026-02-01 10:15:00
2	2	2026-02-02 11:20:00
3	23	2026-02-03 09:05:00
4	11	2026-02-04 17:40:00
\.


--
-- TOC entry 3574 (class 0 OID 31157)
-- Dependencies: 238
-- Data for Name: produit_categories; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.produit_categories (produit_id, categorie_id) FROM stdin;
2	5
2	7
3	5
\.


--
-- TOC entry 3575 (class 0 OID 31174)
-- Dependencies: 239
-- Data for Name: produit_paniers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.produit_paniers (panier_id, produit_id, quantite) FROM stdin;
1	1	1
1	3	1
2	2	3
\.


--
-- TOC entry 3576 (class 0 OID 31193)
-- Dependencies: 240
-- Data for Name: produit_tailles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.produit_tailles (produit_id, taille_id) FROM stdin;
1	14
1	15
1	16
1	17
2	15
2	16
2	17
2	18
\.


--
-- TOC entry 3568 (class 0 OID 31090)
-- Dependencies: 232
-- Data for Name: produits; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.produits (id, nom, description, prix, quantite, date_creation) FROM stdin;
1	chemise	chemise blanche homme	21.00	5	2026-07-06 12:21:17.740599
2	tee shirt	tee shirt noir	10.00	14	2026-07-06 12:21:17.740599
3	basket blanche	basket blanche nike	85.00	2	2026-07-06 12:21:17.740599
\.


--
-- TOC entry 3562 (class 0 OID 31052)
-- Dependencies: 226
-- Data for Name: statut_commandes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.statut_commandes (id, label) FROM stdin;
1	Attente
2	Preparation
3	Finalisee
4	Envoie
\.


--
-- TOC entry 3566 (class 0 OID 31081)
-- Dependencies: 230
-- Data for Name: tailles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tailles (id, nom) FROM stdin;
1	4 ans
2	5 ans
4	6 ans
5	7 ans
6	8 ans
7	9 ans
8	10 ans
9	11 ans
10	12 ans
11	13 ans
12	14 ans
13	15 ans
14	XS
15	S
16	M
17	L
18	XL
19	XLL
20	XLLL
\.


--
-- TOC entry 3560 (class 0 OID 31025)
-- Dependencies: 224
-- Data for Name: utilisateurs; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.utilisateurs (id, adresse_id, nom, prenom, email, mdp, date_creation, admin, emailverification, emailverified) FROM stdin;
25	2	coucou	Marylène	ze@gmail.com	AQAAAAIAAYagAAAAEL0WIKMT8nZcoKALAuuTrfoalFDy3vf6mz...	2026-01-29 19:30:28.226	f	\N	f
11	\N	Mougeot	Marylène	marylene.m39@gmail.com	AQAAAAIAAYagAAAAEN64YQPhukh0NTQo5cvn1ZEdwKtds1j0b...	2026-01-12 14:04:47.735	f	\N	f
19	1	Durant	Qqdqq	dZZh@gmail.com	AQAAAAIAAYagAAAENesStNSmdy5DO6EzYsy6xpk7x/vCwwKX...	2026-01-13 12:52:59.304	f	\N	f
18	1	Durant	Henry	drurantH@gmail.com	AQAAAAIAAYagAAAE0a1mtgxurFWzwlsXAjQeohCCRYb2023C...	2026-01-12 20:18:36.765	f	\N	f
20	3	hollla	QFSSQ	dSSh@gmail.com	AQAAAAIAAYagAAELagCKeSZ7ISDEHK1zeCEky0odMKe5w613...	2026-01-13 13:16:22.444	f	\N	f
21	1	hollladee	fsd	dhsds@gmail.com	AQAAAAIAAYagAAAEB4SKnFbT2Ohpims3KosQE7ZfIDnyGnxX...	2026-01-13 14:06:17.366	f	\N	f
22	1	ssq	Marylène	dkkrurantH@gmail.com	AQAAAAIAAYagAAAEcEWWAAbNPATpog9cOYWOPn2PNXiibUo9...	2026-01-13 15:12:05.468	f	\N	f
1	1	Dupont	Marie	marie.dupont@test.fr	AQAAAAIAAYagAAAAEN64YQPhukh0NTQo5cvn1ZEdwKtds1j0b...	2026-01-05 08:51:58.257	t	\N	t
2	2	Martin	Paul	paul.martin@test.fr	AQAAAAIAAYagAAAAEN64YQPhukh0NTQo5cvn1ZEdwKtds1j0b...	2026-01-05 08:51:58.257	f	\N	t
23	3	Mougeot	Manon	manon.mougeot@gmail.com	AQAAAAIAAYagAAAAEIC1wfEm/WnWluGcvmP/ypepYgsihLV/...	2026-01-17 14:49:49.866	f	\N	f
\.


--
-- TOC entry 3593 (class 0 OID 0)
-- Dependencies: 219
-- Name: adresses_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.adresses_id_seq', 3, true);


--
-- TOC entry 3594 (class 0 OID 0)
-- Dependencies: 221
-- Name: categories_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.categories_id_seq', 9, true);


--
-- TOC entry 3595 (class 0 OID 0)
-- Dependencies: 227
-- Name: commandes_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.commandes_id_seq', 51, true);


--
-- TOC entry 3596 (class 0 OID 0)
-- Dependencies: 234
-- Name: images_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.images_id_seq', 19, true);


--
-- TOC entry 3597 (class 0 OID 0)
-- Dependencies: 236
-- Name: paniers_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.paniers_id_seq', 4, true);


--
-- TOC entry 3598 (class 0 OID 0)
-- Dependencies: 231
-- Name: produits_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.produits_id_seq', 3, true);


--
-- TOC entry 3599 (class 0 OID 0)
-- Dependencies: 225
-- Name: statut_commandes_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.statut_commandes_id_seq', 4, true);


--
-- TOC entry 3600 (class 0 OID 0)
-- Dependencies: 229
-- Name: tailles_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tailles_id_seq', 20, true);


--
-- TOC entry 3601 (class 0 OID 0)
-- Dependencies: 223
-- Name: utilisateurs_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.utilisateurs_id_seq', 25, true);


--
-- TOC entry 3368 (class 2606 OID 31012)
-- Name: adresses adresses_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.adresses
    ADD CONSTRAINT adresses_pkey PRIMARY KEY (id);


--
-- TOC entry 3370 (class 2606 OID 31023)
-- Name: categories categories_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories
    ADD CONSTRAINT categories_pkey PRIMARY KEY (id);


--
-- TOC entry 3384 (class 2606 OID 31115)
-- Name: commande_produit commande_produit_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commande_produit
    ADD CONSTRAINT commande_produit_pkey PRIMARY KEY (commande_id, produit_id);


--
-- TOC entry 3378 (class 2606 OID 31069)
-- Name: commandes commandes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commandes
    ADD CONSTRAINT commandes_pkey PRIMARY KEY (id);


--
-- TOC entry 3386 (class 2606 OID 31136)
-- Name: images images_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.images
    ADD CONSTRAINT images_pkey PRIMARY KEY (id);


--
-- TOC entry 3388 (class 2606 OID 31151)
-- Name: paniers paniers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.paniers
    ADD CONSTRAINT paniers_pkey PRIMARY KEY (id);


--
-- TOC entry 3390 (class 2606 OID 31163)
-- Name: produit_categories produit_categories_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_categories
    ADD CONSTRAINT produit_categories_pkey PRIMARY KEY (produit_id, categorie_id);


--
-- TOC entry 3392 (class 2606 OID 31182)
-- Name: produit_paniers produit_paniers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_paniers
    ADD CONSTRAINT produit_paniers_pkey PRIMARY KEY (panier_id, produit_id);


--
-- TOC entry 3394 (class 2606 OID 31199)
-- Name: produit_tailles produit_tailles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_tailles
    ADD CONSTRAINT produit_tailles_pkey PRIMARY KEY (produit_id, taille_id);


--
-- TOC entry 3382 (class 2606 OID 31104)
-- Name: produits produits_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produits
    ADD CONSTRAINT produits_pkey PRIMARY KEY (id);


--
-- TOC entry 3376 (class 2606 OID 31059)
-- Name: statut_commandes statut_commandes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statut_commandes
    ADD CONSTRAINT statut_commandes_pkey PRIMARY KEY (id);


--
-- TOC entry 3380 (class 2606 OID 31088)
-- Name: tailles tailles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tailles
    ADD CONSTRAINT tailles_pkey PRIMARY KEY (id);


--
-- TOC entry 3372 (class 2606 OID 31045)
-- Name: utilisateurs utilisateurs_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.utilisateurs
    ADD CONSTRAINT utilisateurs_email_key UNIQUE (email);


--
-- TOC entry 3374 (class 2606 OID 31043)
-- Name: utilisateurs utilisateurs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.utilisateurs
    ADD CONSTRAINT utilisateurs_pkey PRIMARY KEY (id);


--
-- TOC entry 3398 (class 2606 OID 31116)
-- Name: commande_produit commande_produit_commande_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commande_produit
    ADD CONSTRAINT commande_produit_commande_id_fkey FOREIGN KEY (commande_id) REFERENCES public.commandes(id) ON DELETE CASCADE;


--
-- TOC entry 3399 (class 2606 OID 31121)
-- Name: commande_produit commande_produit_produit_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commande_produit
    ADD CONSTRAINT commande_produit_produit_id_fkey FOREIGN KEY (produit_id) REFERENCES public.produits(id) ON DELETE CASCADE;


--
-- TOC entry 3396 (class 2606 OID 31075)
-- Name: commandes commandes_statut_comma_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commandes
    ADD CONSTRAINT commandes_statut_comma_fkey FOREIGN KEY (statut_comma) REFERENCES public.statut_commandes(id);


--
-- TOC entry 3397 (class 2606 OID 31070)
-- Name: commandes commandes_utilisateur_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commandes
    ADD CONSTRAINT commandes_utilisateur_id_fkey FOREIGN KEY (utilisateur_id) REFERENCES public.utilisateurs(id) ON DELETE CASCADE;


--
-- TOC entry 3400 (class 2606 OID 31137)
-- Name: images images_produit_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.images
    ADD CONSTRAINT images_produit_id_fkey FOREIGN KEY (produit_id) REFERENCES public.produits(id) ON DELETE CASCADE;


--
-- TOC entry 3401 (class 2606 OID 31152)
-- Name: paniers paniers_utilisateur_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.paniers
    ADD CONSTRAINT paniers_utilisateur_id_fkey FOREIGN KEY (utilisateur_id) REFERENCES public.utilisateurs(id) ON DELETE CASCADE;


--
-- TOC entry 3402 (class 2606 OID 31169)
-- Name: produit_categories produit_categories_categorie_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_categories
    ADD CONSTRAINT produit_categories_categorie_id_fkey FOREIGN KEY (categorie_id) REFERENCES public.categories(id) ON DELETE CASCADE;


--
-- TOC entry 3403 (class 2606 OID 31164)
-- Name: produit_categories produit_categories_produit_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_categories
    ADD CONSTRAINT produit_categories_produit_id_fkey FOREIGN KEY (produit_id) REFERENCES public.produits(id) ON DELETE CASCADE;


--
-- TOC entry 3404 (class 2606 OID 31183)
-- Name: produit_paniers produit_paniers_panier_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_paniers
    ADD CONSTRAINT produit_paniers_panier_id_fkey FOREIGN KEY (panier_id) REFERENCES public.paniers(id) ON DELETE CASCADE;


--
-- TOC entry 3405 (class 2606 OID 31188)
-- Name: produit_paniers produit_paniers_produit_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_paniers
    ADD CONSTRAINT produit_paniers_produit_id_fkey FOREIGN KEY (produit_id) REFERENCES public.produits(id) ON DELETE CASCADE;


--
-- TOC entry 3406 (class 2606 OID 31200)
-- Name: produit_tailles produit_tailles_produit_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_tailles
    ADD CONSTRAINT produit_tailles_produit_id_fkey FOREIGN KEY (produit_id) REFERENCES public.produits(id) ON DELETE CASCADE;


--
-- TOC entry 3407 (class 2606 OID 31205)
-- Name: produit_tailles produit_tailles_taille_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_tailles
    ADD CONSTRAINT produit_tailles_taille_id_fkey FOREIGN KEY (taille_id) REFERENCES public.tailles(id) ON DELETE CASCADE;


--
-- TOC entry 3395 (class 2606 OID 31046)
-- Name: utilisateurs utilisateurs_adresse_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.utilisateurs
    ADD CONSTRAINT utilisateurs_adresse_id_fkey FOREIGN KEY (adresse_id) REFERENCES public.adresses(id) ON DELETE SET NULL;


--
-- TOC entry 3583 (class 0 OID 0)
-- Dependencies: 5
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE USAGE ON SCHEMA public FROM PUBLIC;


-- Completed on 2026-07-07 15:34:52

--
-- PostgreSQL database dump complete
--

\unrestrict I9v25ZQ9a9KvmHFED6Ohdlf07wbBOubbk5TlhrEFSasN51Mf4EOcWOcmvhHhTvk

