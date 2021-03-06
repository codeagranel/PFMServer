/****** Object:  Database [aspnet-PFMServer-20130414121625]    Script Date: 14/04/2013 16:17:51 ******/
CREATE DATABASE [aspnet-PFMServer-20130414121625]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'aspnet-PFMServer-20130414121625.mdf', FILENAME = N'c:\users\juliano\documents\visual studio 2012\Projects\PFMServer\PFMServer\App_Data\aspnet-PFMServer-20130414121625.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'aspnet-PFMServer-20130414121625_log.ldf', FILENAME = N'c:\users\juliano\documents\visual studio 2012\Projects\PFMServer\PFMServer\App_Data\aspnet-PFMServer-20130414121625_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [aspnet-PFMServer-20130414121625].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET ARITHABORT OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET  ENABLE_BROKER 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET  MULTI_USER 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET DB_CHAINING OFF 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 14/04/2013 16:17:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Income_IncomeId] [int] NULL,
	[Expense_ExpenseId] [int] NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 14/04/2013 16:17:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[ExpenseId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Recurrent] [bit] NOT NULL,
	[Parcels] [int] NOT NULL,
	[Paid] [bit] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Date] [datetime] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[MethodOfPayment_MethodOfPaymentId] [int] NULL,
 CONSTRAINT [PK_dbo.Expenses] PRIMARY KEY CLUSTERED 
(
	[ExpenseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Incomes]    Script Date: 14/04/2013 16:17:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incomes](
	[IncomeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Paid] [bit] NOT NULL,
	[Recurrent] [bit] NOT NULL,
	[Parcels] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Date] [datetime] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[MethodOfPayment_MethodOfPaymentId] [int] NULL,
 CONSTRAINT [PK_dbo.Incomes] PRIMARY KEY CLUSTERED 
(
	[IncomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MethodOfPayments]    Script Date: 14/04/2013 16:17:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MethodOfPayments](
	[MethodOfPaymentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.MethodOfPayments] PRIMARY KEY CLUSTERED 
(
	[MethodOfPaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 14/04/2013 16:17:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](56) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 14/04/2013 16:17:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 14/04/2013 16:17:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 14/04/2013 16:17:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 14/04/2013 16:17:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Expense_ExpenseId]    Script Date: 14/04/2013 16:17:51 ******/
CREATE NONCLUSTERED INDEX [IX_Expense_ExpenseId] ON [dbo].[Categories]
(
	[Expense_ExpenseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Income_IncomeId]    Script Date: 14/04/2013 16:17:51 ******/
CREATE NONCLUSTERED INDEX [IX_Income_IncomeId] ON [dbo].[Categories]
(
	[Income_IncomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MethodOfPayment_MethodOfPaymentId]    Script Date: 14/04/2013 16:17:51 ******/
CREATE NONCLUSTERED INDEX [IX_MethodOfPayment_MethodOfPaymentId] ON [dbo].[Expenses]
(
	[MethodOfPayment_MethodOfPaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MethodOfPayment_MethodOfPaymentId]    Script Date: 14/04/2013 16:17:51 ******/
CREATE NONCLUSTERED INDEX [IX_MethodOfPayment_MethodOfPaymentId] ON [dbo].[Incomes]
(
	[MethodOfPayment_MethodOfPaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__UserProf__C9F28456F9EA656E]    Script Date: 14/04/2013 16:17:51 ******/
ALTER TABLE [dbo].[UserProfile] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__webpages__8A2B6160E5678FC1]    Script Date: 14/04/2013 16:17:51 ******/
ALTER TABLE [dbo].[webpages_Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Categories_dbo.Expenses_Expense_ExpenseId] FOREIGN KEY([Expense_ExpenseId])
REFERENCES [dbo].[Expenses] ([ExpenseId])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_dbo.Categories_dbo.Expenses_Expense_ExpenseId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Categories_dbo.Incomes_Income_IncomeId] FOREIGN KEY([Income_IncomeId])
REFERENCES [dbo].[Incomes] ([IncomeId])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_dbo.Categories_dbo.Incomes_Income_IncomeId]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Expenses_dbo.MethodOfPayments_MethodOfPayment_MethodOfPaymentId] FOREIGN KEY([MethodOfPayment_MethodOfPaymentId])
REFERENCES [dbo].[MethodOfPayments] ([MethodOfPaymentId])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_dbo.Expenses_dbo.MethodOfPayments_MethodOfPayment_MethodOfPaymentId]
GO
ALTER TABLE [dbo].[Incomes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Incomes_dbo.MethodOfPayments_MethodOfPayment_MethodOfPaymentId] FOREIGN KEY([MethodOfPayment_MethodOfPaymentId])
REFERENCES [dbo].[MethodOfPayments] ([MethodOfPaymentId])
GO
ALTER TABLE [dbo].[Incomes] CHECK CONSTRAINT [FK_dbo.Incomes_dbo.MethodOfPayments_MethodOfPayment_MethodOfPaymentId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
ALTER DATABASE [aspnet-PFMServer-20130414121625] SET  READ_WRITE 
GO
