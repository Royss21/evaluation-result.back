insert into Config.Level
(name, Description, CreateUser, CreateDate)
values
('Nivel 1','','rmartel','Oct 31 2022 10:31PM'),
('Nivel 2','','rmartel','Oct 31 2022 10:31PM'),
('Nivel 3','','rmartel','Oct 31 2022 10:31PM')

--insert into Employee.Gerency (name, CreateUser, CreateDate)
--values
--('Gerencia 1','rmartel','Oct 31 2022 10:30PM')


go

insert into [Security].Role
(Name, Description, CreateUser, CreateDate)
values
('SuperAdministrador', '', 'rmartel', getdate()),
('Administrador', '', 'rmartel', getdate())

go


insert into [Employee].[IdentityDocument]
(Name, CreateUser, CreateDate)
values
('Dni', 'rmartel', getdate()),
('Pasaporte', 'rmartel', getdate()),
('Carnet Extranjeria', 'rmartel', getdate())

go


--insert into Employee.Area (GerencyId, name, CreateUser, CreateDate)
--values
--(1, 'Area 1','system','Oct 31 2022 10:30PM'),
--(1, 'Area 2','system','Oct 31 2022 10:30PM')


--insert into Employee.Hierarchy(LevelId, name, CreateUser, CreateDate)
--values
--(1,'Gerente General','rmartel','Oct 31 2022 10:30PM'),
--(2,'Sub Gerente','rmartel','Oct 31 2022 10:30PM'),
--(3,'Jefe','rmartel','Oct 31 2022 10:30PM')


--insert into Employee.Charge (AreaId, HierarchyId, name, CreateUser, CreateDate)
--values
--(1,1,'Cargo 1 Area 1','rmartel','Oct 31 2022 10:30PM'),
--(1,2,'Cargo 2 Area 1','rmartel','Oct 31 2022 10:30PM'),
--(1,3,'Cargo 3 Area 1','rmartel','Oct 31 2022 10:30PM'),
--(2,1,'Cargo 1 Area 2','rmartel','Oct 31 2022 10:30PM'),
--(2,2,'Cargo 2 Area 2','rmartel','Oct 31 2022 10:30PM'),
--(2,3,'Cargo 3 Area 2','rmartel','Oct 31 2022 10:30PM')

go

--insert into config.ParameterRange
--(id, name, Description, IsInternalConfiguration, CreateUser, CreateDate)
--values
--('EC4028F8-CF1B-4D84-B32C-A6BB89F09AA4', 'Parametro Internos', '', 1, 'rmartel', getdate()),
--('9FFA613E-378B-4683-9C92-5728864DC0A1', 'Rango de 0 hasta 74.99', '', 0, 'rmartel', getdate()),
--('C86C556E-9F26-48FA-A175-7E8D2C2F6C60', 'Rango de 75 hasta 80<', '', 0, 'rmartel', getdate()),
--('B5F9B1B2-5F9D-4909-A5C8-1AAD47CD8BAA', 'Rango de 80 hasta 90<', '', 0, 'rmartel', getdate())

--go

--insert into config.ParameterValue
--( ParameterRangeId,name, EntityName, Value, NameProperty,  CreateUser, CreateDate)
--values
--('EC4028F8-CF1B-4D84-B32C-A6BB89F09AA4', '@PropValorReal', 'ComponentCollaboratorDetail', 0, 'Result','rmartel', getdate()),
--('EC4028F8-CF1B-4D84-B32C-A6BB89F09AA4', '@PropMeta', 'ComponentCollaboratorDetail', 0, 'MaximunPercentage','rmartel', getdate()),
--('EC4028F8-CF1B-4D84-B32C-A6BB89F09AA4', '@PropMinimo', 'ComponentCollaboratorDetail', 0, 'MinimunPercentage','rmartel', getdate()),
--('9FFA613E-378B-4683-9C92-5728864DC0A1', '@Nota1', '', 0.00, '','rmartel', getdate()),
--('9FFA613E-378B-4683-9C92-5728864DC0A1', '@CisRealMinimo1', '', 0.00, '','rmartel', getdate()),
--('9FFA613E-378B-4683-9C92-5728864DC0A1', '@CisRealMaximo1', '', 0.7499, '','rmartel', getdate()),
--('C86C556E-9F26-48FA-A175-7E8D2C2F6C60', '@Nota2', '', 0.5000, '','rmartel', getdate()),
--('C86C556E-9F26-48FA-A175-7E8D2C2F6C60', '@CisRealMinimo2', '', 0.7500, '','rmartel', getdate()),
--('C86C556E-9F26-48FA-A175-7E8D2C2F6C60', '@CisRealMaximo2', '', 0.7999, '','rmartel', getdate()),
--('B5F9B1B2-5F9D-4909-A5C8-1AAD47CD8BAA', '@Nota3', '', 0.7500, '','rmartel', getdate()),
--('B5F9B1B2-5F9D-4909-A5C8-1AAD47CD8BAA', '@CisRealMinimo3', '', 0.8000, '','rmartel', getdate()),
--('B5F9B1B2-5F9D-4909-A5C8-1AAD47CD8BAA', '@CisRealMaximo3', '', 0.8999, '','rmartel', getdate())

