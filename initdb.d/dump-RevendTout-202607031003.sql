--
-- PostgreSQL database dump
--

\restrict a02vUHAcEQ2upmLM16IPwa8f1GqUv5JFIQY8MethUvO2ibHGuEkI9duo6AargwL

-- Dumped from database version 18.4 (Debian 18.4-1.pgdg13+1)
-- Dumped by pg_dump version 18.4

-- Started on 2026-07-03 10:03:31

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 219 (class 1259 OID 16385)
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
-- TOC entry 220 (class 1259 OID 16396)
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
-- TOC entry 3586 (class 0 OID 0)
-- Dependencies: 220
-- Name: adresses_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.adresses_id_seq OWNED BY public.adresses.id;


--
-- TOC entry 221 (class 1259 OID 16397)
-- Name: categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.categories (
    id integer NOT NULL,
    nom character varying(100) NOT NULL,
    description text
);


ALTER TABLE public.categories OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 16404)
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
-- TOC entry 3587 (class 0 OID 0)
-- Dependencies: 222
-- Name: categories_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.categories_id_seq OWNED BY public.categories.id;


--
-- TOC entry 223 (class 1259 OID 16405)
-- Name: commande_produit; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.commande_produit (
    commande_id integer NOT NULL,
    produit_id integer NOT NULL,
    quantite integer NOT NULL,
    estramasse boolean DEFAULT false,
    estemballe boolean DEFAULT false,
    CONSTRAINT commande_produit_quantite_check CHECK ((quantite > 0))
);


ALTER TABLE public.commande_produit OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 16412)
-- Name: commandes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.commandes (
    id integer NOT NULL,
    utilisateur_id integer NOT NULL,
    date_creation timestamp without time zone DEFAULT now() NOT NULL,
    statut_commandes_id integer
);


ALTER TABLE public.commandes OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 16419)
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
-- TOC entry 3588 (class 0 OID 0)
-- Dependencies: 225
-- Name: commandes_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.commandes_id_seq OWNED BY public.commandes.id;


--
-- TOC entry 226 (class 1259 OID 16420)
-- Name: images; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.images (
    id integer NOT NULL,
    produit_id integer NOT NULL,
    url character varying(100) NOT NULL,
    description character varying(100),
    date_creation timestamp without time zone DEFAULT now() NOT NULL
);


ALTER TABLE public.images OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 16428)
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
-- TOC entry 3589 (class 0 OID 0)
-- Dependencies: 227
-- Name: images_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.images_id_seq OWNED BY public.images.id;


--
-- TOC entry 228 (class 1259 OID 16429)
-- Name: paniers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.paniers (
    id integer NOT NULL,
    utilisateur_id integer NOT NULL,
    date_creation timestamp without time zone DEFAULT now() NOT NULL
);


ALTER TABLE public.paniers OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 16436)
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
-- TOC entry 3590 (class 0 OID 0)
-- Dependencies: 229
-- Name: paniers_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.paniers_id_seq OWNED BY public.paniers.id;


--
-- TOC entry 230 (class 1259 OID 16437)
-- Name: produit_categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.produit_categories (
    produit_id integer NOT NULL,
    categorie_id integer NOT NULL
);


ALTER TABLE public.produit_categories OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 16442)
-- Name: produit_paniers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.produit_paniers (
    produit_id integer NOT NULL,
    panier_id integer NOT NULL,
    quantite integer NOT NULL,
    CONSTRAINT produit_paniers_quantite_check CHECK ((quantite > 0))
);


ALTER TABLE public.produit_paniers OWNER TO postgres;

--
-- TOC entry 232 (class 1259 OID 16449)
-- Name: produit_tailles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.produit_tailles (
    produit_id integer NOT NULL,
    taille_id integer NOT NULL
);


ALTER TABLE public.produit_tailles OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 16454)
-- Name: produits; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.produits (
    id integer NOT NULL,
    nom character varying(255) NOT NULL,
    desc_courte character varying(250),
    description text,
    reduction numeric(10,2),
    prix numeric(10,2) NOT NULL,
    score_vente integer DEFAULT 0,
    quantite integer NOT NULL,
    date_creation timestamp without time zone DEFAULT now() NOT NULL,
    archive boolean DEFAULT false,
    CONSTRAINT produits_prix_check CHECK ((prix >= (0)::numeric)),
    CONSTRAINT produits_quantite_check CHECK ((quantite >= 0)),
    CONSTRAINT produits_reduction_check CHECK ((reduction >= (0)::numeric))
);


