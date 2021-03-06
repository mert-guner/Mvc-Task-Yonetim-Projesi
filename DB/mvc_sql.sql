USE [ProjeIT_Db]
GO
/****** Object:  Table [dbo].[aciliyetDurum]    Script Date: 6.06.2022 21:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aciliyetDurum](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aciliyet_durum] [nvarchar](50) NULL,
 CONSTRAINT [PK_aciliyetDurum] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Calisan]    Script Date: 6.06.2022 21:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calisan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kullanici_adi] [nvarchar](50) NULL,
	[sifre] [nvarchar](50) NULL,
	[Adi] [nvarchar](50) NULL,
	[Soyadi] [nvarchar](50) NULL,
 CONSTRAINT [PK_Calisan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[durum]    Script Date: 6.06.2022 21:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[durum](
	[id] [int] NOT NULL,
	[durum] [nvarchar](50) NULL,
 CONSTRAINT [PK_durum] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[task]    Script Date: 6.06.2022 21:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[task](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[baslik] [nvarchar](max) NULL,
	[icerik] [nvarchar](max) NULL,
	[aciliyet_durumu] [int] NULL,
	[bitirilme_sure] [date] NULL,
	[dokuman] [varbinary](max) NULL,
	[calisan] [int] NULL,
	[durum] [nvarchar](50) NULL,
	[yonetici] [int] NULL,
 CONSTRAINT [PK_task] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Yonetici]    Script Date: 6.06.2022 21:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yonetici](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kullanici_adi] [nvarchar](50) NULL,
	[sifre] [nvarchar](50) NULL,
	[Adi] [nvarchar](50) NULL,
	[Soyadi] [nvarchar](50) NULL,
 CONSTRAINT [PK_Yonetici] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[aciliyetDurum] ON 

INSERT [dbo].[aciliyetDurum] ([id], [aciliyet_durum]) VALUES (1, N'Hemen Yap')
INSERT [dbo].[aciliyetDurum] ([id], [aciliyet_durum]) VALUES (2, N'Ne Zaman Yapılacağını Planla')
INSERT [dbo].[aciliyetDurum] ([id], [aciliyet_durum]) VALUES (3, N'Daha Sonra Yap')
INSERT [dbo].[aciliyetDurum] ([id], [aciliyet_durum]) VALUES (4, N'İşi Devret')
SET IDENTITY_INSERT [dbo].[aciliyetDurum] OFF
SET IDENTITY_INSERT [dbo].[Calisan] ON 

INSERT [dbo].[Calisan] ([id], [kullanici_adi], [sifre], [Adi], [Soyadi]) VALUES (1, N'kullanici@mail.com', N'123', N'Can', N'Güner')
INSERT [dbo].[Calisan] ([id], [kullanici_adi], [sifre], [Adi], [Soyadi]) VALUES (2, N'mertcannguner@gmail.com', N'123', N'ali', N'veli')
SET IDENTITY_INSERT [dbo].[Calisan] OFF
INSERT [dbo].[durum] ([id], [durum]) VALUES (1, N'Beklemede')
INSERT [dbo].[durum] ([id], [durum]) VALUES (2, N'Devam Ediyor')
INSERT [dbo].[durum] ([id], [durum]) VALUES (3, N'Tamamlandı')
SET IDENTITY_INSERT [dbo].[task] ON 

INSERT [dbo].[task] ([id], [baslik], [icerik], [aciliyet_durumu], [bitirilme_sure], [dokuman], [calisan], [durum], [yonetici]) VALUES (4, N'aasdasdasdasdasd', N'asdasdasdasssssssssssssssssssssssss', 1, CAST(N'2022-07-02' AS Date), NULL, 2, N'Hazırlanıyor', NULL)
INSERT [dbo].[task] ([id], [baslik], [icerik], [aciliyet_durumu], [bitirilme_sure], [dokuman], [calisan], [durum], [yonetici]) VALUES (5, N'Deneme', N'Deneme Açıklama', 2, NULL, NULL, 1, N'Tamamlandı', NULL)
SET IDENTITY_INSERT [dbo].[task] OFF
SET IDENTITY_INSERT [dbo].[Yonetici] ON 

INSERT [dbo].[Yonetici] ([id], [kullanici_adi], [sifre], [Adi], [Soyadi]) VALUES (1, N'admin@mail.com', N'123', N'Mert', N'Güner')
SET IDENTITY_INSERT [dbo].[Yonetici] OFF
ALTER TABLE [dbo].[task]  WITH CHECK ADD  CONSTRAINT [FK_task_aciliyetDurum] FOREIGN KEY([aciliyet_durumu])
REFERENCES [dbo].[aciliyetDurum] ([id])
GO
ALTER TABLE [dbo].[task] CHECK CONSTRAINT [FK_task_aciliyetDurum]
GO
ALTER TABLE [dbo].[task]  WITH CHECK ADD  CONSTRAINT [FK_task_Calisan] FOREIGN KEY([calisan])
REFERENCES [dbo].[Calisan] ([id])
GO
ALTER TABLE [dbo].[task] CHECK CONSTRAINT [FK_task_Calisan]
GO
ALTER TABLE [dbo].[task]  WITH CHECK ADD  CONSTRAINT [FK_task_Yonetici] FOREIGN KEY([yonetici])
REFERENCES [dbo].[Yonetici] ([id])
GO
ALTER TABLE [dbo].[task] CHECK CONSTRAINT [FK_task_Yonetici]
GO
