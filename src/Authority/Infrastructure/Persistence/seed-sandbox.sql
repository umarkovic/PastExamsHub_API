TRUNCATE TABLE [IdentityServer4].[ClientCorsOrigins];
SET IDENTITY_INSERT [IdentityServer4].[ClientCorsOrigins] ON 
GO
INSERT INTO [IdentityServer4].[ClientCorsOrigins]
	(Id, Origin, ClientId)
	VALUES 
	(1, 'https://naissustech-authority.azurewebsites.net', 1);
GO
INSERT INTO [IdentityServer4].[ClientCorsOrigins]
	(Id, Origin, ClientId)
	VALUES 
	(2, 'https://naissustech-core.azurewebsites.net', 1);
GO
INSERT INTO [IdentityServer4].[ClientCorsOrigins]
	(Id, Origin, ClientId)
	VALUES 
	(3, 'http://localhost:4002', 1);
GO
INSERT INTO [IdentityServer4].[ClientCorsOrigins]
	(Id, Origin, ClientId)
	VALUES 
	(4, 'http://localhost:4001', 1);
GO
INSERT INTO [IdentityServer4].[ClientCorsOrigins]
	(Id, Origin, ClientId)
	VALUES 
	(5, 'http://localhost', 1);
GO

SET IDENTITY_INSERT [IdentityServer4].[ClientCorsOrigins] OFF
GO
	
		
TRUNCATE TABLE [IdentityServer4].[ClientRedirectUris];
SET IDENTITY_INSERT [IdentityServer4].[ClientRedirectUris] ON 
GO
INSERT INTO [IdentityServer4].[ClientRedirectUris]
	([Id], [RedirectUri], [ClientId])
	VALUES 
	(1, 'https://naissustech-authority.azurewebsites.net', 1);
GO
INSERT INTO [IdentityServer4].[ClientRedirectUris]
	([Id], [RedirectUri], [ClientId])
	VALUES 
	(2, 'https://naissustech-authority.azurewebsites.net/silent-renew.html', 1);
GO	
INSERT INTO [IdentityServer4].[ClientRedirectUris]
	([Id], [RedirectUri], [ClientId])
	VALUES 
	(3, 'https://naissustech-core.azurewebsites.net', 1);
GO
INSERT INTO [IdentityServer4].[ClientRedirectUris]
	([Id], [RedirectUri], [ClientId])
	VALUES 
	(4, 'https://naissustech-core.azurewebsites.net/silent-renew.html', 1);
GO	
INSERT INTO [IdentityServer4].[ClientRedirectUris]
	([Id], [RedirectUri], [ClientId])
	VALUES 
	(5, 'http://localhost:4002/callback', 1);
GO
INSERT INTO [IdentityServer4].[ClientRedirectUris]
	([Id], [RedirectUri], [ClientId])
	VALUES 
	(6, 'http://localhost:4002/silent-renew.html', 1);
GO
INSERT INTO [IdentityServer4].[ClientRedirectUris]
	([Id], [RedirectUri], [ClientId])
	VALUES 
	(7, 'http://localhost:4001', 1);
GO
INSERT INTO [IdentityServer4].[ClientRedirectUris]
	([Id], [RedirectUri], [ClientId])
	VALUES 
	(8, 'http://localhost:4001/silent-renew.html', 1);
GO
INSERT INTO [IdentityServer4].[ClientRedirectUris]
	([Id], [RedirectUri], [ClientId])
	VALUES 
	(9, 'http://localhost', 1);
GO
INSERT INTO [IdentityServer4].[ClientRedirectUris]
	([Id], [RedirectUri], [ClientId])
	VALUES 
	(10, 'http://localhost/silent-renew.html', 1);
GO
SET IDENTITY_INSERT [IdentityServer4].[ClientRedirectUris] OFF
GO


TRUNCATE TABLE [IdentityServer4].[ClientPostLogoutRedirectUris];
SET IDENTITY_INSERT [IdentityServer4].[ClientPostLogoutRedirectUris] ON 
GO
INSERT INTO [IdentityServer4].[ClientPostLogoutRedirectUris]
	([Id], [PostLogoutRedirectUri], [ClientId])
	VALUES 
	(1, 'https://naissustech-authority.azurewebsites.net', 1);
GO
INSERT INTO [IdentityServer4].[ClientPostLogoutRedirectUris]
	([Id], [PostLogoutRedirectUri], [ClientId])
	VALUES 
	(2, 'https://naissustech-authority.azurewebsites.net/silent-renew.html', 1);
GO
INSERT INTO [IdentityServer4].[ClientPostLogoutRedirectUris]
	([Id], [PostLogoutRedirectUri], [ClientId])
	VALUES 
	(3, 'https://naissustech-core.azurewebsites.net', 1);
GO
INSERT INTO [IdentityServer4].[ClientPostLogoutRedirectUris]
	([Id], [PostLogoutRedirectUri], [ClientId])
	VALUES 
	(4, 'https://naissustech-core.azurewebsites.net/silent-renew.html', 1);
GO
INSERT INTO [IdentityServer4].[ClientPostLogoutRedirectUris]
	([Id], [PostLogoutRedirectUri], [ClientId])
	VALUES 
	(5, 'http://localhost:4000', 1);
GO
INSERT INTO [IdentityServer4].[ClientPostLogoutRedirectUris]
	([Id], [PostLogoutRedirectUri], [ClientId])
	VALUES 
	(6, 'http://localhost:4000/silent-renew.html', 1);
GO
INSERT INTO [IdentityServer4].[ClientPostLogoutRedirectUris]
	([Id], [PostLogoutRedirectUri], [ClientId])
	VALUES 
	(7, 'http://localhost:4001', 1);
GO
INSERT INTO [IdentityServer4].[ClientPostLogoutRedirectUris]
	([Id], [PostLogoutRedirectUri], [ClientId])
	VALUES 
	(8, 'http://localhost:4001/silent-renew.html', 1);
GO
INSERT INTO [IdentityServer4].[ClientPostLogoutRedirectUris]
	([Id], [PostLogoutRedirectUri], [ClientId])
	VALUES 
	(9, 'http://localhost:4002/', 1);
GO
INSERT INTO [IdentityServer4].[ClientPostLogoutRedirectUris]
	([Id], [PostLogoutRedirectUri], [ClientId])
	VALUES 
	(10, 'http://localhost:4002/silent-renew.html', 1);
GO
INSERT INTO [IdentityServer4].[ClientPostLogoutRedirectUris]
	([Id], [PostLogoutRedirectUri], [ClientId])
	VALUES 
	(11, 'http://localhost/', 1);
GO
INSERT INTO [IdentityServer4].[ClientPostLogoutRedirectUris]
	([Id], [PostLogoutRedirectUri], [ClientId])
	VALUES 
	(12, 'http://localhost/silent-renew.html', 1);
GO
SET IDENTITY_INSERT [IdentityServer4].[ClientPostLogoutRedirectUris] OFF
GO
