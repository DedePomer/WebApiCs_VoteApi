--
-- PostgreSQL database dump
--

\restrict ZwVokDNQ5WXbnJFqVHwqvSoaCfVBhe5ANtJbkfI0nJwS7oxffKtAyJQv87UTZg0

-- Dumped from database version 18.0 (Debian 18.0-1.pgdg13+3)
-- Dumped by pg_dump version 18.0 (Debian 18.0-1.pgdg13+3)

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
-- Name: pgcrypto; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS pgcrypto WITH SCHEMA public;


--
-- Name: EXTENSION pgcrypto; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION pgcrypto IS 'cryptographic functions';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Candidates; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public."Candidates" (
    "CandidateId" uuid NOT NULL,
    "Program" character varying(400),
    "UserId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL
);


ALTER TABLE public."Candidates" OWNER TO admin;

--
-- Name: UsersAuth; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public."UsersAuth" (
    "UserId" uuid NOT NULL,
    "Username" character varying(50) CONSTRAINT "UsersAuth_UserName_not_null" NOT NULL,
    "PasswordHash" bytea NOT NULL,
    "RefreshTokenHash" bytea
);


ALTER TABLE public."UsersAuth" OWNER TO admin;

--
-- Name: UsersData; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public."UsersData" (
    "DataId" uuid NOT NULL,
    "UserId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL,
    "IsService" boolean NOT NULL,
    "FirstName" character varying(50) NOT NULL,
    "Surname" character varying(50),
    "Description" character varying(400),
    "Photo" bytea,
    "Age" integer
);


ALTER TABLE public."UsersData" OWNER TO admin;

--
-- Name: Votes; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public."Votes" (
    "VoteId" uuid NOT NULL,
    "CandidateId" uuid NOT NULL,
    "UserId" uuid DEFAULT '00000000-0000-0000-0000-000000000000'::uuid NOT NULL
);


ALTER TABLE public."Votes" OWNER TO admin;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO admin;

--
-- Data for Name: Candidates; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public."Candidates" ("CandidateId", "Program", "UserId") FROM stdin;
55776851-3780-4ed6-90cc-74ba374015ac	Всем пива	238b7fec-e18c-4b82-922f-862996a1cd17
1e45ed9f-f4c6-4391-9d01-1b35a1482f9e	Партия «Ким Кицураги — За справедливость и порядок» ставит во главу угла честность, аналитику и защиту прав граждан. Мы боремся с коррупцией, поддерживаем образование, развитие малого бизнеса и науку, создаём безопасные города и экологичное будущее. Лозунг: «Справедливость в каждом деле, порядок в каждом шаге».	e6c710f8-be30-4695-8af5-85756c357eeb
\.


--
-- Data for Name: UsersAuth; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public."UsersAuth" ("UserId", "Username", "PasswordHash", "RefreshTokenHash") FROM stdin;
e6c710f8-be30-4695-8af5-85756c357eeb	CoolPrecision	\\x68c0f07adbd103203436842dd766429c6f6c439d8ed0af7f7e35ed379b3266bc	\N
418551e7-c73d-4bd9-89a3-116a70fda97d	MissOrange	\\x893e03f8ccf320398a23e251bbfdf44d414d8a1be040a26192b6a42313742f51	\N
c3c84e24-e9e7-4c23-a940-32fa1586e5b5	Lil'Mischief	\\xeceb6c772b0a93ddda96913b65feab3ffa141f4dd016f8f703850cc3f2820d0e	\N
850f9dc7-7e23-42b6-9e46-11f36f436b42	Ex_Flame	\\xf52c5aac8c5e39e6cd2a8bd54fac68e6f5bff1cb51be2bad8b021583b05d819f	\N
238b7fec-e18c-4b82-922f-862996a1cd17	DetectiveDust	\\x0400588be2f6f536bdafbb6ed9f7bd231273010fc3af25f5444ba71632e10f63	\\xee9bb0eb23f91f2657a352077691b61dccbcc1e818a7b370348045245f29425c
12060a3a-6c33-427f-9932-c498a95b099c	CorporateOwl	\\x4d147d0f2a322927453a8620c4b4cca9dbd10fe3e1e3b4f498c0a8a030a100d9	\\x5b47edb804faead73b6bdec9d47b57ab2e697220d5c7bd75ee2a8a647bc7db2b
\.


--
-- Data for Name: UsersData; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public."UsersData" ("DataId", "UserId", "IsService", "FirstName", "Surname", "Description", "Photo", "Age") FROM stdin;
3654984d-2dcb-4260-83c0-a02d9f56706d	238b7fec-e18c-4b82-922f-862996a1cd17	f	Harrier	Du Bois	\N	\N	\N
714a31e8-c012-40da-a95d-629f356838b2	e6c710f8-be30-4695-8af5-85756c357eeb	f	Kim	Kitsuragi	\N	\N	\N
103ce475-a233-4031-8086-688eda9d9400	418551e7-c73d-4bd9-89a3-116a70fda97d	f	Klaasje	Amandou	\N	\N	\N
862502e7-1ab4-46ba-9535-e5b94ff0b74f	c3c84e24-e9e7-4c23-a940-32fa1586e5b5	f	Cunoesse	Vittulainen	\N	\N	\N
60943852-3003-477d-8468-53ea072f1029	850f9dc7-7e23-42b6-9e46-11f36f436b42	f	Dora	Ingerlund	\N	\N	\N
6c6f0c3c-e1ba-4d87-8e46-f48f80c44196	12060a3a-6c33-427f-9932-c498a95b099c	f	Joyce	Messier	\N	\N	\N
\.