ALTER TABLE public.produits OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 16470)
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
-- TOC entry 3591 (class 0 OID 0)
-- Dependencies: 234
-- Name: produits_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.produits_id_seq OWNED BY public.produits.id;


--
-- TOC entry 235 (class 1259 OID 16471)
-- Name: statut_commandes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.statut_commandes (
    id integer NOT NULL,
    label character varying(100) NOT NULL
);


ALTER TABLE public.statut_commandes OWNER TO postgres;

--
-- TOC entry 236 (class 1259 OID 16476)
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
-- TOC entry 3592 (class 0 OID 0)
-- Dependencies: 236
-- Name: statut_commandes_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.statut_commandes_id_seq OWNED BY public.statut_commandes.id;


--
-- TOC entry 237 (class 1259 OID 16477)
-- Name: tailles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tailles (
    id integer NOT NULL,
    nom character varying(100)
);


ALTER TABLE public.tailles OWNER TO postgres;

--
-- TOC entry 238 (class 1259 OID 16481)
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
-- TOC entry 3593 (class 0 OID 0)
-- Dependencies: 238
-- Name: tailles_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tailles_id_seq OWNED BY public.tailles.id;


--
-- TOC entry 239 (class 1259 OID 16482)
-- Name: utilisateurs; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.utilisateurs (
    id integer NOT NULL,
    adresse_id integer,
    nom character varying(100),
    prenom character varying(100),
    email character varying(150) NOT NULL,
    mdp character varying(255) NOT NULL,
    date_creation timestamp without time zone DEFAULT now() NOT NULL,
    admin boolean DEFAULT false NOT NULL,
    emailverificationtoken character varying(255),
    emailverified boolean DEFAULT false
);


ALTER TABLE public.utilisateurs OWNER TO postgres;

--
-- TOC entry 240 (class 1259 OID 16495)
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
-- TOC entry 3594 (class 0 OID 0)
-- Dependencies: 240
-- Name: utilisateurs_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.utilisateurs_id_seq OWNED BY public.utilisateurs.id;


--
-- TOC entry 3345 (class 2604 OID 16496)
-- Name: adresses id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.adresses ALTER COLUMN id SET DEFAULT nextval('public.adresses_id_seq'::regclass);


--
-- TOC entry 3347 (class 2604 OID 16497)
-- Name: categories id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories ALTER COLUMN id SET DEFAULT nextval('public.categories_id_seq'::regclass);


--
-- TOC entry 3350 (class 2604 OID 16498)
-- Name: commandes id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commandes ALTER COLUMN id SET DEFAULT nextval('public.commandes_id_seq'::regclass);


--
-- TOC entry 3352 (class 2604 OID 16499)
-- Name: images id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.images ALTER COLUMN id SET DEFAULT nextval('public.images_id_seq'::regclass);


--
-- TOC entry 3354 (class 2604 OID 16500)
-- Name: paniers id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.paniers ALTER COLUMN id SET DEFAULT nextval('public.paniers_id_seq'::regclass);


--
-- TOC entry 3356 (class 2604 OID 16501)
-- Name: produits id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produits ALTER COLUMN id SET DEFAULT nextval('public.produits_id_seq'::regclass);


--
-- TOC entry 3360 (class 2604 OID 16502)
-- Name: statut_commandes id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statut_commandes ALTER COLUMN id SET DEFAULT nextval('public.statut_commandes_id_seq'::regclass);


--
-- TOC entry 3361 (class 2604 OID 16503)
-- Name: tailles id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tailles ALTER COLUMN id SET DEFAULT nextval('public.tailles_id_seq'::regclass);


--
-- TOC entry 3362 (class 2604 OID 16504)
-- Name: utilisateurs id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.utilisateurs ALTER COLUMN id SET DEFAULT nextval('public.utilisateurs_id_seq'::regclass);


