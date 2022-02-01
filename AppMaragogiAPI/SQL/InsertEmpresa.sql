INSERT INTO Empresa (
    NomeEmpresa, Endereco, 
    Telefone1Empresa, Telefone2Empresa,
    Facebook, Instagram, Site, SobreEmpresa,
    Carac1, Carac2, Carac3, Carac4,
    Serv1, Serv2, Serv3, Serv4,
    Nota, MainCategoria, SubCategoria, Video)
VALUES (
    @NomeEmpresa, @Endereco, @Telefone1Empresa, @Telefone2Empresa,
    @Facebook, @Instagram, @Site, @SobreEmpresa,
    @Carac1, @Carac2, @Carac3, @Carac4,
    @Serv1, @Serv2, @Serv3, @Serv4,
    @Nota, @MainCategoria, @SubCategoria, @Video)