--go

--insert into config.Formula
--(id, name, Description, FormulaReal, FormulaQuery, CreateUser, CreateDate, IsDeleted)
--values
--('BEA08DCC-AE3A-4C08-946E-B47F5F9CD6FD', 'Formula Objetivo', '', '', 'IIF(@PropValorReal<@PropMinimo,0,IIF((@PropValorReal/@PropMeta)*100 > 120, 120/100, @PropValorReal/@PropMeta))', 'rmartel', getdate(), 0),
--('E43C9497-BC6D-465E-8832-FBF961636A2A', 'Formula Objetivo Especial', '', '', 'IIF(@PropValorReal<=@CisRealMaximo1, 0, IIF((@PropValorReal>=@CisRealMinimo2 AND @PropValorReal<=@CisRealMaximo2), @Nota2, IIF((@PropValorReal>=@CisRealMinimo3 AND @PropValorReal<=@CisRealMaximo3), @Nota3, @PropValorReal)))', 'rmartel', getdate(), 0)


--insert into EvaResult.Period (name, StartDate, EndDate, CreateUser, CreateDate)
--values ('Period 1','2022-10-25 22:08:13.9550000','2022-10-25 22:08:13.9550000','system','Oct 31 2022 10:30PM')


--insert into Employee.Collaborator(id,ChargeId, DocumentNumber, MiddleName, LastName,Name,Email,Code,DateBirthday,DateAdmission,DateEgress,CreateUser,CreateDate, IsDeleted)
--values
--('1c1c8270-7152-40e3-b6a9-8f2244824434',1,'31313131','Fanny','Kius','Fanny','fan@acity.com.pe',3151,'1998-10-02 00:00:00.0000000','2022-10-10 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
--('2e1041e9-7bca-4f7d-a096-afde97b00e73',2,'44444444','Guillermo','Firme','Guillermo','guille@acity.com.pe',2311,'1989-10-02 00:00:00.0000000','2019-02-01 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
--('2ead2ce1-cc3f-4c52-bdee-2e8fdaf99bc6',3,'22222222','Carlos','Ruiz','arlos','carlos@acity.com.pe',5555,'2022-02-15 00:00:00.0000000','2021-05-01 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
--('aabcf5e6-7c42-4876-b3ff-be1029c80c44',4,'55445544','Kiara','Luiz','Kiara','kia@acity.com.pe',2425,'2000-12-05 00:00:00.0000000','2022-07-15 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
--('c379a686-897f-47f2-bebb-0cc3e5bb29d7',5,'33333333','Fernanda','Rofriguez','Fernanda','fer@acity.com.pe',4258,'1991-05-15 00:00:00.0000000','2020-05-01 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0),
--('f39b64f3-7359-4b7d-ae71-2f3aff538ffc',6,'15151515','Hector','Julio','Hector','hec@acity.com.pe',2131,'1995-10-02 00:00:00.0000000','2022-09-10 00:00:00.0000000','2022-10-31 00:00:00.0000000','rmartel','Oct 31 2022 10:31PM',0)

insert into Config.Component
(name, CreateUser, CreateDate, IsDeleted)
values
('Objetivos Corporativos', 'rmartel', getdate(), 0),
('Objetivos de Area', 'rmartel', getdate(), 0),
('Competencias', 'rmartel', getdate(), 0)

--insert into Config.HierarchyComponent (HierarchyId, ComponentId, Weight, CreateUser, CreateDate, IsDeleted)
--values
--(1, 1, 0.20, 'rmartel', getdate(), 0),
--(1, 2, 0.50, 'rmartel', getdate(), 0),
--(1, 3, 0.30, 'rmartel', getdate(), 0),
--(2, 1, 0.20, 'rmartel', getdate(), 0),
--(2, 2, 0.50, 'rmartel', getdate(), 0),
--(2, 3, 0.30, 'rmartel', getdate(), 0),
--(3, 1, 0.20, 'rmartel', getdate(), 0),
--(3, 2, 0.50, 'rmartel', getdate(), 0),
--(3, 3, 0.30, 'rmartel', getdate(), 0)


--insert into Config.Subcomponent
--(id, ComponentId, AreaId, FormulaId, Name, Description, CreateUser, CreateDate, IsDeleted)
--values
--('A22EA277-F2F5-49B5-89F2-1FDECDA8A003', 1, 1, 'BEA08DCC-AE3A-4C08-946E-B47F5F9CD6FD', 'Subcomponente 1 OBJCORP', '', 'rmartel', getdate(), 0),
--('12A5F857-F067-4EC5-968C-5284616A2929', 1, 1, 'E43C9497-BC6D-465E-8832-FBF961636A2A', 'Subcomponente 2 OBJCORP', '', 'rmartel', getdate(), 0),
--('6A74384F-2DA1-4B23-8569-C00206FDFA98', 1, 2, 'BEA08DCC-AE3A-4C08-946E-B47F5F9CD6FD', 'Subcomponente 3 OBJCORP', '', 'rmartel', getdate(), 0),
--('F22BDCB7-F528-44A2-9267-1B2CE55D5E34', 1, 2, 'E43C9497-BC6D-465E-8832-FBF961636A2A', 'Subcomponente 4 OBJCORP', '', 'rmartel', getdate(), 0),
--('DA886354-B2BB-483A-8430-F2F5DC31E9B9', 2, 1, null, 'Subcomponente 5 KPIAREA', '', 'rmartel', getdate(), 0),
--('BBFABC97-44DB-4925-91D6-C8B42827B1C1', 2, 1, null, 'Subcomponente 6 KPIAREA', '', 'rmartel', getdate(), 0),
--('0C24DF55-1C5A-45DC-B0BE-576F1B6D2192', 2, 2, null, 'Subcomponente 7 KPIAREA', '', 'rmartel', getdate(), 0),
--('E66C2F20-FC0E-4F89-9A9E-4D1367D91D9A', 2, 2, null, 'Subcomponente 8 KPIAREA', '', 'rmartel', getdate(), 0),
--('0FEF6000-AA34-40F1-AB47-1E42D750EF1E', 3, null, null, 'Subcomponente 9 COMPETE', '', 'rmartel', getdate(), 0),
--('99654822-D86A-4C0C-AC83-859C9BA2A0F5', 3, null, null, 'Subcomponente 10 COMPETE', '', 'rmartel', getdate(), 0),
--('D38F679E-A6A5-403C-99F0-032F3528B534', 3, null, null, 'Subcomponente 11 COMPETE', '', 'rmartel', getdate(), 0),
--('42B76A33-E812-44BB-98A1-605F880C2ED6', 3, null, null, 'Subcomponente 12 COMPETE', '', 'rmartel', getdate(), 0)


--insert into Config.SubcomponentValue
--(id, SubcomponentId, ChargeId, RelativeWeight, MinimunPercentage, MaximunPercentage, CreateUser, CreateDate, IsDeleted)
--values

----OBJCOPR
--(newid(),'A22EA277-F2F5-49B5-89F2-1FDECDA8A003', 1, 0.15, 0.75, 0.90, 'rmartel', getdate(), 0),
--(newid(),'A22EA277-F2F5-49B5-89F2-1FDECDA8A003', 2, 0.20, 0.65, 1, 'rmartel', getdate(), 0),
--(newid(),'A22EA277-F2F5-49B5-89F2-1FDECDA8A003', 3, 0.20, 0.80, 0.95, 'rmartel', getdate(), 0),
--(newid(),'12A5F857-F067-4EC5-968C-5284616A2929', 1, 0.15, 0.75, 0.99, 'rmartel', getdate(), 0),
--(newid(),'12A5F857-F067-4EC5-968C-5284616A2929', 2, 0.20, 0.78, 0.85, 'rmartel', getdate(), 0),
--(newid(),'12A5F857-F067-4EC5-968C-5284616A2929', 3, 0.25, 0.82, 1, 'rmartel', getdate(), 0),
														  		
--(newid(),'F22BDCB7-F528-44A2-9267-1B2CE55D5E34', 4, 0.15, 0.75, 0.90, 'rmartel', getdate(), 0),
--(newid(),'F22BDCB7-F528-44A2-9267-1B2CE55D5E34', 5, 0.20, 0.65, 1, 'rmartel', getdate(), 0),
--(newid(),'F22BDCB7-F528-44A2-9267-1B2CE55D5E34', 6, 0.20, 0.80, 0.95, 'rmartel', getdate(), 0),
--(newid(),'6A74384F-2DA1-4B23-8569-C00206FDFA98', 4, 0.15, 0.75, 0.99, 'rmartel', getdate(), 0),
--(newid(),'6A74384F-2DA1-4B23-8569-C00206FDFA98', 5, 0.20, 0.78, 0.85, 'rmartel', getdate(), 0),
--(newid(),'6A74384F-2DA1-4B23-8569-C00206FDFA98', 6, 0.25, 0.82, 1, 'rmartel', getdate(), 0),
														  		
----KPI AREA												  		
--(newid(),'BBFABC97-44DB-4925-91D6-C8B42827B1C1', 1, 0.15, 0.75, 0.90, 'rmartel', getdate(), 0),
--(newid(),'BBFABC97-44DB-4925-91D6-C8B42827B1C1', 2, 0.20, 0.65, 1, 'rmartel', getdate(), 0),
--(newid(),'BBFABC97-44DB-4925-91D6-C8B42827B1C1', 3, 0.20, 0.80, 0.95, 'rmartel', getdate(), 0),
--(newid(),'DA886354-B2BB-483A-8430-F2F5DC31E9B9', 1, 0.15, 0.75, 0.99, 'rmartel', getdate(), 0),
--(newid(),'DA886354-B2BB-483A-8430-F2F5DC31E9B9', 2, 0.20, 0.78, 0.85, 'rmartel', getdate(), 0),
--(newid(),'DA886354-B2BB-483A-8430-F2F5DC31E9B9', 3, 0.25, 0.82, 1, 'rmartel', getdate(), 0),
														  		
--(newid(),'E66C2F20-FC0E-4F89-9A9E-4D1367D91D9A', 4, 0.15, 0.75, 0.90, 'rmartel', getdate(), 0),
--(newid(),'E66C2F20-FC0E-4F89-9A9E-4D1367D91D9A', 5, 0.20, 0.65, 1, 'rmartel', getdate(), 0),
--(newid(),'E66C2F20-FC0E-4F89-9A9E-4D1367D91D9A', 6, 0.20, 0.80, 0.95, 'rmartel', getdate(), 0),
--(newid(),'0C24DF55-1C5A-45DC-B0BE-576F1B6D2192', 4, 0.15, 0.75, 0.99, 'rmartel', getdate(), 0),
--(newid(),'0C24DF55-1C5A-45DC-B0BE-576F1B6D2192', 5, 0.20, 0.78, 0.85, 'rmartel', getdate(), 0),
--(newid(),'0C24DF55-1C5A-45DC-B0BE-576F1B6D2192', 6, 0.25, 0.82, 1, 'rmartel', getdate(), 0)

--insert into Config.Conduct
--(id, LevelId, SubcomponentId, IsActive, Description, CreateUser, CreateDate, IsDeleted)
--values
--(newid(),1 ,'D38F679E-A6A5-403C-99F0-032F3528B534',1, 'Conducta 1', 'rmartel', getdate(), 0),
--(newid(),1 ,'D38F679E-A6A5-403C-99F0-032F3528B534',1, 'Conducta 1.1', 'rmartel', getdate(), 0),
--(newid(),2 ,'D38F679E-A6A5-403C-99F0-032F3528B534',1, 'Conducta 2', 'rmartel', getdate(), 0),
--(newid(),2 ,'D38F679E-A6A5-403C-99F0-032F3528B534',1, 'Conducta 2.2', 'rmartel', getdate(), 0),
--(newid(),3 ,'D38F679E-A6A5-403C-99F0-032F3528B534',1, 'Conducta 3', 'rmartel', getdate(), 0),
--(newid(),3 ,'D38F679E-A6A5-403C-99F0-032F3528B534',1, 'Conducta 3.1', 'rmartel', getdate(), 0),
--(newid(),1 ,'0FEF6000-AA34-40F1-AB47-1E42D750EF1E',1, 'Conducta 4', 'rmartel', getdate(), 0),
--(newid(),2 ,'0FEF6000-AA34-40F1-AB47-1E42D750EF1E',1, 'Conducta 5', 'rmartel', getdate(), 0),
--(newid(),3 ,'42B76A33-E812-44BB-98A1-605F880C2ED6',1, 'Conducta 6', 'rmartel', getdate(), 0),
--(newid(),2 ,'42B76A33-E812-44BB-98A1-605F880C2ED6',1, 'Conducta 7', 'rmartel', getdate(), 0),
--(newid(),2 ,'42B76A33-E812-44BB-98A1-605F880C2ED6',1, 'Conducta 7.1', 'rmartel', getdate(), 0),
--(newid(),1 ,'99654822-D86A-4C0C-AC83-859C9BA2A0F5',1, 'Conducta 8', 'rmartel', getdate(), 0),
--(newid(),2 ,'99654822-D86A-4C0C-AC83-859C9BA2A0F5',1, 'Conducta 9', 'rmartel', getdate(), 0),
--(newid(),2 ,'99654822-D86A-4C0C-AC83-859C9BA2A0F5',1, 'Conducta 9.1', 'rmartel', getdate(), 0),
--(newid(),2 ,'99654822-D86A-4C0C-AC83-859C9BA2A0F5',1, 'Conducta 9.2', 'rmartel', getdate(), 0),
--(newid(),3 ,'99654822-D86A-4C0C-AC83-859C9BA2A0F5',1, 'Conducta 10', 'rmartel', getdate(), 0)


insert into Config.Stage
(Name, CreateUser, CreateDate, IsDeleted)
values
('Evaluacion','rmartel', getdate(), 0),
('Calibracion','rmartel', getdate(), 0),
('Feedback','rmartel', getdate(), 0),
('Visto Bueno','rmartel', getdate(), 0)


go

insert into Config.Status (name, CreateUser, CreateDate)
values
('Prueba','rmartel',getdate()),
('Creado','rmartel',getdate()),
('Pendiente','rmartel',getdate()),
('En Progreso','rmartel',getdate()),
('Completado','rmartel',getdate()),
('Finalizado','rmartel',getdate())

go 


insert into Config.Label
(Name, Description, CreateUser, CreateDate)
values
('Cantidad de evaluaciones', '', 'rmartel', getdate()),
('Puntajes de competencias', '', 'rmartel', getdate()),
('Total de Competencias', '', 'rmartel', getdate())



insert into Config.LabelDetail
(LabelId, Name, Description, RealValue, MinimunValue, MaximunValue,Icon, CreateUser, CreateDate)
values
(1, 'cantidad por año', '', 2, 0, 0,'', 'rmartel', getdate()),
(2,'Punto 1', '', 1, 0,0,'', 'rmartel',getdate()),
(2,'Punto 2', '', 2, 0,0,'', 'rmartel',getdate()),
(2,'Punto 3', '', 3, 0,0,'', 'rmartel',getdate()),
(2,'Punto 4', '', 4, 0,0,'', 'rmartel',getdate()),
(2,'Punto 5', '', 5, 0,0,'', 'rmartel',getdate()),
(3, 'Total', '', 18,0,0,'' , 'rmartel',getdate())

go

create proc uspGetLastEvaluationCollaboratorDeleted
@collaboratorId varchar(50)
as
begin
	
	select 
		top 1 
		* 
	from EvaResult.EvaluationCollaborator
	where CollaboratorId = @collaboratorId
	order by CreateDate desc

end


go

create proc uspUpdateEvaluationCollaboratorCurrentIdInEvaluationLeader
@evaluationCollaboratorDeletedId varchar(50),
@evaluationCollaboratorCurrentId varchar(50)
as
begin

	update lc
	set
	IsDeleted = 0
	from EvaResult.LeaderCollaborator lc
	inner join EvaResult.LeaderStage ls
		on lc.LeaderStageId = ls.Id and ls.IsDeleted = 1
	inner join  EvaResult.EvaluationLeader el
		on ls.EvaluationLeaderId = el.Id and el.IsDeleted = 1
	where 
	el.EvaluationCollaboratorId = @evaluationCollaboratorDeletedId and
	lc.IsDeleted = 1


	update ls
	set
	IsDeleted = 0
	from EvaResult.LeaderStage ls
	inner join  EvaResult.EvaluationLeader el
		on ls.EvaluationLeaderId = el.Id and el.IsDeleted = 1
	where 
	el.EvaluationCollaboratorId = @evaluationCollaboratorDeletedId and
	ls.IsDeleted = 1


	update EvaResult.EvaluationLeader
	set
	EvaluationCollaboratorId = @evaluationCollaboratorCurrentId,
	IsDeleted = 0
	where 
	EvaluationCollaboratorId = @evaluationCollaboratorDeletedId
	and IsDeleted = 1

	update EvaResult.LeaderCollaborator
	set
	EvaluationCollaboratorId = @evaluationCollaboratorCurrentId,
	IsDeleted = 0
	where 
	EvaluationCollaboratorId = @evaluationCollaboratorDeletedId
	and IsDeleted = 1

end

go

create proc uspCalculateFormulaCompliance
@formulaQuerySql varchar(2000)
as
begin

	set @formulaQuerySql = concat('select ', @formulaQuerySql);

	exec (@formulaQuerySql)
end


--delete from EvaResult.Evaluation
--delete from EvaResult.EvaluationComponent
--delete from EvaResult.EvaluationCollaborator
--delete from EvaResult.EvaluationComponentStage
--delete from EvaResult.ComponentCollaboratorDetail
--delete from EvaResult.ComponentCollaboratorConduct
--delete from EvaResult.ComponentCollaborator
--delete from EvaResult.ComponentCollaboratorComment
--delete from EvaResult.EvaluationLeader
--delete from EvaResult.LeaderStage
--delete from EvaResult.LeaderCollaborator

/*


{
  "periodId": 2,
  "name": "evaluacion de prueba 1",
  "startDate": "2023-01-01T01:23:32.373Z",
  "endDate": "2023-07-01T01:23:32.373Z",
  "weight": 0.60,
  "isEvaluationTest": false,
  "EvaluationComponents": [
    {
      "evaluationId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "componentId": 1,
      "startDate": "2023-01-02T16:55:38.682Z",
      "endDate": "2023-02-01T16:55:38.682Z"
    },
 {
      "evaluationId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "componentId": 2,
      "startDate": "2023-02-02T16:55:38.682Z",
      "endDate": "2023-03-01T16:55:38.682Z"
    },
 {
      "evaluationId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "componentId": 3,
      "startDate": "2023-03-02T16:55:38.682Z",
      "endDate": "2023-04-01T16:55:38.682Z"
    }
  ],
  "EvaluationComponentStages": [
    {
      "evaluationComponentId": null,
      "stageId": 1,
      "startDate": "2023-03-03T16:55:38.682Z",
      "endDate": "2023-03-10T16:55:38.682Z",
      "componentId": 3
    },
    {
      "evaluationComponentId": null,
      "stageId": 2,
     "startDate": "2023-03-11T16:55:38.682Z",
      "endDate": "2023-03-28T16:55:38.682Z",
      "componentId": 3
    },
{
      "evaluationComponentId": null,
      "stageId": 3,
     "startDate": "2023-04-03T16:55:38.682Z",
      "endDate": "2023-04-15T16:55:38.682Z",
      "componentId": null
    },
{
      "evaluationComponentId": null,
      "stageId": 4,
     "startDate": "2023-04-16T16:55:38.682Z",
      "endDate": "2023-04-30T16:55:38.682Z",
      "componentId": null
    }
  ]
}

*/