--
-- TOC entry 3559 (class 0 OID 16385)
-- Dependencies: 219
-- Data for Name: adresses; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.adresses (id, numero_rue, nom_rue, ville, code_postal, pays, date_creation) FROM stdin;
2	8	Avenue Victor Hugo	Lyon	69006	France	2026-01-05 08:51:58.257581
14	3	Rue des tulipes	Dole	39100	France	2026-01-12 20:18:36.765091
15	5	Rue des tulipes	Dole	39100	France	2026-01-13 12:52:59.304181
16	4	Rue des tulipes	Dole	39100	France	2026-01-13 13:16:22.444122
17	9	Rue des tulipes	Dole	39100	France	2026-01-13 14:06:17.366325
18	4	Rue des tulipes	Dole	39100	France	2026-01-13 15:12:05.468833
19	3	rue de stulipes	saint loup	39120	France	2026-01-17 19:49:49.866692
1	12	Rue des Lilas	Saint Aubin	39410	France	2026-01-05 08:51:58.257581
21	3	rue de stulipes	saint loup	39120	France	2026-01-29 19:30:28.226441
\.


--
-- TOC entry 3561 (class 0 OID 16397)
-- Dependencies: 221
-- Data for Name: categories; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.categories (id, nom, description) FROM stdin;
5	Hommes	La catégorie Homme propose des vêtements variés alliant confort et style, adaptés à toutes les occasions. T-shirts, chemises, pantalons, vestes et plus, pour répondre aux besoins quotidiens des hommes.
7	Pulls	La catégorie Pulls regroupe une variété de pulls confortables et stylés, adaptés à toutes les saisons. Idéals pour apporter chaleur et élégance à vos tenues, avec des modèles pour femmes, hommes et enfants.
9	Tee-shirt	La catégorie Tee-shirt rassemble une sélection de tee-shirts confortables et tendance, adaptés à tous les styles et occasions. Disponibles pour hommes, femmes et enfants, ils sont conçus pour allier simplicité et élégance au quotidien.
11	Accessoires	La catégorie Accessoires regroupe une sélection d’articles complémentaires pour parfaire votre tenue. Écharpes, ceintures, chapeaux, sacs et bien plus, pour hommes, femmes et enfants.
17	Chaussures	La catégorie Chaussures propose des chaussures variés alliant confort et style, adaptés à toutes les occasions.  aux besoins quotidiens des hommes.
8	Sports	La catégorie Sport propose des vêtements conçus pour allier confort et performance lors de toutes vos activités physiques. Des articles techniques et fonctionnels adaptés à la pratique sportive, pour hommes, femmes et enfants.
\.


--
-- TOC entry 3563 (class 0 OID 16405)
-- Dependencies: 223
-- Data for Name: commande_produit; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.commande_produit (commande_id, produit_id, quantite, estramasse, estemballe) FROM stdin;
1	1	2	f	f
1	3	1	f	f
2	2	1	f	f
3	6	1	f	f
4	1	2	f	f
4	3	2	f	f
46	2	1	f	f
3	5	2	f	f
48	2	1	f	f
51	2	1	f	f
\.


--
-- TOC entry 3564 (class 0 OID 16412)
-- Dependencies: 224
-- Data for Name: commandes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.commandes (id, utilisateur_id, date_creation, statut_commandes_id) FROM stdin;
2	2	2026-01-05 08:51:58.257581	1
4	1	0202-11-15 08:51:58.257	2
3	1	0202-11-15 08:51:58.257	2
1	1	0202-11-15 08:51:58.257	2
48	1	2026-01-29 16:42:21.369476	2
46	1	2026-01-25 14:44:47.650379	2
51	1	2026-02-02 10:24:01.107879	1
\.


