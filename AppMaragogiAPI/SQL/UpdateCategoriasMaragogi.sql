UPDATE CategoriasMaragogi SET
	Nome=@Nome, UrlVideo=@UrlVideo, Descricao=@Descricao, Localizacao=@Localizacao, Categoria = @Categoria, Icone = @Icone
WHERE 
	CategoriaMaragogiId = @CategoriaMaragogiId