insert into Config.Level
(name, Description, CreateUser, CreateDate)
values
('Nivel 1','','rmartel','Oct 31 2022 10:31PM'),
('Nivel 2','','rmartel','Oct 31 2022 10:31PM'),
('Nivel 3','','rmartel','Oct 31 2022 10:31PM')

insert into Employee.Gerency (name, CreateUser, CreateDate)
values
('Gerencia 1','rmartel','Oct 31 2022 10:30PM')


insert into Employee.Area (GerencyId, name, CreateUser, CreateDate)
values
(1, 'Area 1','system','Oct 31 2022 10:30PM'),
(1, 'Area 2','system','Oct 31 2022 10:30PM')


insert into Employee.Hierarchy(LevelId, name, CreateUser, CreateDate)
values
(1,'Gerente General','rmartel','Oct 31 2022 10:30PM'),
(2,'Sub Gerente','rmartel','Oct 31 2022 10:30PM'),
(3,'Jefe','rmartel','Oct 31 2022 10:30PM')


insert into Employee.Charge (AreaId, HierarchyId, name, CreateUser, CreateDate)
values
(1,1,'Cargo 1 Area 1','rmartel','Oct 31 2022 10:30PM'),
(1,2,'Cargo 2 Area 1','rmartel','Oct 31 2022 10:30PM'),
(1,3,'Cargo 3 Area 1','rmartel','Oct 31 2022 10:30PM'),
(2,1,'Cargo 1 Area 2','rmartel','Oct 31 2022 10:30PM'),
(2,2,'Cargo 2 Area 2','rmartel','Oct 31 2022 10:30PM'),
(2,3,'Cargo 3 Area 2','rmartel','Oct 31 2022 10:30PM')

insert into EvaResult.Period (name, StartDate, EndDate, CreateUser, CreateDate)
values ('Period 1','2022-10-25 22:08:13.9550000','2022-10-25 22:08:13.9550000','system','Oct 31 2022 10:30PM')