--
-- TOC entry 3566 (class 0 OID 16420)
-- Dependencies: 226
-- Data for Name: images; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.images (id, produit_id, url, description, date_creation) FROM stdin;
5	6	/images/Produits/snitkzfm.webp	Pantalon de tailleur en maille extensible avec taille élastiquée femme grande taille	2026-01-15 10:50:05.765036
6	6	/images/Produits/dimtpvv0.webp	grand et affiné	2026-01-15 16:36:17.184779
7	6	/images/Produits/3yachjry.webp	Pantalon de tailleur en maille extensible avec taille élastiquée femme grande taille	2026-01-15 16:37:49.64293
11	1	/images/Produits/hw3hfc3c.webp	image_2	2026-01-16 09:45:31.80119
12	1	/images/Produits/2bedgkkm.webp	image_2	2026-01-16 09:46:18.024998
13	1	/images/Produits/0exqxzth.webp	image_3	2026-01-16 09:46:33.762859
14	3	/images/Produits/lvgmouvj.webp	image_1	2026-01-16 09:50:17.319901
15	3	/images/Produits/e2nfuw1z.webp	image_2	2026-01-16 09:50:26.550152
16	3	/images/Produits/f5baohi2.webp	image_3	2026-01-16 09:50:41.249979
17	2	/images/Produits/frd5rcph.webp	image_1	2026-01-16 09:53:03.053189
18	2	/images/Produits/p1na4gsh.webp	image_2	2026-01-16 09:53:14.173112
19	2	/images/Produits/klsjnwzj.webp	image_3	2026-01-16 09:53:24.005771
20	4	/images/Produits/wd1ugeeg.webp	\N	2026-01-16 09:56:33.257485
21	4	/images/Produits/v1mrru1n.webp	\N	2026-01-16 09:56:41.089714
22	4	/images/Produits/sgc4oqwq.webp	\N	2026-01-16 09:56:47.701932
23	5	/images/Produits/3jfilcpf.webp	\N	2026-01-16 09:58:50.28019
24	5	/images/Produits/xc4iz2mt.webp	\N	2026-01-16 09:58:57.191296
25	5	/images/Produits/4vmtf1mb.webp	\N	2026-01-16 09:59:02.500342
\.


--
-- TOC entry 3568 (class 0 OID 16429)
-- Dependencies: 228
-- Data for Name: paniers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.paniers (id, utilisateur_id, date_creation) FROM stdin;
2	2	2026-01-05 08:51:58.257581
11	11	2026-01-22 19:45:25.036992
12	23	2026-01-23 10:43:14.04265
\.


--
-- TOC entry 3570 (class 0 OID 16437)
-- Dependencies: 230
-- Data for Name: produit_categories; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.produit_categories (produit_id, categorie_id) FROM stdin;
4	7
1	9
3	5
3	11
\.


--
-- TOC entry 3571 (class 0 OID 16442)
-- Dependencies: 231
-- Data for Name: produit_paniers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.produit_paniers (produit_id, panier_id, quantite) FROM stdin;
2	2	1
\.


--
-- TOC entry 3572 (class 0 OID 16449)
-- Dependencies: 232
-- Data for Name: produit_tailles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.produit_tailles (produit_id, taille_id) FROM stdin;
25	7
26	9
27	18
2	5
4	8
5	1
6	19
1	17
3	18
\.


