/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2000                    */
/* Created on:     2012/8/8 18:52:34                            */
/*==============================================================*/
use Rance
go

if exists (select 1
   from dbo.sysreferences r join dbo.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TeamRole') and o.name = 'FK_TEAMROLE_REFERENCE_TEAM')
alter table TeamRole
   drop constraint FK_TEAMROLE_REFERENCE_TEAM
go

if exists (select 1
   from dbo.sysreferences r join dbo.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TeamRole') and o.name = 'FK_TEAMROLE_REFERENCE_ROLE')
alter table TeamRole
   drop constraint FK_TEAMROLE_REFERENCE_ROLE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Role')
            and   type = 'U')
   drop table Role
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Team')
            and   type = 'U')
   drop table Team
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TeamRole')
            and   type = 'U')
   drop table TeamRole
go

/*==============================================================*/
/* Table: Role                                                  */
/*==============================================================*/
create table Role (
   ID                   uniqueidentifier     not null,
   Name                 varchar(30)          not null,
   兵种                   varchar(20)          not null,
   攻                    int                  not null,
   防                    int                  not null,
   速                    int                  not null,
   智                    int                  not null,
   行动点                  int                  not null,
   兵力                   int                  not null,
   基础攻击技能               varchar(20)          not null,
   技能1                  varchar(20)          not null,
   技能2                  varchar(20)          not null,
   被动技能                 varchar(20)          not null,
   特殊技能                 varchar(20)          not null,
   constraint PK_ROLE primary key (ID)
)
go

/*==============================================================*/
/* Table: Team                                                  */
/*==============================================================*/
create table Team (
   ID                   uniqueidentifier     not null,
   Name                 varchar(30)          not null,
   constraint PK_TEAM primary key (ID)
)
go

/*==============================================================*/
/* Table: TeamRole                                              */
/*==============================================================*/
create table TeamRole (
   ID                   uniqueidentifier     not null,
   TeamID               uniqueidentifier     not null,
   RoleID               uniqueidentifier     not null,
   排                    int                  not null,
   列                    int                  not null,
   constraint PK_TEAMROLE primary key (ID)
)
go

alter table TeamRole
   add constraint FK_TEAMROLE_REFERENCE_TEAM foreign key (TeamID)
      references Team (ID)
go

alter table TeamRole
   add constraint FK_TEAMROLE_REFERENCE_ROLE foreign key (RoleID)
      references Role (ID)
go

