--insert into Level
--(name, Description, CreateUser, CreateDate)
--values
--('Nivel 1','','rmartel','Oct 31 2022 10:31PM'),
--('Nivel 2','','rmartel','Oct 31 2022 10:31PM'),
--('Nivel 3','','rmartel','Oct 31 2022 10:31PM')

--insert into Gerency (name, CreateUser, CreateDate)
--values
--('Gerencia 1','rmartel','Oct 31 2022 10:30PM')


--insert into Area (GerencyId, name, CreateUser, CreateDate)
--values
--(1, 'Area 1','system','Oct 31 2022 10:30PM'),
--(1, 'Area 2','system','Oct 31 2022 10:30PM')


--insert into Hierarchy(LevelId, name, CreateUser, CreateDate)
--values
--(1,'Gerente General','rmartel','Oct 31 2022 10:30PM'),
--(2,'Sub Gerente','rmartel','Oct 31 2022 10:30PM'),
--(3,'Jefe','rmartel','Oct 31 2022 10:30PM')


--insert into Charge (AreaId, HierarchyId, name, CreateUser, CreateDate)
--values
--(1,1,'Cargo 1 Area 1','rmartel','Oct 31 2022 10:30PM'),
--(1,2,'Cargo 2 Area 1','rmartel','Oct 31 2022 10:30PM'),
--(1,3,'Cargo 3 Area 1','rmartel','Oct 31 2022 10:30PM'),
--(2,1,'Cargo 1 Area 2','rmartel','Oct 31 2022 10:30PM'),
--(2,2,'Cargo 2 Area 2','rmartel','Oct 31 2022 10:30PM'),
--(2,3,'Cargo 3 Area 2','rmartel','Oct 31 2022 10:30PM')

--insert into Period (name, StartDate, EndDate, CreateUser, CreateDate)
--values ('Period 1','2022-10-25 22:08:13.9550000','2022-10-25 22:08:13.9550000','system','Oct 31 2022 10:30PM')


--insert into Collaborator(id,ChargeId, DocumentNumber, FullName, LastName,Name,Email,Code,DateBirthday,DateAdmission,DateEgress,CreateUser,CreateDate, IsDeleted)
--values
--('1c1c8270-7152-40e3-b6a9-8f2244824434',1,'31313131','Fanny','Kius','Fanny','fan@acity.com.pe',3151,'1998-10-02 00:00:00.0000000','2022-10-10 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
--('2e1041e9-7bca-4f7d-a096-afde97b00e73',2,'44444444','Guillermo','Firme','Guillermo','guille@acity.com.pe',2311,'1989-10-02 00:00:00.0000000','2019-02-01 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
--('2ead2ce1-cc3f-4c52-bdee-2e8fdaf99bc6',3,'22222222','Carlos','Ruiz','arlos','carlos@acity.com.pe',5555,'2022-02-15 00:00:00.0000000','2021-05-01 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
--('aabcf5e6-7c42-4876-b3ff-be1029c80c44',4,'55445544','Kiara','Luiz','Kiara','kia@acity.com.pe',2425,'2000-12-05 00:00:00.0000000','2022-07-15 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
--('c379a686-897f-47f2-bebb-0cc3e5bb29d7',5,'33333333','Fernanda','Rofriguez','Fernanda','fer@acity.com.pe',4258,'1991-05-15 00:00:00.0000000','2020-05-01 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
--('f39b64f3-7359-4b7d-ae71-2f3aff538ffc',6,'15151515','Hector','Julio','Hector','hec@acity.com.pe',2131,'1995-10-02 00:00:00.0000000','2022-09-10 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0)

--insert into Component
--(name, CreateUser, CreateDate, IsDeleted)
--values
--('Objetivos Corporativos', 'rmartel', getdate(), 0),
--('Objetivos de Area', 'rmartel', getdate(), 0),
--('Competencias', 'rmartel', getdate(), 0)


--insert into HierarchyComponent (HierarchyId, ComponentId, Weight, CreateUser, CreateDate, IsDeleted)
--values
--(1, 1, 20, 'rmartel', getdate(), 0),
--(1, 2, 50, 'rmartel', getdate(), 0),
--(1, 3, 30, 'rmartel', getdate(), 0),
--(2, 1, 20, 'rmartel', getdate(), 0),
--(2, 2, 50, 'rmartel', getdate(), 0),
--(2, 3, 30, 'rmartel', getdate(), 0),
--(3, 1, 20, 'rmartel', getdate(), 0),
--(3, 2, 50, 'rmartel', getdate(), 0),
--(3, 3, 30, 'rmartel', getdate(), 0)

select * from Area
select * from Formula
select * from Subcomponent