--
-- TOC entry 3573 (class 0 OID 16454)
-- Dependencies: 233
-- Data for Name: produits; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.produits (id, nom, desc_courte, description, reduction, prix, score_vente, quantite, date_creation, archive) FROM stdin;
25	 Pull  fille	Sweat à capuche 	Ce pull pour fille a tout pour plaire aux jeunes passionnées de mode. Confectionné dans une maille douce enrichie en viscose, il offre un confort incomparable tout en adoptant une coupe oversize ultra tendance. Ses jolis motifs nœuds ajoutent une touche girly et délicate, idéale pour égayer le dressing de saison. Doté d’un col rond et de finitions en bord-côte, ce pull à motifs se marie parfaitement avec un jean ou un pantalon uni pour un look à la fois moderne et plein de charme.	7.00	35.00	0	8	2026-01-05 09:34:39.843939	t
6	Pantalon de tailleur en maille	Pantalon de tailleur en maille extensible avec taille élastiquée femme grande taille gris	Un pantalon droit et large très élégant mais aussi très confortable grâce à sa maille lourde, souple et extensible, pour une silhouette chic et impeccable ! Le pantalon femme grande taille (du 46/48 au 54/56) est idéal pour composer des looks formels ou sophistiqués avec un tee-shirt blanc et un blazer ou avec une chemise par exemple. Facile à vivre, il s'enfile en un clin d'œil grâce à sa taille élastiquée. 2 poches italiennes. Pinces au dos. Plis marqués par surpiqûres devant.	0.00	10.00	2	0	2026-01-06 17:37:14.440571	f
2	Jean slim en coton garçon - LuluCastagnette	Jean slim délavé en coton stretch garçon - LuluCastagnette double stone	Jean slim bleu foncé, qui s'accorde pour toutes les occasions	5.00	59.00	13	34	2026-01-05 08:51:58.257581	f
5	Pantalon en toile garçon 	Pantalon garçon confortable et élégant.	Un vrai bonheur à porter ! Ce pantalon pour garçon est la pièce idéale pour combiner un style soigné et une grande aisance. Sa matière, un mélange de Lyocell et de coton, offre un toucher d'une grande douceur et une belle souplesse. On adore sa coupe droite de type pantalon chino, qui permet de bouger et de jouer en toute liberté. Côté pratique, sa taille entièrement élastiquée avec un cordon de serrage le rend super facile à enfiler. Et pour un ajustement qui suit la croissance de votre enfant, la taille est également réglable de l'intérieur grâce à un élastique boutonné. Il est doté de deux poches italiennes sur l'avant et d'une poche discrète au dos.  Ce basique malin est un incontournable parmi les pantalons garçon. Pour une tenue décontractée, on l'associe avec un sweat à capuche et des baskets. Pour une occasion plus spéciale, il sera très joli avec une chemise. C'est un de ces pantalons pour enfant polyvalents qui trouve sa place dans toutes les garde-robes.	0.00	10.00	19	18	2026-01-05 09:41:20.737341	f
3	Casquette noire belle	Casquette simple	Casquette noire réglable	5.00	15.00	5	77	2026-01-05 08:51:58.257581	t
4	 Pull avec motifs nœuds fille	Sweat à capuche doublée - Disney	Ce pull pour fille a tout pour plaire aux jeunes passionnées de mode. Confectionné dans une maille douce enrichie en viscose, il offre un confort incomparable tout en adoptant une coupe oversize ultra tendance. Ses jolis motifs nœuds ajoutent une touche girly et délicate, idéale pour égayer le dressing de saison. Doté d’un col rond et de finitions en bord-côte, ce pull à motifs se marie parfaitement avec un jean ou un pantalon uni pour un look à la fois moderne et plein de charme.	7.00	35.00	2	6	2026-01-05 09:34:39.843939	f
26	Pantalon garçon 	Pantalon garçon 	Un vrai bonheur à porter ! Ce pantalon pour garçon est la pièce idéale pour combiner un style soigné et une grande aisance. Sa matière, un mélange de Lyocell et de coton, offre un toucher d'une grande douceur et une belle souplesse. On adore sa coupe droite de type pantalon chino, qui permet de bouger et de jouer en toute liberté. Côté pratique, sa taille entièrement élastiquée avec un cordon de serrage le rend super facile à enfiler. Et pour un ajustement qui suit la croissance de votre enfant, la taille est également réglable de l'intérieur grâce à un élastique boutonné. Il est doté de deux poches italiennes sur l'avant et d'une poche discrète au dos.  Ce basique malin est un incontournable parmi les pantalons garçon. Pour une tenue décontractée, on l'associe avec un sweat à capuche et des baskets. Pour une occasion plus spéciale, il sera très joli avec une chemise. C'est un de ces pantalons pour enfant polyvalents qui trouve sa place dans toutes les garde-robes.	0.00	10.00	0	1	2026-01-05 09:41:20.737341	t
27	Pantalon de tailleur 	Pantalon de tailleur 	Un pantalon droit et large très élégant mais aussi très confortable grâce à sa maille lourde, souple et extensible, pour une silhouette chic et impeccable ! Le pantalon femme grande taille (du 46/48 au 54/56) est idéal pour composer des looks formels ou sophistiqués avec un tee-shirt blanc et un blazer ou avec une chemise par exemple. Facile à vivre, il s'enfile en un clin d'œil grâce à sa taille élastiquée. 2 poches italiennes. Pinces au dos. Plis marqués par surpiqûres devant.	0.00	10.00	0	2	2026-01-06 17:37:14.440571	t
28	Trousse	trousse rose	trousse pat patrouille rose	0.00	5.00	10	50	2026-06-30 00:00:00	f
1	Tee-shirt blanc	Tee-shirt coton	Tee-shirt blanc 100% coton	0.00	22.00	15	100	2026-01-05 08:51:58.257581	f
\.


--
-- TOC entry 3575 (class 0 OID 16471)
-- Dependencies: 235
-- Data for Name: statut_commandes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.statut_commandes (id, label) FROM stdin;
3	Finalisee
4	Envoie
1	Attente
2	Préparation
\.


