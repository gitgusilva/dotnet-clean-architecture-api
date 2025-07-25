# Projeto de API RESTful em .NET

## Visão Geral

Esta API segue o padrão Clean Architecture/DDD, inspirado em projetos oficiais da Microsoft e grandes empresas. O objetivo é garantir alta manutenibilidade, testabilidade e escalabilidade.

## Estrutura de Pastas

```
src/
  Domain/
    Entities/
      Product.cs
    Interfaces/
      IProductRepository.cs
  Application/
    DTOs/
      ProductDto.cs, ...
    Services/
      ProductService.cs
    Validators/
      CreateProductDtoValidator.cs, ...
  Infrastructure/
    Data/
      AppDbContext.cs
      Migrations/
    Repositories/
      ProductRepository.cs
    Helpers/
      PaginationExtensions.cs
  Presentation/
    Controllers/
      ProductsController.cs
    Middleware/
      ExceptionHandlingMiddleware.cs
  Program.cs
  appsettings.json
  appsettings.Development.json
  app.http
```

## Padrões da API REST
- **CRUD completo** para Products
- **Paginação, filtro e ordenação** nos endpoints de listagem
- **Validação automática** com FluentValidation
- **Tratamento global de exceções** (middleware)
- **DTOs** para entrada e saída (nunca expõe entidades diretamente)
- **Resposta paginada** no padrão `{ data, total, page, pageSize }`

## Docker
O projeto já está pronto para rodar com Docker e Docker Compose, incluindo banco MySQL:

### Subir a stack
```sh
docker-compose up -d
```

- A API estará disponível em `http://localhost:5000`
- O MySQL estará disponível na porta `3306` (acesso interno via `container`) e `3399` para acesso externo

### Rodar migrations (dentro do container da API)
```sh
docker exec -it myapi bash
# Dentro do container:
dotnet tool install --global dotnet-ef
export PATH="$PATH:/home/dotnetuser/.dotnet/tools"
dotnet ef database update --project /app/app.csproj
```

## Como iniciar localmente (sem Docker)
1. Instale o .NET 9 SDK e o MySQL localmente
2. Ajuste a string de conexão em `appsettings.json` para `localhost`
3. Rode:
```sh
dotnet restore
cd src
 dotnet ef database update
 dotnet run
```

## Testando a API
Use o arquivo `app.http` ou ferramentas como Postman/Insomnia para testar os endpoints.

## Referências
- [Clean Architecture (Microsoft)](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)
- [eShopOnWeb (Microsoft)](https://github.com/dotnet-architecture/eShopOnWeb)
- [Clean Architecture Template (Jason Taylor)](https://github.com/jasontaylordev/CleanArchitecture)

