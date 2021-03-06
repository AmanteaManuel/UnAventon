USE [UnAventon]
GO
/****** Object:  Table [dbo].[EstadoViaje]    Script Date: 19/6/2018 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoViaje](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [int] NOT NULL,
	[Descripcion] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_EstadoViaje] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EstadoViaje] ON 

INSERT [dbo].[EstadoViaje] ([Id], [Codigo], [Descripcion]) VALUES (1, 1, N'Pendiente')
INSERT [dbo].[EstadoViaje] ([Id], [Codigo], [Descripcion]) VALUES (2, 2, N'Aceptado')
INSERT [dbo].[EstadoViaje] ([Id], [Codigo], [Descripcion]) VALUES (3, 3, N'Rechazado')
SET IDENTITY_INSERT [dbo].[EstadoViaje] OFF