--
-- TOC entry 3577 (class 0 OID 16477)
-- Dependencies: 237
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
-- TOC entry 3579 (class 0 OID 16482)
-- Dependencies: 239
-- Data for Name: utilisateurs; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.utilisateurs (id, adresse_id, nom, prenom, email, mdp, date_creation, admin, emailverificationtoken, emailverified) FROM stdin;
25	21	coucou	Marylène	ze@gmail.com	AQAAAAIAAYagAAAAEL0WIKMT8nZcoKALAuuTrfoaIFDy3vf6mzkEJN1UiWS6kj+rEfgQiwDBEToODibpzQ==	2026-01-29 19:30:28.226441	f	eVhC/AVLWYEBsgqG572xoubBhHdCoRF08UDvHb8jDK0ORuEqHXmtoz0rjNeWFnp9	f
11	\N	Mougeot	Marylène	marylene.m39@gmail.com	AQAAAAIAAYagAAAAEN64YQPhukh0NTQo5cvn1ZEdwKtds1j0bl3fPfTR8E2bms4icGhm2zod38aqx4Uabw==	2026-01-12 14:04:47.735701	t	cb87iTLjw8xm5QhYm2YHq61VwU1SMfIeP7Na5wfI4KtJGU+itpNwU2GLWzXT1uKX	t
19	15	Durant	Qqdqq	dZZh@gmail.com	AQAAAAIAAYagAAAAENesStNSmdy5DO6EzYsy6xpk7x/vCwwKX9vrIp9miT6og2vR43yA2GBq/N5RVPaoxQ==	2026-01-13 12:52:59.304181	f	pAeqI2CNo4LhSWFJlKfXK/GITPDIVCVEIv0KZu+fxHRqd1FlJKLiyl4uS5qV0XGq	f
18	14	Durant	Henry	drurantH@gmail.com	AQAAAAIAAYagAAAAEOa1mtGxurFWzwISxxAJqEohCCRYb2023OAP4sR3VkkTCj8IefXQ+8TavWnP+zTfVQ==	2026-01-12 20:18:36.765091	f	xcuCdZSwaHf3pFCWuLfnGoExRZ6vsFlfWkedoMLcalCESdU9bKd1gi9RpBFFweiO	t
20	16	hollla	QFSSQ	dSSh@gmail.com	AQAAAAIAAYagAAAAELagCKeSZ7ISDEHK1zeCEky0odMKe5w61+ObIxozxMMHZgRR8Z+4RDBnf9E0tKuA0Q==	2026-01-13 13:16:22.444122	f	a3tYuULmDMftXNGtrsoFvkHXniuX2kW5lHvQIqTJaEOEUR2GgV8YvEMO5RDM2Pil	t
21	17	hollladee	fsd	dhsds@gmail.com	AQAAAAIAAYagAAAAEB4SKnFbhT2Ohpims3KosQE72fIDNyGnXosGnCbmfqiBA5/1wQvYF9OtNSOBDiRxLQ==	2026-01-13 14:06:17.366325	f	peLNiMPdTw3hoz2DGbaP8wLcyys1IvuWHoX0kmP1+YcLJbRXxVkefbKKc+giece1	f
22	18	ssq	Marylène	dkkrurantH@gmail.com	AQAAAAIAAYagAAAAECsEWWAbNPATpog9cOYWOPn2PNXiibRxLUKtvPlRV3oEAT9/LTh0P9ZyEQS/FAanTw==	2026-01-13 15:12:05.468833	f	WIjMSUt1WZg3XN3uHHvm5luC/MVuPTk6alCLhtUCCejcbaZaeKDZjoB8ENgALtvx	f
1	1	Dupont	Marie	marie.dupont@test.fr	AQAAAAIAAYagAAAAEN64YQPhukh0NTQo5cvn1ZEdwKtds1j0bl3fPfTR8E2bms4icGhm2zod38aqx4Uabw==	2026-01-05 08:51:58.257581	f	\N	f
2	2	Martin	Paul	paul.martin@test.fr	AQAAAAIAAYagAAAAEN64YQPhukh0NTQo5cvn1ZEdwKtds1j0bl3fPfTR8E2bms4icGhm2zod38aqx4Uabw==	2026-01-05 08:51:58.257581	f	\N	f
23	19	Mougeot	Manon	manon.mougeot@gmail.com	AQAAAAIAAYagAAAAEIC1wfEm/WnWIuGcvmP/ypezpygsihLV/sG1ViVrKRLRnDeMY2Q48ZFAv3PdJnFEgQ==	2026-01-17 19:49:49.866692	f	EfvJfsgxjb9h2nuJ4oTxNALzy2QF6ALTbIhMGBpZpcEMI6ck2taTsdd9fGjtpexf	t
\.


