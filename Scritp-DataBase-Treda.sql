USE [Treda]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 16/07/2020 1:21:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[SKU] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Value] [decimal](18, 0) NOT NULL,
	[Store] [int] NOT NULL,
	[Base64Imagen] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[SKU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stores]    Script Date: 16/07/2020 1:21:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stores](
	[StoreId] [int] IDENTITY(1,1) NOT NULL,
	[StoreName] [nvarchar](max) NOT NULL,
	[OpeningDate] [date] NOT NULL,
 CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([SKU], [ProductName], [Value], [Store], [Base64Imagen]) VALUES (1, N'Tenis', CAST(500 AS Decimal(18, 0)), 2, N'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGAAAABgCAYAAADimHc4AAAACXBIWXMAAAsSAAALEgHS3X78AAABSUlEQVR42u3aQYrCQBAFUPcexVMEQs4xN4uH8iizd9IQxU1AMKnfOO9BgRDcdMP/UMnpBAAAAAAAAHRqHMefNk4ic/iXZX7XuTiR2sM/L3Nb5r5O+312MgWmaWoXcH05/Mdc2zNqcv++MfqgKPe3LkAfFOb+1uiDvQ3D0C5gfuPwHzO3/1CT+/ognPv6oIPc1wcHXcD8weE/+8BJ1uW+Pgjnvj7oIPf1wQF7nr3Gvqgw9/VBOPf1QQe5rw8O2PPsNfZFhbmvD8K5rw86yH19cMCeZ7c+UAYAAAAAfC3LuPwFWEd3cAleyHRwCV5JJnkp/z/7wGcpwT6Q++E+kPtbfJz73X0g94N9IPfDfSD3g/siH10F+0DuB/tA7of7QO4H90X2PME+kPvBPpD74T6Q+8F9kT1PsA/kfrAP5H64D+Q+AAAAAAAAdOsP27xTi2D5TUEAAAAASUVORK5CYII=')
INSERT [dbo].[Products] ([SKU], [ProductName], [Value], [Store], [Base64Imagen]) VALUES (2, N'Zapatillas', CAST(350 AS Decimal(18, 0)), 2, N'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGAAAABgCAYAAADimHc4AAAACXBIWXMAAAsSAAALEgHS3X78AAABSUlEQVR42u3aQYrCQBAFUPcexVMEQs4xN4uH8iizd9IQxU1AMKnfOO9BgRDcdMP/UMnpBAAAAAAAAHRqHMefNk4ic/iXZX7XuTiR2sM/L3Nb5r5O+312MgWmaWoXcH05/Mdc2zNqcv++MfqgKPe3LkAfFOb+1uiDvQ3D0C5gfuPwHzO3/1CT+/ognPv6oIPc1wcHXcD8weE/+8BJ1uW+Pgjnvj7oIPf1wQF7nr3Gvqgw9/VBOPf1QQe5rw8O2PPsNfZFhbmvD8K5rw86yH19cMCeZ7c+UAYAAAAAfC3LuPwFWEd3cAleyHRwCV5JJnkp/z/7wGcpwT6Q++E+kPtbfJz73X0g94N9IPfDfSD3g/siH10F+0DuB/tA7of7QO4H90X2PME+kPvBPpD74T6Q+8F9kT1PsA/kfrAP5H64D+Q+AAAAAAAAdOsP27xTi2D5TUEAAAAASUVORK5CYII=')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Stores] ON 

INSERT [dbo].[Stores] ([StoreId], [StoreName], [OpeningDate]) VALUES (1, N'Sony', CAST(N'1960-10-19' AS Date))
INSERT [dbo].[Stores] ([StoreId], [StoreName], [OpeningDate]) VALUES (2, N'Jordan', CAST(N'1987-10-28' AS Date))
SET IDENTITY_INSERT [dbo].[Stores] OFF
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Products] FOREIGN KEY([Store])
REFERENCES [dbo].[Stores] ([StoreId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Products]
GO
/****** Object:  StoredProcedure [dbo].[SPProductosPorTienda]    Script Date: 16/07/2020 1:21:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPProductosPorTienda]
@Store INT
AS
BEGIN
 SELECT [SKU], [ProductName], [Value], [Base64Imagen] FROM [dbo].[Products] C 
 INNER JOIN [dbo].[Stores] D ON D.[StoreId]=@Store and C.[Store] = D.[StoreId]                         
END
GO
