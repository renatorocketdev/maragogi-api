UPDATE Empresa SET
	nomeEmpresa=@nomeEmpresa, Endereco=@Endereco, 
	Telefone1Empresa=@Telefone1Empresa, Telefone2Empresa=@Telefone2Empresa,
	Facebook=@Facebook, Instagram=@Instagram, Site=@Site, SobreEmpresa=@SobreEmpresa,
	Carac1=@Carac1, Carac2=@Carac2, Carac3=@Carac3, Carac4=@Carac4,
	Serv1=@Serv1, Serv2=@Serv2, Serv3=@Serv3, Serv4=@Serv4,
	Nota=@nota, MainCategoria=@MainCategoria, SubCategoria=@SubCategoria, Video=@Video
WHERE 
	IdEmpresa = @IdEmpresa