--
-- TOC entry 3595 (class 0 OID 0)
-- Dependencies: 220
-- Name: adresses_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.adresses_id_seq', 53, true);


--
-- TOC entry 3596 (class 0 OID 0)
-- Dependencies: 222
-- Name: categories_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.categories_id_seq', 36, true);


--
-- TOC entry 3597 (class 0 OID 0)
-- Dependencies: 225
-- Name: commandes_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.commandes_id_seq', 51, true);


--
-- TOC entry 3598 (class 0 OID 0)
-- Dependencies: 227
-- Name: images_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.images_id_seq', 25, true);


--
-- TOC entry 3599 (class 0 OID 0)
-- Dependencies: 229
-- Name: paniers_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.paniers_id_seq', 29, true);


--
-- TOC entry 3600 (class 0 OID 0)
-- Dependencies: 234
-- Name: produits_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.produits_id_seq', 28, true);


--
-- TOC entry 3601 (class 0 OID 0)
-- Dependencies: 236
-- Name: statut_commandes_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.statut_commandes_id_seq', 2, true);


--
-- TOC entry 3602 (class 0 OID 0)
-- Dependencies: 238
-- Name: tailles_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tailles_id_seq', 20, true);


--
-- TOC entry 3603 (class 0 OID 0)
-- Dependencies: 240
-- Name: utilisateurs_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.utilisateurs_id_seq', 57, true);


--
-- TOC entry 3372 (class 2606 OID 16506)
-- Name: adresses adresses_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.adresses
    ADD CONSTRAINT adresses_pkey PRIMARY KEY (id);


--
-- TOC entry 3374 (class 2606 OID 16508)
-- Name: categories categories_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories
    ADD CONSTRAINT categories_pkey PRIMARY KEY (id);


--
-- TOC entry 3376 (class 2606 OID 16510)
-- Name: commande_produit commande_produit_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commande_produit
    ADD CONSTRAINT commande_produit_pk PRIMARY KEY (commande_id, produit_id);


--
-- TOC entry 3378 (class 2606 OID 16512)
-- Name: commandes commandes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commandes
    ADD CONSTRAINT commandes_pkey PRIMARY KEY (id);


--
-- TOC entry 3380 (class 2606 OID 16514)
-- Name: images images_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.images
    ADD CONSTRAINT images_pkey PRIMARY KEY (id);


--
-- TOC entry 3382 (class 2606 OID 16516)
-- Name: paniers paniers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.paniers
    ADD CONSTRAINT paniers_pkey PRIMARY KEY (id);


--
-- TOC entry 3384 (class 2606 OID 16518)
-- Name: produit_categories produit_categories_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_categories
    ADD CONSTRAINT produit_categories_pk PRIMARY KEY (produit_id, categorie_id);


--
-- TOC entry 3386 (class 2606 OID 16520)
-- Name: produit_paniers produit_paniers_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_paniers
    ADD CONSTRAINT produit_paniers_pk PRIMARY KEY (produit_id, panier_id);


--
-- TOC entry 3388 (class 2606 OID 16522)
-- Name: produit_tailles produit_tailles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_tailles
    ADD CONSTRAINT produit_tailles_pkey PRIMARY KEY (produit_id, taille_id);


--
-- TOC entry 3390 (class 2606 OID 16524)
-- Name: produits produits_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produits
    ADD CONSTRAINT produits_pkey PRIMARY KEY (id);


--
-- TOC entry 3392 (class 2606 OID 16526)
-- Name: statut_commandes statut_commandes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statut_commandes
    ADD CONSTRAINT statut_commandes_pkey PRIMARY KEY (id);


--
-- TOC entry 3394 (class 2606 OID 16528)
-- Name: tailles tailles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tailles
    ADD CONSTRAINT tailles_pkey PRIMARY KEY (id);