insert into Collaborator(id,ChargeId, DocumentNumber, FullName, LastName,Name,Email,Code,DateBirthday,DateAdmission,DateEgress,CreateUser,CreateDate, IsDeleted)
values
('1c1c8270-7152-40e3-b6a9-8f2244824434',1,'31313131','Fanny','Kius','Fanny','fan@acity.com.pe',3151,'1998-10-02 00:00:00.0000000','2022-10-10 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
('2e1041e9-7bca-4f7d-a096-afde97b00e73',2,'44444444','Guillermo','Firme','Guillermo','guille@acity.com.pe',2311,'1989-10-02 00:00:00.0000000','2019-02-01 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
('2ead2ce1-cc3f-4c52-bdee-2e8fdaf99bc6',3,'22222222','Carlos','Ruiz','arlos','carlos@acity.com.pe',5555,'2022-02-15 00:00:00.0000000','2021-05-01 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
('aabcf5e6-7c42-4876-b3ff-be1029c80c44',4,'55445544','Kiara','Luiz','Kiara','kia@acity.com.pe',2425,'2000-12-05 00:00:00.0000000','2022-07-15 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
('c379a686-897f-47f2-bebb-0cc3e5bb29d7',5,'33333333','Fernanda','Rofriguez','Fernanda','fer@acity.com.pe',4258,'1991-05-15 00:00:00.0000000','2020-05-01 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
('f39b64f3-7359-4b7d-ae71-2f3aff538ffc',6,'15151515','Hector','Julio','Hector','hec@acity.com.pe',2131,'1995-10-02 00:00:00.0000000','2022-09-10 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0)

insert into Config.Component
(name, CreateUser, CreateDate, IsDeleted)
values
('Objetivos Corporativos', 'rmartel', getdate(), 0),
('Objetivos de Area', 'rmartel', getdate(), 0),
('Competencias', 'rmartel', getdate(), 0)

insert into Config.HierarchyComponent (HierarchyId, ComponentId, Weight, CreateUser, CreateDate, IsDeleted)
values
(1, 1, 20, 'rmartel', getdate(), 0),
(1, 2, 50, 'rmartel', getdate(), 0),
(1, 3, 30, 'rmartel', getdate(), 0),
(2, 1, 20, 'rmartel', getdate(), 0),
(2, 2, 50, 'rmartel', getdate(), 0),
(2, 3, 30, 'rmartel', getdate(), 0),
(3, 1, 20, 'rmartel', getdate(), 0),
(3, 2, 50, 'rmartel', getdate(), 0),
(3, 3, 30, 'rmartel', getdate(), 0)

insert into Config.Formula (id, name, Description, FormulaQuery, FormulaReal, CreateUser, CreateDate, IsDeleted)
values
('E43C9497-BC6D-465E-8832-FBF961636A2A','Formula 1', 'formula 1111','IIF(2>5, 5*2,  3*2)', 'SI(2>5, 5*2,  3*2)', 'rmartel', getdate(), 0)


insert into Config.Subcomponent
(id, ComponentId, AreaId, FormulaId, Name, Description, CreateUser, CreateDate, IsDeleted)
values
('A22EA277-F2F5-49B5-89F2-1FDECDA8A003', 1, 1, null, 'Subcomponente 1 OBJCORP', '', 'rmartel', getdate(), 0),
('12A5F857-F067-4EC5-968C-5284616A2929', 1, 1, 'E43C9497-BC6D-465E-8832-FBF961636A2A', 'Subcomponente 2 OBJCORP', '', 'rmartel', getdate(), 0),
('6A74384F-2DA1-4B23-8569-C00206FDFA98', 1, 2, null, 'Subcomponente 3 OBJCORP', '', 'rmartel', getdate(), 0),
('F22BDCB7-F528-44A2-9267-1B2CE55D5E34', 1, 2, 'E43C9497-BC6D-465E-8832-FBF961636A2A', 'Subcomponente 4 OBJCORP', '', 'rmartel', getdate(), 0),
('DA886354-B2BB-483A-8430-F2F5DC31E9B9', 2, 1, null, 'Subcomponente 5 KPIAREA', '', 'rmartel', getdate(), 0),
('BBFABC97-44DB-4925-91D6-C8B42827B1C1', 2, 1, null, 'Subcomponente 6 KPIAREA', '', 'rmartel', getdate(), 0),
('0C24DF55-1C5A-45DC-B0BE-576F1B6D2192', 2, 2, null, 'Subcomponente 7 KPIAREA', '', 'rmartel', getdate(), 0),
('E66C2F20-FC0E-4F89-9A9E-4D1367D91D9A', 2, 2, null, 'Subcomponente 8 KPIAREA', '', 'rmartel', getdate(), 0),
('0FEF6000-AA34-40F1-AB47-1E42D750EF1E', 3, null, null, 'Subcomponente 9 COMPETE', '', 'rmartel', getdate(), 0),
('99654822-D86A-4C0C-AC83-859C9BA2A0F5', 3, null, null, 'Subcomponente 10 COMPETE', '', 'rmartel', getdate(), 0),
('D38F679E-A6A5-403C-99F0-032F3528B534', 3, null, null, 'Subcomponente 11 COMPETE', '', 'rmartel', getdate(), 0),
('42B76A33-E812-44BB-98A1-605F880C2ED6', 3, null, null, 'Subcomponente 12 COMPETE', '', 'rmartel', getdate(), 0)


insert into Config.SubcomponentValue
(id, SubcomponentId, ChargeId, RelativeWeight, MinimunPercentage, MaximunPercentage, CreateUser, CreateDate, IsDeleted)
values

--OBJCOPR
(newid(),'A22EA277-F2F5-49B5-89F2-1FDECDA8A003', 1, 15, 75, 90, 'rmartel', getdate(), 0),
(newid(),'A22EA277-F2F5-49B5-89F2-1FDECDA8A003', 2, 20, 65, 100, 'rmartel', getdate(), 0),
(newid(),'A22EA277-F2F5-49B5-89F2-1FDECDA8A003', 3, 20, 80, 95, 'rmartel', getdate(), 0),
(newid(),'12A5F857-F067-4EC5-968C-5284616A2929', 1, 15, 75, 99, 'rmartel', getdate(), 0),
(newid(),'12A5F857-F067-4EC5-968C-5284616A2929', 2, 20, 78, 85, 'rmartel', getdate(), 0),
(newid(),'12A5F857-F067-4EC5-968C-5284616A2929', 3, 25, 82, 100, 'rmartel', getdate(), 0),

(newid(),'F22BDCB7-F528-44A2-9267-1B2CE55D5E34', 4, 15, 75, 90, 'rmartel', getdate(), 0),
(newid(),'F22BDCB7-F528-44A2-9267-1B2CE55D5E34', 5, 20, 65, 100, 'rmartel', getdate(), 0),
(newid(),'F22BDCB7-F528-44A2-9267-1B2CE55D5E34', 6, 20, 80, 95, 'rmartel', getdate(), 0),
(newid(),'6A74384F-2DA1-4B23-8569-C00206FDFA98', 4, 15, 75, 99, 'rmartel', getdate(), 0),
(newid(),'6A74384F-2DA1-4B23-8569-C00206FDFA98', 5, 20, 78, 85, 'rmartel', getdate(), 0),
(newid(),'6A74384F-2DA1-4B23-8569-C00206FDFA98', 6, 25, 82, 100, 'rmartel', getdate(), 0),

--KPI AREA
(newid(),'BBFABC97-44DB-4925-91D6-C8B42827B1C1', 1, 15, 75, 90, 'rmartel', getdate(), 0),
(newid(),'BBFABC97-44DB-4925-91D6-C8B42827B1C1', 2, 20, 65, 100, 'rmartel', getdate(), 0),
(newid(),'BBFABC97-44DB-4925-91D6-C8B42827B1C1', 3, 20, 80, 95, 'rmartel', getdate(), 0),
(newid(),'DA886354-B2BB-483A-8430-F2F5DC31E9B9', 1, 15, 75, 99, 'rmartel', getdate(), 0),
(newid(),'DA886354-B2BB-483A-8430-F2F5DC31E9B9', 2, 20, 78, 85, 'rmartel', getdate(), 0),
(newid(),'DA886354-B2BB-483A-8430-F2F5DC31E9B9', 3, 25, 82, 100, 'rmartel', getdate(), 0),

(newid(),'E66C2F20-FC0E-4F89-9A9E-4D1367D91D9A', 4, 15, 75, 90, 'rmartel', getdate(), 0),
(newid(),'E66C2F20-FC0E-4F89-9A9E-4D1367D91D9A', 5, 20, 65, 100, 'rmartel', getdate(), 0),
(newid(),'E66C2F20-FC0E-4F89-9A9E-4D1367D91D9A', 6, 20, 80, 95, 'rmartel', getdate(), 0),
(newid(),'0C24DF55-1C5A-45DC-B0BE-576F1B6D2192', 4, 15, 75, 99, 'rmartel', getdate(), 0),
(newid(),'0C24DF55-1C5A-45DC-B0BE-576F1B6D2192', 5, 20, 78, 85, 'rmartel', getdate(), 0),
(newid(),'0C24DF55-1C5A-45DC-B0BE-576F1B6D2192', 6, 25, 82, 100, 'rmartel', getdate(), 0)

insert into Config.Conduct
(id, LevelId, SubcomponentId, IsActive, Description, CreateUser, CreateDate, IsDeleted)
values
(newid(),1 ,'D38F679E-A6A5-403C-99F0-032F3528B534',1, 'Conducta 1', 'rmartel', getdate(), 0),
(newid(),1 ,'D38F679E-A6A5-403C-99F0-032F3528B534',1, 'Conducta 1.1', 'rmartel', getdate(), 0),
(newid(),2 ,'D38F679E-A6A5-403C-99F0-032F3528B534',1, 'Conducta 2', 'rmartel', getdate(), 0),
(newid(),2 ,'D38F679E-A6A5-403C-99F0-032F3528B534',1, 'Conducta 2.2', 'rmartel', getdate(), 0),
(newid(),3 ,'D38F679E-A6A5-403C-99F0-032F3528B534',1, 'Conducta 3', 'rmartel', getdate(), 0),
(newid(),3 ,'D38F679E-A6A5-403C-99F0-032F3528B534',1, 'Conducta 3.1', 'rmartel', getdate(), 0),
(newid(),1 ,'0FEF6000-AA34-40F1-AB47-1E42D750EF1E',1, 'Conducta 4', 'rmartel', getdate(), 0),
(newid(),2 ,'0FEF6000-AA34-40F1-AB47-1E42D750EF1E',1, 'Conducta 5', 'rmartel', getdate(), 0),
(newid(),3 ,'42B76A33-E812-44BB-98A1-605F880C2ED6',1, 'Conducta 6', 'rmartel', getdate(), 0),
(newid(),2 ,'42B76A33-E812-44BB-98A1-605F880C2ED6',1, 'Conducta 7', 'rmartel', getdate(), 0),
(newid(),2 ,'42B76A33-E812-44BB-98A1-605F880C2ED6',1, 'Conducta 7.1', 'rmartel', getdate(), 0),
(newid(),1 ,'99654822-D86A-4C0C-AC83-859C9BA2A0F5',1, 'Conducta 8', 'rmartel', getdate(), 0),
(newid(),2 ,'99654822-D86A-4C0C-AC83-859C9BA2A0F5',1, 'Conducta 9', 'rmartel', getdate(), 0),
(newid(),2 ,'99654822-D86A-4C0C-AC83-859C9BA2A0F5',1, 'Conducta 9.1', 'rmartel', getdate(), 0),
(newid(),2 ,'99654822-D86A-4C0C-AC83-859C9BA2A0F5',1, 'Conducta 9.2', 'rmartel', getdate(), 0),
(newid(),3 ,'99654822-D86A-4C0C-AC83-859C9BA2A0F5',1, 'Conducta 10', 'rmartel', getdate(), 0)


insert into Config.Stage
(Name, CreateUser, CreateDate, IsDeleted)
values
('Evaluacion','rmartel', getdate(), 0),
('Calibracion','rmartel', getdate(), 0),
('Feedback','rmartel', getdate(), 0),
('Visto Bueno','rmartel', getdate(), 0)