--
-- Data for Name: Votes; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public."Votes" ("VoteId", "CandidateId", "UserId") FROM stdin;
9c14896a-f14a-4901-95db-f918077b5517	55776851-3780-4ed6-90cc-74ba374015ac	238b7fec-e18c-4b82-922f-862996a1cd17
0d8cae4d-13d0-4feb-b179-c8f94312e40e	55776851-3780-4ed6-90cc-74ba374015ac	12060a3a-6c33-427f-9932-c498a95b099c
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20251103195301_InitialCreate	9.0.10
20251104103755_AddNewFkForUserAuth	9.0.10
20251104121201_EditUserData	9.0.10
20251104130013_EditUsersAuth	9.0.10
20251104130808_EditAllEntity	9.0.10
20251104143049_EditUsersData	9.0.10
20251104164807_EditEntity	9.0.10
20251104165330_OpiatEditEntity	9.0.10
20251104165903_Cascade	9.0.10
20251104170432_EditUsersAuth_2	9.0.10
20251105125037_AddVotesEntity	9.0.10
20251105130016_EditCandidate	9.0.10
20251105134039_AddUserIdToVotes	9.0.10
20251105141154_Test_1	9.0.10
20251105175806_Test_2	9.0.10
20251105193351_Test_3	9.0.10
20251107155205_AddUnigue	9.0.10
\.


--
-- Name: Candidates PK_Candidates; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."Candidates"
    ADD CONSTRAINT "PK_Candidates" PRIMARY KEY ("CandidateId");


--
-- Name: UsersAuth PK_UsersAuth; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."UsersAuth"
    ADD CONSTRAINT "PK_UsersAuth" PRIMARY KEY ("UserId");


--
-- Name: UsersData PK_UsersData; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."UsersData"
    ADD CONSTRAINT "PK_UsersData" PRIMARY KEY ("DataId");


--
-- Name: Votes PK_Votes; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."Votes"
    ADD CONSTRAINT "PK_Votes" PRIMARY KEY ("VoteId");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_Candidates_UserId; Type: INDEX; Schema: public; Owner: admin
--

CREATE UNIQUE INDEX "IX_Candidates_UserId" ON public."Candidates" USING btree ("UserId");


--
-- Name: IX_UsersAuth_Username; Type: INDEX; Schema: public; Owner: admin
--

CREATE UNIQUE INDEX "IX_UsersAuth_Username" ON public."UsersAuth" USING btree ("Username");


--
-- Name: IX_UsersData_UserId; Type: INDEX; Schema: public; Owner: admin
--

CREATE UNIQUE INDEX "IX_UsersData_UserId" ON public."UsersData" USING btree ("UserId");


--
-- Name: IX_Votes_CandidateId; Type: INDEX; Schema: public; Owner: admin
--

CREATE INDEX "IX_Votes_CandidateId" ON public."Votes" USING btree ("CandidateId");


--
-- Name: IX_Votes_UserId; Type: INDEX; Schema: public; Owner: admin
--

CREATE UNIQUE INDEX "IX_Votes_UserId" ON public."Votes" USING btree ("UserId");


--
-- Name: Candidates FK_Candidates_UsersAuth_UserId; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."Candidates"
    ADD CONSTRAINT "FK_Candidates_UsersAuth_UserId" FOREIGN KEY ("UserId") REFERENCES public."UsersAuth"("UserId") ON DELETE CASCADE;


--
-- Name: UsersData FK_UsersData_UsersAuth_UserId; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."UsersData"
    ADD CONSTRAINT "FK_UsersData_UsersAuth_UserId" FOREIGN KEY ("UserId") REFERENCES public."UsersAuth"("UserId") ON DELETE CASCADE;


--
-- Name: Votes FK_Votes_Candidates_CandidateId; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."Votes"
    ADD CONSTRAINT "FK_Votes_Candidates_CandidateId" FOREIGN KEY ("CandidateId") REFERENCES public."Candidates"("CandidateId") ON DELETE CASCADE;


--
-- Name: Votes FK_Votes_UsersAuth_UserId; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."Votes"
    ADD CONSTRAINT "FK_Votes_UsersAuth_UserId" FOREIGN KEY ("UserId") REFERENCES public."UsersAuth"("UserId") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

\unrestrict ZwVokDNQ5WXbnJFqVHwqvSoaCfVBhe5ANtJbkfI0nJwS7oxffKtAyJQv87UTZg0