--
-- TOC entry 3396 (class 2606 OID 16530)
-- Name: utilisateurs utilisateurs_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.utilisateurs
    ADD CONSTRAINT utilisateurs_email_key UNIQUE (email);


--
-- TOC entry 3398 (class 2606 OID 16532)
-- Name: utilisateurs utilisateurs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.utilisateurs
    ADD CONSTRAINT utilisateurs_pkey PRIMARY KEY (id);


--
-- TOC entry 3399 (class 2606 OID 16533)
-- Name: commande_produit commande_produit_commandes_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commande_produit
    ADD CONSTRAINT commande_produit_commandes_fkey FOREIGN KEY (commande_id) REFERENCES public.commandes(id);


--
-- TOC entry 3400 (class 2606 OID 16538)
-- Name: commande_produit commande_produit_produits_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commande_produit
    ADD CONSTRAINT commande_produit_produits_fkey FOREIGN KEY (produit_id) REFERENCES public.produits(id);


--
-- TOC entry 3401 (class 2606 OID 16543)
-- Name: commandes commandes_statut_commandes_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commandes
    ADD CONSTRAINT commandes_statut_commandes_fkey FOREIGN KEY (statut_commandes_id) REFERENCES public.statut_commandes(id);


--
-- TOC entry 3402 (class 2606 OID 16548)
-- Name: commandes commandes_utilisateurs_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commandes
    ADD CONSTRAINT commandes_utilisateurs_fkey FOREIGN KEY (utilisateur_id) REFERENCES public.utilisateurs(id);


--
-- TOC entry 3403 (class 2606 OID 16553)
-- Name: images images_produits_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.images
    ADD CONSTRAINT images_produits_fkey FOREIGN KEY (produit_id) REFERENCES public.produits(id);


--
-- TOC entry 3404 (class 2606 OID 16558)
-- Name: paniers paniers_utilisateurs_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.paniers
    ADD CONSTRAINT paniers_utilisateurs_fkey FOREIGN KEY (utilisateur_id) REFERENCES public.utilisateurs(id);


--
-- TOC entry 3405 (class 2606 OID 16563)
-- Name: produit_categories produit_categories_categories_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_categories
    ADD CONSTRAINT produit_categories_categories_fkey FOREIGN KEY (categorie_id) REFERENCES public.categories(id);


--
-- TOC entry 3406 (class 2606 OID 16568)
-- Name: produit_categories produit_categories_produits_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_categories
    ADD CONSTRAINT produit_categories_produits_fkey FOREIGN KEY (produit_id) REFERENCES public.produits(id);


--
-- TOC entry 3407 (class 2606 OID 16573)
-- Name: produit_paniers produit_paniers_paniers_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_paniers
    ADD CONSTRAINT produit_paniers_paniers_fkey FOREIGN KEY (panier_id) REFERENCES public.paniers(id);


--
-- TOC entry 3408 (class 2606 OID 16578)
-- Name: produit_paniers produit_paniers_produits_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_paniers
    ADD CONSTRAINT produit_paniers_produits_fkey FOREIGN KEY (produit_id) REFERENCES public.produits(id);


--
-- TOC entry 3409 (class 2606 OID 16583)
-- Name: produit_tailles produit_taille_produits_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_tailles
    ADD CONSTRAINT produit_taille_produits_fkey FOREIGN KEY (produit_id) REFERENCES public.produits(id);


--
-- TOC entry 3410 (class 2606 OID 16588)
-- Name: produit_tailles produit_taille_taille_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produit_tailles
    ADD CONSTRAINT produit_taille_taille_fkey FOREIGN KEY (taille_id) REFERENCES public.tailles(id);


--
-- TOC entry 3411 (class 2606 OID 16593)
-- Name: utilisateurs utilisateurs_adresses_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.utilisateurs
    ADD CONSTRAINT utilisateurs_adresses_fkey FOREIGN KEY (adresse_id) REFERENCES public.adresses(id);


-- Completed on 2026-07-03 10:03:31

--
-- PostgreSQL database dump complete
--

\unrestrict a02vUHAcEQ2upmLM16IPwa8f1GqUv5JFIQY8MethUvO2ibHGuEkI9duo6AargwL

